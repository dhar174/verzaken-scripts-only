using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour {
    public Pause pauseScript;
    public bool startScreenActive = false;
    public GameObject startScreen;
    public Canvas canvas2;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;
    public Text PauseText;

    public static bool unavailable;

    public GameObject itemScreen;
    public ItemInventory itemScript;

    // Use this for initialization
    void Start () {
        pauseScript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();
        itemScreen = gameObject.transform.Find("ItemScreen").gameObject;
        itemScript = gameObject.GetComponent<ItemInventory>();
        startScreen = GameObject.Find("StartScreen");
        PauseText = GameObject.Find("PauseText").GetComponent<Text>();
        canvas2 = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<Canvas>();
        startScreen.SetActive(false);
        
    }

    void OpenStart()
    {

       // print("Bob's your uncle");
        if (startScreen==null)
        {
            startScreen = GameObject.FindGameObjectWithTag("StartScreen");
        }
        if (canvas2==null)
        {
            canvas2 = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<Canvas>();
        }
       // canvas2.renderMode = RenderMode.WorldSpace;
        //canvas2.worldCamera = Camera.main;
        //canvas2.renderMode = RenderMode.ScreenSpaceCamera;
        startScreen.SetActive(true);
        if (!startScreenActive)
        {
            startScreenActive = true;
        }
        //fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        //fpscontroller.enabled = false;
        //GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ResumeGameButton"), null);


        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
       
        
        pauseScript.MenuOn();
    }


   

    public void CloseStartScreen()
    {
         print("Close pressed");
        startScreen.SetActive(false);
        startScreenActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"));


        pauseScript.MenuOff();
    }

    public IEnumerator waitandfix()
    {
        yield return new WaitForSeconds(.2f);
        pauseScript.MenuOn();
    }



    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("StartScreen"))
        {
           // print("Menu Button Pressed");
            if (!startScreenActive)
            {
                

                if (!itemScreen.activeSelf)
                {
                    if (!unavailable)
                    {
                        //pauseScript.MenuOn();
                        //StartCoroutine(waitandfix());
                        ItemInventory.unavailable = true;
                        TimeStop.unavailable = true;
                        WeaponInventory.unavailable = true;
                        OpenStart();
                    }
                }
                else
                {
                    ItemInventory.unavailable = false;
                    itemScript.Closeitems();
                }
            }
            else
            {
                if (!itemScreen.activeSelf)
                {
                    ItemInventory.unavailable = false;

                    CloseStartScreen();
                    TimeStop.unavailable = false;

                    WeaponInventory.unavailable = false;
                    itemScreen.SetActive(true);

                    itemScript.OpenItems();
                }
                else
                {
                    CloseStartScreen();
                    ItemInventory.unavailable = false;
                    itemScript.Closeitems();

                }

            }

        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            //print("Menu Button Pressed");

            if (!startScreenActive)
            {
                //print("Startscreen was inactive");
                if (!itemScreen.activeSelf)
                {
                   // print("itemscreen was inactive");
                    if (!unavailable)
                    {
                       // print("Bool unavailable was false");
                        pauseScript.MenuOn();
                        //StartCoroutine(waitandfix());
                        ItemInventory.unavailable = true;
                        TimeStop.unavailable = true;
                        WeaponInventory.unavailable = true;
                        OpenStart();
                    }
                }
                else
                {
                  //  print("item screen was active");
                    itemScript.Closeitems();
                }
            }
            else
            {
               // print("Startscreen was active");
                if (!itemScreen.activeSelf)
                {
                    //print("itemscreen was imactive after startscreen was found active");
                    ItemInventory.unavailable = false;

                    CloseStartScreen();
                    TimeStop.unavailable = false;

                    WeaponInventory.unavailable = false;
                    itemScript.OpenItems();
                }
                else
                {
                   // print("itemscreen was also active");
                    CloseStartScreen();
                    itemScript.Closeitems();

                }

            }


        }
        if (Input.GetKeyUp(KeyCode.P))
        {


            if (!startScreenActive)
            {
                if (!unavailable)
                {
                    pauseScript.MenuOn();
                    ItemInventory.unavailable = true;
                    TimeStop.unavailable = true;
                    WeaponInventory.unavailable = true;
                    OpenStart();
                }
            }
            else
            {
                ItemInventory.unavailable = false;

                CloseStartScreen();
                TimeStop.unavailable = false;
                WeaponInventory.unavailable = false;


            }


        }
    }
}
