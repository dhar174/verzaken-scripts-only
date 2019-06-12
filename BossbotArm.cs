using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


public class BossbotArm : MonoBehaviour {
    public BossTowerAI BossBrain;


    public int basehealth;
    public int currenthealth;
    public GameObject player;
    public GameObject WeaponContainer;
    public WeaponStats weaponstats;
    public int weapondmg;
    public GameObject CurrentPlayerWeapon;
    public int levelmultiplier;
    private bool explosionstarted;
    public AudioSource music;
    public float flashwait;

    public Collider[] ArmColliders;

    public bool firstseen;


    public GameObject sparks;

    public GameObject deathsplosion;

    public bool hitOnce;

    public CharacterStats playerstats;

    public int characterAttackBonus;

    public int healthPercentage;
    public SwitchWeapons scriptedSwitchWeapons;

    public Renderer[] rend;

    public GameObject[] bossparticles;

    public bool flashing;

    // Use this for initialization
    void Start () {
        BossBrain = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<BossTowerAI>();

        firstseen = false;

        ArmColliders = GameObject.Find("Bone.008").GetComponentsInChildren<Collider>();

        player = GameObject.FindGameObjectWithTag("Player");
        //WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        hitOnce = false;

        //scriptedSwitchWeapons = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        bossparticles = GameObject.FindGameObjectsWithTag("BossParticle");
       if(flashwait == 0)
        {
            flashwait = .1f;
        }
            basehealth = 100;

        foreach (GameObject pp in bossparticles)
        {
            pp.gameObject.SetActive(false);
        }

        currenthealth = basehealth;
        music = GameObject.Find("Music").GetComponent<AudioSource>();
       
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        characterAttackBonus = playerstats.attackBonus;

    }

    public IEnumerator FlashArm()
    {
        rend = GameObject.FindGameObjectWithTag("BossBotArm").GetComponentsInChildren<Renderer>();
        //Color originalColor = rend[0].material.color;
        while (flashing)
        {

           
            int rendererIndex = 0;
            Color originalColor = rend[0].material.color;

            foreach (Renderer i in rend)
            {

                
                Material mat = rend[rendererIndex].material;
                Color baseColor = Color.red;
                Color finalColor = baseColor * Mathf.LinearToGammaSpace(1);
                mat.SetColor("_EmissionColor", finalColor);
                mat.color = Color.red;
                foreach(GameObject pp in bossparticles)
                {
                    pp.SetActive(true);
                }
                rendererIndex++;




            }
            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
            rendererIndex = 0;
            yield return new WaitForSeconds(flashwait);

            foreach (Renderer i in rend)
            {


                // yield return new WaitForSeconds(.5f);
                //Color originalColor = rend[rendererIndex].material.color;
                Material mat = rend[rendererIndex].material;
                foreach (GameObject pp in bossparticles)
                {
                    pp.SetActive(false);
                }

                Color finalColor = originalColor * Mathf.LinearToGammaSpace(0);
                mat.SetColor("_EmissionColor", finalColor);
                mat.color = Color.white;
                rendererIndex++;


            }
            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
            rendererIndex = 0;
            yield return new WaitForSeconds(flashwait);
        }

        if (!flashing)
        {
            StopCoroutine(FlashArm());
        }


        //Material mat = rend[].material;

        yield return null;
        
       



    }

    public IEnumerator TestFlash()
    {
        flashing = true;
        StartCoroutine(FlashArm());
        yield return new WaitForSeconds(5);
        flashing = false;



        yield return null;

    }


    public void OnTriggerEnter(Collider other)
    {
        //GameObject otherObj = other.gameObject;
        //Debug.Log("Triggered with: " + otherObj);

        
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
            Debug.Log("Arm Hit");
                ArmDamage();
                StartCoroutine(WaitQuick());
                //hitOnce = true;
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

    public void OnCollisionStay(Collision collision)
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

    public IEnumerator WaitQuick()
    {
     yield return new WaitForSeconds(1f);
      hitOnce = false;
        StopCoroutine(WaitQuick());
        yield return null;
     
    }

    public void ArmDamage()
    {
        characterAttackBonus = playerstats.attackBonus;
        if (!hitOnce)
        {
           
            currenthealth -= (weapondmg + characterAttackBonus);
            Debug.Log("Arm Damaged");
            hitOnce = true;
            StartCoroutine(DamageFlash());
        }
    }

    public IEnumerator DamageFlash()
    {
        flashing = true;
        StartCoroutine(FlashArm());
        yield return new WaitForSeconds(.5f);
        flashing = false;
        yield return null;
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

    public void ArmDeath()
    {
        Debug.Log("Arm Destroyed");
        int pindex = 0;
        StartCoroutine(Explode());
        BossTowerAI.armDestroyed = true;
        BossTowerAI.BossStage = 1;
        foreach(GameObject p in bossparticles)
        {
            Destroy(bossparticles[pindex]);
            pindex++;
        }
        BallChainHealth.armjustgone = true;
        foreach(Collider c in ArmColliders)
        {
            c.enabled = false;
        }

        BossBrain.ArmDestroyed();

        StopAllCoroutines();
        
        //BossTowerAI.BossisDead = true;

    }

    public IEnumerator DeathFlash()
    {
        flashing = true;
        StartCoroutine(FlashArm());
        yield return new WaitForSeconds(1);
        flashing = false;
        ArmDeath();
        StopCoroutine(DeathFlash());
        yield return null;
    }

    void Update()
    {
        if (currenthealth <= 1)
        {
            
            ArmGrab.letgo = true;
            if (BossTowerAI.armDestroyed)
            {
                Destroy(this);
            }
            StartCoroutine(DeathFlash());
            if (BossTowerAI.armDestroyed)
            {
                Destroy(GameObject.FindGameObjectWithTag("BossBotArm").gameObject, .1f);

            }

        }

       // if (scriptedSwitchWeapons.weaponZero != null)
        //{
       //     CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
       // }

        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        //weapondmg = weaponstats.WeaponStrength;
        if (!firstseen)
        {
            if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 15)
            {
                StartCoroutine(TestFlash());
                firstseen = true;
            }
        }
       



        if (Input.GetKey(KeyCode.T))
        {
            StartCoroutine(TestFlash());
            
        }


    }

}
