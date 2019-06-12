using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGrowl : MonoBehaviour { 
    public AudioClip growls;

	// Use this for initialization
	void Start () {
		
	}

    public AudioSource PlayGrowlAt(AudioClip currentgrowl1, Vector3 pos)
    {
        GameObject tempGRR = new GameObject("TempGrowl"); // create the temp object
        tempGRR.transform.SetParent(gameObject.transform);
        tempGRR.transform.position = pos; // set its position
        AudioSource bSource = tempGRR.AddComponent<AudioSource>(); // add an audio source
        GameObject.Find("TempGrowl").GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
        bSource.clip = currentgrowl1; // define the clip
        bSource.rolloffMode.Equals(AudioRolloffMode.Linear);                     // set other aSource properties here, if desired
        bSource.Play(); // start the sound

        Destroy(tempGRR, 2f);
        //Destroy(tempGO, 0); // destroy object after clip duration
        return bSource; // return the AudioSource reference
    }

    // Update is called once per frame
    void Update () {
		
	}
}
