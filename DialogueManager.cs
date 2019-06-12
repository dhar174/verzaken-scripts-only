using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public  int correctSymb1;
    public  int correctSymb2;
    public  int correctSymb3;

    public Pause pause;

    public GameObject canvas;

    public ActivatePuzzleOne activatePuzzOne;
  
    public Transform dialogueSlot1;
    public Transform dialogueSlot2;
    public Transform dialogueSlot3;

    public GameObject[] puzzSymbCopys;

    public PuzzleOneManager puzz1Man;
    public GameObject PuzzleCanvas1;


    // Use this for initialization
    void Start () {

        pause = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();



    }

    public void DialogueBox()
    {
        gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Camera (eye)").GetComponent<Camera>();
        canvas = GameObject.Find("Canvas");
        //canvas.SetActive(true);
        if (PuzzleCanvas1 == null)
        {
            PuzzleCanvas1 = GameObject.FindGameObjectWithTag("PuzzleCanvasOne");
        }
        if (puzz1Man == null)
        {
            puzz1Man = PuzzleCanvas1.GetComponent<PuzzleOneManager>();
        }
        if (!PuzzleCanvas1.activeSelf)
        {
            PuzzleCanvas1.SetActive(true);
        }
        puzz1Man.DecideCorrect();
        correctSymb1 = PuzzleOneManager.correctSymb1;
        correctSymb2 = PuzzleOneManager.correctSymb2;
        correctSymb3 = PuzzleOneManager.correctSymb3;
        if (PuzzleCanvas1.activeSelf)
        {
            //PuzzleCanvas1.SetActive(false);
        }

        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        dialogueSlot1 = GameObject.FindGameObjectWithTag("DialogueSlot1").transform;
        dialogueSlot2 = GameObject.FindGameObjectWithTag("DialogueSlot2").transform;
        dialogueSlot3 = GameObject.FindGameObjectWithTag("DialogueSlot3").transform;
        puzzSymbCopys = GameObject.FindGameObjectsWithTag("PuzzleSymbol3");

        

        //GameObject clone1 = Instantiate(puzzSymbCopys[correctSymb1], dialogueSlot1.position, transform.rotation) as GameObject;
        //GameObject clone2 = Instantiate(puzzSymbCopys[correctSymb2], dialogueSlot2.position, transform.rotation) as GameObject;
        //GameObject clone3 = Instantiate(puzzSymbCopys[correctSymb3], dialogueSlot3.position, transform.rotation) as GameObject;

        puzzSymbCopys[correctSymb1].transform.position = dialogueSlot1.position;
        // puzzSymbCopys[correctSymb1].transform.parent = canvas.transform;
        puzzSymbCopys[correctSymb2].transform.position = dialogueSlot2.position;
        // puzzSymbCopys[correctSymb2].transform.parent = canvas.transform;
        puzzSymbCopys[correctSymb3].transform.position = dialogueSlot3.position;
        // puzzSymbCopys[correctSymb3].transform.parent = canvas.transform;
       // pause.MenuOn();

        //canvas.SetActive(false);



    }

    public void ExitDialogue()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
        activatePuzzOne = GameObject.Find("PuzzleConsole").GetComponent<ActivatePuzzleOne>();
        activatePuzzOne.CloseDialogue();
        
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        //pause.MenuOff();
        //GameObject.Find("PuzzleDialogue1").SetActive(false);
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Cancel"))
        {
            ExitDialogue();
        }
    }
}
