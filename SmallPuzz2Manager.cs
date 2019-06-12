using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SmallPuzz2Manager : MonoBehaviour {
    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;


    public int q2Value;

    public GameObject puzzPanel;

    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;

    public int ans1int;
    public int ans4int;


    public InputField myInput;
    public Dropdown myDropdown;

    public GameObject keyboard1;
    //public GameObject keyboard2;
    public GameObject keyboard3;
    public GameObject keyboard4;

    public bool qbool1;
    public bool qbool2=false;
    public bool qbool3 = false;
    public bool qbool4 = false;



    // Use this for initialization
    void Start() {

        puzzPanel = gameObject.transform.Find("PuzzPanel").gameObject;
        q1 = gameObject.transform.Find("Q1").gameObject;
        myInput = q1.GetComponent<InputField>();
        //myInput.onValidateInput += delegate (string input, int charIndex, char addedChar) { return MyValidate(addedChar); };
        q2 = gameObject.transform.Find("Q2").gameObject;
        myDropdown = q2.GetComponent<Dropdown>();
        q3 = gameObject.transform.Find("Q3").gameObject;
        q4 = gameObject.transform.Find("Q4").gameObject;

        q2.SetActive(false);
        q3.SetActive(false);
        q4.SetActive(false);
        myDropdown.onValueChanged.AddListener(delegate {
            QuestionTwoAnswered(myDropdown);
        });
        puzzPanel.SetActive(false);
        q1.SetActive(false);
        qbool1 = true;
    }


    public void QuestionOneAnswered()
    {
       // GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

        answer1 = q1.GetComponent<InputField>().text;
        ans1int = int.Parse(answer1);
        if (ans1int == 2)
        {
            keyboard1.SetActive(false);
            GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();
            qbool1 = false;
            QuestionTwo();
        }
        else
        {
            Lose();
        }
    }
    public void QuestionTwo()
    {
        q1.SetActive(false);
        Debug.Log("Q1 disabled");
        puzzPanel.transform.Find("Question").GetComponent<Text>().text = "A parsec is equal to how many light years?";
        q2.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Q2"), null);
        qbool2 = true;


    }

    public void QuestionTwoAnswered(Dropdown target)
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();
        print("Question 2");
        q2Value = target.value;
        if (qbool2)
        {
            if (q2Value == 1)
            {
                qbool2 = false;
                print("Correct Answer q2");
                QuestionThree();
                
            }
            else
            {
                qbool2 = false;
                print("Wrong answer Q2");
                Lose();
                
            }
        }

    }

    public void Lose()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleFail();
        print("Lose");
        ItemInventory.unavailable = false;
        if (q1.activeSelf)
        {
            q1.SetActive(false);
        }
        if (q2.activeSelf)
        {
            q2.SetActive(false);
        }
        if (q3.activeSelf)
        {
            q3.SetActive(false);
        }
        if (q4.activeSelf)
        {
            q4.SetActive(false);
        }
        puzzPanel.transform.Find("Question").GetComponent<Text>().text = "Sorry, that is incorrect. Access Revoked. ERROR CODE 5312";
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleFail();
        TimeStop.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;


    }

    public void Win()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        puzzPanel.transform.Find("Question").GetComponent<Text>().text = "Access granted to the Vault. Have a nice day";
        q4.SetActive(false);
        GameObject.FindGameObjectWithTag("PuzzleDoor").GetComponent<OpenPuzzleDoor>().OpenThePuzzDoor();
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

    }


    public void QuestionThree()
    {
        keyboard3.SetActive(true);
        q2.SetActive(false);
        puzzPanel.transform.Find("Question").GetComponent<Text>().text = "The 'singular' point at the center of a black hole is called what?";
        q3.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Q3"), null);
        qbool3 = true;

    }

    public void QuestionFour()
    {
        keyboard4.SetActive(true);

        q3.SetActive(false);
        puzzPanel.transform.Find("Question").GetComponent<Text>().text = "What is the meaning of life, the Universe, and everything?";
        qbool4 = true;
        q4.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Q4"), null);

    }

    public void QuestionFourAnswered()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

        answer4 = q4.GetComponent<InputField>().text;
        ans4int = int.Parse(answer4);
        if (ans4int == 42)
        {
           Win();
        }
        else
        {
            Lose();
        }
    }

    public void QuestionThreeAnswered()
    {
        keyboard3.SetActive(false);

        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

        answer3 = q3.GetComponent<InputField>().text;
        
        if (answer3 == "Singularity")
        {
            qbool3 = false;
            print("Correct Answer Q3");
            QuestionFour();
        }
        else
        {
            if (answer3 == "singularity")
            {
                qbool3 = false;
                print("Correct Answer Q3");

                QuestionFour();
            }
            else
            {
                if (answer3 == "a singularity")
                {
                    qbool3 = false;
                    print("Correct Answer Q3");

                    QuestionFour();
                }
                else
                {
                    if (answer3 == "the singularity")
                    {
                        qbool3 = false;
                        print("Correct Answer Q3");

                        QuestionFour();
                    }
                    else
                    {
                        print("Wrong Answer Q3");
                        Lose();
                    }
                }
               
            }
           
        }
       




    }

   

    private void Update()
    {
        
    }



}
