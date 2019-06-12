using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorOpen : MonoBehaviour {
    private Animator dooranim;


    // Use this for initialization
    void Start()
    {
        dooranim = gameObject.GetComponent<Animator>();
    }

    public void OpenThePuzzDoor()
    {


        dooranim.SetTrigger("OpenTheSecretDoor");


    }

    public void SetDoorBool()
    {
        dooranim.SetBool("DoorIsOpened", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
