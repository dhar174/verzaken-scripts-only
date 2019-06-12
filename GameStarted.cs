using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarted : MonoBehaviour {
    public keepWeapon keepweaponScript;
    public SwitchWeapons switchweaponsScript;

	// Use this for initialization
	void Start () {
        keepweaponScript = GameObject.FindGameObjectWithTag("Player").GetComponent<keepWeapon>();
        switchweaponsScript = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //switchweaponsScript.Persistence();
        LevelProgression.MasterLevelMultiplier +=1;
        Debug.Log("GameStarted working" + gameObject.name);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
