using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PuzzleOneManager : MonoBehaviour {
    public  GameObject[] symbols;
   public static int correctSymb1;
   public static int correctSymb2;
   public static int correctSymb3;

    public int cSym1;
    public int cSym2;
    public int cSym3;

    public GameObject canvas;

    public static bool puzzleOneActive;

    public bool slotOneFilled;
    public bool slotTwoFilled;
    public bool slotThreeFilled;

    public Transform dialogueSlot1;
    public Transform dialogueSlot2;
    public Transform dialogueSlot3;

    public GameObject[] puzzSymbCopys;

    public ActivatePuzzleOne activePuzzOne;

    public bool decisionHasRunOnce;

    public GameObject consoleOutline;

    public Camera consoleCam;

    public GameObject sun;

    public int numCorrectSymbols;

    private bool restartcheck;

    public DialogueManager2 dmanage2;
    public GameObject dialogue2;
    public Pause pause;


    // Use this for initialization
    void Start () {
        dialogue2 = GameObject.FindGameObjectWithTag("PuzzleDialogue2");
        numCorrectSymbols = 0;
        sun = GameObject.FindGameObjectWithTag("Sun");
        sun.SetActive(false);
        canvas = GameObject.FindGameObjectWithTag("PuzzleCanvasOne");
        decisionHasRunOnce = false;
        pause = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

        consoleOutline = GameObject.FindGameObjectWithTag("ConsoleOutline");
        consoleCam = GameObject.FindGameObjectWithTag("ConsoleCamera").GetComponent<Camera>();

        consoleCam.enabled = false;
        consoleOutline.SetActive(false);
        

        cSym1 = correctSymb1;
        cSym2 = correctSymb2;
        cSym3 = correctSymb3;

        activePuzzOne = GameObject.Find("PuzzleConsole").GetComponent<ActivatePuzzleOne>();


        puzzleOneActive = false;





        print("Deactivating PuzzOne");
        canvas.SetActive(false);
        
    }

    public void OnEnable()
    {
        print("PuzzOneMan enabled");
    }


    public void DecideCorrect()
    {
        if (!decisionHasRunOnce)
        {
            correctSymb1 = Random.Range(0, 18);
            correctSymb2 = Random.Range(0, 18);
            correctSymb3 = Random.Range(0, 18);

            StartCoroutine("ErrorCheck");
            
                            
            
        }
        else
        {
            print("Deactivating PuzzOne");
            canvas.SetActive(false);
        }
    }

    public IEnumerator ErrorCheck()
    {
        restartcheck = false;
        if (correctSymb1 == correctSymb2)
        {
            correctSymb1 = Random.Range(0, 18);
            restartcheck = true;
        }
        if (correctSymb2 == correctSymb3)
        {
            correctSymb2 = Random.Range(0, 18);
            restartcheck = true;

        }
        if (correctSymb1 == correctSymb3)
        {
            correctSymb1 = Random.Range(0, 18);
            restartcheck = true;

        }
        if (correctSymb2 == correctSymb3)
        {
            correctSymb2 = Random.Range(0, 18);
            restartcheck = true;

        }
        if (restartcheck)
        {
            StopCoroutine("ErrorCheck");
            decisionHasRunOnce = true;
            StartCoroutine("ErrorCheck");
            restartcheck = false;

        }
        cSym1 = correctSymb1;
        cSym2 = correctSymb2;
        cSym3 = correctSymb3;

        decisionHasRunOnce = true;
        print("Deactivating PuzzOne");
        canvas.SetActive(false);

        yield return null;
    }

    public void PopulatePuzzle()
    {
        //consoleCam.enabled = true;
        //consoleOutline.SetActive(true);
        //sun.SetActive(true);
        //symbols = GameObject.FindGameObjectsWithTag("PuzzleSymbol");
        //print("Retagged Symbols");
        symbols[correctSymb1].transform.tag = "CorrectSymbol";
        symbols[correctSymb2].transform.tag = "CorrectSymbol";
        symbols[correctSymb3].transform.tag = "CorrectSymbol";
        print("Retagged Symbols");
        //print("Deactivating PuzzOne");

        //canvas.SetActive(false);
    }





    // Update is called once per frame
    void Update () {
		
        if(numCorrectSymbols == 3)
        {
            OpenPuzzleDoor openPuzz = GameObject.FindGameObjectWithTag("PuzzleDoor").GetComponent<OpenPuzzleDoor>();
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();
            // = GameObject.FindGameObjectWithTag("PuzzleDialogue2");

           // consoleCam.enabled = false;
            //consoleOutline.SetActive(false);
            //sun.SetActive(false);
            openPuzz.OpenThePuzzDoor();
            
            dmanage2.OpenDialogue3();
            dialogue2.SetActive(true);
            //GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Button"), null);
            GameObject.Find("PuzzleConsole").GetComponent<EnablePointerGrab>().DisablePointerGrab();


            dialogue2.GetComponentInChildren<Text>().text = "Sounds like a door opened";
            dmanage2.MakeWait();
            activePuzzOne.ClosePuzzle();


        }

        

	}
}
