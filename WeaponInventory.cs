using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventory : MonoBehaviour {

    public GameObject weapon1;
    public GameObject weapon2;

    public GameObject weapon1clonereference;
    public GameObject weapon2clonereference;

    public GameObject weaponContainer;
    public SwitchWeapons switchweaponScripts;
    public GameObject weaponScreen;

    public Transform holdster1;
    public Transform holdster2;
    

    public bool wScreenActive = false;


    public WeaponStats weaponstats1;
    public WeaponStats weaponstats2;

    public int weapon1AP;
    public int weapon2AP;

    public Text weapon1APtext;
    public Text weapon2APtext;
    public Canvas canvas2;

    public Pause pauseScript;

    public static bool unavailable;


	// Use this for initialization
	void Start () {
        pauseScript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();
        weaponScreen = GameObject.FindGameObjectWithTag("WeaponScreen");
        weapon1APtext = GameObject.FindGameObjectWithTag("WeaponText1").GetComponent<Text>();
        weapon2APtext = GameObject.FindGameObjectWithTag("WeaponText2").GetComponent<Text>();

        canvas2 = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<Canvas>();

        weaponContainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        
        switchweaponScripts = weaponContainer.GetComponent<SwitchWeapons>();
        

        holdster1 = GameObject.FindGameObjectWithTag("holdster1").GetComponent<Transform>();
        holdster2 = GameObject.FindGameObjectWithTag("holdster2").GetComponent<Transform>();

        // weapon1 = switchweaponScripts.weaponZero;
        // weapon2 = switchweaponScripts.weaponOne;

        weapon1 = switchweaponScripts.weaponZero;
        weapon2 = switchweaponScripts.weaponOne;
        weaponstats1 = weapon1.GetComponent<WeaponStats>();
        weaponstats2 = weapon2.GetComponent<WeaponStats>();
        weapon1AP = weaponstats1.WeaponStrength;
        weapon2AP = weaponstats2.WeaponStrength;
        weapon1APtext = GameObject.FindGameObjectWithTag("WeaponText1").GetComponent<Text>();
        weapon2APtext = GameObject.FindGameObjectWithTag("WeaponText2").GetComponent<Text>();

        if (!SwitchWeapons.pickaxeActive)
        {
            switchweaponScripts.PutAwayPickaxe();
        }

        //wScreenActive = false;
        weaponScreen.SetActive(false);
    }
	
    public void OpenScreen()
    {

        //weaponScreen = GameObject.FindGameObjectWithTag("WeaponScreen");
        //print("Open pressed");

        if (!weapon1APtext)
        {
            weapon1APtext = GameObject.FindGameObjectWithTag("WeaponText1").GetComponent<Text>();
        }

        if (!weapon2APtext)
        {
            weapon2APtext = GameObject.FindGameObjectWithTag("WeaponText2").GetComponent<Text>();
        }

        if (!weaponScreen)
        {
            weaponScreen = GameObject.FindGameObjectWithTag("WeaponScreen");
        }

        if (!holdster1)
        {
            holdster1 = GameObject.FindGameObjectWithTag("holdster1").GetComponent<Transform>();
        }
        if (!holdster2)
        {
            holdster2 = GameObject.FindGameObjectWithTag("holdster2").GetComponent<Transform>();
        }
        if (!canvas2)
        {
            canvas2 = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<Canvas>();
        }
        canvas2.renderMode = RenderMode.WorldSpace;
        canvas2.worldCamera = Camera.main;
        canvas2.renderMode = RenderMode.ScreenSpaceCamera;



        weapon1 = switchweaponScripts.weaponZero;
        weapon2 = switchweaponScripts.weaponOne;
        weaponstats1 = weapon1.GetComponent<WeaponStats>();
        weaponstats2 = weapon2.GetComponent<WeaponStats>();
        weapon1AP = weaponstats1.WeaponStrength;
        weapon2AP = weaponstats2.WeaponStrength;
        weaponScreen.SetActive(true);
        //holdster1 = GameObject.FindGameObjectWithTag("holdster1").GetComponent<Transform>();
        //holdster2 = GameObject.FindGameObjectWithTag("holdster2").GetComponent<Transform>();

        GameObject weapon1clone = Instantiate(weapon1, holdster1) as GameObject;


        if (weapon1.name == "spear(Clone)")
        {
            weapon1clone.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("spearinventory", typeof(RuntimeAnimatorController)));
            weapon1clone.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        if (weapon1.name == "lowpolysword(Clone)")
        {
            weapon1clone.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("inventorysword", typeof(RuntimeAnimatorController)));
            weapon1clone.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        if (weapon1.name == "lowpolymace(Clone)")
        {
            weapon1clone.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("inventorymace", typeof(RuntimeAnimatorController)));
            weapon1clone.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        if (weapon1.name == "lowpolyhammer(Clone)")
        {
            weapon1clone.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("hammerinventory", typeof(RuntimeAnimatorController)));
            weapon1clone.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        if (weapon1.name == "battleaxe(Clone)")
        {
            weapon1clone.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("battleaxeinventory", typeof(RuntimeAnimatorController)));
            weapon1clone.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        }
       

        GameObject weapon2clone = Instantiate(weapon2, holdster2) as GameObject;

        Renderer[] rendslot2;

            rendslot2 = weapon2clone.GetComponentsInChildren<Renderer>();
        foreach (Renderer obj in rendslot2)
        {
            obj.enabled = true;
        }

        weapon1clonereference = weapon1clone;
        weapon2clonereference = weapon2clone;

        if(weapon1.name != "spear(Clone)")
        {
            weapon1clone.transform.localScale = new Vector3(1500, 1500, 1500);
        }
        
        if (weapon2.name != "spear(Clone)")
        {
            weapon2clone.transform.localScale = new Vector3(1500, 1500, 1500);
        }

        if (weapon1.name == "spear(Clone)")
        {
            weapon1clone.transform.localScale = new Vector3(7, 7, 7);
        }

        if (weapon2.name == "spear(Clone)")
        {
            weapon2clone.transform.localScale = new Vector3(7, 7, 7);
        }

        if (weapon1.name == "battleaxe(Clone)")
        {
            weapon1clone.transform.localScale = new Vector3(20, 20, 20);
        }


        weapon1APtext.text = "Attack " +
            "Power:"  + weapon1AP;
            if (!wScreenActive)
            {
              wScreenActive = true;
            }

        weapon2APtext.text = "Attack " +
           "Power:" + weapon2AP;

        if (LanguageChange.LangNum == 1)
        {
            weapon1APtext.text = "攻击 " +
            "力量:" + weapon1AP;
            if (!wScreenActive)
            {
                wScreenActive = true;
            }

            weapon2APtext.text = "攻击 " +
               "力量:" + weapon2AP;
        }
        if (LanguageChange.LangNum == 2)
        {
            weapon1APtext.text = "Angriffsstärke" + weapon1AP;

            
            if (!wScreenActive)
            {
                wScreenActive = true;
            }

            weapon2APtext.text = "Angriffsstärke " + weapon2AP;

        }
        if (LanguageChange.LangNum == 3)
        {
            weapon1APtext.text = "Сила атаки " + weapon1AP;

            if (!wScreenActive)
            {
                wScreenActive = true;
            }

            weapon2APtext.text = "Сила атаки " + weapon1AP;
        }
        if (LanguageChange.LangNum == 4)
        {
            weapon1APtext.text = "Poder de ataque " + weapon1AP;
            if (!wScreenActive)
            {
                wScreenActive = true;
            }

            weapon2APtext.text = "Poder de ataque " + weapon1AP;
        }


        if (!wScreenActive)
        {
            wScreenActive = true;
        }
        pauseScript.MenuOn();

    }
    public void CloseScreen()
    {
       // print("Close pressed");
        weaponScreen.SetActive(false);
        wScreenActive = false;
        Destroy(weapon1clonereference);
        Destroy(weapon2clonereference);
        pauseScript.MenuOff();
    }

	// Update is called once per frame
	void Update () {

        //if (!wScreenActive)
        //{
            if (Input.GetButtonUp("WeaponScreen"))
            {

              if (!wScreenActive)
              {
                if (!unavailable)
                {
                    StartScreen.unavailable = true;
                    TimeStop.unavailable = true;
                    ItemInventory.unavailable = true;
                    OpenScreen();
                }
              }
              else
              {
                StartScreen.unavailable = false;
                TimeStop.unavailable = false;
                ItemInventory.unavailable = false;
                CloseScreen();
              }  
                
            }
        //}
        
        

    }
}
