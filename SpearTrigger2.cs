using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrigger2 : MonoBehaviour {
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<Animator>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("FrontSpear", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("FrontSpear", false);
        }
    }

}
