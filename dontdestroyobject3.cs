using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyobject3 : MonoBehaviour {
    public static bool gamesharted = false;
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


        if (!gamesharted)
        {
            //this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            gamesharted = true;
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }


        // Update is called once per frame

    }

    // Update is called once per frame
    void Update () {
		
	}
}
