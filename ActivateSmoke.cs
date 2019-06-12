using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSmoke : MonoBehaviour {
    public GameObject particle;
	// Use this for initialization
	void Start () {
        particle.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (BossBrainHealth.BossIsDead)
        {
            particle.gameObject.SetActive(true);
        }	
	}
}
