using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class endConsole : MonoBehaviour {
    public bool canOperate;
    public GameObject EndConsole;
    private Pause pausescript;


    // Use this for initialization
    void Start () {
        EndConsole = GameObject.FindGameObjectWithTag("Canvas2").transform.Find("EndConsole").gameObject;
        EndConsole.SetActive(false);
        pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate = false;
        }
    }

    public void StartEndSequence()
    {
        EndConsole.SetActive(false);
        pausescript.MenuOff();

        GameObject.FindGameObjectWithTag("endCam").GetComponent<FinalSequence>().EndSequence();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }
    public void StartReboot()
    {
        EndConsole.SetActive(false);
        pausescript.MenuOff();

        StartCoroutine(GameObject.FindGameObjectWithTag("endCam").GetComponent<FinalSequence>().RebootText());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Submit"))
        {
            if (canOperate)
            {
                if (BossBrainHealth.BossIsDead)
                {
                    if (!EndConsole.activeSelf)
                    {

                        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
                        fpscontroller.enabled = false;
                        Cursor.lockState = CursorLockMode.Confined;

                        Cursor.lockState = CursorLockMode.None;
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                        pausescript.MenuOn();
                        EndConsole.SetActive(true);
                        EndConsole.transform.Find("Button").GetComponent<Button>().onClick.AddListener(StartReboot);
                        EndConsole.transform.Find("Button (1)").GetComponent<Button>().onClick.AddListener(StartEndSequence);
                        if (LanguageChange.LangNum == 1)
                        {
                            EndConsole.transform.Find("Text").GetComponent<Text>().text = "该控制台有两个选择：重新启动或启动自毁序列。";
                            EndConsole.transform.Find("Text").GetComponent<Text>().fontSize = 16;
                            EndConsole.transform.Find("Button").GetComponentInChildren<Text>().text = "重新启动";
                            EndConsole.transform.Find("Button (1)").GetComponentInChildren<Text>().text = "启动自毁命令";

                        }
                        if (LanguageChange.LangNum == 2)
                        {
                            EndConsole.transform.Find("Text").GetComponent<Text>().text = "Die Konsole hat zwei Möglichkeiten: Neustart oder eine selbst zerstörende Sequenz starten.";
                            EndConsole.transform.Find("Text").GetComponent<Text>().fontSize = 16;
                            EndConsole.transform.Find("Button").GetComponentInChildren<Text>().text = "Rebooten";
                            EndConsole.transform.Find("Button (1)").GetComponentInChildren<Text>().text = "Selbstzerstörungssequenz";
                        }
                        if (LanguageChange.LangNum == 3)
                        {
                            EndConsole.transform.Find("Text").GetComponent<Text>().text = "Консоль имеет два варианта: перезапустить или запустить последовательность саморазрушения.";
                            EndConsole.transform.Find("Text").GetComponent<Text>().fontSize = 16;
                            EndConsole.transform.Find("Button").GetComponentInChildren<Text>().text = "перезагружать";
                            EndConsole.transform.Find("Button (1)").GetComponentInChildren<Text>().text = "Самоуничтожение Последовательность";
                        }
                        if (LanguageChange.LangNum == 4)
                        {
                            EndConsole.transform.Find("Text").GetComponent<Text>().text = "La consola tiene dos opciones: reiniciar o iniciar una secuencia de autodestrucción.";
                            EndConsole.transform.Find("Text").GetComponent<Text>().fontSize = 16;
                            EndConsole.transform.Find("Button").GetComponentInChildren<Text>().text = "Reiniciar";
                            EndConsole.transform.Find("Button (1)").GetComponentInChildren<Text>().text = "Secuencia de autodestrucción";
                        }

                        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Button"), null);


                    }
                }
                

            }

        }
    }
}
