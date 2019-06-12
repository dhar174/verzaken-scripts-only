using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openred : MonoBehaviour {
    public bool beenAsked;
    public bool choseOpen;
    public Pause pausescript;
    public GameObject RedDoorPanel;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    private Animator dooranim;
    // Use this for initialization
    void Start () {
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    public void OpenRedDoor()
    {
        RedDoorPanel = GameObject.Find("RedDoorPanel");
        //RedDoorPanel.SetActive(false);
        beenAsked = true;
        choseOpen = true;
        RedDoorPanel.transform.Find("Red").transform.Find("Text").gameObject.GetComponent<Text>().text = "What have you done? Do you want the rainforest to die?";
        if (LanguageChange.LangNum == 1)
        {
            RedDoorPanel.transform.Find("Red").transform.Find("Text").gameObject.GetComponent<Text>().text = "你做了什么？ 你想要雨林去死吗？";
        }
        RedDoorPanel.transform.Find("Red").transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "OK";
        if (LanguageChange.LangNum == 1)
        {
            RedDoorPanel.transform.Find("Red").transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "好的";
        }
        RedDoorPanel.transform.Find("Red").transform.Find("OpenIt").gameObject.SetActive(false);
        dooranim = GameObject.Find("mysteriousRedDoor").GetComponent<Animator>();
        dooranim.SetTrigger("OpenDoor");
    }
    public void CloseDiag()
    {
        
        fpscontroller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RedDoorPanel.SetActive(false);
        pausescript.MenuOff();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
