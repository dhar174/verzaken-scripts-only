using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {
    public  GameObject loadScreen;
    public PopupManager popup;

    // Use this for initialization
    void Awake() {
        loadScreen = transform.Find("Loading").gameObject;
        popup = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();

    }

    public  void ReactivateLoadScreen()
    {
        loadScreen.SetActive(true);
        StartCoroutine(popup.waitforloading());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
