using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyobject4 : MonoBehaviour {

    public static bool gamekarted = false;
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


        if (!gamekarted)
        {
            //this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            gamekarted = true;
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }


        // Update is called once per frame

    }
}
