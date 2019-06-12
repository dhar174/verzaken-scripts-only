using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePointerGrab : MonoBehaviour {
    public GameObject rightController;
	// Use this for initialization
	void Start () {
        rightController = GameObject.Find("RightController");
	}


    public void EnablePointerToGrab()
    {
        rightController.GetComponent<VRTK.VRTK_Pointer>().interactWithObjects = true;
        rightController.GetComponent<VRTK.VRTK_Pointer>().grabToPointerTip = true;
    }

    public void DisablePointerGrab()
    {
        rightController.GetComponent<VRTK.VRTK_Pointer>().interactWithObjects = false;
        rightController.GetComponent<VRTK.VRTK_Pointer>().grabToPointerTip = false;
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
