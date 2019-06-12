using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchWeapons : MonoBehaviour {

    public GameObject[] weapons;
    public keepWeapon keepweaponScript;
    public NextIsland nextislandScript;
    public static WeaponInventory weaponinventoryScript;

    //public GameObject weapon1;
    //public GameObject weapon2;

    public GameObject newWeaponPickup;
    public ReplaceWeapon replaceWeaponScript;

    public List<GameObject> weaponsList = new List<GameObject>();

    public int count;
    
    //public GameObject[] availableWeapons;
    public List<GameObject> availableweapons = new List<GameObject>();

    public Renderer[] rend0;
    public Renderer[] rend1;
    public Renderer[] rendp;

    public Collider[] coll1;
    public Collider[] coll0;

    public static bool weaponZeroActive;
    public static bool weaponOneActive;
    public static bool pickaxeActive;

    public bool weaponZeroActivecheck;
    public bool weaponOneActivecheck;
    public bool pickaxeActivecheck;

    public GameObject weaponZero;
    public GameObject weaponOne;
    public GameObject pickaxe;

    public GameObject weaponScreen;

    public GameObject test;

    public int buttonCounter;

    public bool fixSlot1;
    public bool levelrestartFlipped = false;


    // Use this for initialization
    void Start() {

        weaponinventoryScript = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<WeaponInventory>();

        weapons = new GameObject[2];
        //weapons[0] = gameObject.transform.GetChild(0).gameObject;
        //weapons[1] = gameObject.transform.GetChild(1).gameObject;

        weaponZero = gameObject.transform.GetChild(0).gameObject;
        weaponOne = gameObject.transform.GetChild(1).gameObject;
        pickaxe = GameObject.Find("pickaxe");



        //replaceWeaponScript = 

        //   count = 0;
        //   foreach (Transform i in gameObject.transform)
        //   {

        //       count++;

        //   }
        //   weapons = new GameObject[count];
        //   count = 0;
        //   foreach (Transform i in gameObject.transform)
        //   {
        //       weaponsList.Add(i.gameObject);
        //       weapons[count] = i.gameObject;
        //       count++;
        //   }



        //   count = 0;
        //   foreach (GameObject i in weapons)
        //   {

        //           count++;

        //       if(count > 2)
        //       {
        //           count = 2;
        //       }
        //   }
        //   availableWeapons = new GameObject[count];
        //   count = 0;
        //   foreach (GameObject i in weapons)
        //   {
        //       availableWeapons[count] = i.gameObject;
        //      count++;
        //  }



        //weapons[1].SetActive(false);
        rend1 = weaponOne.GetComponentsInChildren<Renderer>();
        foreach (Renderer obj in rend1)
        {
            obj.enabled = false;
        }
        //weapons[1].GetComponentsInChildren<Renderer>().enabled = false;
        weaponOne.GetComponent<Collider>().enabled = false;
        weaponOne.GetComponent<Animator>().enabled = false;
        weaponZeroActive = true;
        weaponOneActive = false;

        fixSlot1 = false;
        SwitchToPickaxe();
    }
   


    public void PutAwayPickaxe()
    {
        pickaxeActive = false;
        rendp = pickaxe.GetComponentsInChildren<Renderer>();
        foreach (Renderer obj in rendp)
        {
            obj.enabled = false;
        }
        //weapons[0].GetComponent<Renderer>().enabled = false;
        //pickaxe.GetComponent<Collider>().enabled = false;
       // pickaxe.GetComponent<Animator>().enabled = false;
        Debug.Log("Pickaxe put away");
        
    }
    

    public void ChangeWeapon()
    {
        weaponOne = gameObject.transform.GetChild(1).gameObject;
    }

    public void Persistence()
    {
        weaponinventoryScript.OpenScreen();
        weaponinventoryScript.CloseScreen();
        weaponScreen = GameObject.FindGameObjectWithTag("WeaponScreen");
        //weaponinventoryScript.wScreenActive = false;
        //weaponScreen.SetActive(false);
        NextIsland.levelRestarted = false;
        levelrestartFlipped = true;
        if (!pickaxeActive)
        {
            //SwitchToPickaxe();
            //PutAwayPickaxe();
            StartCoroutine(Fixpickaxe());
            //weaponZeroActive = true;
        }
    }

    public IEnumerator Fixpickaxe()
    {

        yield return new WaitForSeconds(.1f);
        weaponZeroActive = true;
        PutAwayPickaxe();
        yield return null;
    }

    public void SwitchMainWeapons()
    {
        if (pickaxeActive)
        {
            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponOne.transform.SetSiblingIndex(1);
            //weapons[1].SetActive(false);
            rendp = pickaxe.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rendp)
            {
                obj.enabled = false;
            }
            //weapons[1].GetComponentsInChildren<Renderer>().enabled = false;
            pickaxe.GetComponent<Collider>().enabled = false;
            pickaxe.GetComponent<Animator>().enabled = false;
            //weaponZero = gameObject.transform.GetChild(0).gameObject;
            //weaponOne = gameObject.transform.GetChild(1).gameObject;
            //weaponOneActive = false;
            //weaponZeroActive = true;

            pickaxeActive = false;

            rend0 = weaponZero.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend0)
            {
                obj.enabled = true;
            }


            weaponZero.GetComponent<Collider>().enabled = true;
            weaponZero.GetComponent<Animator>().enabled = true;

            weaponZero.transform.SetAsFirstSibling();

            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponZeroActive = true;
            weaponOneActive = false;
        }
        if (weaponZeroActive)
        {

            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            //weapons[0].SetActive(false);
            weaponZero.transform.SetSiblingIndex(1);
            rend0 = weaponZero.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend0)
            {
                obj.enabled = false;
            }
            //weapons[0].GetComponent<Renderer>().enabled = false;
            coll0 = weaponZero.GetComponentsInChildren<Collider>();

            foreach (Collider col in coll0)
            {
                col.enabled = false;
            }
            weaponZero.GetComponent<Animator>().enabled = false;
            //weaponZero = gameObject.transform.GetChild(0).gameObject;
            //weaponOne = gameObject.transform.GetChild(1).gameObject;
            //weaponZeroActive = false;
            //weaponOneActive = true;



            rend1 = weaponOne.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend1)
            {
                obj.enabled = true;
            }

            weaponOne.GetComponent<Collider>().enabled = true;
            weaponOne.GetComponent<Animator>().enabled = true;


            weaponOne.transform.SetAsFirstSibling();

            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponZeroActive = false;
            weaponOneActive = true;
            pickaxeActive = false;

        }
        //if (!weaponOneActive)
        //{
        //weapons[1].SetActive(true);

        //     rend1 = weaponOne.GetComponentsInChildren<Renderer>();
        //     foreach (Renderer obj in rend1)
        //     {
        //         obj.enabled = true;
        //     }
        //weapons[1].GetComponent<Renderer>().enabled = true;
        //      weaponOne.GetComponent<Collider>().enabled = true;
        //      weaponOne.GetComponent<Animator>().enabled = true;
        //      weaponOne.transform.SetAsFirstSibling();
        //      weaponZero = gameObject.transform.GetChild(0).gameObject;
        //      weaponOne = gameObject.transform.GetChild(1).gameObject;
        //      weaponOneActive = true;

        // }








        if (weaponOneActive)
        {

            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponOne.transform.SetSiblingIndex(1);
            //weapons[1].SetActive(false);
            rend1 = weaponOne.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend1)
            {
                obj.enabled = false;
            }
            //weapons[1].GetComponentsInChildren<Renderer>().enabled = false;
            coll1 = weaponOne.GetComponentsInChildren<Collider>();

            foreach (Collider col in coll1)
            {
                col.enabled = false;
            }
            weaponOne.GetComponent<Animator>().enabled = false;
            //weaponZero = gameObject.transform.GetChild(0).gameObject;
            //weaponOne = gameObject.transform.GetChild(1).gameObject;
            //weaponOneActive = false;
            //weaponZeroActive = true;


            rend0 = weaponZero.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend0)
            {
                obj.enabled = true;
            }


            weaponZero.GetComponent<Collider>().enabled = true;
            weaponZero.GetComponent<Animator>().enabled = true;

            weaponZero.transform.SetAsFirstSibling();

            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponZeroActive = true;
            weaponOneActive = false;
            pickaxeActive = false;
        }
        if (!weaponinventoryScript)
        {
            weaponinventoryScript = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<WeaponInventory>();

        }

        if (weaponinventoryScript)
        {
            if (weaponinventoryScript.wScreenActive)
            {

                weaponinventoryScript.CloseScreen();
                weaponinventoryScript.OpenScreen();
            }
        }
    }

    

    public void SwitchToPickaxe()
    {
        if (weaponZeroActive)
        {

            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;

            rend0 = weaponZero.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend0)
            {
                obj.enabled = false;
            }
            //weapons[0].GetComponent<Renderer>().enabled = false;
            coll0 = weaponZero.GetComponentsInChildren<Collider>();

            foreach (Collider col in coll0)
            {
                col.enabled = false;
            }
            weaponZero.GetComponent<Animator>().enabled = false;
            //weaponZero = gameObject.transform.GetChild(0).gameObject;
            //weaponOne = gameObject.transform.GetChild(1).gameObject;
            //weaponZeroActive = false;
            //weaponOneActive = true;



            rendp = pickaxe.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rendp)
            {
                obj.enabled = true;
            }

            pickaxe.GetComponent<Collider>().enabled = true;
            pickaxe.GetComponent<Animator>().enabled = true;




            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponZeroActive = false;
            weaponOneActive = false;
            pickaxeActive = true;

        }
        if (weaponOneActive)
        {

            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;

            rend1 = weaponOne.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend1)
            {
                obj.enabled = false;
            }
            //weapons[1].GetComponentsInChildren<Renderer>().enabled = false;
            coll1 = weaponOne.GetComponentsInChildren<Collider>();

            foreach (Collider col in coll1)
            {
                col.enabled = false;
            }
            weaponOne.GetComponent<Animator>().enabled = false;
            //weaponZero = gameObject.transform.GetChild(0).gameObject;
            //weaponOne = gameObject.transform.GetChild(1).gameObject;
            //weaponOneActive = false;
            //weaponZeroActive = true;


            rendp = pickaxe.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rendp)
            {
                obj.enabled = true;
            }


            pickaxe.GetComponent<Collider>().enabled = true;
            pickaxe.GetComponent<Animator>().enabled = true;


            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponZeroActive = false;
            weaponOneActive = false;
            pickaxeActive = true;

        }
        if (pickaxeActive)
        {
            //shouldnt happen, but need a contingency!

            rendp = pickaxe.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rendp)
            {
                obj.enabled = true;
            }


            pickaxe.GetComponent<Collider>().enabled = true;
            pickaxe.GetComponent<Animator>().enabled = true;



        }
        if(!weaponZeroActive && !pickaxeActive)  //shouldnt happen, but will fix problem if no bool is marked! Assumes WeaponZero is active.
        {
            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;

            rend0 = weaponZero.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rend0)
            {
                obj.enabled = false;
            }
            //weapons[0].GetComponent<Renderer>().enabled = false;
            coll0 = weaponZero.GetComponentsInChildren<Collider>();

            foreach (Collider col in coll0)
            {
                col.enabled = false;
            }
            weaponZero.GetComponent<Animator>().enabled = false;
            //weaponZero = gameObject.transform.GetChild(0).gameObject;
            //weaponOne = gameObject.transform.GetChild(1).gameObject;
            //weaponZeroActive = false;
            //weaponOneActive = true;



            rendp = pickaxe.GetComponentsInChildren<Renderer>();
            foreach (Renderer obj in rendp)
            {
                obj.enabled = true;
            }

            pickaxe.GetComponent<Collider>().enabled = true;
            pickaxe.GetComponent<Animator>().enabled = true;




            weaponZero = gameObject.transform.GetChild(0).gameObject;
            weaponOne = gameObject.transform.GetChild(1).gameObject;
            weaponZeroActive = false;
            weaponOneActive = false;
            pickaxeActive = true;
        }
    }

    public void FixedUpdate()
    {
        if (fixSlot1)
        {
            ChangeWeapon();
            fixSlot1 = false;
        }

    }

    public void Spawn()
    {
        Vector3 screenPoint = new Vector3(250, 250, 20);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
         GameObject obj = Instantiate(test, worldPos, Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Mine"))
        {
            buttonCounter = 0;
            SwitchToPickaxe();
        }

        if (Input.GetButtonUp("ChangeWeapon1"))
        {
            buttonCounter++;
            SwitchMainWeapons();
           // pickaxeActive = false;
            if (buttonCounter == 3)
            {
                weaponOneActive = false;
                weaponZeroActive = false;
                SwitchToPickaxe();
                buttonCounter = 0;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel")> 0)
        {
            buttonCounter++;

            SwitchMainWeapons();
           // pickaxeActive = false;

            if (buttonCounter == 3)
            {
                weaponOneActive = false;
                weaponZeroActive = false;
                SwitchToPickaxe();
                buttonCounter = 0;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            buttonCounter++;

            SwitchMainWeapons();
            //pickaxeActive = false;

            if (buttonCounter == 3)
            {
                weaponOneActive = false;
                weaponZeroActive = false;
                SwitchToPickaxe();
                buttonCounter = 0;
            }

        }
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //Spawn();
        //}
        if (NextIsland.levelRestarted)
        {
            
            if (!pickaxeActive)
            {
                weaponOneActive = false;
                weaponZeroActive = false;
                PutAwayPickaxe();
            }
            Persistence();
        }
        weaponOneActivecheck = weaponOneActive;
        weaponZeroActivecheck = weaponZeroActive;
        pickaxeActivecheck = pickaxeActive;


    }
}
