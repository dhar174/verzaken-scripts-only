using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {
    public Light torchlight;
    public GameObject player;
    public int maxdistance;


	// Use this for initialization
	void Start () {
        if (maxdistance==0)
        {
            maxdistance = 10;

        }
        torchlight = gameObject.GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > maxdistance)
        {
            torchlight.enabled = false;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            torchlight.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            torchlight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            torchlight.enabled = false;
        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}
