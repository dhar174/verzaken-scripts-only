using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaserClick : MonoBehaviour {

    private GameObject selectedObject;
    private BtnManager btn;
    private GameModeScript gameModeManager;
	// Use this for initialization
	void Start () {
        btn = GameObject.Find("BtnManager").GetComponent<BtnManager>();
        gameModeManager = GameObject.Find("GameModeManager").GetComponent<GameModeScript>();
	}


    public void OnTriggerEnter(Collider other)
    {
        selectedObject = other.gameObject;
       
    }
    // Update is called once per frame
    void Update () {

        
        

    }
}
