using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour {
    public bool position1;
    public bool position2;
    public Animator anim;
    public bool stop;

    public GameObject player;

    public GameObject[] floorceiling;
    public Renderer[] rends;
   // public int rendindex;
	// Use this for initialization
	void Start () {
        position1 = true;
        position2 = false;
        if (gameObject.name == "Elevator4" || gameObject.name == "ElevatorB") 
        {
            position1 = false;
            position2 = true;
        }
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        //floorceiling = GameObject.FindGameObjectsWithTag("FloorCeiling");
        foreach(GameObject g in floorceiling)
        {
            if (g.GetComponent<Collider>())
            {
                Physics.IgnoreCollision(g.GetComponent<Collider>(), GetComponent<Collider>());
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!anim.isActiveAndEnabled)
            {
                anim.enabled = true;
            }
            if (!stop)
            {
                foreach (GameObject g in floorceiling)
                {
                    g.GetComponent<Renderer>().enabled = false;


                }
                if (position1)
                {
                    anim.SetTrigger("goingUp");
                    //other.gameObject.transform.parent = gameObject.transform;

                }
                if (position2)
                {
                    anim.SetTrigger("goingDown");
                   // other.gameObject.transform.parent = gameObject.transform;


                }
            }
        }
    }

    public void SetPosition1()
    {
        //GameObject.FindGameObjectWithTag("Player").gameObject.transform.parent = null;

        StartCoroutine(waitforexit());

        position1 = true;
        position2 = false;
    }
    public void SetPosition2()
    {
        //GameObject.FindGameObjectWithTag("Player").gameObject.transform.parent = null;
        StartCoroutine(waitforexit());
        position1 = false;
        position2 = true;
    }

    public IEnumerator waitforexit()
    {
        anim.SetBool("Stop", true);
        stop = true;
        foreach (GameObject g in floorceiling)
        {
            g.GetComponent<Renderer>().enabled = true;


        }

       // player.gameObject.transform.parent = null;
       // player.GetComponent<keepWeapon>().ReDDOL();
        yield return new WaitForSecondsRealtime(10);
        anim.SetBool("Stop", false);
        stop = false;
        StopCoroutine(waitforexit());
        yield return null;


    }



    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > 5)
        {
            
            //player.gameObject.transform.parent = GameObject.Find("[VRTK]").gameObject.transform;
            foreach (GameObject g in floorceiling)
            {
                g.GetComponent<Renderer>().enabled = true;


            }

        }
        
       
    }
}
