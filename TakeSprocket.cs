using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSprocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().sprocket());

            ItemInventory.hasSprocket = true;

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
