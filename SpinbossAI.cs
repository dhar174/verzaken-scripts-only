using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class SpinbossAI : MonoBehaviour {


    public bool ThisOneIsActive;
    public GameObject otherSpinBot;

    public float heightMultiplier;
    public bool sawPlayer;
    public NavMeshAgent agent;
    private ThirdPersonCharacter character;
    public AudioRolloffMode rolloffmode1;
    //public List<GameObject> waypointz;
    public bool pathpending;
    public bool haspath;
    public bool randomize;
    private Animator anim;
    private Animator playeranim;
    private Vector3 endposition;
    public PlayerDied m_playerdied;
    public int soundhashInd;

    public int enemyStrength;
    public int levelMultiplier;

    public bool hitplayer;

    public int multiplier;

    public static AudioSource Music;

    public GrowlManager growlscript;

    public bool movingsideways = false;

    public float maxRayDistance;

    public AudioClip chaseclip;
    public AudioClip[] growls;
    public int destination;
    public bool isalive;
    public enum State
    {
        PATROL,
        CHASE,
        BBOTATTACK,
    }

    NavMeshPath path;

    public GameObject eyebotGun;

    public GameObject particleHolder;

    public CharacterController playercontroller;
    public Rigidbody playerRB;
    private Rigidbody polypRB;
    public State state;
    public bool alive;
    //Patrolling Variables
    public GameObject[] waypoints;
    private int waypointInd;
    public float patrolSpeed;

    //public ParticleSystem particlegun;

    //Chasing Variables
    public float chaseSpeed;
    public GameObject target;
    public AudioSource sound;
    public bool clipPlaying;
    public Vector3 pos;
    public AudioClip currentgrowl;

    public float attackDistance;
    public Vector3 targetPosition;

    public bool movingback = false;
    public bool arrivedBack = false;
    public bool attacking = false;

    public GameObject bone;

    public int growlIndex;


    // Use this for initialization
    void Start () {
        //maxRayDistance = 20;
        anim = gameObject.GetComponent<Animator>();
        particleHolder.SetActive(false);

        agent = gameObject.GetComponentInParent<NavMeshAgent>();
        if (!agent)
        {
            agent = gameObject.transform.parent.root.GetComponent<NavMeshAgent>();
        }
        if (!agent)
        {
            agent = gameObject.transform.parent.root.GetComponentInChildren<NavMeshAgent>();
        }
        growlIndex = Random.Range(0, growls.Length);


        currentgrowl = growls[growlIndex];

        growlscript = GameObject.FindGameObjectWithTag("GrowlManager").GetComponent<GrowlManager>();

        levelMultiplier = LevelProgression.MasterLevelMultiplier;
        if (levelMultiplier == 0)
        {
            levelMultiplier = 1;
        }
        enemyStrength = 5* levelMultiplier;
        if (attackDistance == 0)
        {
            attackDistance = 4;
        }
        soundhashInd = Random.Range(0, growls.Length);
        polypRB = gameObject.GetComponent<Rigidbody>();



        character = GetComponent<ThirdPersonCharacter>();
        clipPlaying = false;
        
        m_playerdied = GameObject.Find("DeathManager").GetComponent<PlayerDied>();
        if (!randomize)
        {
            waypointInd = 0;
        }

        if (randomize)
        {

            waypoints = GameObject.FindGameObjectsWithTag("BossNavPoints");
            waypointInd = Random.Range(0, waypoints.Length);
        }

        Music = GameObject.Find("Music").GetComponent<AudioSource>();

        rolloffmode1 = AudioRolloffMode.Linear;
        //patrolSpeed = .5f;
        agent.updatePosition = true;
        agent.updateRotation = true;

        state = State.PATROL;
        
        alive = true;

        sound = gameObject.GetComponent<AudioSource>();



        sound.clip = chaseclip;
        //growlscript.StartCoroutine("GrowlsManager");
        StartCoroutine("FSM");
        multiplier = LevelProgression.MasterLevelMultiplier;

    }

    public IEnumerator RandomGrowl()
    {
        growlIndex = Random.Range(0, growls.Length);
        if (growlIndex > growls.Length)
        {
            growlIndex = 0;
        }


        currentgrowl = growls[growlIndex];

        yield return new WaitForSecondsRealtime(20);
        PlayClipAt(currentgrowl, gameObject.transform.position);

       // StopCoroutine(RandomGrowl());

        yield return null;
    }



    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
                case State.BBOTATTACK:
                    bbbotAttack();
                    break;

            }
            yield return null;
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


    void Patrol()
    {
        agent.speed = patrolSpeed;
        path = new NavMeshPath();

        target = waypoints[waypointInd].gameObject;

        agent.CalculatePath(target.transform.position, path);
        agent.SetPath(path);



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
        else
        {
            //character.Move(Vector3.zero, false, false);
            //agent.SetDestination(waypoints[waypointInd].transform.position);
            //character.Move(agent.desiredVelocity, false, false);
        }
    }

    public IEnumerator SideToSide()
        {

            if (!movingback)
            {
                anim.SetTrigger("trigger1");
                movingsideways = true;
                attacking = false;
                agent.isStopped = true;
                
                
                yield return new WaitForSeconds(1.666f);
                
                
                agent.isStopped = false;
                movingsideways = false;
                movingback = true;
            //attacking = false;
            yield return new WaitForSecondsRealtime(6);
                StartCoroutine(Wait());
                StopCoroutine(SideToSide());
            }
            yield return null;
        }


    public IEnumerator Wait()
    {
        if (otherSpinBot != null)
        {
            otherSpinBot.GetComponent<SpinbossAI>().ThisOneIsActive = true;
        }
        ThisOneIsActive = false;
        particleHolder.SetActive(false);
        state = State.CHASE;
        yield return new WaitForSecondsRealtime(6);
        state = State.PATROL;
        
        sawPlayer = false;
    }

    public void bbbotAttack()
    {
        //Color originalColor = gameObject.GetComponentInChildren<Renderer>().material.color;
        //float stoppingDistance = agent.stoppingDistance;
        //Vector3 toPlayer = target.transform.position - transform.position;
        if (!attacking) //if hes close
        {
            //Renderer renderer = GetComponentInChildren<Renderer>();
           // Material mat = renderer.material;
            agent.acceleration = 10;

            //Color finalColor = originalColor * Mathf.LinearToGammaSpace(0);
           // mat.SetColor("_EmissionColor", finalColor);
            particleHolder.SetActive(false);
           


            agent.isStopped = true;

            if (!movingsideways)
            {
                movingback = true;
                transform.Translate(Vector3.back * 1f);
            }

            if (Vector3.Distance(target.transform.position, transform.position) >= 80)
            {
                attacking = true;
                movingback = false;
            }
            









            agent.isStopped = false;



            //agent.updateRotation = true; //when no longer need to step back then go to normal
        }

        if (attacking)
        {

           // Renderer renderer = GetComponentInChildren<Renderer>();
           // Material mat = renderer.material;

            //Color baseColor = Color.blue;
            //Color finalColor = baseColor * Mathf.LinearToGammaSpace(1);
            //mat.SetColor("_EmissionColor", finalColor);
            particleHolder.SetActive(true);


            agent.isStopped = false;
            agent.destination = target.transform.position;
            path = new NavMeshPath();
            agent.CalculatePath(target.transform.position, path);
            chaseSpeed = 3;
            agent.speed = chaseSpeed * 12;
            agent.acceleration = 80;
            agent.isStopped = true;
            agent.SetPath(path);
            agent.isStopped = false;
        }
        if (Vector3.Distance(target.transform.position, transform.position) <= attackDistance) //if he comes within attacking distance
        {

            if (!movingback)
            {
                if (!movingsideways)
                {
                    StartCoroutine(SideToSide());
                }
            }
        }

    }




    void Chase()
        {
        StartCoroutine(RandomGrowl());
            
            path = new NavMeshPath();
            agent.CalculatePath(target.transform.position, path);

            

            agent.speed = chaseSpeed;
            agent.SetPath(path);
           
            if (Vector3.Distance(transform.position, target.transform.position) <= attackDistance)
            {
            state = State.BBOTATTACK;
            }


            if (pathpending)
            {
                agent.Move(agent.desiredVelocity * Time.deltaTime);
            }
            if (!pathpending)
            {
                agent.isStopped = false;
                agent.Move(agent.desiredVelocity * Time.deltaTime);
            }
            

            

        }
    private void Update()
    {
        destination = waypointInd;
        isalive = alive;
        pathpending = agent.pathPending;
        haspath = agent.hasPath;
        pos = gameObject.transform.position;


    }

    private void FixedUpdate()
    {
        if (ThisOneIsActive)
        {
            
            if (!sawPlayer)
            {

                Ray ray1 = new Ray(transform.position + Vector3.up * heightMultiplier, transform.forward);
                Ray ray2 = new Ray(transform.position + Vector3.up * heightMultiplier, transform.right);
                Ray ray3 = new Ray(transform.position + Vector3.up * heightMultiplier, -transform.forward);
                Ray ray4 = new Ray(transform.position + Vector3.up * heightMultiplier, -transform.right);
                RaycastHit hit1;
                RaycastHit hit2;
                RaycastHit hit3;
                RaycastHit hit4;


                Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * maxRayDistance, Color.red);
                Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.right * maxRayDistance, Color.red);
                Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, -transform.right * maxRayDistance, Color.red);
                Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, -transform.forward * maxRayDistance, Color.red);
                if (Physics.Raycast(ray1, out hit1, maxRayDistance))
                {

                    if (hit1.collider.gameObject.CompareTag("Player"))
                    {
                        anim.enabled = true;
                        target = hit1.collider.gameObject;
                        polypRB.isKinematic = false;
                        sawPlayer = true;
                        state = State.CHASE;
                    }
                }
                if (Physics.Raycast(ray2, out hit2, maxRayDistance))
                {

                    if (hit2.collider.gameObject.CompareTag("Player"))
                    {
                        anim.enabled = true;
                        target = hit2.collider.gameObject;
                        polypRB.isKinematic = false;

                        sawPlayer = true;
                        state = State.CHASE;

                    }
                }
                if (Physics.Raycast(ray3, out hit3, maxRayDistance))
                {

                    if (hit3.collider.gameObject.CompareTag("Player"))
                    {
                        anim.SetBool("attacking", true);

                        anim.enabled = true;
                        target = hit3.collider.gameObject;
                        polypRB.isKinematic = false;

                        sawPlayer = true;
                        state = State.CHASE;

                    }
                }
                if (Physics.Raycast(ray4, out hit4, maxRayDistance))
                {

                    if (hit4.collider.gameObject.CompareTag("Player"))
                    {
                        anim.SetBool("attacking", true);

                        anim.enabled = true;
                        target = hit4.collider.gameObject;
                        polypRB.isKinematic = false;

                        sawPlayer = true;
                        state = State.CHASE;

                    }
                }
            }
        }
        
    }

}
