using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOldBottle : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().oldbottle());

            ItemInventory.hasOldbottle = true;
            Destroy(gameObject);
        }
    }
}
