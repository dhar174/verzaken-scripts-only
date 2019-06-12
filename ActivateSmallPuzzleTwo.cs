using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class ActivateSmallPuzzleTwo : MonoBehaviour {
    public GameObject PuzzleCanvas;
    public bool canOperate;
    private FirstPersonController fpscontroller;
    private GameObject puzzleDialogue;
    private SmallPuzz2Manager puzzMan;
    public bool firstActivation;
    public Pause pause;

    // Use this for initialization
    void Start () {
        PuzzleCanvas = GameObject.FindGameObjectWithTag("PuzzleCanvasOne");
        //zleDialogue = GameObject.FindGameObjectWithTag("PuzzleDialogue1");
        puzzMan = PuzzleCanvas.GetComponent<SmallPuzz2Manager>();
        pause = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate = false;
        }
    }

    public void OpenPuzzle()
    {
        PuzzleCanvas.SetActive(true);
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayComputerBeepOne();

        if (!firstActivation)
        {
            puzzMan.q1.SetActive(true);
            firstActivation = true;
        }
        puzzMan.puzzPanel.SetActive(true);
        canOperate = false;

        ItemInventory.unavailable = true;

        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;

        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pause.MenuOn();
    }

    public void ClosePuzzle()
    {
        PuzzleCanvas.SetActive(false);

        fpscontroller.enabled = true;

        ItemInventory.unavailable = false;
        canOperate = true;
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause.MenuOff();

    }
    public void OpenDialogue()
    {


        pause.MenuOn();

        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            if (canOperate)
            {
                
                
                   
                    

                        OpenPuzzle();

                
                    
                
               

            }

        }
    }
}
