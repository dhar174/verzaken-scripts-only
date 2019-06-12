using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class LevelProgression : MonoBehaviour {
    public static int MasterLevelMultiplier;
    public SwitchWeapons scriptofSwitchWeapons;
    public GameObject weaponContainer1;
    public GameObject weaponScreen;
    public WeaponInventory weaponinventoryScript;
    public int levelmultipliercheck;

    public static bool pixelationOff;

    public Pause pausescript;

    public static bool diedNOTportal;
    public GameObject levelUpScreen;

    public GameObject player;

    public static bool diagHasRun;
    public PopupManager popup;
    public GameObject popdiag;

    // Use this for initialization
    public void Awake()
    {
        

        if (!diedNOTportal)
        {
            MasterLevelMultiplier++;
            Debug.Log("Added to Level Multiplier");
            Debug.Log("Current Island is " + MasterLevelMultiplier);
            Debug.Log("Script ID is " + gameObject.GetInstanceID());

        }
    }


    void Start () {
        popup = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
        popdiag = GameObject.FindGameObjectWithTag("PopupDiag");

        pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

        weaponContainer1 = GameObject.FindGameObjectWithTag("WeaponContainer");
        //scriptofSwitchWeapons = weaponContainer1.GetComponent<SwitchWeapons>();
        //scriptofSwitchWeapons.Persistence();
        //weaponScreen = GameObject.FindGameObjectWithTag("WeaponScreen");
        // weaponinventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponInventory>();
        //weaponinventoryScript.wScreenActive = false;
        //weaponScreen.SetActive(false);
        //scriptofSwitchWeapons.Persistence();
        //scriptofSwitchWeapons.PutAwayPickaxe();
        if (!levelUpScreen)
        {
            levelUpScreen = GameObject.Find("LevelUpScreen");
        }
        levelUpScreen.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        
        if(GameModeScript.GameMode == 1)
        {

        }
        if (pixelationOff)
        {
           
            
        }
        if (diedNOTportal)
        {
            diedNOTportal = false;
        }
        //StartCoroutine(seconddialogue());
        GameObject.FindGameObjectWithTag("Music").GetComponent<RandomMusic>().PlayMusic();

        //Debug.Log("LevelProgression working" + gameObject.name);
        if(GameObject.FindGameObjectWithTag("Player").transform.Find("Controller (left)").GetComponent<ViveController>().holdingObject)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Find("Controller (left)").gameObject.GetComponent<FixControllerModel>().FixModel();
        }
        if (!GameObject.FindGameObjectWithTag("Player").transform.Find("Controller (right)").GetComponent<ViveController>().holdingObject)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Find("Controller (right)").gameObject.GetComponent<FixControllerModel>().FixModel();
        }
    }

    public IEnumerator seconddialogue()
    {
        if (!popup)
        {
            popup = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
        }
        
        //GameObject.FindGameObjectWithTag("PopupDiag").transform.Find("ContinueButton").GetComponent<Button>().onClick.AddListener(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().deactivateBox);
        //yield return new WaitForSeconds(.4f);
        if (MasterLevelMultiplier == 2)
        {
            print("SecondDiagTried");
            while (!diagHasRun)
            {
                

                if (!popdiag)
                {
                    popdiag = GameObject.FindGameObjectWithTag("PopupDiag");
                }
                //popdiag.SetActive(true);
                //GameObject.FindGameObjectWithTag("Player").GetComponent
                if (!PopupManager.showedLoading)
                {
                    seconddialogue();
                    print("SecondDiagFailed,try again");
                    diagHasRun = false;
                    yield return null;
                }
                else
                {
                    popup.secondlevel();
                    print("SecondDiag Initiated");
                    diagHasRun = true;
                    StopCoroutine(seconddialogue());
                    //yield return null;
                }
                yield return null;
                //Debug.Log("Pooped");
                //PopupManager.secondlevelpopup = true;
            }
            
        }
    }
	
    public void LvlUpScreenActivate()
    {
        levelUpScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(null);
        ItemInventory.unavailable = true;
        TimeStop.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();

        pausescript.MenuOn();
        //GameObject.FindGameObjectWithTag("Player").transform.Find("Controller (right)").GetComponent<SwitchToMenuController>().MenuMode();

    }
    public void LvlUpScreenOff()
    {
        pausescript.MenuOff();
        levelUpScreen.SetActive(false);
        ItemInventory.unavailable = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        player.GetComponent<FirstPersonController>().enabled = true;
        TimeStop.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        //GameObject.FindGameObjectWithTag("Player").transform.Find("Controller (right)").GetComponent<SwitchToMenuController>().GameMode();


    }

    // Update is called once per frame
    void Update () {
        levelmultipliercheck = MasterLevelMultiplier;
	}
}
