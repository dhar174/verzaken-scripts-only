using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour {

    public int WeaponStrength;
    public int weaponType;
    public int matInt;


	// Use this for initialization
	void OnEnable () {
        if (WeaponStrength == 0)
        {
            WeaponStrength = 10;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
