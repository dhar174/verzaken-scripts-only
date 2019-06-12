using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeStatuette : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().statuette());

            ItemInventory.hasStatuette = true;
            Destroy(gameObject);
        }
    }
}
