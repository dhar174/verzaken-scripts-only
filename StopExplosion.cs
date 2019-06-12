using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopExplosion : MonoBehaviour {
    public float time;


	// Use this for initialization
	void OnEnable () {
       Timer();
	}

    public void Timer()
    {
        //yield return new WaitForSeconds(time);
        StartCoroutine(GameObject.Find("Deathsplosions").GetComponent<SplosionManager>().ReturnSplosion());
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
