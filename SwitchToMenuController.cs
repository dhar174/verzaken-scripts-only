using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class SwitchToMenuController : MonoBehaviour {
    public VRUIinput vrInput;
    public SteamVR_TrackedController svrTrackedController;
    public SteamVR_LaserPointer laserpointer;
    public ViveController viveController;
    public WeaponControlVR weaponControlVR;
    public SteamVR_TrackedObject svrTrackedObject;

    public ArmSwinger armswing;
    public bool switchedtoMenu;
    public bool switchedtoGame;

    public GameObject lvlUpScreen;
    public GameObject popup;

	// Use this for initialization
	void Awake () {
        if (!lvlUpScreen)
        {
            lvlUpScreen = GameObject.Find("LevelUpScreen");

        }
        if (!vrInput)
        {
            vrInput = gameObject.GetComponent<VRUIinput>();

        }
        if (svrTrackedController)
        {
            svrTrackedController = gameObject.GetComponent<SteamVR_TrackedController>();

        }
        
        laserpointer = gameObject.GetComponent<SteamVR_LaserPointer>();
        viveController = gameObject.GetComponent<ViveController>();
        weaponControlVR = gameObject.GetComponent<WeaponControlVR>();
        armswing = GameObject.FindGameObjectWithTag("Player").GetComponent<ArmSwinger>();
        svrTrackedObject = gameObject.GetComponent<SteamVR_TrackedObject>();
        switchedtoGame = true;
        popup = GameObject.FindGameObjectWithTag("PopupDiag");
    }

    public void MenuMode()
    {
        if (vrInput)
        {
            vrInput.enabled = true;
        }
        else
        {
            vrInput = gameObject.GetComponent<VRUIinput>();
            vrInput.enabled = true;
        }

        //svrTrackedController.enabled = true;
        laserpointer.enabled = true;

        //svrTrackedObject.enabled = false;
        armswing.enabled = false;
        viveController.enabled = false;
        weaponControlVR.enabled = false;
        

        switchedtoMenu = true;
        switchedtoGame = false;
        if (gameObject.transform.Find("New Game Object"))
        {
            gameObject.transform.Find("New Game Object").gameObject.SetActive(true);
            gameObject.transform.Find("New Game Object").gameObject.layer = 17;
        }

    }
    public void GameMode()
    {
        if (vrInput)
        {
            vrInput.enabled = false;

            //svrTrackedController.enabled = false;
            laserpointer.enabled = false;

            svrTrackedObject.enabled = true;
            armswing.enabled = true;
            viveController.enabled = true;
            weaponControlVR.enabled = true;
        }

        switchedtoMenu = false;
        switchedtoGame = true;

        if (gameObject.transform.Find("New Game Object"))
        {
            gameObject.transform.Find("New Game Object").gameObject.SetActive(false);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Canvas2").GetComponent<StartScreen>().startScreenActive )
        {
            if (!switchedtoMenu)
            {
                MenuMode();
            }
        }
        else
        {
            if (!GameObject.FindGameObjectWithTag("Canvas2").GetComponent<StartScreen>().startScreenActive && !GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().lvlUpScreenActive)
            {
                if (!switchedtoGame)
                {
                    GameMode();
                }
            }
        }
        
	}
}
