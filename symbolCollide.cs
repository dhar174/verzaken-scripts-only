using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class symbolCollide : MonoBehaviour {
    public PuzzleOneManager puzzleManager;
    public static int winNum;



	// Use this for initialization
	void Start () {
        puzzleManager = GameObject.Find("PuzzleCanvasOne").GetComponent<PuzzleOneManager>();
        winNum = 0;
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CorrectSymbol"))
        {

            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotOneFilled = true;
                winNum += 1;
                puzzleManager.numCorrectSymbols = winNum;
            }
            if (gameObject.CompareTag("PuzzleSlotTwo"))
            {
                puzzleManager.slotTwoFilled = true;
                winNum += 1;
                puzzleManager.numCorrectSymbols = winNum;

            }
            if (gameObject.CompareTag("PuzzleSlotThree"))
            {
                puzzleManager.slotThreeFilled = true;
                winNum += 1;
                puzzleManager.numCorrectSymbols = winNum;

            }

        }
        if (collision.CompareTag("PuzzleSymbol"))
        {
            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotOneFilled = true;
            }
            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotTwoFilled = true;
            }
            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotThreeFilled = true;
            }
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CorrectSymbol"))
        {

            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotOneFilled = false;
                winNum -= 1;
                puzzleManager.numCorrectSymbols = winNum;


            }
            if (gameObject.CompareTag("PuzzleSlotTwo"))
            {
                puzzleManager.slotTwoFilled = false;
                winNum -= 1;
                puzzleManager.numCorrectSymbols = winNum;


            }
            if (gameObject.CompareTag("PuzzleSlotThree"))
            {
                puzzleManager.slotThreeFilled = false;
                winNum -= 1;
                puzzleManager.numCorrectSymbols = winNum;


            }

        }
        if (collision.CompareTag("PuzzleSymbol"))
        {
            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotOneFilled = false;
            }
            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotTwoFilled = false;
            }
            if (gameObject.CompareTag("PuzzleSlotOne"))
            {
                puzzleManager.slotThreeFilled = false;
            }
        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}
