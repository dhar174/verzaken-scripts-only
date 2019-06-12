using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeClippingPlane : MonoBehaviour {
    public Camera mainC;
    public float clipInt;
    public Slider clipSlider;
    


	// Use this for initialization
	void Start () {
        if (Camera.main)
        {
            mainC = Camera.main;
        }
        clipInt = 600;
        if (GameObject.FindGameObjectWithTag("ClipSlider").GetComponentInChildren<Slider>())
        {
            clipSlider = GameObject.FindGameObjectWithTag("ClipSlider").GetComponentInChildren<Slider>();
        }

    }


    public void ChangeClip()
    {
        if (GameObject.FindGameObjectWithTag("ClipSlider").GetComponentInChildren<Slider>())
        {
            clipSlider = GameObject.FindGameObjectWithTag("ClipSlider").GetComponentInChildren<Slider>();
        }
        if (Camera.main)
        {
            mainC = Camera.main;
        }
        clipInt = clipSlider.value;
        mainC.farClipPlane = clipInt;
    }
}
