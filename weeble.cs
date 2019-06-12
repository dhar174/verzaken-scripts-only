using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weeble : MonoBehaviour {

    Rigidbody rb;
    private int count;

	// Use this for initialization
	void Start () {

        rb = gameObject.GetComponent<Rigidbody>();
        rb.rotation = new Quaternion(0, 0, 0, 1);
        count = 0;
	}


    Vector3 previousAngle;
    float accelerationBuffer = 0.3f;
    float decelerationBuffer = 0.1f;
    Vector3 angleDelta;

    void FixedUpdate()
    {

        count++;
        if (count > 6)
        {
            count = 0;
            Quaternion rot = rb.rotation;
            rot[0] = 0; //null rotation X
            rot[2] = 0; //null rotation Z
            rb.rotation = rot;
        }
    }
}
