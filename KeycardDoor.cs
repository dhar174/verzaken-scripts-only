using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardDoor : MonoBehaviour {
    public ItemInventory itemScript;
    public Animator dooranim;


	// Use this for initialization
	void Start () {
        itemScript = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<ItemInventory>();
        dooranim = gameObject.GetComponent<Animator>();
	}


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(itemScript.hasKeycard)
            {
                dooranim.SetTrigger("OpenDoor");
            }
        }
    }
    public void SetDoorBool()
    {
        dooranim.SetBool("isOpen", true);
    }


   
}
