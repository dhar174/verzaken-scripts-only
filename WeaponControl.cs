using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class WeaponControl : MonoBehaviour {

    private  Animator anim;
    //private  Animation animation;
    public Material[] weaponmats;
    public Renderer weaponrend;

    //public Renderer[] weaponrends;
    private int weaponrendIndex;
    public int rcount;

    public GameObject weapon;
    public int count;
    public GameObject[] weaponparts;

    private int materialIndex;
    private int weaponpartIndex;

    public GameObject sparks;

    public static bool swingingWeapon;
    public bool swinginWeaponDebug;
    public AudioSource sound;
    public AudioClip woosh;
    public bool waitforsound;


    private int _playerAttackStateHash = Animator.StringToHash("Base Layer.sword1attack1");

    // Use this for initialization
    void Start () {
        swingingWeapon = false;
        swinginWeaponDebug = swingingWeapon;
        //animation = gameObject.GetComponent<Animation>();
        materialIndex = 0;
        weaponrend = gameObject.GetComponent<Renderer>();
        weapon = gameObject;
        anim = weapon.GetComponent<Animator>();
        if (!weaponrend)
        {
            weaponrend = weapon.GetComponentInChildren<Renderer>();
        }

        sound = gameObject.GetComponent<AudioSource>();
        if (woosh != null)
        {
            sound.clip = woosh;
        }

        count = 0;
        foreach (Transform i in weapon.transform)
        {
            count++;
        }
        weaponparts = new GameObject[count];
        count = 0;
        foreach (Transform i in weapon.transform)
        {
            weaponparts[count] = i.gameObject;
            count++;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

     //       Debug.Log("Boom");
            //sparks = (GameObject)GameObject.Instantiate(Resources.Load("sparks", typeof(GameObject)));
     //       ContactPoint contact = collision.contacts[0];
     //       Quaternion sparkrot = Quaternion.FromToRotation(Vector3.up, contact.normal);
     //       Vector3 sparkpos = contact.point;
     //   GameObject sparks2 = Instantiate(sparks, sparkpos, sparkrot) as GameObject;

     //   Destroy(sparks,.1f);
        
    }
    public void SetBool()
    {
        if (swingingWeapon)
        {
            swingingWeapon = false;
        }
        if (!swingingWeapon)
        {
            swingingWeapon = true;
        }


    }



    public void SwingSword()
    {

        anim.SetTrigger("PlayAttack1");
        if (!waitforsound)
        {
            sound.Play();
            waitforsound = true;
            StartCoroutine(waittoplay());
            StopCoroutine(waittoplay());
        }
        StartCoroutine(Attacking());
      

    }
    public IEnumerator waittoplay()
    {
        yield return new WaitForSecondsRealtime(1);
        waitforsound = false;
    }


    private IEnumerator Attacking()
    {
        swingingWeapon = true;
        yield return new WaitForSeconds(.5f);
        if (Input.GetAxisRaw("Attack1") > 0)
        {
            swingingWeapon = true;
            yield return new WaitForSeconds(.7f);
            StartCoroutine(Attacking());
        }
        swingingWeapon = false;
        StopCoroutine(Attacking());
    }

    

   

    // Update is called once per frame
    void Update()
    {


       

        swinginWeaponDebug = swingingWeapon;
        if (Input.GetAxisRaw ("Attack1") > 0 )
        {
            //Debug.Log("Swung Weapon");
            SwingSword();
            //anim.SetTrigger("PlayAttack1");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            SwingSword();
            //anim.SetTrigger("PlayAttack1");
        }
        //if (Input.GetKeyUp(KeyCode.K))
      //  {
      //      materialIndex += 1;
      //      weaponrend.material = weaponmats[materialIndex];

            //for (int i = 0; i < weaponparts.Length; i++)
            //{
            //    weaponparts[i].GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex", yourNewTexture);
            //}



     //   }
     //   if (Input.GetKeyUp(KeyCode.J))
    //    {
     //       materialIndex -= 1;
     //       weaponrend.material = weaponmats[materialIndex];




     //   }
        
    }
}
