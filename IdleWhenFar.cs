using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

public class IdleWhenFar : MonoBehaviour {
   // public GameObject player;
    public BasicAI AI;
    public Animator anim;
    public NavMeshAgent agent;
    public NavMeshPath path;
    public SpriteLookAt spritelookat;

    private Renderer[] rends;
    private Collider[] colls;
    private Rigidbody rb;

    public bool distanceCheck;

   // public float distance;

	// Use this for initialization
	void Start () {
        
        AI = gameObject.GetComponent<BasicAI>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        if (gameObject.GetComponentInChildren<SpriteLookAt>())
        {
            spritelookat = gameObject.GetComponentInChildren<SpriteLookAt>();
        }
        rends = gameObject.GetComponentsInChildren<Renderer>();
        colls = gameObject.GetComponentsInChildren<Collider>();
        StartCoroutine(Disappear());
        rb = gameObject.GetComponent<Rigidbody>();
        //StartCoroutine(Disappear());
	}

    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5);
        checkDistance();
        yield return null;
    }

    public void checkDistance()
    {
        
       GameObject  player = GameObject.FindGameObjectWithTag("Player");
       float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
       // print("checking distance" + gameObject.name+"Distance equals:"+distance);
        if (distance > 300)
            {

                anim.enabled = false;
                // Destroy(rb);
                if (spritelookat)
                {
                    spritelookat.enabled = false;
                }
                //agent.enabled = false;
                AI.enabled = false;
               // foreach (Renderer r in rends)
               // {
               //     r.enabled = false;
               // }
                //foreach (Collider c in colls)
               // {
                    //c.enabled = false;
              //  }


        }
            else {
            if (distance <= 300)
            {
                //gameObject.AddComponent<Rigidbody>();

                AI.enabled = true;
                anim.enabled = true;
                if (spritelookat)
                {
                    spritelookat.enabled = true;
                }
              //  foreach (Renderer r in rends)
               // {
               //     r.enabled = true;
              //  }
                //foreach (Collider c in colls)
               // {
                    //c.enabled = true;
               // }

            }
        }
        StartCoroutine(Disappear());
           // distanceCheck = false;
        
    }
    

}
