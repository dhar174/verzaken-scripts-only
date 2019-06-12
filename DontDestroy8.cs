using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy8 : MonoBehaviour {

    public static bool creamsharted = false;
    //private static bool firstweaponexists = false;
    //private static bool secondweaponexists = false;
    //public GameObject WeaponContainer;
    //public GameObject firstweapon;
    //public GameObject secondweapon;



    // Use this for initialization
    void Awake()
    {
        //WeaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");

        DontDestroyOnLoad(this.gameObject);


        if (!creamsharted)
        {
            //this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            creamsharted = true;
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }



    }
}
