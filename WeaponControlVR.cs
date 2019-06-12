using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControlVR : MonoBehaviour {
    public GameObject weapon;

    public static bool swingingWeapon;
    public bool swinginWeaponDebug;
    public AudioSource sound;
    public AudioClip woosh;
    public bool waitforsound;

    // Use this for initialization
    void Start () {
        swingingWeapon = false;
        swinginWeaponDebug = swingingWeapon;
        weapon = gameObject;
        sound = gameObject.GetComponent<AudioSource>();
        if (woosh != null)
        {
            sound.clip = woosh;
        }
    }

   

    public void SwingSword()
    {

        if (!waitforsound)
        {
            sound.Play();
            waitforsound = true;
            StartCoroutine(waittoplay());
            StopCoroutine(waittoplay());
        }
        //StartCoroutine(Attacking());


    }
    public IEnumerator waittoplay()
    {
        yield return new WaitForSecondsRealtime(1);
        waitforsound = false;
    }


    

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            SwingSword();
        }
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}
