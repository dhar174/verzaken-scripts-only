using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript1 : MonoBehaviour {
    public Animator dooranim;
    public AudioClip doorslide;
    public AudioSource sound;

	// Use this for initialization
	void Start () {
        dooranim = gameObject.GetComponent<Animator>();
        if (gameObject.GetComponent<AudioSource>())
        {
            sound = gameObject.GetComponent<AudioSource>();

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dooranim.SetTrigger("OpenDoor");
            if (doorslide)
            {
                if (sound)
                {
                    sound.clip = doorslide;
                    sound.Play();
                }
            }
        }

    }

    public void SetDoorBool()
    {
        dooranim.SetBool("isOpen", true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
