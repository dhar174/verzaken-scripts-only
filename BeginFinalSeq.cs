using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginFinalSeq : MonoBehaviour {
    public GameObject endcam;
    public FinalSequence finalscript;
	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>().MenuOff();
        if (GameObject.FindGameObjectWithTag("Canvas2").transform.Find("EndConsole"))
        {
            GameObject.FindGameObjectWithTag("Canvas2").transform.Find("EndConsole").gameObject.SetActive(false);
        }



        endcam = GameObject.FindGameObjectWithTag("endCam");
        finalscript = endcam.GetComponent<FinalSequence>();
        StartCoroutine(finalscript.WaitForFinalScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
