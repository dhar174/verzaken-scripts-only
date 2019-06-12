using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinkSound : MonoBehaviour {
    public AudioSource sound;
    public int clinkIndex;
    public AudioClip[] clinks;
    public AudioClip currentclink;

	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
	}

    public void PlayClipAt(AudioClip clink)
    {
        sound.clip = clink;

        sound.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
       // print("Robo Collision happened");
        RandomClink();
        
    }


    public void RandomClink()
    {
        clinkIndex = Random.Range(0, clinks.Length);


        currentclink = clinks[clinkIndex];
        PlayClipAt(currentclink);


    }


    // Update is called once per frame
    void Update () {
		
	}
}
