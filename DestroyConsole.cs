using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class DestroyConsole : MonoBehaviour {

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

    public SecretDoorOpen secretDoor;

    public bool xpGiven;

    public GameObject sparks;

    public GameObject deathsplosion;

    public bool hitOnce;

    public int xpvalue;

    public CharacterStats playerstats;

    public int characterAttackBonus;

    

    public SwitchWeapons scriptedSwitchWeapons;


    // Use this for initialization
    void Start()
    {
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
        player = GameObject.FindGameObjectWithTag("Player");
        WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        hitOnce = false;

        //scriptedSwitchWeapons = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();

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
       
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        characterAttackBonus = playerstats.attackBonus;
        xpGiven = false;

        secretDoor = GameObject.FindGameObjectWithTag("SecretDoor").GetComponent<SecretDoorOpen>();


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

            //hitOnce = true;

            DealDamage();
            //hitOnce = true;
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
            hitOnce = true;
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
       
        GiveXP();
        StartCoroutine(Explode());

        secretDoor.OpenThePuzzDoor();
        Destroy(gameObject, .5f);
    }


    void Update()
    {
        if (currenthealth <= 1)
        {
            Death();
        }

       // if (scriptedSwitchWeapons.weaponZero != null)
       // {
          //  CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
        //}

        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        //w/eapondmg = weaponstats.WeaponStrength;

        





    }
}
