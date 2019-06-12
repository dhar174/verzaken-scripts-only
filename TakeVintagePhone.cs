using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeVintagePhone : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().telephone());

            ItemInventory.hasVintagephone = true;
            Destroy(gameObject);
        }
    }
}
