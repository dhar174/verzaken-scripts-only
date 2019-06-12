using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeRAM : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().RAM());

            ItemInventory.hasRAM = true;
            Destroy(gameObject);
        }
    }
}
