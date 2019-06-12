using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGoblet : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().goblet());

            ItemInventory.hasGoblet = true;
            Destroy(gameObject);
        }
    }
}
