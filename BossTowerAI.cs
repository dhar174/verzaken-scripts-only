using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class BossTowerAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private ThirdPersonCharacter character;
    public AudioRolloffMode rolloffmode1;
    //public List<GameObject> waypointz;
    public bool pathpending;
    public bool haspath;
    public bool randomize;
    public Animator anim;
    private Animator playeranim;
    private Vector3 endposition;
    public PlayerDied m_playerdied;
    private int soundhashInd;

    private openTreasureDoor openTreasureVault;
    private openTreasureDoor openEndDoor;

    private GameObject player;

    //public GameObject[] handColliders;

    public int enemyStrength;
    public int levelMultiplier;

    public bool hitplayer;

    public int multiplier;

    public static AudioSource Music;

    public bool movingsideways = false;

    public static int BossStage;

    public AudioClip chaseclip;
    public AudioClip[] growls;
    public int destination;
    public bool isalive;
    public enum State
    {
        TOWARDPLAYER,
        RUNAWAY,
        TOCENTER,
        RUNWILD,


    }

    NavMeshPath path;

    public GameObject particleHolder;

    public CharacterController playercontroller;
    public Rigidbody playerRB;
    private Rigidbody polypRB;
    public State state;
    private bool alive;
    //Patrolling Variables
    public GameObject[] waypoints;
    private int waypointInd;
    public float patrolSpeed;

    //private Transform bossPos;
    //private Transform navPos;


    //Chasing Variables
    public float chaseSpeed;
    public GameObject target;
    public AudioSource sound;
    public bool clipPlaying;
    private Vector3 pos;
    private AudioClip currentgrowl;

    public float attackDistance;
    public Vector3 targetPosition;

    public bool movingback = false;
    public bool arrivedBack = false;
    public bool attacking = false;

    public GameObject grabtarget;

    public static bool armDestroyed;
    public static bool ballChainDestroyed;
    public static bool wheelsDestroyed;
    public static bool BossisDead;

    [SerializeField] private Rigidbody[] ballchainRBs;


    public Transform grabber;
    private int ballDirection;

    public int stageID;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontrollerScript;

    // Use this for initialization
    void Start() {

        ballchainRBs = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rb in ballchainRBs)
        {
            rb.solverIterations = 90;
            rb.solverVelocityIterations = 90;
            //print(rb.solverVelocityIterations);

        }
        Physics.defaultSolverIterations = 20;
        Physics.defaultSolverVelocityIterations = 20;
        //print(Physics.defaultSolverVelocityIterations);

        levelMultiplier = LevelProgression.MasterLevelMultiplier;
        enemyStrength = Random.Range(1, 3) * levelMultiplier;
        BossisDead = false;
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        fpscontrollerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        armDestroyed = false;
        ballChainDestroyed = false;
        stageID = 0;
        BossStage = 0;
        //bossPos = gameObject.transform;
        //navPos = GameObject.FindGameObjectWithTag("BossNavManager").transform;
        ballDirection = 0;
        anim = gameObject.GetComponent<Animator>();

        openTreasureVault = GameObject.FindGameObjectWithTag("TreasureDoor").GetComponent<openTreasureDoor>();
        openEndDoor = GameObject.Find("reddoor (7)").GetComponent<openTreasureDoor>();

        anim.SetBool("BallchainActive", false);
        //anim.SetInteger("BallchainDirection", ballDirection);

        player = GameObject.FindGameObjectWithTag("Player");
        grabtarget = player;

        if (attackDistance == 0)
        {
            attackDistance = 4;
        }
        soundhashInd = Random.Range(0, growls.Length);
        polypRB = gameObject.GetComponent<Rigidbody>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        clipPlaying = false;
        chaseSpeed = 1;
        m_playerdied = GameObject.Find("DeathManager").GetComponent<PlayerDied>();
        if (!randomize)
        {
            waypointInd = 0;
        }

        if (randomize)
        {
            waypoints = GameObject.FindGameObjectsWithTag("BossNavpoints");
            waypointInd = Random.Range(0, waypoints.Length);
        }

        Music = GameObject.Find("Music").GetComponent<AudioSource>();
        grabber = GameObject.FindGameObjectWithTag("Grabber").transform;
        rolloffmode1 = AudioRolloffMode.Linear;
        //patrolSpeed = .5f;
        agent.updatePosition = true;
        agent.updateRotation = true;

        state = BossTowerAI.State.RUNAWAY;
        alive = true;

        sound = gameObject.GetComponent<AudioSource>();

        anim.SetFloat("SpeedMultiplier", .5f);


        sound.clip = chaseclip;
        StartCoroutine("GrowlManager");
        StartCoroutine("FSM");
        anim.SetBool("WheelsGo", true);
        anim.SetBool("SpearsActive", true);
    }

    IEnumerator GrowlManager()
    {

       
            currentgrowl = growls[soundhashInd];
            if (soundhashInd >= growls.Length)
            {
                soundhashInd = 0;
            }
            //sound.PlayOneShot(growls[Random.Range(0, growls.Length)], 1f);




            yield return new WaitForSeconds(Random.Range(30, 200));
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 80)
            {
                PlayGrowlAt(currentgrowl, pos);
            }



        

        yield return null;
    }

    private AudioSource PlayGrowlAt(AudioClip currentgrowl1, Vector3 pos)
    {
        GameObject tempGRR = new GameObject("TempGrowl"); // create the temp object
        tempGRR.transform.SetParent(gameObject.transform);
        tempGRR.transform.position = pos; // set its position
        AudioSource bSource = tempGRR.AddComponent<AudioSource>(); // add an audio source
        GameObject.Find("TempGrowl").GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
        bSource.clip = currentgrowl1; // define the clip
        bSource.rolloffMode.Equals(AudioRolloffMode.Linear);                     // set other aSource properties here, if desired
        bSource.Play(); // start the sound

        Destroy(tempGRR, 3f);
        //Destroy(tempGO, 0); // destroy object after clip duration
        return bSource; // return the AudioSource reference
    }



    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.RUNAWAY:
                    Runaway();

                    break;
                case State.TOWARDPLAYER:
                    TowardPlayer();
                    break;
                case State.TOCENTER:
                    ToCenter();
                    break;
                case State.RUNWILD:
                    RunWild();
                    break;

            }
            yield return null;
        }
    }

   public IEnumerator Flee()
    {
        state = State.RUNAWAY;
        yield return new WaitForSecondsRealtime(30);
        state = State.TOWARDPLAYER;
        StopCoroutine(Flee());
        yield return null;
    }


    void TowardPlayer()
    {

        path = new NavMeshPath();
        agent.CalculatePath(target.transform.position, path);
        chaseSpeed = 3;
        agent.speed = chaseSpeed;
        //agent.isStopped = true;
        agent.SetPath(path);


        if (pathpending)
        {
            agent.Move(agent.desiredVelocity * Time.deltaTime);
        }
        if (!pathpending)
        {
            agent.isStopped = false;
            agent.Move(agent.desiredVelocity * Time.deltaTime);
        }
        //agent.isStopped = false;
        //  agent.Move(agent.desiredVelocity * Time.deltaTime);
        //character.Move(agent.desiredVelocity, false, false);
        if (Vector3.Distance(transform.position, target.transform.position) >= 80)
        {
            //target = null;
            clipPlaying = false;
            sound.Stop();
            //state = BasicAI.State.PATROL;
            if (!clipPlaying)
            {
                Destroy(GameObject.Find("TempAudio"), 0);
            }
            Music.enabled = true;
            target = null;
            state = BossTowerAI.State.RUNAWAY;
        }
        if (Vector3.Distance(transform.position, target.transform.position) <= attackDistance)
        {



        }

    }


    public void Grab()
    {
        playerRB = grabtarget.GetComponent<Rigidbody>();

        //playeranim = target.GetComponent<Animator>();
        //playerRB.constraints = RigidbodyConstraints.FreezeAll;
        //playerRB.transform.position = Vector3.MoveTowards(playerRB.transform.position, this.gameObject.transform.position, .25f);
        //anim.SetTrigger("GrabDistance");


        StartCoroutine("GrabAttack");
    }

    public IEnumerator GrabAttack()
    {

        //playerRB.constraints = RigidbodyConstraints.FreezeAll;
        playercontroller.enabled = false;
        //fpscontrollerScript.enabled = false;
        ArmGrab.currentlyGrabbing = true;
        //playeranim.enabled = false;
        polypRB.constraints = RigidbodyConstraints.FreezeAll;
        playerRB.transform.position = Vector3.MoveTowards(playerRB.transform.position, grabber.position, .5f * Time.deltaTime);

        yield return new WaitForSeconds(3);

        anim.SetTrigger("HoldingPlayer");




        //playerisdead = true;
        //endposition = playerRB.transform.position;
        //playerRB.transform.position = playerRB.transform.position;
        //playerRB.AddForce(Vector3.MoveTowards(playerRB.transform.position, this.gameObject.transform.position, -1f * Time.deltaTime));
        // playeranim.enabled = true;
        //playercontroller.enabled = true;
        //playerRB.transform.position = endposition;
        //playerRB.velocity.Equals(0);
        polypRB.velocity.Equals(0);
        //playerRB.constraints = RigidbodyConstraints.FreezeRotation;

        //playerRB.transform.localEulerAngles = new Vector3(0, 0, 0);

        // Debug.Log("GrabCoroutine Worked");

        yield return new WaitForSeconds(2);
        //GameObject.FindGameObjectWithTag("TowerBone10").GetComponents<Collider>();
        ArmGrab.letgo = true;
        playercontroller.enabled = true;
        fpscontrollerScript.enabled = true;
        yield return new WaitForSeconds(2);
        ArmGrab.currentlyGrabbing = false;
        polypRB.constraints = RigidbodyConstraints.None;

        StopCoroutine("GrabAttack");
    }


    void ToCenter()
    {
        StopAllCoroutines();
    }


    void RunWild()
    {
        //StartCoroutine(SpinBoss());
        target = waypoints[waypointInd];
        path = new NavMeshPath();
        agent.CalculatePath(target.transform.position, path);
        //chaseSpeed = 3;
        //agent.speed = chaseSpeed;
        //agent.isStopped = true;
        agent.SetPath(path);

        agent.speed = patrolSpeed;
        path = new NavMeshPath();


        //path = new NavMeshPath();
        //agent.CalculatePath(waypoints[waypointInd].transform.position, path);
        //chaseSpeed = 3;
        //agent.speed = chaseSpeed;
        //agent.isStopped = true;
        //agent.SetPath(path);
        if (pathpending)
        {
            agent.Move(agent.desiredVelocity * Time.deltaTime);
        }
        if (!pathpending)
        {
            agent.isStopped = false;
            agent.Move(agent.desiredVelocity * Time.deltaTime);
        }



        if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) >= 2)
        {





            agent.SetDestination(waypoints[waypointInd].transform.position);
            if (pathpending)
            {
                agent.Move(agent.desiredVelocity * Time.deltaTime);
            }
            if (!pathpending)
            {
                agent.isStopped = false;
                agent.Move(agent.desiredVelocity * Time.deltaTime);
            }
            //agent.CalculatePath(waypoints[waypointInd].transform.position, path);

            //agent.SetPath(path);
            agent.SetDestination(waypoints[waypointInd].transform.position);
            agent.Move(agent.desiredVelocity * Time.deltaTime);
            //character.Move(agent.desiredVelocity, false, false);
        }
        else if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) <= 2)
        {
            //agent.destination = (waypoints[waypointInd+1].transform.position);
            //agent.Move(agent.desiredVelocity * Time.deltaTime);
            //character.Move(Vector3.zero, false, false);

            if (!randomize)
            {
                waypointInd = waypointInd += 1;
                if (waypointInd >= waypoints.Length)
                {
                    waypointInd = 0;

                }
            }
            if (randomize)
            {
                waypointInd = Random.Range(0, waypoints.Length);
            }
            //Patrol();
            agent.SetDestination(waypoints[waypointInd].transform.position);
            //agent.CalculatePath(waypoints[waypointInd].transform.position, path);

            //agent.SetPath(path);
            agent.Move(agent.desiredVelocity * Time.deltaTime);
            //character.Move(agent.desiredVelocity, false, false);


        }
    }
    public IEnumerator SpinBoss()
    {
        //polypRB.MoveRotation(Vector3.up * Time.deltaTime, Space.World);
        yield return null;
    }

    void Runaway()
    {
        target = waypoints[waypointInd];
        path = new NavMeshPath();
        agent.CalculatePath(target.transform.position, path);
        //chaseSpeed = 3;
        //agent.speed = chaseSpeed;
        //agent.isStopped = true;
        agent.SetPath(path);

        agent.speed = patrolSpeed;
        path = new NavMeshPath();


        //path = new NavMeshPath();
        //agent.CalculatePath(waypoints[waypointInd].transform.position, path);
        //chaseSpeed = 3;
        //agent.speed = chaseSpeed;
        //agent.isStopped = true;
        //agent.SetPath(path);
        if (pathpending)
        {
            agent.Move(agent.desiredVelocity * Time.deltaTime);
        }
        if (!pathpending)
        {
            agent.isStopped = false;
            agent.Move(agent.desiredVelocity * Time.deltaTime);
        }


        if (Vector3.Distance(transform.position, player.transform.position) < 20)
        {
            StartCoroutine(Flee());
        }

        if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) >= 3)
        {





            agent.SetDestination(waypoints[waypointInd].transform.position);
            if (pathpending)
            {
                agent.Move(agent.desiredVelocity * Time.deltaTime);
            }
            if (!pathpending)
            {
                agent.isStopped = false;
                agent.Move(agent.desiredVelocity * Time.deltaTime);
            }
            //agent.CalculatePath(waypoints[waypointInd].transform.position, path);

            //agent.SetPath(path);
            agent.SetDestination(waypoints[waypointInd].transform.position);
            agent.Move(agent.desiredVelocity * Time.deltaTime);
            //character.Move(agent.desiredVelocity, false, false);
        }
        if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) <= 3)
        {
            //agent.destination = (waypoints[waypointInd+1].transform.position);
            //agent.Move(agent.desiredVelocity * Time.deltaTime);
            //character.Move(Vector3.zero, false, false);
            //print("Boss choosing new navpoint");

            if (!randomize)
            {
                waypointInd = waypointInd += 1;
                if (waypointInd >= waypoints.Length)
                {
                    waypointInd = 0;

                }
            }
            if (randomize)
            {
                waypointInd = Random.Range(0, waypoints.Length);
            }
            //Patrol();
            agent.SetDestination(waypoints[waypointInd].transform.position);
            //agent.CalculatePath(waypoints[waypointInd].transform.position, path);

            //agent.SetPath(path);
            agent.Move(agent.desiredVelocity * Time.deltaTime);
            //character.Move(agent.desiredVelocity, false, false);


        }
    }

    AudioSource PlayClipAt(AudioClip chaseclip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        tempGO.transform.SetParent(gameObject.transform);
        AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
        GameObject.Find("TempAudio").GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
        aSource.clip = chaseclip; // define the clip
        aSource.rolloffMode.Equals(AudioRolloffMode.Linear);                     // set other aSource properties here, if desired
        aSource.Play(); // start the sound
        if (!clipPlaying)
        {
            if (!GameObject.Find("TempAudio"))
            {
                Music.enabled = true;
            }

            Destroy(tempGO, 0);
        }
        //Destroy(tempGO, 0); // destroy object after clip duration
        return aSource; // return the AudioSource reference
    }


    public void SetBallActive()
    {
        anim.SetBool("BallchainActive", true);
    }

    public void switchBallDirection()
    {
        Debug.Log("Direction Switched");
        if (BallChainHealth.chainCollisionjusthappened)
        {
            if (ballDirection == 0)
            {
                ballDirection = 1;
                anim.SetInteger("BallchainDirection", 1);
                BallChainHealth.chainCollisionjusthappened = false;
            }
            
        }
        if (BallChainHealth.chainCollisionjusthappened)
        {

            if (ballDirection == 1)
            {
                ballDirection = 0;
                anim.SetInteger("BallchainDirection", 0);
                BallChainHealth.chainCollisionjusthappened = false;

            }
        }
    }
    public void ArmDestroyed()
    {
        if (armDestroyed)
        {
            SetBallActive();
            anim.SetFloat("SpeedMultiplier", 1f);
        }
    }
    public void BallChainDestroyed()
    {
        if (ballChainDestroyed)
        {
            anim.SetFloat("SpeedMultiplier", 1.5f);
            state = State.RUNWILD;
        }
    }
    
    public void BossIsDead()
    {
        state = BossTowerAI.State.TOCENTER;
        BossisDead = true;
        agent.isStopped = true;
        //agent.enabled = false;
        //anim.enabled = false;
        polypRB.constraints = RigidbodyConstraints.FreezeAll;
        anim.SetTrigger("OpenDoor");
        anim.SetBool("WheelsGo", false);
        anim.SetBool("SpearsActive", false);

        openEndDoor.openSesame();
        openTreasureVault.openSesame();
    }

    

}
