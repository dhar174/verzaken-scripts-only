using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
//using System;

public class HealthAndDamage : MonoBehaviour {

    public int basehealth;
    public int currenthealth;
    public GameObject player;
    public  GameObject WeaponContainer;
    //public WeaponStats weaponstats;
    public int weapondmg;
   // public GameObject CurrentPlayerWeapon;
    public int levelmultiplier;
    private bool explosionstarted;
    public AudioSource music;
    public BasicAI basicAI;
    public bool isclipPlaying;
    public bool scoregiven;
    public float flashwait;

    private Renderer[] rend;

    private bool flashing;

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
    public int dropbuff;
    private bool buffisdropped;

    public  int healthPercentage;
    public float floatingPercentage;

    public SwitchWeapons scriptedSwitchWeapons;

    public int score;

    public AudioClip explodeClip;

    public AudioClip ding;
    public AudioSource sound;
    public bool nowdead;
	// Use this for initialization
	void Start () {
        spriteRect = gameObject.GetComponentInChildren<RectTransform>();
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
        player = GameObject.FindGameObjectWithTag("Player");
        WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        hitOnce = false;
        sound = gameObject.GetComponent<AudioSource>();
        
        //scriptedSwitchWeapons = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //CurrentPlayerWeapon = scriptedSwitchWeapons.weaponZero;
        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        if (flashwait == 0)
        {
            flashwait = .1f;
        }

        if (levelmultiplier < 1)
        {
            basehealth = UnityEngine.Random.Range(50, 150);
        }
        if (levelmultiplier >= 1)
        {
            basehealth = UnityEngine.Random.Range(50, 150) * levelmultiplier;
        }
        
        if(levelmultiplier == 0)
        {
            xpvalue = (basehealth / 10);
        }
        if (levelmultiplier >= 1)
        {
            xpvalue = (basehealth / 10) * levelmultiplier;
        }
        score = basehealth * 10;

       dropbuff = Random.Range(1, 101);

        if (gameObject.CompareTag("FloatingEyebot"))
        {
            basehealth = Random.Range(25, 75) * levelmultiplier;
        }
        currenthealth = basehealth;
        music = GameObject.Find("Music").GetComponent<AudioSource>();

        if (!gameObject.CompareTag("SpinBoss"))
        {
            basicAI = gameObject.GetComponentInChildren<BasicAI>();

            isclipPlaying = basicAI.clipPlaying;
        }
       
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        characterAttackBonus = playerstats.attackBonus;
        xpGiven = false;
        
        //scaledone = false;
        healthHolder = this.gameObject.transform.Find("HealthHolder").GetComponent<Transform>();
        originalscale = healthHolder.localScale.x;


    }
   

   

   
    


