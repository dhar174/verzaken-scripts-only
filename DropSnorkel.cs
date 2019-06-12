using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSnorkel : MonoBehaviour {
    public GameObject snorkel;
    public bool buffisdropped;


	// Use this for initialization
	void Start ()
    {
		
	}

    public void DropSnork()
    {
        if (!buffisdropped)
        {
            GameObject newBuff = Instantiate(snorkel, transform.position + transform.up, gameObject.transform.rotation) as GameObject;
            buffisdropped = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
