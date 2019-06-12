using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour {
    public AudioSource music;
    public AudioClip cavemusic;
    public RandomMusic randomusic;
    //public AudioSource oldmusic;

   

    // Use this for initialization
    void Start () {
        randomusic = GameObject.FindGameObjectWithTag("Music").GetComponent<RandomMusic>();
        randomusic.PlayMusic();
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();

        StartCoroutine(ChangeMusic());
    }

    private IEnumerator ChangeMusic()
    {
        yield return new WaitForSecondsRealtime(.1f);
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        randomusic.isCave = true;

        randomusic.PlayMusic();
        //oldmusic = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        // oldmusic.enabled = false;
        //music.clip = cavemusic;
       // music.Play();
        //music.loop = true;
       // StopCoroutine(ChangeMusic());
        yield return null;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
