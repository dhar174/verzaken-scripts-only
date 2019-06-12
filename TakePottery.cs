using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePottery : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().pottery());

            ItemInventory.hasPottery = true;
            Destroy(gameObject);
        }
    }
}
