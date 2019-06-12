using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursordebug : MonoBehaviour {
    pointerdebug pointerDebug;
	// Use this for initialization
	void OnEnable () {
        pointerDebug = GameObject.Find("RightController").GetComponent<pointerdebug>();

    }


    private void OnCollisionEnter(Collision collision)
    {
        pointerDebug.CollisionDetected(collision.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
