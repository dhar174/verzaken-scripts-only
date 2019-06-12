using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAirSigDebug : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        AirSig.AirSigManager.DEBUG_LOG_ENABLED = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
