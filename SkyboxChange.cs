using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour {
    

    public Material[] skyboxes;
    private int i;
    private int skyboxIndex;

	void Start () {
        i = 0;
        skyboxIndex = Random.Range(0, skyboxes.Length);
        RenderSettings.skybox = skyboxes[skyboxIndex];
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyUp(KeyCode.Tab)) { 
       //     RenderSettings.skybox = skyboxes[i];
       //     i += 1;
       //     if(i >= skyboxes.Length)
       //     {
       //         i = 0;
      //      }
      //  }
        

	}
}
