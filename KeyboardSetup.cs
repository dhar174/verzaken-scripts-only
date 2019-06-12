using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurvedVRKeyboard;

public class KeyboardSetup : MonoBehaviour {
    public KeyboardCreator kc;


	// Use this for initialization
	void Awake () {
        StartCoroutine(latestart());
        kc = gameObject.GetComponent<KeyboardCreator>();
	}
    public IEnumerator latestart()
    {
        yield return new WaitForSeconds(2);
        kc.RaycastingSource = GameObject.FindGameObjectWithTag("Player").transform.Find("Camera (eye)").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
