using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHuntinghorn : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().huntinghorn());

            ItemInventory.hasHuntinghorn = true;
            Destroy(gameObject);
        }
    }
}
