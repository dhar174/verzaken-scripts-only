using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapManager : MonoBehaviour {
    public Camera minimapCam;

	// Use this for initialization
	void Start () {
        minimapCam = GameObject.FindGameObjectWithTag("MinimapCam").GetComponent<Camera>();
		if(ItemInventory.hasAtlas == false)
        {
            minimapCam.enabled = false;
            gameObject.GetComponent<RawImage>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
