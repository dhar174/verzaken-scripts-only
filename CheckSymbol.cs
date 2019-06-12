using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSymbol : MonoBehaviour {
    public PuzzleOneManager puzzleManager;

    public bool slot1Check;
    public bool slot2Check;
    public bool slot3Check;

    public static bool inHand;
    // Use this for initialization
    void Start () {
        puzzleManager = GameObject.FindGameObjectWithTag("PuzzleCanvasOne").GetComponent<PuzzleOneManager>();

    }

    public void OnTriggerEnter(Collider other)
    {

        //other.gameObject.transform.position = gameObject.transform.position;
        //transform.parent = ps1.transform;
        if (!inHand)
        {
            if (other.CompareTag("CorrectSymbol"))
            {
                if (gameObject.CompareTag("PuzzleSlotOne"))
                {
                    puzzleManager.slotOneFilled = true;
                    if (!slot1Check)
                    {
                        puzzleManager.numCorrectSymbols += 1;
                        slot1Check = true;
                        print("Slot One Correct");
                        other.gameObject.tag = null;

                    }
                }
                if (gameObject.CompareTag("PuzzleSlotTwo"))
                {
                    puzzleManager.slotOneFilled = true;

                    if (!slot2Check)
                    {
                        puzzleManager.numCorrectSymbols += 1;
                        slot2Check = true;
                        print("Slot Two Correct");
                        other.gameObject.tag = null;

                    }
                }
                if (gameObject.CompareTag("PuzzleSlotThree"))
                {
                    puzzleManager.slotOneFilled = true;


                    if (!slot3Check)
                    {
                        print("Slot Three Correct");
                        puzzleManager.numCorrectSymbols += 1;
                        slot3Check = true;
                        other.gameObject.tag = null;

                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
