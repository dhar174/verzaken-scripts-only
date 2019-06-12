using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;
using VRTK;


public class NextIsland : MonoBehaviour {

    public CharacterStats cstats;
    public static bool levelRestarted;
    public bool islevelrestarted;

    public SwitchWeapons switchweaponsScript;
    public GameObject loadscreen;
    public GameObject popup;

	// Use this for initialization
	void Start () {
       // switchweaponsScript = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        islevelrestarted = levelRestarted;
        cstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");
        popup = GameObject.FindGameObjectWithTag("PopupDiag");
        //loadscreen.SetActive(true);
        
            GameObject.Find("Canvas2").GetComponent<LoadingScreen>().ReactivateLoadScreen();
        
        if(SceneManager.GetActiveScene().name == "smallcave2")
        {
            GameObject.Find("RedDoorSecretPanel").GetComponent<RedDoorManager>().ActivateRed();
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");
            popup = GameObject.FindGameObjectWithTag("PopupDiag");
            //print("portal collider hit");
            levelRestarted = true;
            islevelrestarted = levelRestarted;
            
            if (GameModeScript.GameMode == 1)
            {
                // This is commented out TEMPORARILY for VR version- must change cstats.Save to make it work with the new system
                //cstats.Save();
            }

            if (LevelProgression.MasterLevelMultiplier == 2)
            {
                //loadscreen.gameObject.SetActive(true);
                //popup.gameObject.SetActive(true);
            }
            //VRTK_SDKManager.instance.enabled = false;
            GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = false;
            SteamVR_LoadLevel.Begin("testscene");

            //SceneManager.LoadScene("testscene");
           
        }
    }


    
}
