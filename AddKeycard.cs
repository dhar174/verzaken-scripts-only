using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKeycard : MonoBehaviour {
    public ItemInventory itemScript;
    public Animator dooranim;


    // Use this for initialization
    void Start()
    {
        itemScript = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<ItemInventory>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemScript.hasKeycard = true;
            Destroy(gameObject);
        }
    }


    
}
