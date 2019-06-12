using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource sound;
    public AudioClip chaching;
    public AudioClip menubutton;
    public AudioClip puzzleYes;
    public AudioClip puzzleNo;
    public AudioClip computerBeepOne;



    public GameObject player;


	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");

	}



    public void PlayChaching()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayClipAt(chaching, player.transform.position);
    }
    public void PlayMenuSound()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayClipAt(menubutton, player.transform.position);
    }
    public void PlayPuzzleSuccess()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayClipAt(puzzleYes, player.transform.position);
    }

    public void PlayPuzzleFail()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayClipAt(puzzleNo, player.transform.position);
    }
    public void PlayComputerBeepOne()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayClipAt(computerBeepOne, player.transform.position);
    }

    public void PlayDisk(AudioClip disk)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayClipAt(disk, player.transform.position);
    }






    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGRR = new GameObject("TempClip"); // create the temp object
        tempGRR.transform.SetParent(player.transform);
        tempGRR.transform.position = pos; // set its position
        AudioSource bSource = tempGRR.AddComponent<AudioSource>(); // add an audio source
        GameObject.Find("TempClip").GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
        bSource.clip = clip; // define the clip
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
