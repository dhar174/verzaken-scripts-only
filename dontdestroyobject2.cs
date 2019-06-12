using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyobject2 : MonoBehaviour
{

    public static bool gametarted = false;
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


        if (!gametarted)
        {
            //this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            gametarted = true;
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }


        // Update is called once per frame

    }
}
