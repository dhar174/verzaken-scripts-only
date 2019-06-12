using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSymbol : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public PuzzleOneManager puzzleManager;

    public static GameObject itemBeingDragged;
    Vector2 startPosition;
    Transform startParent;
    Transform canvas;

    private Vector3 VERYstartPos;

    public Canvas myCanvas;

    

    // Use this for initialization
    void Start () {
        puzzleManager = GameObject.FindGameObjectWithTag("PuzzleCanvasOne").GetComponent<PuzzleOneManager>();
        //myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas = myCanvas.transform;
        VERYstartPos = gameObject.transform.position;

	}


    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        canvas = myCanvas.gameObject.transform;

        transform.parent = canvas;
    }


    public void OnDrag(PointerEventData eventData)
    {
       

       // In the OnDrag function
      //Vector2 pos;
       //RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
		//transform.position = myCanvas.transform.TransformPoint(pos);

        
        gameObject.transform.position += (Vector3)eventData.delta;

        


    }


    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject ps1 = GameObject.FindGameObjectWithTag("PuzzleSlotOne");
        GameObject ps2 = GameObject.FindGameObjectWithTag("PuzzleSlotTwo");
        GameObject ps3 = GameObject.FindGameObjectWithTag("PuzzleSlotThree");


        float distance1 = Vector2.Distance(gameObject.transform.position, ps1.transform.position);

        float distance2 = Vector2.Distance(gameObject.transform.position, ps2.transform.position);

        float distance3 = Vector2.Distance(gameObject.transform.position, ps3.transform.position);

        if (distance1 < 50)
        {
            gameObject.transform.position = ps1.transform.position;
            transform.parent = ps1.transform;
            if (gameObject.CompareTag("CorrectSymbol"))
            {

                if (gameObject.transform.parent.CompareTag("PuzzleSlotOne"))
                {
                    puzzleManager.slotOneFilled = true;

                    puzzleManager.numCorrectSymbols += 1;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotTwo"))
                {
                    puzzleManager.slotTwoFilled = true;
                    puzzleManager.numCorrectSymbols += 1;


                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotThree"))
                {
                    puzzleManager.slotThreeFilled = true;
                    puzzleManager.numCorrectSymbols += 1;


                }

            }
            if (gameObject.CompareTag("PuzzleSymbol"))
            {
                if (gameObject.transform.parent.CompareTag("PuzzleSlotOne"))
                {
                    puzzleManager.slotOneFilled = true;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotTwo"))
                {
                    puzzleManager.slotTwoFilled = true;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotThree"))
                {
                    puzzleManager.slotThreeFilled = true;
                }
            }

        }

        if (distance2 < 50)
        {
            gameObject.transform.position = ps2.transform.position;
            transform.parent = ps2.transform;
            
            if (gameObject.CompareTag("CorrectSymbol"))
            {

                if (gameObject.transform.parent.CompareTag("PuzzleSlotOne"))
                {
                    puzzleManager.slotOneFilled = true;

                    puzzleManager.numCorrectSymbols += 1;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotTwo"))
                {
                    puzzleManager.slotTwoFilled = true;
                    puzzleManager.numCorrectSymbols += 1;


                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotThree"))
                {
                    puzzleManager.slotThreeFilled = true;
                    puzzleManager.numCorrectSymbols += 1;


                }

            }
            if (gameObject.CompareTag("PuzzleSymbol"))
            {
                if (gameObject.transform.parent.CompareTag("PuzzleSlotOne"))
                {
                    puzzleManager.slotOneFilled = true;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotTwo"))
                {
                    puzzleManager.slotTwoFilled = true;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotThree"))
                {
                    puzzleManager.slotThreeFilled = true;
                }
            }

        }



        if (distance3 < 50)
        {
            gameObject.transform.position = ps3.transform.position;
            transform.parent = ps3.transform;
           
            if (gameObject.CompareTag("CorrectSymbol"))
            {

                if (gameObject.transform.parent.CompareTag("PuzzleSlotOne"))
                {
                    puzzleManager.slotOneFilled = true;

                    puzzleManager.numCorrectSymbols += 1;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotTwo"))
                {
                    puzzleManager.slotTwoFilled = true;
                    puzzleManager.numCorrectSymbols += 1;


                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotThree"))
                {
                    puzzleManager.slotThreeFilled = true;
                    puzzleManager.numCorrectSymbols += 1;


                }

            }
            if (gameObject.CompareTag("PuzzleSymbol"))
            {
                if (gameObject.transform.parent.CompareTag("PuzzleSlotOne"))
                {
                    puzzleManager.slotOneFilled = true;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotTwo"))
                {
                    puzzleManager.slotTwoFilled = true;
                }
                if (gameObject.transform.parent.CompareTag("PuzzleSlotThree"))
                {
                    puzzleManager.slotThreeFilled = true;
                }
            }

        }


        float distanceFromStart = Vector3.Distance(VERYstartPos, transform.position);

        if(distanceFromStart < 80)
        {

            
            transform.position = VERYstartPos;
            transform.parent = startParent;


        }



        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == canvas)
        {
            transform.position = startPosition;
            transform.parent = startParent;
        }



    }

    
}
