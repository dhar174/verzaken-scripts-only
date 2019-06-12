using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


public class BossBrainHealth : MonoBehaviour {

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
    public bool isclipPlaying;
    public GameObject indicator;

    public GameObject[] spheres;

    public bool xpGiven;

    public GameObject sparks;

    public GameObject deathsplosion;

    public bool hitOnce;

    public int xpvalue;

    public CharacterStats playerstats;

    public int characterAttackBonus;

    public int enemyStrength;


    private AudioSource audiosource;


    public SwitchWeapons scriptedSwitchWeapons;

    public int score;

    public static bool BossIsDead;
    public bool soundalreadyplaying;


    // Use this for initialization
    void Awake () {
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
        player = GameObject.Find("[VRTK]");
        //WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        hitOnce = false;

        indicator = GameObject.Find("FinalConsole").transform.Find("Indicator").gameObject;
        indicator.SetActive(false);

        audiosource = gameObject.GetComponent<AudioSource>();
        //scriptedSwitchWeapons = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();

        BossIsDead = false;
        basehealth = 10000;

        if (levelmultiplier == 0)
        {
            xpvalue = (basehealth / 10);
        }
        if (levelmultiplier >= 1)
        {
            xpvalue = (basehealth / 10) * levelmultiplier;
        }
        score = basehealth * 10;



        currenthealth = basehealth;
        music = GameObject.Find("Music").GetComponent<AudioSource>();

        

        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        characterAttackBonus = playerstats.attackBonus;
        xpGiven = false;
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
                        weapondmg = Random.Range(0, 25);

                    }
                }

            }
            DealDamage();
                //hitOnce = true;
           }
        



    }

    public IEnumerator ResetHit()
    {
        //this coroutine is intended to reset "hitOnce" if it takes too long for weapon to exit collider, to prevent weapon hits from being ineffective
        yield return new WaitForSecondsRealtime(2);
        hitOnce = false;
        StopCoroutine(ResetHit());
        yield return null;


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
            hitOnce = true;
            StartCoroutine(ResetHit());
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

    public void GiveXP()
    {
        if (!xpGiven)
        {
            playerstats.playerXP = playerstats.playerXP + xpvalue;
            playerstats.XPGain(xpvalue);
            xpGiven = true;
        }
    }
    public IEnumerator waitasec()
    {
        yield return new WaitForSecondsRealtime(6);
        playerstats.XPStop();
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
        gameObject.transform.GetComponentInChildren<RotateTowardPlayer>().enabled = false;
        foreach(GameObject sp in spheres)
        {
            sp.GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
        }
        StartCoroutine(Explode());
        indicator.SetActive(true);
    }







        // Update is called once per frame
        void Update () {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 20)
        {
            if (!soundalreadyplaying)
            {
                audiosource.Play();
               // print("boss sound playing");
                soundalreadyplaying = true;
            }
        }
        if (currenthealth <= 1)
        {
            if (!BossIsDead)
            {
                Death();
                BossIsDead = true;
            }
        }

        

       // weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        //weapondmg = weaponstats.WeaponStrength;

    }
}
