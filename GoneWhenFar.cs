using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoneWhenFar : MonoBehaviour {
    public Transform player;

    private Renderer[] rends;

    public float distance;
    public bool distanceCheck;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rends = gameObject.GetComponentsInChildren<Renderer>();
        StartCoroutine(Disappear());
    }

    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(6);
        checkDistance();
    }
    public void checkDistance()
    {
        distance = Vector3.Distance(player.position, gameObject.transform.position);
        if (distance > 350)
        {

            foreach (Renderer r in rends)
            {
                r.enabled = false;
            }



        }
        else
        {
            if (distance < 350)
            {

                foreach (Renderer r in rends)
                {
                    r.enabled = true;
                }


            }
        }
        StartCoroutine(Disappear());
        
        distanceCheck = false;
    }


   
    // Update is called once per frame

}
