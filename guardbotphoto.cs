using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardbotphoto : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Animator>().SetBool("attacking", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
