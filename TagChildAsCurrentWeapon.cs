using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChildAsCurrentWeapon : MonoBehaviour {

    public GameObject playerweaponstart;
    public GameObject weaponupdate;
	// Use this for initialization
	void Start () {
        //playerweapon = gameObject.transform.GetChild(0);
        playerweaponstart =  this.gameObject.transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        weaponupdate = this.gameObject.transform.GetChild(0).gameObject;
        if (weaponupdate == playerweaponstart){
            weaponupdate.tag = "CurrentWeapon";
        }
        if(weaponupdate != playerweaponstart)
        {
            //playerweaponstart.tag = "Untagged";
            playerweaponstart = weaponupdate;
            weaponupdate.tag = "CurrentWeapon";
            
        }
        if (!playerweaponstart)
        {
            playerweaponstart = weaponupdate;
            weaponupdate.tag = "CurrentWeapon";
        }



    }
}
