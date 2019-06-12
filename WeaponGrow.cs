using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrow : MonoBehaviour {
    private WeaponStats thisweaponstats;
    private int formerstat;
	// Use this for initialization
	void Start () {
        thisweaponstats = gameObject.GetComponent<WeaponStats>();
	}

    public void AddWeaponLevel()
    {
        formerstat = thisweaponstats.WeaponStrength;
        thisweaponstats.WeaponStrength = formerstat + (12 * LevelProgression.MasterLevelMultiplier);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
