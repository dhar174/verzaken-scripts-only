using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    
    public class BasicAI : MonoBehaviour
    {
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

        public AudioClip[] whips;

        public AudioClip lazersound;
        private bool shotplayed;
        private bool soundplayed;

        public int enemyStrength;
        public int levelMultiplier;

        public bool hitplayer;
        private bool lazer;

        public int multiplier;

        public static AudioSource Music;

        public GrowlManager growlscript;

        public bool movingsideways = false;

        public float maxRayDistance;

        public PopupManager popupscript;

        public AudioClip chaseclip;
        public AudioClip[] growls;
        public int destination;
        public bool isalive;
        public enum State
        {
            PATROL,
            CHASE,
            GRAB,
            BBBOTATTACK,
            SPIDERATTACK,
            EYEBOTATTACK,
            SCORPIOATTACK,
            GUARDBOT,
            WALKERATTACK,

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

        public float animSpeed;

        public GameObject bone;

        public int growlIndex;

        private Transform playa;
        void Start()
        {
            playa = GameObject.FindGameObjectWithTag("Player").transform;

            if (maxRayDistance == 0)
            {
                maxRayDistance = 25;
            }
            popupscript = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
            animSpeed = 1;
        

            agent = gameObject.GetComponentInParent<NavMeshAgent>();
            if (!agent)
            {
                agent = gameObject.transform.parent.root.GetComponent<NavMeshAgent>();
            }
            if (!agent)
            {
                agent = gameObject.transform.parent.root.GetComponentInChildren<NavMeshAgent>();
            }
            if (gameObject.CompareTag("FloatingEyebot"))
            {
                //bone = transform.root.gameObject;


                //eyebotGun = gameObject.transform.Find("floatingeyebot").transform.Find("Armature").transform.Find("Bone").transform.Find("Bone.001").transform.Find("Bone.002").transform.Find("Bone.002_end").transform.Find("Particle System").transform.gameObject;

                if (!eyebotGun)
                {
                     //bone = transform.root.gameObject;
                    eyebotGun = gameObject.transform.Find("Armature").transform.Find("Bone").transform.Find("Bone.001").transform.Find("Bone.002").transform.Find("Bone.002_end").transform.Find("Particle System").transform.gameObject;
                    Transform arm = transform.Find("Armature").gameObject.transform;
                    foreach (Transform child in arm)
                    {
                        if (child.gameObject.CompareTag("EyebotGun"))
                        {
                            eyebotGun = child.gameObject;
                        }
                    }

                    //Transform transform = gameObject.transform.root.transform.Find("Armature").transform;
                   // foreach (Transform child in transform)
                 //  {
                       
                  //  }
                }
                eyebotGun.SetActive(false);
                
            }

            growlIndex = Random.Range(0, growls.Length);


            currentgrowl = growls[growlIndex];

            growlscript = GameObject.FindGameObjectWithTag("GrowlManager").GetComponent<GrowlManager>();

            levelMultiplier = LevelProgression.MasterLevelMultiplier;
            if(levelMultiplier == 0)
            {
                levelMultiplier = 1;
            }
            enemyStrength = Random.Range(1, 3) +levelMultiplier;
            polypRB = gameObject.GetComponent<Rigidbody>();
            if (gameObject.CompareTag("Bbbot"))
            {
                particleHolder = gameObject.transform.Find("ParticleHolder").gameObject;
                particleHolder.SetActive(false);
                
            }
            if (gameObject.CompareTag("Robospider"))
            {
                particleHolder = gameObject.transform.Find("robospider2").transform.Find("Armature").transform.Find("Bone").transform.Find("ParticleHolder").gameObject;
                particleHolder.SetActive(false);
            }

            if (attackDistance == 0)
            {
                attackDistance = 4;
            }
            soundhashInd = Random.Range(0, growls.Length);
            if (gameObject.CompareTag("FloatingEyebot"))
            {
                anim= gameObject.GetComponentInParent<Animator>();
                polypRB.constraints = RigidbodyConstraints.FreezeAll;
                polypRB.constraints = RigidbodyConstraints.FreezePosition;
            }
           

            if (!gameObject.CompareTag("FloatingEyebot"))
            {
                
                anim = gameObject.GetComponent<Animator>();
                if (gameObject.CompareTag("GuardBot"))
                {
                    anim.enabled = false;
                    Debug.Log("Anim Disabled?");
                    polypRB.isKinematic = true;
                    
                }
                if (gameObject.CompareTag("TwoWheel"))
                {
                    anim = gameObject.transform.Find("2wheelpart1").transform.gameObject.GetComponent<Animator>();
                }

            }
           
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
                
                waypoints = GameObject.FindGameObjectsWithTag("Navpoints");
                waypointInd = Random.Range(0, waypoints.Length);
            }

            Music = GameObject.Find("Music").GetComponent<AudioSource>();

            rolloffmode1 = AudioRolloffMode.Linear;
            //patrolSpeed = .5f;
            agent.updatePosition = true;
            agent.updateRotation = true;

            state = BasicAI.State.PATROL;
            if (gameObject.CompareTag("GuardBot"))
            {
                state = BasicAI.State.GUARDBOT;
            }
            alive = true;

            sound = gameObject.GetComponent<AudioSource>();

           

            sound.clip = chaseclip;
           //growlscript.StartCoroutine("GrowlsManager");
            StartCoroutine("FSM");
            multiplier = LevelProgression.MasterLevelMultiplier;
            anim.SetFloat("speed", animSpeed);

        }
        public void SetAnimSpeed()
        {
            anim.SetFloat("speed", animSpeed);

        }

        public IEnumerator RandomGrowl()
        {
            growlIndex = Random.Range(0, growls.Length);


            currentgrowl = growls[growlIndex];

            StopCoroutine(RandomGrowl());

            yield return null;
        }

        

        IEnumerator FSM()
        {
            while (alive)
            {
                if (!Pause.gamePaused)
                {
                    switch (state)
                    {
                        case State.PATROL:
                            Patrol();

                            break;
                        case State.CHASE:
                            Chase();
                            break;
                        case State.GRAB:
                            //Grab();
                            break;
                        case State.BBBOTATTACK:
                            bbbotAttack();
                            break;
                        case State.SPIDERATTACK:
                            SpiderAttack();
                            break;
                        case State.EYEBOTATTACK:
                            EyebotAttack();
                            break;
                        case State.SCORPIOATTACK:
                            ScorpioAttack();
                            break;
                        case State.GUARDBOT:
                            GuardBot();
                            break;
                        case State.WALKERATTACK:
                            WalkerAttack();
                            break;



                    }
                }
                yield return null;
            }
        }
        public void WalkerAttack()
        {
            anim.SetTrigger("Attack");
            anim.SetBool("stopattack", false);
            if (Vector3.Distance(target.transform.position, transform.position) < 5)
            {
                anim.SetBool("walk", false);
            }
            if (Vector3.Distance(target.transform.position, transform.position) == 5)
            {
                anim.SetBool("walk", true);
            }
            
            if(Vector3.Distance(target.transform.position, transform.position) > 8)
            {
                anim.SetBool("stopattack", true);
                anim.SetBool("walk", true);

                state = BasicAI.State.CHASE;
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
            lazer = false;
            agent.speed = patrolSpeed;
            path = new NavMeshPath();
            if (gameObject.CompareTag("FloatingEyebot"))
            {
                agent.stoppingDistance = 1;
            }

            //path = new NavMeshPath();
            //agent.CalculatePath(waypoints[waypointInd].transform.position, path);
            //chaseSpeed = 3;
            //agent.speed = chaseSpeed;
            //agent.isStopped = true;
            //agent.SetPath(path);


            

            if (Vector3.Distance (transform.position, waypoints[waypointInd].transform.position) > 2)
            {





                agent.SetDestination(waypoints[waypointInd].transform.position);
                if (pathpending)
                {
                    agent.isStopped = false;

                    if (Vector3.Distance(playa.position, transform.position) <= 150)
                    {
                        agent.Move(agent.desiredVelocity * Time.deltaTime);
                    }
                }
                if (!pathpending)
                {
                    agent.isStopped = false;
                    if (Vector3.Distance(playa.position, transform.position) <= 150)
                    {
                        agent.Move(agent.desiredVelocity * Time.deltaTime);
                    }
                }
                //agent.CalculatePath(waypoints[waypointInd].transform.position, path);

                //agent.SetPath(path);
                agent.SetDestination(waypoints[waypointInd].transform.position);
                if (Vector3.Distance(playa.position, transform.position) <= 150)
                {
                    agent.Move(agent.desiredVelocity * Time.deltaTime);
                }

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

        public void ScorpioAttack()
        {
           

            if (!attacking)
            {
                
                if (Vector3.Distance(target.transform.position, transform.position) > 6)
                {
                    anim.SetBool("dontattack", true);
                    state = State.CHASE;

                }



                
                if (Vector3.Distance(target.transform.position, transform.position) <= 3)
                {
                    
                    anim.SetBool("dontattack", false);
                    anim.SetTrigger("attack");
                    attacking = true;
                }

               
                agent.isStopped = false;



                //agent.updateRotation = true; //when no longer need to step back then go to normal
            }

            if (attacking)
            {

              


                agent.isStopped = false;


                if (Vector3.Distance(target.transform.position, transform.position) > 6)
                {
                    anim.SetBool("dontattack", true);
                    attacking = false;
                    state = State.CHASE;


                }

                if (Vector3.Distance(target.transform.position, transform.position) <= 3)
                {
                    agent.isStopped = true;
                    if (!shotplayed)
                    {
                        lazer = true;
                        lazersound = whips[growlIndex];
                        StartCoroutine(RandomGrowl());
                        StartCoroutine(PlayLazerSound());
                    }
                    anim.SetBool("dontattack", false);
                    anim.SetTrigger("attack");
                    //attacking = false;
                }


                //agent.isStopped = false;
                agent.destination = target.transform.position;
                path = new NavMeshPath();
                agent.CalculatePath(target.transform.position, path);
                chaseSpeed = 3;
                agent.speed = chaseSpeed * 8;
                //agent.isStopped = true;
                agent.SetPath(path);
                agent.isStopped = false;



                agent.isStopped = false;
            }
           
        }

        public void SpiderAttack()
        {
            Color originalColor = gameObject.transform.Find("robospider2").transform.Find("Sphere").GetComponent<Renderer>().material.color;
            //float stoppingDistance = agent.stoppingDistance;
            //Vector3 toPlayer = target.transform.position - transform.position;

            if (hitplayer)
            {
                anim.SetTrigger("playerhit");
                hitplayer = false;
                attacking = false;
            }
            if (!attacking) 
            {
                Renderer renderer = gameObject.transform.Find("robospider2").transform.Find("Sphere").GetComponent<Renderer>();
                Material mat = renderer.material;
                

               // Color finalColor = originalColor * Mathf.LinearToGammaSpace(0);
               // mat.SetColor("_EmissionColor", finalColor);
                particleHolder.SetActive(false);
                //agent.updateRotation = false; // disable the automatic rotation





                //Vector3 targetPosition = transform.position + Vector3.back * 0.2f;
                //agent.destination = targetPosition;
                if (Vector3.Distance(target.transform.position, transform.position) > 6)
                {
                    anim.SetBool("dontjump", true);

                }

                

                transform.Translate(Vector3.back * .5f);
                //polypRB.MovePosition(Vector3.back * .5f);
                if (Vector3.Distance(target.transform.position, transform.position) >= 8)
                {
                    attacking = true;
                }

                //transform.Translate(Vector3.back * Time.deltaTime);

                //path = new NavMeshPath();
                //agent.CalculatePath(targetPosition, path);
                //chaseSpeed = 3;
                //agent.speed = chaseSpeed;
                //agent.isStopped = true;
                //agent.SetPath(path);





                //transform.Translate(Vector3.MoveTowards(transform.position, targetPosition, 1));
                //if (transform.position == targetPosition)
                //{
                //    arrivedBack = true;
                // }




                




                agent.isStopped = false;



                //agent.updateRotation = true; //when no longer need to step back then go to normal
            }

            if (attacking)
            {

                Renderer renderer = GetComponentInChildren<Renderer>();
                Material mat = renderer.material;

                Color baseColor = Color.blue;
                Color finalColor = baseColor * Mathf.LinearToGammaSpace(1);
               // mat.SetColor("_EmissionColor", finalColor);
                particleHolder.SetActive(true);


                agent.isStopped = false;


                if (Vector3.Distance(target.transform.position, transform.position) > 6)
                {
                    anim.SetBool("dontjump", true);

                }

                if (Vector3.Distance(target.transform.position, transform.position) <= 6)
                {
                    anim.SetBool("dontjump", false);
                    anim.SetTrigger("jump");
                    //attacking = false;
                }
               

                    agent.isStopped = false;
                agent.destination = target.transform.position;
                path = new NavMeshPath();
                agent.CalculatePath(target.transform.position, path);
                chaseSpeed = 3;
                agent.speed = chaseSpeed * 8;
                //agent.isStopped = true;
                agent.SetPath(path);
                agent.isStopped = false;

                if (Vector3.Distance(target.transform.position, transform.position) <= 1.2)
                {
                    movingback = true;



                }


                agent.isStopped = false;
            }
            if (movingback)
            {
                attacking = false;
                
            }
        }

        public void EyebotAttack()
        {
            if (!shotplayed)
            {
                lazer = true;
                StartCoroutine(PlayLazerSound());
            }
            
            GunAim gunaimScript = eyebotGun.GetComponent<GunAim>();
            gunaimScript.AimGun(target.transform);
            agent.isStopped = true;
            anim.SetBool("isAttacking",true);
            if (Vector3.Distance(target.transform.position, transform.parent.transform.position) > 2)
            {
                transform.parent.transform.LookAt(target.transform, Vector3.up);
                //Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
               // float str = Mathf.Min(.5f * Time.deltaTime, 1);
               // transform.parent.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
            }
            if (!eyebotGun.activeSelf)
            {
                eyebotGun.SetActive(true);
            }
            if(Vector3.Distance(target.transform.position, transform.position) >= 15)
            {
                eyebotGun.SetActive(false);
                agent.isStopped = false;
                anim.SetBool("isAttacking", false);
                state = BasicAI.State.CHASE;

            }
           



        }

        public IEnumerator PlayLazerSound()
        {
            if (!lazer)
            {
                StopCoroutine(PlayLazerSound());
            }
            if (lazer)
            {
                if (!shotplayed)
                {
                    sound.PlayOneShot(lazersound);
                    shotplayed = true;
                }
                lazer = false;
                yield return new WaitForSecondsRealtime(1f);
                shotplayed = false;
                
            }
            
        }

        public void bbbotAttack()
        {
            Color originalColor = gameObject.GetComponentInChildren<Renderer>().material.color;
            //float stoppingDistance = agent.stoppingDistance;
            //Vector3 toPlayer = target.transform.position - transform.position;
            if (!attacking) //if hes close
            {
                Renderer renderer = GetComponentInChildren<Renderer>();
                Material mat = renderer.material;
                agent.acceleration = 10;
                
                Color finalColor = originalColor * Mathf.LinearToGammaSpace(0);
               // mat.SetColor("_EmissionColor", finalColor);
                particleHolder.SetActive(false);
                //agent.updateRotation = false; // disable the automatic rotation





                //Vector3 targetPosition = transform.position + Vector3.back * 0.2f;
                //agent.destination = targetPosition;


                agent.isStopped = true;

                if (!movingsideways)
                {
                    movingback = true;
                    transform.Translate(Vector3.back * 1f);
                    
                }

                    if (Vector3.Distance(target.transform.position, transform.position) >= 15)
                    {
                        attacking = true;
                       movingback = false;
                    }
                
                //transform.Translate(Vector3.back * Time.deltaTime);

                //path = new NavMeshPath();
                //agent.CalculatePath(targetPosition, path);
                //chaseSpeed = 3;
                //agent.speed = chaseSpeed;
                //agent.isStopped = true;
                //agent.SetPath(path);

                



                //transform.Translate(Vector3.MoveTowards(transform.position, targetPosition, 1));
                //if (transform.position == targetPosition)
                //{
                //    arrivedBack = true;
               // }









                agent.isStopped = false;
                
                

                //agent.updateRotation = true; //when no longer need to step back then go to normal
            }
            
            if (attacking)
            {
                
                Renderer renderer = GetComponentInChildren<Renderer>();
                Material mat = renderer.material;
                
                Color baseColor = Color.blue;
                Color finalColor = baseColor * Mathf.LinearToGammaSpace(1);
                //mat.SetColor("_EmissionColor", finalColor);
                particleHolder.SetActive(true);

                
                agent.isStopped = false;
                agent.destination = target.transform.position;
                path = new NavMeshPath();
                agent.CalculatePath(target.transform.position, path);
                chaseSpeed = 3;
                agent.speed = chaseSpeed*12;
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
                StopCoroutine(SideToSide());
            }
            yield return null;
        }

        public void GuardBot()
        {
            if (!sawPlayer)
            {
                if (anim.isActiveAndEnabled)
                {
                    anim.SetBool("attacking", false);
                }
            }
            if (sawPlayer)
            {
                anim.SetBool("attacking", true);
                state = BasicAI.State.CHASE;
            }
        }

        public IEnumerator PlayGrowlSound()
        {
            if (!lazer)
            {
                StopCoroutine(PlayGrowlSound());
            }
            if (lazer)
            {
                if (!soundplayed)
                {
                    sound.PlayOneShot(currentgrowl);
                    soundplayed = true;
                }
                lazer = false;
                yield return new WaitForSecondsRealtime(20f);
                soundplayed = false;

            }

        }

         
    

        void Chase()
        {
            //sound.clip = currentgrowl;
            if (!soundplayed)
            {
                StartCoroutine(RandomGrowl());
                    lazer = true;
               // sound.clip = currentgrowl;
                //sound.Play();
                //soundplayed = true;
                StartCoroutine(PlayGrowlSound());
            }
            path = new NavMeshPath();
            agent.CalculatePath(target.transform.position, path);

            if (!gameObject.CompareTag("GuardBot"))
            {
                chaseSpeed = 3;
            }

            agent.speed = chaseSpeed;
            //agent.isStopped = true;
            
            
                agent.SetPath(path);
            
            if (gameObject.CompareTag("FloatingEyebot"))
            {
                agent.stoppingDistance = 15;
            }
            if (Vector3.Distance(transform.position, target.transform.position) <= attackDistance)
            {

                if (gameObject.CompareTag("Bbbot"))
                {
                    state = BasicAI.State.BBBOTATTACK;
                }
                if (gameObject.CompareTag("Robospider"))
                {
                    state = BasicAI.State.SPIDERATTACK;
                }
                if (gameObject.CompareTag("FloatingEyebot"))
                {
                    agent.isStopped = true;
                    state = BasicAI.State.EYEBOTATTACK;
                }
                if (gameObject.CompareTag("Roboscorpion"))
                {
                    state = BasicAI.State.SCORPIOATTACK;
                }
                if (gameObject.CompareTag("WalkerBot"))
                {
                    state = BasicAI.State.WALKERATTACK;
                }
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
            //agent.isStopped = false;
            //  agent.Move(agent.desiredVelocity * Time.deltaTime);
            //character.Move(agent.desiredVelocity, false, false);

            if (Vector3.Distance (transform.position, target.transform.position) >= 80)
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
                state = BasicAI.State.PATROL;
                sawPlayer = false;
            }
            

        }

        void Grab()
        {
            playerRB = target.GetComponent<Rigidbody>();
           
            playeranim = target.GetComponent<Animator>();
            //playerRB.constraints = RigidbodyConstraints.FreezeAll;
            //playerRB.transform.position = Vector3.MoveTowards(playerRB.transform.position, this.gameObject.transform.position, .25f);
            //anim.SetTrigger("GrabDistance");
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("GrabAttackstate"))
                anim.SetTrigger("GrabDistance");

            StartCoroutine("GrabAttack");
        }

        IEnumerator GrabAttack()
        {
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            //playercontroller.enabled = false;
            playeranim.enabled = false;
            polypRB.constraints = RigidbodyConstraints.FreezeAll;
            //playerRB.transform.position = Vector3.MoveTowards(playerRB.transform.position, this.gameObject.transform.position, .5f * Time.deltaTime);

            yield return new WaitForSeconds(5);

            //playerisdead = true;
            //endposition = playerRB.transform.position;
            //playerRB.transform.position = playerRB.transform.position;
            //playerRB.AddForce(Vector3.MoveTowards(playerRB.transform.position, this.gameObject.transform.position, -1f * Time.deltaTime));
            playeranim.enabled = true;
            //playercontroller.enabled = true;
            //playerRB.transform.position = endposition;
            //playerRB.velocity.Equals(0);
            //polypRB.velocity.Equals(0);
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            //polypRB.constraints = RigidbodyConstraints.None;
            //playerRB.transform.localEulerAngles = new Vector3(0, 0, 0);

        
            
            yield return new WaitForSeconds(2);
            

            state = BasicAI.State.CHASE;
            StopCoroutine("GrabAttack");
        }

        private void OnTriggerEnter(Collider coll)
        {
            //Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("CurrentWeapon").GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            //Physics.IgnoreLayerCollision(10, 11, true);
            //Physics.IgnoreLayerCollision(12, 11, true);
            //sound.PlayOneShot(growls[soundhashInd], 1f);

            //AudioSource.PlayClipAtPoint(currentgrowl, pos);
            GameObject otherobject = coll.gameObject;
            
            if (coll.CompareTag("Player")) 
            {
                
                    if (!PopupManager.firstenemyEncountered)
                    {
                        StartCoroutine(popupscript.firstenemy());
                        PopupManager.firstenemyEncountered = true;
                    }
                
                //Debug.Log("detected Player");
                growlscript.PlayGrowlAt(currentgrowl, pos);
                target = coll.gameObject;
                if (gameObject.CompareTag("FloatingEyebot"))
                {
                    anim.SetTrigger("SawPlayer");
                }
                state = BasicAI.State.CHASE;
                

               
            }
           
            
            
            //if(coll.tag != "Player")
            //{
                //Debug.Log("Detected something else" + otherobject);
            //}        
                   
            
        }

        private void Update()
        {
            destination = waypointInd;
            isalive = alive;
            pathpending = agent.pathPending;
            haspath = agent.hasPath;
            pos = gameObject.transform.position;
            targetPosition = agent.destination;
            
        }

        private void FixedUpdate()
        {
            if (gameObject.CompareTag("Roboscorpion"))
            {
                if (!sawPlayer)
                {

                    Ray ray1 = new Ray(transform.position + Vector3.up * heightMultiplier, transform.forward);
                    Ray ray2 = new Ray(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward);
                    Ray ray3 = new Ray(transform.position + Vector3.up * (heightMultiplier + 1), transform.forward);
                    RaycastHit hit1;
                    RaycastHit hit2;
                    RaycastHit hit3;

                    Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier + 1), transform.forward * maxRayDistance, Color.red);

                    if (Physics.Raycast(ray1, out hit1, maxRayDistance))
                    {

                        if (hit1.collider.gameObject.CompareTag("Player"))
                        {
                            growlscript.PlayGrowlAt(currentgrowl, pos);

                            state = BasicAI.State.CHASE;
                            target = hit1.collider.gameObject;
                           
                            sawPlayer = true;
                        }
                    }
                    if (Physics.Raycast(ray2, out hit2, maxRayDistance))
                    {

                        if (hit2.collider.gameObject.CompareTag("Player"))
                        {
                            state = BasicAI.State.CHASE;
                            target = hit2.collider.gameObject;
                            growlscript.PlayGrowlAt(currentgrowl, pos);

                            sawPlayer = true;
                        }
                    }
                    if (Physics.Raycast(ray3, out hit3, maxRayDistance))
                    {

                        if (hit3.collider.gameObject.CompareTag("Player"))
                        {
                            state = BasicAI.State.CHASE;
                            target = hit3.collider.gameObject;
                            growlscript.PlayGrowlAt(currentgrowl, pos);

                            sawPlayer = true;
                        }
                    }
                }
            }
            if (gameObject.CompareTag("GuardBot"))
            {
                if (!sawPlayer)
                {

                    Ray ray1 = new Ray(transform.position+Vector3.up*heightMultiplier, transform.forward);
                    Ray ray2 = new Ray(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward);
                    Ray ray3= new Ray(transform.position + Vector3.up * (heightMultiplier - 3), transform.forward);
                    RaycastHit hit1;
                    RaycastHit hit2;
                    RaycastHit hit3;


                    Debug.DrawRay(transform.position+Vector3.up*heightMultiplier, transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier - 3), transform.forward * maxRayDistance, Color.red);
                    if (Physics.Raycast(ray1, out hit1, maxRayDistance))
                    {
                        
                        if (hit1.collider.gameObject.CompareTag("Player"))
                        {
                            anim.enabled = true;
                            //print("Anim Enabled?");
                            target = hit1.collider.gameObject;
                            polypRB.isKinematic = false;
                            sawPlayer = true;
                        }
                    }
                    if (Physics.Raycast(ray2, out hit2, maxRayDistance))
                    {

                        if (hit2.collider.gameObject.CompareTag("Player"))
                        {
                            anim.enabled = true;
                            target = hit2.collider.gameObject;
                            polypRB.isKinematic = false;
                            //print("Anim Enabled?");

                            sawPlayer = true;
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
                           // print("Anim Enabled?");

                            sawPlayer = true;
                        }
                    }
                }
            }
            if (gameObject.CompareTag("WalkerBot"))
            {
                if (!sawPlayer)
                {

                    Ray ray1 = new Ray(transform.position + Vector3.up * heightMultiplier, transform.forward);
                    Ray ray2 = new Ray(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward * maxRayDistance);
                    Ray ray3 = new Ray(transform.position + Vector3.up * (heightMultiplier - 3), transform.forward);
                    RaycastHit hit1;
                    RaycastHit hit2;
                    RaycastHit hit3;


                    Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier - 3), transform.forward * maxRayDistance, Color.red);
                 //   if (Physics.Raycast(ray1, out hit1, maxRayDistance))
                  //  {

                  //      if (hit1.collider.gameObject.CompareTag("Player"))
                  //      {
                  //          anim.enabled = true;
                  //          target = hit1.collider.gameObject;
                  //          polypRB.isKinematic = false;
                  //          sawPlayer = true;
                  //      }
                 //   }
                    if (Physics.Raycast(ray2, out hit2, maxRayDistance))
                    {

                        if (hit2.collider.gameObject.CompareTag("Player"))
                        {
                            anim.enabled = true;
                            target = hit2.collider.gameObject;
                            polypRB.isKinematic = false;

                            sawPlayer = true;
                        }
                    }
                  //  if (Physics.Raycast(ray3, out hit3, maxRayDistance))
                  //  {

                  //      if (hit3.collider.gameObject.CompareTag("Player"))
                  //      {
                            //anim.SetBool("attacking", true);

                  //          anim.enabled = true;
                  //          target = hit3.collider.gameObject;
                   //         polypRB.isKinematic = false;

                   //         sawPlayer = true;
                 //       }
                 //   }
                }
                if (sawPlayer)
                {
                    state = BasicAI.State.WALKERATTACK;
                }
            }
            if (gameObject.CompareTag("TwoWheel"))
            {
                if (!sawPlayer)
                {

                    Ray ray1 = new Ray(transform.position + Vector3.up * heightMultiplier, transform.forward);
                    Ray ray2 = new Ray(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward);
                    Ray ray3 = new Ray(transform.position + Vector3.up * (heightMultiplier - 3), transform.forward);
                    RaycastHit hit1;
                    RaycastHit hit2;
                    RaycastHit hit3;


                    Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier - 1), transform.forward * maxRayDistance, Color.red);
                    Debug.DrawRay(transform.position + Vector3.up * (heightMultiplier - 3), transform.forward * maxRayDistance, Color.red);
                    if (Physics.Raycast(ray1, out hit1, maxRayDistance))
                    {

                        if (hit1.collider.gameObject.CompareTag("Player"))
                        {
                            growlscript.PlayGrowlAt(currentgrowl, pos);

                            state = BasicAI.State.CHASE;
                            target = hit1.collider.gameObject;
                           // anim.SetBool("attacking", true);
                            sawPlayer = true;
                        }
                    }
                    if (Physics.Raycast(ray2, out hit2, maxRayDistance))
                    {

                        if (hit2.collider.gameObject.CompareTag("Player"))
                        {
                            growlscript.PlayGrowlAt(currentgrowl, pos);

                            state = BasicAI.State.CHASE;
                            target = hit2.collider.gameObject;
                           // anim.SetBool("attacking", true);
                            sawPlayer = true;
                        }
                    }
                    if (Physics.Raycast(ray3, out hit3, maxRayDistance))
                    {

                        if (hit3.collider.gameObject.CompareTag("Player"))
                        {
                            growlscript.PlayGrowlAt(currentgrowl, pos);

                            state = BasicAI.State.CHASE;
                            target = hit3.collider.gameObject;
                            //anim.SetBool("attacking", true);
                            sawPlayer = true;
                        }
                    }
                }
            }
        }
        

    }





 }  



