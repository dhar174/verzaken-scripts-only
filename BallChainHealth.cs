using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


public class BallChainHealth : MonoBehaviour {


    public int basehealth;
    public int currenthealth;
    public GameObject player;
    public GameObject WeaponContainer;
    public WeaponStats weaponstats;
    public int weapondmg;
    public GameObject CurrentPlayerWeapon;
    public int levelmultiplier;
    private bool explosionstarted;
    
    public float flashwait;

    public BossTowerAI BossBrain;


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

    public static bool armjustgone;

    public static bool chainCollisionjusthappened;


    // Use this for initialization
    void Start () {
        BossBrain = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<BossTowerAI>();
        

        player = GameObject.FindGameObjectWithTag("Player");
       // WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        hitOnce = false;

       // scriptedSwitchWeapons = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
       // weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        bossparticles = GameObject.FindGameObjectsWithTag("BallchainParticle");
        if (flashwait == 0)
        {
            flashwait = .1f;
        }
        basehealth = 100;

        foreach (GameObject pp in bossparticles)
        {
            pp.gameObject.SetActive(false);
        }

        currenthealth = basehealth;
        


        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        characterAttackBonus = playerstats.attackBonus;


    }

    public IEnumerator FlashChain()
    {
        rend = GameObject.FindGameObjectWithTag("BossTowerBallchain").GetComponentsInChildren<Renderer>();
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
                foreach (GameObject pp in bossparticles)
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
            StopCoroutine(FlashChain());
        }


        //Material mat = rend[].material;

        yield return null;





    }

    public IEnumerator TestFlash()
    {
        flashing = true;
        StartCoroutine(FlashChain());
        yield return new WaitForSeconds(5);
        flashing = false;
        armjustgone = false;


        yield return null;

    }
    public void OnTriggerEnter(Collider other)
    {
        //GameObject otherObj = other.gameObject;
        //Debug.Log("Triggered with: " + otherObj);
        if (BossTowerAI.BossStage >= 1)
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
                
                //hitOnce = true;
            
                Debug.Log("Chain Hit");
                    ChainDamage();
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
        
        
       
       
            if (collision.gameObject.tag == "CurrentWeapon" || collision.gameObject.tag == "CanGrab" || collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Sickle")
            {
                //sparks = (GameObject)GameObject.Instantiate(Resources.Load("sparks", typeof(GameObject)));
                ContactPoint contact = collision.contacts[0];
                Quaternion sparkrot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 sparkpos = contact.point;
                GameObject sparks2 = Instantiate(sparks, sparkpos, sparkrot) as GameObject;

                if (chainCollisionjusthappened)
                {
                    BossBrain.switchBallDirection();
                }
                chainCollisionjusthappened = true;

                //sparks.gameObject.transform.SetParent()
                Debug.Log("Weapon Collision worked");
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

    public void ChainDamage()
    {
        characterAttackBonus = playerstats.attackBonus;
        if (!hitOnce)
        {

            currenthealth -= (weapondmg + characterAttackBonus);
            Debug.Log("Chain Damaged");
            hitOnce = true;
            StartCoroutine(DamageFlash());
            StartCoroutine(Handicap());
        }
    }

    public IEnumerator Handicap()
    {
        yield return new WaitForSecondsRealtime(120);
        currenthealth -= 0;
        StopCoroutine(Handicap());
    }

    public IEnumerator DamageFlash()
    {
        flashing = true;
        StartCoroutine(FlashChain());
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

    public void ChainDeath()
    {
        int pindex = 0;
        StartCoroutine(Explode());
        BossTowerAI.ballChainDestroyed = true;
        BossTowerAI.BossStage = 2;
        foreach (GameObject p in bossparticles)
        {
            Destroy(bossparticles[pindex]);
            pindex++;
        }
        Collider[] chainColls = gameObject.GetComponents<Collider>();
        foreach(Collider cc in chainColls)
        {
            cc.enabled = false;
        }
        BossBrain.BallChainDestroyed();
        BossWheelHealth.ballchainJustgone = true;
        StopAllCoroutines();

    }

    public IEnumerator DeathFlash()
    {
        flashing = true;
        StartCoroutine(FlashChain());
        yield return new WaitForSeconds(1);
        flashing = false;
        StopAllCoroutines();
        StopCoroutine(DeathFlash());
        if (!BossWheelHealth.ballchainJustgone)
        {
            ChainDeath();
        }
      
        yield return null;
    }

    void Update()
    {
        if (currenthealth <= 1)
        {
            //ArmGrab.letgo = true;
            if (BossTowerAI.ballChainDestroyed)
            {
                Destroy(this);
            }
            StartCoroutine(DeathFlash());
            if (BossTowerAI.ballChainDestroyed)
            {
                Destroy(GameObject.FindGameObjectWithTag("BossTowerBallchain").gameObject);
            }

        }

        //if (scriptedSwitchWeapons.weaponZero != null)
      //  {
            //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
       // }

        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
       // weapondmg = weaponstats.WeaponStrength;
        if (armjustgone)
        {
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 15)
            {
                StartCoroutine(TestFlash());
                
            }
        }



        


    }

}

