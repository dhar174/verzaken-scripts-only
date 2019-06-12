using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

public class BossHealthAndDamage : MonoBehaviour {
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
    public BossTowerAI basicAI;
    public bool isclipPlaying;

    public BossTowerAI bossBrain;

    public bool xpGiven;

    public GameObject sparks;

    public GameObject deathsplosion;

    public bool hitOnce;

    public int xpvalue;

    public CharacterStats playerstats;

    public int characterAttackBonus;

    public RectTransform spriteRect;
    public Transform healthHolder;

    public float originalscale;
    public float newscale;
    public float scalePercentage;

    //public bool scaledone;

    public int healthPercentage;
    public float floatingPercentage;

    public SwitchWeapons scriptedSwitchWeapons;

    // Use this for initialization
    void Start()
    {
        spriteRect = gameObject.GetComponentInChildren<RectTransform>();
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
        player = GameObject.FindGameObjectWithTag("Player");
       // WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        hitOnce = false;

        //scriptedSwitchWeapons = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        bossBrain = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<BossTowerAI>();


        if (levelmultiplier < 1)
        {
            basehealth = UnityEngine.Random.Range(50, 150);
        }
        if (levelmultiplier >= 1)
        {
            basehealth = UnityEngine.Random.Range(50, 150) * levelmultiplier;
        }

        if (levelmultiplier == 0)
        {
            xpvalue = (basehealth / 10);
        }
        if (levelmultiplier >= 1)
        {
            xpvalue = (basehealth / 10) * levelmultiplier;
        }
        currenthealth = basehealth;
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        basicAI = gameObject.GetComponent<BossTowerAI>();
        isclipPlaying = basicAI.clipPlaying;
        playerstats = GameObject.Find("PlayerCharacter").GetComponent<CharacterStats>();
        characterAttackBonus = playerstats.attackBonus;
        xpGiven = false;

        //scaledone = false;
        healthHolder = this.gameObject.transform.Find("HealthHolder").GetComponent<Transform>();
        originalscale = healthHolder.localScale.x;


    }
    public void FixedUpdate()
    {
        //floatingPercentage = (float)healthPercentage;
        //healthPercentage = (int)floatingPercentage;
        //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        //weapondmg = weaponstats.WeaponStrength;


    }



    public void ChangeScale()
    {


        //newscale = (originalscale) *= (healthPercentage /= 100);
        //scalePercentage = (newscale * 100) / originalscale;

        //Vector2 rectSize = gameObject.GetComponentInChildren<RectTransform>().sizeDelta;
        //rectSize = new Vector2(newscale, 1f);
        //spriteRect.sizeDelta = rectSize;

        spriteRect.localScale = new Vector3(newscale, 1f, 1f);
        //spriteRect.localPosition = healthHolder.localPosition + new Vector3(newscale, 1f, 1f);
        //scaledone = true;

    }



    public void OnTriggerEnter(Collider other)
    {
        //GameObject otherObj = other.gameObject;
        //Debug.Log("Triggered with: " + otherObj);
        if (BossTowerAI.BossStage >= 3)
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
                            weapondmg = UnityEngine.Random.Range(0, 5);

                        }
                    }

                }
                DealDamage();
                    //hitOnce = true;
                }
            
        }



    }
    public void OnTriggerExit(Collider other)
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

                //sparks.gameObject.transform.SetParent()
                Destroy(sparks2, .4f);
            }
        
    }


    public void DealDamage()
    {
        characterAttackBonus = playerstats.attackBonus;
        if (!hitOnce)
        {
            currenthealth -= (weapondmg + characterAttackBonus);
            ChangeScale();
            hitOnce = true;
        }
    }
    public IEnumerator Explode()
    {
        if (!explosionstarted)
        {
            ChangeScale();
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

    public void GiveXP()
    {
        if (!xpGiven)
        {
            playerstats.playerXP = playerstats.playerXP + xpvalue;
            xpGiven = true;
        }
    }

    public void Death()
    {
        if (!GameObject.Find("TempAudio"))
        {
            music.enabled = true;
            //music.Play();
        }
        if (!isclipPlaying)
        {
            music.enabled = true;
        }
        GiveXP();
        StartCoroutine(Explode());
        bossBrain.BossIsDead();
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealth <= 1)
        {
            Death();
        }

        floatingPercentage = (float)healthPercentage;
        healthPercentage = (int)floatingPercentage;
        healthPercentage = (currenthealth * 100) / basehealth;
        newscale = originalscale * (floatingPercentage / 100f);





    }
}
