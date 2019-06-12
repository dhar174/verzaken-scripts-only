using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLoading : MonoBehaviour {
    public GameObject loadscreen;
    public PopupManager popup;
    // Use this for initialization
    void OnEnable() {
       
        StartCoroutine(waitforloading());
        

    }
    public IEnumerator waitforloading()
    {
        yield return new WaitForSecondsRealtime(4);
        loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");
        popup = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
        PopupManager.showedLoading = true;
        //loadscreen.SetActive(false);
        StopCoroutine(waitforloading());
    }

    public void ReactivateLoadScreen()
    {
        loadscreen.SetActive(true);
        StartCoroutine(popup.waitforloading());
    }

}