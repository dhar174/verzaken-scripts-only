using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzleDoor : MonoBehaviour {
    public Animator dooranim;


    // Use this for initialization
    void Start()
    {
        dooranim = gameObject.GetComponent<Animator>();
    }

    public void OpenThePuzzDoor()
    {
        
        
            dooranim.SetTrigger("OpenDoor");
        

    }

    public void SetDoorBool()
    {
        dooranim.SetBool("isOpen", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