    public void OnTriggerEnter(Collider other)
    {
        //GameObject otherObj = other.gameObject;
        //Debug.Log("Triggered with: " + otherObj);

            if (other.gameObject.CompareTag("CanGrab") || other.gameObject.CompareTag("Rock"))
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
            if (weaponstats != null)
            {
                DealDamage(weaponstats, weapondmg);
            }
                //hitOnce = true;
            }
            else
            {
                if (other.gameObject.CompareTag("Hammer"))
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
                    DealDamage(weaponstats, weapondmg);
                }
                  else
                  {
                    if (other.gameObject.CompareTag("Sickle"))
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
                    DealDamage(weaponstats, weapondmg);
                    }

                  }
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
        if (other.gameObject.tag == "CurrentWeapon" || other.gameObject.tag == "CanGrab" || other.gameObject.tag == "Hammer" || other.gameObject.tag == "Sickle" || other.gameObject.tag == "Rock")
        {
            
            hitOnce = false;
            //scaledone = false;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.tag == "CurrentWeapon" || collision.gameObject.tag == "CanGrab" || collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Sickle")
            {
                sound.PlayOneShot(ding);
                //sparks = (GameObject)GameObject.Instantiate(Resources.Load("sparks", typeof(GameObject)));
                ContactPoint contact = collision.contacts[0];
                Quaternion sparkrot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 sparkpos = contact.point;
            //GameObject sparks2 = Instantiate(sparks, sparkpos, sparkrot) as GameObject;
            GameObject.Find("SparkManager").GetComponent<SparksManager>().GiveSparks(contact, sparkrot, sparkpos);
            //sparks.gameObject.transform.SetParent()
            //Destroy(sparks2, .4f);
             // StartCoroutine(GameObject.Find("SparkManager").GetComponent<SparksManager>().ReturnSparks());
            }
        else
        {
            if(collision.gameObject.tag == "Rock")
            {
                if (collision.gameObject.GetComponent<WeaponStats>())
                {
                    sound.PlayOneShot(ding);
                    //sparks = (GameObject)GameObject.Instantiate(Resources.Load("sparks", typeof(GameObject)));
                    ContactPoint contact = collision.contacts[0];
                    Quaternion sparkrot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                    Vector3 sparkpos = contact.point;
                    GameObject sparks2 = Instantiate(sparks, sparkpos, sparkrot) as GameObject;

                    //sparks.gameObject.transform.SetParent()
                    Destroy(sparks2, .4f);
                }
                
            }
        }
        
    }


    public void DealDamage(WeaponStats stats, int dmg)
    {
        characterAttackBonus = playerstats.attackBonus;
        if (!hitOnce)
        {
            
            StartCoroutine(DamageFlash());
            currenthealth -= (weapondmg+characterAttackBonus);
            //ChangeScale();
            hitOnce = true;
            StartCoroutine(ResetHit());
        }
    }

    public IEnumerator DamageFlash()
    {
        flashing = true;
        StartCoroutine(Flash());
        yield return new WaitForSeconds(.5f);
        flashing = false;
        yield return null;
    }

    public IEnumerator Flash()
    {
        rend = gameObject.GetComponentsInChildren<Renderer>();
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


                Color finalColor = originalColor * Mathf.LinearToGammaSpace(0);
                mat.SetColor("_EmissionColor", finalColor);
                mat.color = Color.white;
                rendererIndex++;


            }
            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
            rendererIndex = 0;
            yield return new WaitForSeconds(flashwait);
        }
    }


        public IEnumerator Explode()
        {
          if (!explosionstarted)
           {
            //ChangeScale();

            //GameObject deathanimation = Instantiate(deathsplosion, transform.position + transform.up, gameObject.transform.rotation) as GameObject;
            SplosionManager.GiveSplosion(transform.position);
            yield return new WaitForSeconds(.1f);
            SplosionManager.Blowsplosion();
            //deathanimation.transform.parent = null;
            explosionstarted = true;
            //StartCoroutine(GameObject.Find("Deathsplosions").GetComponent<SplosionManager>().ReturnSplosion());
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
            playerstats.playerXP +=  xpvalue;
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
        if (gameObject.CompareTag("SpinBoss"))
        {
            if (TriggerOnBossDefeat.boss1dead)
            {
                TriggerOnBossDefeat.boss2dead = true;
            }
            else
            {
                TriggerOnBossDefeat.boss1dead = true;

            }
        }
        if (gameObject.CompareTag("GuardBot"))
        {
            if (gameObject.GetComponent<DropSnorkel>())
            {
                gameObject.GetComponent<DropSnorkel>().DropSnork();
            }
        }
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
        sound.Stop();
        sound.clip = explodeClip;
        sound.Play();
        StartCoroutine(Explode());
        if(GameModeScript.GameMode == 0)
        {
            if (!scoregiven)
            {
                player.GetComponent<CharacterStats>().totalscore = player.GetComponent<CharacterStats>().totalscore + score;
                scoregiven = true;
            }
            if (!buffisdropped)
            {
                if (levelmultiplier < 10)
                {
                    if (dropbuff > 45)
                    {
                        if (dropbuff <= 89)
                        {
                            GameObject newBuff = Instantiate(Resources.Load("HealthPickup", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                            buffisdropped = true;
                        }
                    }
                    if (dropbuff > 89)
                    {
                        if (dropbuff < 92)
                        {
                            GameObject newBuff = Instantiate(Resources.Load("StrengthBuff", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                            buffisdropped = true;

                        }


                    }
                    if (dropbuff >= 92)
                    {
                        if (dropbuff <= 98)
                        {
                            GameObject newBuff = Instantiate(Resources.Load("MaxHealthPickup", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                            buffisdropped = true;

                        }
                    }
                    if (dropbuff > 98)
                    {
                        GameObject newBuff = Instantiate(Resources.Load("SpeedBuff", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                        buffisdropped = true;


                    }
                }
                if (levelmultiplier >= 10)
                {
                    if (levelmultiplier < 20)
                    {

                        if (dropbuff > 65)
                        {
                            if (dropbuff <= 89)
                            {
                                GameObject newBuff = Instantiate(Resources.Load("HealthPickup", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                                buffisdropped = true;


                            }
                        }
                        if (dropbuff == 91)
                        {


                            GameObject newBuff = Instantiate(Resources.Load("StrengthBuff", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                            buffisdropped = true;




                        }
                        if (dropbuff >= 92)
                        {
                            if (dropbuff <= 98)
                            {
                                GameObject newBuff = Instantiate(Resources.Load("MaxHealthPickup", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                                buffisdropped = true;

                            }
                        }
                        if (dropbuff == 99)
                        {
                            GameObject newBuff = Instantiate(Resources.Load("SpeedBuff", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                            buffisdropped = true;


                        }
                    }
                    if (levelmultiplier >= 20)
                    {
                        if (dropbuff > 75)
                        {
                            if (dropbuff <= 89)
                            {
                                GameObject newBuff = Instantiate(Resources.Load("HealthPickup", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                                buffisdropped = true;


                            }
                        }
                        if (dropbuff == 91)
                        {


                            GameObject newBuff = Instantiate(Resources.Load("StrengthBuff", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                            buffisdropped = true;




                        }
                        if (dropbuff >= 94)
                        {
                            if (dropbuff <= 98)
                            {
                                GameObject newBuff = Instantiate(Resources.Load("MaxHealthPickup", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                                buffisdropped = true;

                            }
                        }
                        if (dropbuff == 99)
                        {
                            GameObject newBuff = Instantiate(Resources.Load("SpeedBuff", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                            buffisdropped = true;


                        }
                    }
                }
            }
        }
        if (GameModeScript.GameMode == 1)
        {
            if (!buffisdropped)
            {
                if(dropbuff >= 79)
                {
                    GameObject newBuff = Instantiate(Resources.Load("HealthPickup", typeof(GameObject)), transform.position + transform.up, gameObject.transform.rotation) as GameObject;
                    buffisdropped = true;
                }
            }
        }
            Destroy(gameObject, .5f);
    }

    // Update is called once per frame
    void Update () {
		if(currenthealth <= 1)
        {
            if (!nowdead)
            {
                Death();
                nowdead = true;
            }
        }

        

        
        
        //weaponstats = CurrentPlayerWeapon.GetComponent<WeaponStats>();
        //weapondmg = weaponstats.WeaponStrength;


        


        


    }
}
