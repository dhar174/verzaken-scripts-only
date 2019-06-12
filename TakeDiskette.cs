using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDiskette : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().diskette());

            ItemInventory.hasDiskette = true;

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
