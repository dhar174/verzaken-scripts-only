using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActivatePuzzleOne : MonoBehaviour {
    public GameObject PuzzleCanvas;
    public bool canOperate;
    private FirstPersonController fpscontroller;

    private int index1;
    private int index2;
    private int index3;

    public DialogueManager dialogue;

    public Pause pause;

    private GameObject puzzleDialogue;

    public PuzzleOneManager puzzle1Manager;
    public bool disable=false;
    

	// Use this for initialization
	void Start () {
        PuzzleCanvas = GameObject.FindGameObjectWithTag("PuzzleCanvasOne");
        //PuzzleCanvas.SetActive(false);
        pause = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

        puzzle1Manager = PuzzleCanvas.GetComponent<PuzzleOneManager>();
        puzzleDialogue = GameObject.FindGameObjectWithTag("PuzzleDialogue1");
        dialogue = puzzleDialogue.GetComponent<DialogueManager>();
        puzzleDialogue.SetActive(false);
	}


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!disable)
            {
                canOperate = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate = false;
            disable = false;
        }
    }

    public void OpenPuzzle()
    {
        print("Opening Puzzle");
        PuzzleCanvas.SetActive(true);
        puzzle1Manager.PopulatePuzzle();

        puzzle1Manager.gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Camera (eye)").GetComponent<Camera>();

        pause.MenuOn();

        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayComputerBeepOne();
        canOperate = false;
        disable = true;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ClosePuzzle()
    {
        print("Deactivating PuzzOne");

        PuzzleCanvas.SetActive(false);
        pause.MenuOff();
        fpscontroller.enabled = true;
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenDialogue()
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
        //GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(puzzleDialogue.transform.Find("Panel").transform.Find("Button").gameObject, null);

        dialogue.DialogueBox();
    }
    public void CloseDialogue()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
        pause.MenuOff();
        puzzleDialogue.SetActive(false);
        disable = false;

        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        fpscontroller.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            //print("pressed Submit");
            if (canOperate)
            {
                print("pressed Submit while canOperate = true");
                if (PuzzleOneManager.puzzleOneActive)
                {
                    print("pressed Submit while puzzle active");
                    if (!PuzzleCanvas.activeSelf)
                    {

                        OpenPuzzle();
                        gameObject.GetComponent<EnablePointerGrab>().EnablePointerToGrab();

                    }
                    else
                    {
                        pause.MenuOn();
                    }
                }
                if (!PuzzleOneManager.puzzleOneActive)
                {
                    OpenDialogue();
                }

            }

        }
    }
}
