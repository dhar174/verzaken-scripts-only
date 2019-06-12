using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                if (collision.gameObject.GetComponent<Rigidbody>().isKinematic)
                {
                    collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    collision.gameObject.tag = "CanGrab";
                }
            }
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
