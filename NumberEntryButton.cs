using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberEntryButton : MonoBehaviour {
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public GameObject button4;


    public GameObject keyboard1;
    public GameObject keyboard2;

    public GameObject keyboard3;

    public GameObject keyboard4;

    // Use this for initialization
    void Start () {
        keyboard1.SetActive(false);
        keyboard2.SetActive(false);
        keyboard3.SetActive(false);

        keyboard4.SetActive(false);

        gameObject.GetComponent<Canvas>().worldCamera= GameObject.Find("Camera (eye)").GetComponent<Camera>();

    }

    public void FadeButton1()
    {
        button1.SetActive(false);
        keyboard1.SetActive(true);
        if (keyboard2.activeSelf)
        {
            keyboard2.SetActive(false);
        }
        if (keyboard3.activeSelf)
        {
            keyboard3.SetActive(false);
        }
        if (keyboard4.activeSelf)
        {
            keyboard4.SetActive(false);
        }
        
    }

    public void FadeButton1In()
    {
        button1.SetActive(true);
        keyboard1.SetActive(false);
        button1.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
        button1.GetComponentInChildren<Text>().color = new Color32(255, 255, 225, 0);
    }

    public void FadeButton2()
    {
        button2.SetActive(false);
        keyboard2.SetActive(true);
        if (keyboard1.activeSelf)
        {
            keyboard1.SetActive(false);
        }
        if (keyboard3.activeSelf)
        {
            keyboard3.SetActive(false);
        }
        if (keyboard4.activeSelf)
        {
            keyboard4.SetActive(false);
        }
    }

    public void FadeButton12In()
    {
        button2.SetActive(true);
        keyboard2.SetActive(false);
        button2.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
        button2.GetComponentInChildren<Text>().color = new Color32(255, 255, 225, 0);
    }

    public void FadeButton3()
    {
        button3.SetActive(false);
        keyboard3.SetActive(true);
        if (keyboard2.activeSelf)
        {
            keyboard2.SetActive(false);
        }
        if (keyboard1.activeSelf)
        {
            keyboard1.SetActive(false);
        }
        if (keyboard4.activeSelf)
        {
            keyboard4.SetActive(false);
        }
    }

    public void FadeButton3In()
    {
        button3.SetActive(true);
        keyboard3.SetActive(false);
        button3.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
        button3.GetComponentInChildren<Text>().color = new Color32(255, 255, 225, 0);
    }

    public void FadeButton4()
    {
        button4.SetActive(false);
        keyboard4.SetActive(true);
        if (keyboard2.activeSelf)
        {
            keyboard2.SetActive(false);
        }
        if (keyboard3.activeSelf)
        {
            keyboard3.SetActive(false);
        }
        if (keyboard1.activeSelf)
        {
            keyboard1.SetActive(false);
        }
    }

    public void FadeButton4In()
    {
        button4.SetActive(true);
        keyboard4.SetActive(false);
        button4.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
        button4.GetComponentInChildren<Text>().color = new Color32(255, 255, 225, 0);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
