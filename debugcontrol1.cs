using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debugcontrol1 : MonoBehaviour {
    public GameObject player;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.U))
        {
            player.GetComponentInChildren<Camera>().renderingPath = RenderingPath.DeferredShading;
            SceneManager.LoadScene("bosstest");
        }
	}
}
