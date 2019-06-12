using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHeadphones : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().headphones());

            ItemInventory.hasHeadphones = true;

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
