using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleTwoActivate : MonoBehaviour {
    public GameObject PuzzleCanvas2;
    public bool canOperate2;
    private FirstPersonController fpscontroller;

    private GameObject puzzleDialogue;

    private PuzzleTwoManager puzzle2Manager;
    public Pause pause;
    private bool disable = false;
    // Use this for initialization
    void Start()
    {
        PuzzleCanvas2 = GameObject.FindGameObjectWithTag("PuzzleCanvasTwo");
        pause = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

        puzzle2Manager = PuzzleCanvas2.GetComponent<PuzzleTwoManager>();
        //puzzleDialogue = GameObject.Find("PuzzleDialogue1");
        //puzzleDialogue.SetActive(false);
        puzzle2Manager.DeactivateThis();
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!disable)
            {
                canOperate2 = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate2 = false;
            disable = false;
        }
    }

    public void OpenPuzzle2()
    {
        PuzzleCanvas2.SetActive(true);
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayComputerBeepOne();
        if (!puzzle2Manager)
        {
            puzzle2Manager = PuzzleCanvas2.GetComponent<PuzzleTwoManager>();

        }
        pause.MenuOn();
        disable = true;
        canOperate2 = false;
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
        //GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(PuzzleCanvas2.transform.Find("Panel").transform.Find("Button").gameObject, null);
        puzzle2Manager.PopulateScreen();

    }

    public void ClosePuzzle2()
    {
        PuzzleCanvas2.SetActive(false);
        pause.MenuOff();
        fpscontroller.enabled = true;

        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenDialogue2()
    {
        puzzleDialogue.SetActive(true);
        pause.MenuOn();
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //puzzle2Manager.DialogueBox();
    }
    public void CloseDialogue2()
    {
        puzzleDialogue.SetActive(false);
        pause.MenuOff();
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            if (canOperate2)
            {
                if (!PuzzleCanvas2.activeSelf)
                {

                    OpenPuzzle2();


                }
            }
           


        }
    }
}
