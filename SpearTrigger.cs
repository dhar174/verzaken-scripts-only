using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrigger : MonoBehaviour {
    public Animator anim;
    public bool boolSet;

	// Use this for initialization
	void Start () {
        anim = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<Animator>();
	}


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!boolSet)
            {
                anim.SetBool("SideSpears", true);
                boolSet = true;

            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (boolSet)
            {
                anim.SetBool("SideSpears", false);
                boolSet = false;
            }
        }
    }
    
}
