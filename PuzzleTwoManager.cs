using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTwoManager : MonoBehaviour {
    public GameObject[] puzzSymbs;

    public bool puzzleOn;

    public int correctSymb1;
    public int correctSymb2;
    public int correctSymb3;

    public RectTransform slot1;
    public RectTransform slot2;
    public RectTransform slot3;

    public int index1;
    public int index2;
    public int index3;

    public int rand1;
    public int rand2;
    public int rand3;

    public RectTransform canvas;

    public DialogueManager2 dManager2;


    public GameObject clone1;
    public GameObject clone2;
    public GameObject clone3;

    public bool slotOneCorrect;
    public bool slotTwoCorrect;
    public bool slotThreeCorrect;

    public int numCorrect;

    public GameObject PuzzleCanvas1;

    public PuzzleTwoActivate activatePuzzTwo;

    public PuzzleOneManager puzz1Man;

    public GameObject dialogue2;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    public bool wait =false;

    // Use this for initialization
    void Start () {
        

        PuzzleCanvas1 = GameObject.FindGameObjectWithTag("PuzzleCanvasOne");
       // puzz1Man = PuzzleCanvas1.GetComponent<PuzzleOneManager>();

        puzzleOn = false;

        rand1 = Random.Range(0, 18);
        rand2 = Random.Range(0, 18);
        rand3 = Random.Range(0, 18);

        slotOneCorrect = false;
        slotTwoCorrect = false;
        slotThreeCorrect = false;
        dialogue2 = GameObject.Find("PuzzleDialogue2");
        //dManager2 = dialogue2.GetComponent<DialogueManager2>();
       


        index1 = 0;
        index2 = 1;
        index3 = 2;

        

        //canvas = GameObject.Find("Canvas").GetComponent<Transform>();

        correctSymb1 = PuzzleOneManager.correctSymb1;
        correctSymb2 = PuzzleOneManager.correctSymb2;
        correctSymb3 = PuzzleOneManager.correctSymb3;


        slot1 = GameObject.FindGameObjectWithTag("Roulette1").GetComponent<RectTransform>();
        slot2 = GameObject.FindGameObjectWithTag("Roulette2").GetComponent<RectTransform>();
        slot3 = GameObject.FindGameObjectWithTag("Roulette3").GetComponent<RectTransform>();






    }

    public void DeactivateThis()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();

        dialogue2.SetActive(false);
        gameObject.SetActive(false);
    }

    public IEnumerator Delay()
    {
        wait = true;
        yield return new WaitForSecondsRealtime(.35f);
        wait = false;
        StopCoroutine(Delay());

    }

    public void PopulateScreen()
    {
       // if (!PuzzleCanvas1)
       // {
         //   PuzzleCanvas1 = GameObject.FindGameObjectWithTag("PuzzleCanvasOne");

      //  }
        //if (!puzz1Man)
       // {
        //    puzz1Man = PuzzleCanvas1.GetComponent<PuzzleOneManager>();
       // }

        if (!PuzzleCanvas1.activeSelf)
        {
            PuzzleCanvas1.SetActive(true);
        }
        puzz1Man.DecideCorrect();
        puzzSymbs = GameObject.FindGameObjectsWithTag("PuzzleSymbol2");
        correctSymb1 = PuzzleOneManager.correctSymb1;
        correctSymb2 = PuzzleOneManager.correctSymb2;
        correctSymb3 = PuzzleOneManager.correctSymb3;
        if (PuzzleCanvas1.activeSelf)
        {
            //PuzzleCanvas1.SetActive(false);
        }


        clone1 = Instantiate(puzzSymbs[index1], slot1.position, transform.rotation, canvas) as GameObject;
        clone1.transform.SetParent(canvas);
        clone1.GetComponent<RectTransform>().transform.position = slot1.position;
        
        clone2 = Instantiate(puzzSymbs[index2], slot2.position, transform.rotation, canvas) as GameObject;
        clone2.transform.SetParent(canvas);
        clone2.GetComponent<RectTransform>().transform.position = slot2.position;

        clone3 = Instantiate(puzzSymbs[index3], slot3.position, transform.rotation, canvas) as GameObject;
        clone3.transform.SetParent(canvas);
        clone3.GetComponent<RectTransform>().transform.position = slot3.position;
    }

    public void SlotOneUp()
    {
        if (!wait)
        {
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
            //print("Button Pressed 1up");
            Destroy(clone1);
            index1 += 1;
            if (index1 == 18)
            {
                index1 = 0;
            }
            clone1 = Instantiate(puzzSymbs[index1], slot1.position, transform.rotation, canvas) as GameObject;
            clone1.transform.SetParent(canvas);
            clone1.GetComponent<RectTransform>().transform.position = slot1.position;
            if (index1 == correctSymb1)
            {
                slotOneCorrect = true;
            }
            if (index1 != correctSymb1)
            {
                slotOneCorrect = false;
            }
            StartCoroutine(Delay());
        }
    }

    public void SlotOneDown()
    {
        if (!wait)
        {
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
            //print("Button Pressed 1down");

            Destroy(clone1);
            index1 -= 1;
            if (index1 < 0)
            {
                index1 = 17;
            }
            clone1 = Instantiate(puzzSymbs[index1], slot1.position, transform.rotation, canvas) as GameObject;
            clone1.transform.SetParent(canvas);
            clone1.GetComponent<RectTransform>().transform.position = slot1.position;

            if (index1 == correctSymb1)
            {
                slotOneCorrect = true;
            }
            if (index1 != correctSymb1)
            {
                slotOneCorrect = false;
            }
            StartCoroutine(Delay());

        }
    }

    public void SlotTwoUp()
    {
        if (!wait)
        {
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
            //print("Button Pressed 2up");

            Destroy(clone2);
            index2 += 1;
            if (index2 == 18)
            {
                index2 = 0;
            }
            clone2 = Instantiate(puzzSymbs[index2], slot2.position, transform.rotation, canvas) as GameObject;
            clone2.transform.SetParent(canvas);
            clone2.GetComponent<RectTransform>().transform.position = slot2.position;

            if (index2 == correctSymb2)
            {
                slotTwoCorrect = true;
            }
            if (index2 != correctSymb2)
            {
                slotTwoCorrect = false;
            }
            StartCoroutine(Delay());

        }
    }

    public void SlotTwoDown()
    {
        if (!wait)
        {
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
           // print("Button Pressed 2down");

            Destroy(clone2);
            index2 -= 1;
            if (index2 < 0)
            {
                index2 = 17;
            }
            clone2 = Instantiate(puzzSymbs[index2], slot2.position, transform.rotation, canvas) as GameObject;
            clone2.transform.SetParent(canvas);
            clone2.GetComponent<RectTransform>().transform.position = slot2.position;

            if (index2 == correctSymb2)
            {
                slotTwoCorrect = true;
            }
            if (index2 != correctSymb2)
            {
                slotTwoCorrect = false;
            }
            StartCoroutine(Delay());

        }

    }

    public void SlotThreeUp()
    {
        if (!wait)
        {
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
            //print("Button Pressed 3up");

            Destroy(clone3);
            index3 += 1;
            if (index3 == 18)
            {
                index3 = 0;
            }
            clone3 = Instantiate(puzzSymbs[index3], slot3.position, transform.rotation, canvas) as GameObject;
            clone3.transform.SetParent(canvas);
            clone3.GetComponent<RectTransform>().transform.position = slot3.position;

            if (index3 == correctSymb3)
            {
                slotThreeCorrect = true;
            }
            if (index3 != correctSymb3)
            {
                slotThreeCorrect = false;
            }
            StartCoroutine(Delay());

        }
    }

    public void SlotThreeDown()
    {
        if (!wait)
        {
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
            //print("Button Pressed 3down");

            Destroy(clone3);
            index3 -= 1;
            if (index3 < 0)
            {
                index3 = 17;
            }
            clone3 = Instantiate(puzzSymbs[index3], slot3.position, transform.rotation, canvas) as GameObject;
            clone3.transform.SetParent(canvas);
            clone3.GetComponent<RectTransform>().transform.position = slot3.position;

            if (index3 == correctSymb3)
            {
                slotThreeCorrect = true;
            }
            if (index3 != correctSymb3)
            {
                slotThreeCorrect = false;
            }
            StartCoroutine(Delay());

        }
    }

    public void ExitPuzzleTwo()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();

        activatePuzzTwo = GameObject.Find("PuzzleConsole2").GetComponent<PuzzleTwoActivate>();
        activatePuzzTwo.ClosePuzzle2();
        //GameObject.Find("PuzzleDialogue1").SetActive(false);
    }

   


    // Update is called once per frame
    void Update () {
        if (slotOneCorrect)
        {
            if (slotTwoCorrect)
            {
                if (slotThreeCorrect)
                {
                    
                    PuzzleOneManager.puzzleOneActive = true;
                    PuzzleCanvas1.SetActive(false);
                    GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

                    ExitPuzzleTwo();
                    Destroy(clone1);
                    Destroy(clone2);
                    Destroy(clone3);
                   dManager2.OpenDialogue3();



                }
            }
        }
	}
}
