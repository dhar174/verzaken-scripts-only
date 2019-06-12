using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RedDoor : MonoBehaviour {
    public bool beenAsked;
    public bool choseOpen;
    public Pause pausescript;
    public GameObject RedDoorPanel;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    private Animator dooranim;

    private Collider[] colls;


    // Use this for initialization
    void Start () {

        StartCoroutine(LateStart());
        dooranim = gameObject.GetComponent<Animator>();
	}

    public IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1.5f);
        RedDoorPanel = GameObject.Find("RedDoorPanel");
        RedDoorPanel.SetActive(false);
        StopCoroutine(LateStart());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!beenAsked)
            {
                fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
                fpscontroller.enabled = false;
                //Cursor.lockState = CursorLockMode.Confined;

                //Cursor.lockState = CursorLockMode.None;
                //Cursor.lockState = CursorLockMode.Confined;
                //Cursor.visible = true;
                RedDoorPanel.SetActive(true);
                //RedDoorPanel.transform.Find("OpenIt").GetComponent<Button>().onClick.AddListener(delegate { OpenRedDoor(); });
                //RedDoorPanel.transform.Find("LeaveIt").GetComponent<Button>().onClick.AddListener(delegate { DontOpen(); });

                if (!pausescript)
                {
                    pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();
                }
                pausescript.MenuOn();

                if (LanguageChange.LangNum == 1)
                {
                    RedDoorPanel.transform.Find("Text").GetComponent<Text>().text = "红门后面什么也没有。";

                    RedDoorPanel.transform.Find("LeaveIt").GetComponentInChildren<Text>().text = "选择不打开它";
                    RedDoorPanel.transform.Find("OpenIt").GetComponentInChildren<Text>().text = "打开红门";

                }
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("LeaveIt"), null);


            }
        }
    }



    public void OpenRedDoor()
    {
        beenAsked = true;
        choseOpen = true;
        RedDoorPanel.transform.Find("Text").gameObject.GetComponent<Text>().text = "What have you done? Do you want the rainforest to die?";
        if (LanguageChange.LangNum == 1)
        {
            RedDoorPanel.transform.Find("Text").gameObject.GetComponent<Text>().text = "你做了什么？ 你想要雨林去死吗？";
        }
        RedDoorPanel.transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "OK";
        if (LanguageChange.LangNum == 1)
        {
            RedDoorPanel.transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "好的";
        }
        RedDoorPanel.transform.Find("OpenIt").gameObject.SetActive(false);
        dooranim.SetTrigger("OpenDoor");
    }

    public void SetDoorBool()
    {
        dooranim.SetBool("isOpen", true);
    }

    public void DontOpen()
    {
        if (beenAsked)
        {
            CloseDiag();
        }
        if (!choseOpen)
        {
            RedDoorPanel.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 20;
            RedDoorPanel.transform.Find("Text").gameObject.GetComponent<Text>().text = "Of course you want to make your mark, down here, , but, um, you can't just go messing around with the snibbit storeroom, willy-nilly. You can't upset the whole harmony of the place.";
            RedDoorPanel.transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "OK";
            if (LanguageChange.LangNum == 1)
            {
                RedDoorPanel.transform.Find("Text").gameObject.GetComponent<Text>().fontSize = 12;
                RedDoorPanel.transform.Find("Text").gameObject.GetComponent<Text>().text = "当然，你想使你的商标，到这里，但是，嗯，你不能去与snibbit库房乱搞都无可奈何。 你可以不打乱地方的整体和谐。";
                RedDoorPanel.transform.Find("LeaveIt").transform.Find("Text").gameObject.GetComponent<Text>().text = "好的";
            }

            RedDoorPanel.transform.Find("OpenIt").gameObject.SetActive(false);
        }
        beenAsked = true;

    }

    public void CloseDiag()
    {
        fpscontroller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RedDoorPanel.SetActive(false);


    }

    public void endMystery()
    {
        colls = gameObject.GetComponents<Collider>();
        foreach(Collider c in colls)
        {
            
            if (c.GetType() == typeof(SphereCollider))
            {
                c.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
