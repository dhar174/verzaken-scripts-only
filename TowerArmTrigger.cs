using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArmTrigger : MonoBehaviour {
    public Animator anim;


	// Use this for initialization
	void Start () {
        anim = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<Animator>();
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("ArmGrab Triggered");
            anim.SetTrigger("ArmGrab");
        }
    }
}
