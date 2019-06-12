using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaveit : MonoBehaviour {
    public bool beenAsked;
    public bool choseOpen;
    public Pause pausescript;
    public GameObject RedDoorPanel;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    private Animator dooranim;
    // Use this for initialization
    void Start () {
        RedDoorPanel = GameObject.Find("RedDoorPanel");
    }

    public void DontOpen()
    {
        if (beenAsked)
        {
            RedDoorPanel = GameObject.Find("RedDoorPanel");

            CloseDiag();
        }
        beenAsked = true;
        if (!choseOpen)
        {
            if (!RedDoorPanel)
            {
                RedDoorPanel = GameObject.Find("RedDoorPanel");
            }

            RedDoorPanel.transform.Find("Red").transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 22;
            RedDoorPanel.transform.Find("Red").transform.Find("Text").gameObject.GetComponent<Text>().text = "Of course you want to make your mark, down here, , but, um, you can't just go messing around with the snibbit storeroom, willy-nilly. You can't upset the whole harmony of the place.";
            RedDoorPanel.transform.Find("Red").transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "OK";
            if (LanguageChange.LangNum == 1)
            {
                RedDoorPanel.transform.Find("Red").transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 12;
                RedDoorPanel.transform.Find("Red").transform.Find("Text").gameObject.GetComponent<Text>().text = "当然，你想使你的商标，到这里，但是，嗯，你不能去与snibbit库房乱搞都无可奈何。 你可以不打乱地方的整体和谐。";
                RedDoorPanel.transform.Find("Red").transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "好的";
            }

            RedDoorPanel.transform.Find("Red").transform.Find("OpenIt").gameObject.SetActive(false);
        }
        

    }

    public void CloseDiag()
    {
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RedDoorPanel.SetActive(false);
        pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();
        pausescript.MenuOff();
        GameObject.Find("mysteriousRedDoor").GetComponent<RedDoor>().endMystery();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
