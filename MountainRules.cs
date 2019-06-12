using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainRules : MonoBehaviour {

    public bool mountainscolliding;
    public static MountainMinder mountainMinder;
    public static ObjectPopulation objectPopulation;
    public static bool mountainsDone = false;

    private float distance;
    

	// Use this for initialization
	void Start () {
        mountainscolliding = false;
        //MountainManager = GameObject.FindGameObjectWithTag("MountainManager");
        GameObject o = GameObject.FindGameObjectWithTag("ObjectDistributor");
        GameObject m = GameObject.FindGameObjectWithTag("MountainManager");

        mountainMinder = m.GetComponent<MountainMinder>();
        objectPopulation = o.GetComponent<ObjectPopulation>();
        objectPopulation.mountainisfixed = true;
        //StartCoroutine(distancecheck());
    }



    public void OnTriggerEnter(Collider mtcoll)
    {


       
           // GameObject otherObj = mtcoll.gameObject;
            //Debug.Log("Triggered with: " + otherObj);
        
        if (mtcoll.tag == "Mountains")
        {
            
            mountainscolliding = true;
            objectPopulation.mountainisfixed = false;
            mountainMinder.mustfixmountains = true;
            
        }
        if (mtcoll.tag == "Portal")
        {

            mountainscolliding = true;
            objectPopulation.mountainisfixed = false;
            mountainMinder.mustfixmountains = true;

        }
        if (mtcoll.tag == "CaveOpening")
        {

            mountainscolliding = true;
            objectPopulation.mountainisfixed = false;
            mountainMinder.mustfixmountains = true;

        }
        if (mtcoll.tag == "Player")
        {

            mountainscolliding = true;
            objectPopulation.mountainisfixed = false;
            mountainMinder.mustfixmountains = true;

        }
        //mountainMinder.mustfixmountains = false;
    }

    public void OnTriggerExit(Collider mtcoll)
    {
        if (mtcoll.tag == "Mountains")
        {
            mountainscolliding = false;
            objectPopulation.mountainisfixed = true;
            //mountainMinder.mustfixmountains = false;

        }
        if (mtcoll.tag == "Portal")
        {
            mountainscolliding = false;
            objectPopulation.mountainisfixed = true;
            //mountainMinder.mustfixmountains = false;

        }
        if (mtcoll.tag == "CaveOpening")
        {
            mountainscolliding = false;
            objectPopulation.mountainisfixed = true;
            //mountainMinder.mustfixmountains = false;

        }
        if (mtcoll.tag == "Player")
        {
            mountainscolliding = false;
            objectPopulation.mountainisfixed = true;
            //mountainMinder.mustfixmountains = false;

        }

    }

    IEnumerator DeleteThisScript()
    {
        yield return new WaitForFixedUpdate();
        Destroy(this, 1f);
    }

    public void Update()
    {
        if (mountainsDone)
        {

            StartCoroutine(DeleteThisScript());
        }
    }

}
