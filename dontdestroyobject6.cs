using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyobject6 : MonoBehaviour {
    public static bool gameretarded = false;
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


        if (!gameretarded)
        {
            //this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            gameretarded = true;
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }


        // Update is called once per frame

    }
}
