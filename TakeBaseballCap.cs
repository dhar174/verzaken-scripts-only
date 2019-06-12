using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBaseballCap : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().baseballcap());

            ItemInventory.hasBaseballcap = true;
            Destroy(gameObject);
        }
    }
}
