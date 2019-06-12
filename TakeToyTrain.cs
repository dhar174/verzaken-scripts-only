using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeToyTrain : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().toytrain());

            ItemInventory.hasToytrain = true;
            Destroy(gameObject);
        }
    }
}
