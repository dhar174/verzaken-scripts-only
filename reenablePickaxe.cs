using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reenablePickaxe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
