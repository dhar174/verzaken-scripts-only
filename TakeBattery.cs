using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBattery : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!PopupManager.firstartifactfound)
            {
                StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().firstartifact());
                PopupManager.firstartifactfound = true;

            }
            ItemInventory.hasBattery = true;
            Destroy(gameObject);
        }
    }
}
