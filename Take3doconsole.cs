using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take3doconsole : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().console());

            ItemInventory.has3doconsole = true;
            Destroy(gameObject);
        }
    }
}
