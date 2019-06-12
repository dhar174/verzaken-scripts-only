using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardEnter1 : MonoBehaviour {
    public SmallPuzz2Manager smallpuzz;
    public static bool touching;
    public Dropdown droppy;
    public bool canTouch;
    // Use this for initialization
    void Start () {
        smallpuzz = GameObject.FindGameObjectWithTag("PuzzleCanvasOne").GetComponent<SmallPuzz2Manager>();
        canTouch = true;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (canTouch)
        {
            if (other.gameObject.CompareTag("Controller"))
            {
                touching = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (canTouch)
        {
            if (other.gameObject.CompareTag("Controller"))
            {
                touching = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            touching = false;
        }
    }


    public IEnumerator Waitup()
    {
        touching = false;
        canTouch = false;
        yield return new WaitForSeconds(1);
        canTouch = true;
        StopCoroutine(Waitup());
    }


    // Update is called once per frame
    void Update () {
        if (touching)
        {
            if (Input.GetButtonUp("Submit"))
            {
                if (smallpuzz.qbool1)
                {
                    smallpuzz.QuestionOneAnswered();
                    StartCoroutine(Waitup());
                }
                else
                {
                    if (smallpuzz.qbool2)
                    {
                        //smallpuzz.QuestionTwoAnswered(droppy);
                        StartCoroutine(Waitup());

                    }
                    else
                    {
                        if (smallpuzz.qbool3)
                        {
                            smallpuzz.QuestionThreeAnswered();
                            StartCoroutine(Waitup());

                        }
                        else
                        {
                            if (smallpuzz.qbool4)
                            {
                                smallpuzz.QuestionFourAnswered();
                                StartCoroutine(Waitup());

                            }
                        }
                    }
                   
                }
            }
        }

	}
}
