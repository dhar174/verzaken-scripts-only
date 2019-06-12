using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTreasureDoor : MonoBehaviour {
    private Animator anim;
    


	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
    public void openSesame()
    {
        anim.SetTrigger("OpenDoor");
    }


    public void SetDoorBool()
    {
        anim.SetBool("isOpen", true);
    }


}
