using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCrucible : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().crucible());

            ItemInventory.hasCrucible = true;
            Destroy(gameObject);
        }
    }
}
