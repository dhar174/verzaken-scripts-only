using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


public class BossWheelHealth : MonoBehaviour {

    // Use this for initialization

    [SerializeField]  private int basehealth;
     [SerializeField]  private int currenthealth;
    public GameObject player;
    public GameObject WeaponContainer;
    public WeaponStats weaponstats;
    public int weapondmg;
    public GameObject CurrentPlayerWeapon;
    public int levelmultiplier;
    private bool explosionstarted;

    [SerializeField] private BossWheelFlash wheelflashScripts;

    public float flashwait;

    public BossTowerAI BossBrain;


    public GameObject sparks;

    public GameObject deathsplosion;

    public bool hitOnce;

    public CharacterStats playerstats;

    public int characterAttackBonus;

    public int healthPercentage;
    public SwitchWeapons scriptedSwitchWeapons;

    //public Renderer rend;

    //public GameObject bossparticles;

    public bool flashing;

    public static bool ballchainJustgone;
    private bool deadOnce;

    // Use this for initialization
    void Start()
    {
        BossBrain = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<BossTowerAI>();

        if (!wheelflashScripts)
        {

            if (gameObject.name == "Bone.019")
            {
                Debug.Log("assigned bone 19");
                wheelflashScripts = GameObject.Find("pSphere4").GetComponent<BossWheelFlash>();
            }

            if (gameObject.name == "Bone.020")
            {
                Debug.Log("assigned bone 20");

                wheelflashScripts = GameObject.Find("pSphere1").GetComponent<BossWheelFlash>();
            }

            if (gameObject.name == "Bone.021")
            {
                Debug.Log("assigned bone 21");

                wheelflashScripts = GameObject.Find("pSphere2").GetComponent<BossWheelFlash>();
            }

            if (gameObject.name == "Bone.022")
            {
                Debug.Log("assigned bone 22");

                wheelflashScripts = GameObject.Find("pSphere3").GetComponent<BossWheelFlash>();
            }

        }

        player = GameObject.FindGameObjectWithTag("Player");
       // WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        hitOnce = false;

      //  scriptedSwitchWeapons = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
       // CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
       // weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        //bossparticles = gameObject.GetComponentInChildren<ParticleSystem>().gameObject;
        if (flashwait == 0)
        {
            flashwait = .1f;
        }
        basehealth = 100;

        //bossparticles.SetActive(false);
        currenthealth = basehealth;
       // rend = wheelflashScripts.gameObject.GetComponent<Renderer>();


        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        characterAttackBonus = playerstats.attackBonus;


    }

   
    public void OnTriggerEnter(Collider other)
    {
        //GameObject otherObj = other.gameObject;
        //Debug.Log("Triggered with: " + otherObj);
        if (BossTowerAI.BossStage >= 2)
        {
           

                if (other.gameObject.tag == "CurrentWeapon" || other.gameObject.tag == "CanGrab" || other.gameObject.tag == "Hammer" || other.gameObject.tag == "Sickle")
                {
                weapondmg = 0;
                WeaponStats weaponstats = null;
                if (other.gameObject.GetComponent<WeaponStats>())
                {
                    weaponstats = other.gameObject.GetComponent<WeaponStats>();
                    weapondmg = weaponstats.WeaponStrength;
                }
                else
                {
                    if (other.gameObject.GetComponent<Rigidbody>())
                    {
                        if (!other.gameObject.GetComponent<Rigidbody>().isKinematic)
                        {
                            weapondmg = Random.Range(0, 5);

                        }
                    }

                }
                Debug.Log("Wheel Hit");
                    WheelDamage();
                    StartCoroutine(WaitQuick());
                    //hitOnce = true;
                }
            
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CurrentWeapon" || other.gameObject.tag == "CanGrab" || other.gameObject.tag == "Hammer" || other.gameObject.tag == "Sickle")
        {

            hitOnce = false;
            //scaledone = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        //BossBrain.switchBallDirection();
        if (BossTowerAI.BossStage >= 2)
        {
           
                if (collision.gameObject.tag == "CurrentWeapon" || collision.gameObject.tag == "CanGrab" || collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Sickle")
                {
                    //sparks = (GameObject)GameObject.Instantiate(Resources.Load("sparks", typeof(GameObject)));
                    ContactPoint contact = collision.contacts[0];
                    Quaternion sparkrot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                    Vector3 sparkpos = contact.point;
                    GameObject sparks2 = Instantiate(sparks, sparkpos, sparkrot) as GameObject;

                    //sparks.gameObject.transform.SetParent()
                    Debug.Log("Collision worked");
                    StartCoroutine(WaitQuick());
                    // hitOnce = true;

                    Destroy(sparks2, .4f);
                }
            
        }
    }

    public IEnumerator WaitQuick()
    {
        yield return new WaitForSeconds(1f);
        hitOnce = false;
        StopCoroutine(WaitQuick());
        yield return null;

    }

    public void WheelDamage()
    {
        characterAttackBonus = playerstats.attackBonus;
        if (!hitOnce)
        {

            currenthealth -= (weapondmg + characterAttackBonus);
            Debug.Log("Wheel Damaged");
            hitOnce = true;
            StartCoroutine(wheelflashScripts.DamageFlash());
        }
    }

    
    public IEnumerator Explode()
    {
        if (!explosionstarted)
        {
            GameObject deathanimation = Instantiate(deathsplosion, transform.position + transform.up, gameObject.transform.rotation) as GameObject;
            deathanimation.transform.parent = null;
            explosionstarted = true;
            StopCoroutine(Explode());

        }
        if (explosionstarted)
        {
            StopCoroutine(Explode());
        }
        yield return null;
    }

    public void WheelDeath()
    {
        
        StartCoroutine(Explode());
        if (!deadOnce)
        {
            WheelCounter.wheelsLeft -= 1;
            deadOnce = true;
            
        }
        
        
       

    }

    
    void Update()
    {
        if (currenthealth <= 1)
        {
            //ArmGrab.letgo = true;
           
            StartCoroutine(wheelflashScripts.DeathFlash());

            if (BossTowerAI.BossisDead)
            {
                Destroy(this);
            }
            
            
            

        }

       // if (scriptedSwitchWeapons.weaponZero != null)
       // {
            //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
       // }

       // weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
       // weapondmg = weaponstats.WeaponStrength;
        if (ballchainJustgone)
        {
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 15)
            {
                StartCoroutine(wheelflashScripts.TestFlash());

            }
        }
        if (wheelflashScripts)
        {
            wheelflashScripts.flashing = flashing;
        }

        if (!wheelflashScripts)
        {
            if (gameObject.name == "Bone.019")
            {
                
                wheelflashScripts = GameObject.Find("pSphere4").GetComponent<BossWheelFlash>();
            }

            if (gameObject.name == "Bone.020")
            {
                

                wheelflashScripts = GameObject.Find("pSphere1").GetComponent<BossWheelFlash>();
            }

            if (gameObject.name == "Bone.021")
            {
               

                wheelflashScripts = GameObject.Find("pSphere2").GetComponent<BossWheelFlash>();
            }

            if (gameObject.name == "Bone.022")
            {
                

                wheelflashScripts = GameObject.Find("pSphere3").GetComponent<BossWheelFlash>();
            }
        }


    }
}
