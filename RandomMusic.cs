using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour {
    public AudioClip[] worldmusic;
    public AudioClip[] cavemusic;
    public int musicIndex;
    public AudioSource music;
    public AudioClip currentTrack;

    public bool isCave;


	// Use this for initialization
	void Start () {
        music = gameObject.GetComponent<AudioSource>();
        //PlayMusic();
       
	}
	public void PlayMusic()
    {
        if (isCave)
        {
            music = gameObject.GetComponent<AudioSource>();

            musicIndex = Random.Range(0, cavemusic.Length);
            currentTrack = cavemusic[musicIndex];
           // StartCoroutine(ChangeMusic());
            music.clip = currentTrack;
            music.Play();
            music.loop = true;
        }
        if (!isCave)
        {
            music = gameObject.GetComponent<AudioSource>();

            musicIndex = Random.Range(0, worldmusic.Length);
            currentTrack = worldmusic[musicIndex];
            //StartCoroutine(ChangeMusic());
            music.clip = currentTrack;
            music.Play();
            music.loop = true;

        }
        isCave = false;
    }


    private IEnumerator ChangeMusic()
    {
        yield return new WaitForFixedUpdate();
        music = gameObject.GetComponent<AudioSource>();
        //oldmusic = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        // oldmusic.enabled = false;
        music.clip = currentTrack;
        music.Play();
        music.loop = true;
        StopCoroutine(ChangeMusic());
        yield return null;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
