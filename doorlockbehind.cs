using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlockbehind : MonoBehaviour {
    public Animator dooranim;
    public bool openedoncealready;
    public ItemInventory itemScript;
    public AudioClip doorslide;
    public AudioSource sound;

    // Use this for initialization
    void Start()
    {
        dooranim = gameObject.GetComponent<Animator>();
        itemScript = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<ItemInventory>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (openedoncealready)
            {
                if (itemScript.hasKeycard)
                {
                    
                       
                        dooranim.SetTrigger("OpenDoor");
                    if(gameObject.name=="towerdoor (7)")
                    {
                        GameObject.Find("pCube25").SetActive(false);
                        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
                    }
                        
                    
                }
            }
        }
        if (other.tag == "Player")
        {
            if (!openedoncealready)
            {
                
                    dooranim.SetTrigger("OpenDoor");
                    openedoncealready = true;
                
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (openedoncealready)
            {
                dooranim.SetTrigger("CloseDoor");
                dooranim.SetBool("isOpen", false);
            }
        }
    }


    public void SetDoorBool()
    {
        dooranim.SetBool("isOpen", true);
    }

}
