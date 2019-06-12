using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoundLimit : MonoBehaviour {
    public GameObject[] moundList;
    public GameObject daPlaya;
    private int wait;
    private bool listDone;

	// Use this for initialization
	void Start () {
        
        //StartCoroutine(Wait());
        wait = 0;
    }

   


    public void PopulateMoundList()
    {
        moundList = null;
        moundList = GameObject.FindGameObjectsWithTag("Mound");
        daPlaya = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (daPlaya != null)
        {
            wait++;
            if (wait >= 20)
            {
                wait = 0;
                foreach (GameObject MOUND in moundList)
                {
                    if (MOUND != null)
                    {
                        if (Vector3.Distance(daPlaya.transform.position, MOUND.transform.position) > 60)
                        {
                            MOUND.GetComponent<RandomItem>().enabled = false;
                            MOUND.GetComponent<SphereCollider>().enabled = false;

                        }
                        if (Vector3.Distance(daPlaya.transform.position, MOUND.transform.position) <= 60)
                        {
                            MOUND.GetComponent<RandomItem>().enabled = true;
                            MOUND.GetComponent<SphereCollider>().enabled = true;

                        }
                    }



                }
            }
        }
        else
        {
            daPlaya = GameObject.FindGameObjectWithTag("Player");

        }

    }
}
