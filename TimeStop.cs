using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class TimeStop : MonoBehaviour {
    public GameObject[] monsters;
    public GameObject[] roboscorpions;
    public GameObject[] eyebots;
    public GameObject[] guardbots;
    public GameObject[] bbbots;
    public GameObject[] robospiders;
    public GameObject[] walkerbot;
    public GameObject[] spinbots;
    public GameObject towerboss;

    

    public float speedVar;

    private static int lifetimeUses;
    public int useCounter;
    public bool usedup;

    public static bool unavailable;

    public GameObject stopwatchdiag;

	// Use this for initialization
	void Start () {
        stopwatchdiag = GameObject.FindGameObjectWithTag("Canvas").transform.Find("StopwatchDiag").gameObject;

        stopwatchdiag.SetActive(false);
        monsters = GameObject.FindGameObjectsWithTag("Monsters");
        roboscorpions = GameObject.FindGameObjectsWithTag("Roboscorpion");
        eyebots = GameObject.FindGameObjectsWithTag("FloatingEyebot");
        guardbots = GameObject.FindGameObjectsWithTag("GuardBot");
        bbbots = GameObject.FindGameObjectsWithTag("Bbbot");
        robospiders = GameObject.FindGameObjectsWithTag("Robospider");
        walkerbot = GameObject.FindGameObjectsWithTag("WalkerBot");
        spinbots = GameObject.FindGameObjectsWithTag("SpinBoss");
        towerboss = GameObject.FindGameObjectWithTag("BossBotTower");
        lifetimeUses = Random.Range(5, 15);
        if (stopwatchdiag.activeSelf)
        {
            stopwatchdiag.SetActive(false);

        }

    }

    public IEnumerator TimeSlow()
    {
        foreach(GameObject go in monsters)
        {
            go.GetComponent<BasicAI>().animSpeed = speedVar;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = speedVar;
            go.GetComponent<BasicAI>().chaseSpeed = speedVar;
        }
        foreach(GameObject go in roboscorpions)
        {
            go.GetComponent<BasicAI>().animSpeed = speedVar;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = speedVar;
            go.GetComponent<BasicAI>().chaseSpeed = speedVar;
        }
        foreach(GameObject go in eyebots)
        {
            go.GetComponentInChildren<BasicAI>().animSpeed = speedVar;
            go.GetComponentInChildren<BasicAI>().SetAnimSpeed();
            go.GetComponentInChildren<BasicAI>().patrolSpeed = speedVar;
            go.GetComponentInChildren<BasicAI>().chaseSpeed = speedVar;
        }
        foreach(GameObject go in guardbots)
        {
            go.GetComponent<BasicAI>().animSpeed = speedVar;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = speedVar;
            go.GetComponent<BasicAI>().chaseSpeed = speedVar;
        }
        foreach (GameObject go in bbbots)
        {
            go.GetComponent<BasicAI>().animSpeed = speedVar;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = speedVar;
            go.GetComponent<BasicAI>().chaseSpeed = speedVar;
        }
        foreach (GameObject go in robospiders)
        {
            go.GetComponent<BasicAI>().animSpeed = speedVar;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = speedVar;
            go.GetComponent<BasicAI>().chaseSpeed = speedVar;
        }
        foreach (GameObject go in walkerbot)
        {
            go.GetComponent<BasicAI>().animSpeed = speedVar;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = speedVar;
            go.GetComponent<BasicAI>().chaseSpeed = speedVar;
        }
        foreach (GameObject go in spinbots)
        {
            go.GetComponent<BasicAI>().animSpeed = speedVar;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = speedVar;
            go.GetComponent<BasicAI>().chaseSpeed = speedVar;
        }
       
        
            towerboss.GetComponent<BasicAI>().animSpeed = speedVar;
            towerboss.GetComponent<BasicAI>().SetAnimSpeed();
            towerboss.GetComponent<BasicAI>().patrolSpeed = speedVar;
            towerboss.GetComponent<BasicAI>().chaseSpeed = speedVar;

        yield return new WaitForSecondsRealtime(15);

        foreach (GameObject go in monsters)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }
        foreach (GameObject go in roboscorpions)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }
        foreach (GameObject go in eyebots)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }
        foreach (GameObject go in guardbots)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }
        foreach (GameObject go in bbbots)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }
        foreach (GameObject go in robospiders)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }
        foreach (GameObject go in walkerbot)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }
        foreach (GameObject go in spinbots)
        {
            go.GetComponent<BasicAI>().animSpeed = 1;
            go.GetComponent<BasicAI>().SetAnimSpeed();
            go.GetComponent<BasicAI>().patrolSpeed = 1;
            go.GetComponent<BasicAI>().chaseSpeed = 1;
        }


        towerboss.GetComponent<BasicAI>().animSpeed = 1;
        towerboss.GetComponent<BasicAI>().SetAnimSpeed();
        towerboss.GetComponent<BasicAI>().patrolSpeed = 1;
        towerboss.GetComponent<BasicAI>().chaseSpeed = 1;
        StopCoroutine(TimeSlow());
        StopAllCoroutines();
        useCounter += 1;
    }

    public IEnumerator BrokenWatch()
    {
        stopwatchdiag.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        stopwatchdiag.SetActive(false);
    }

    public IEnumerator waitbeforeopenagain()
    {
        unavailable = true;
        yield return new WaitForSecondsRealtime(2);
        unavailable = false;
        StopCoroutine(waitbeforeopenagain());
    }

    // Update is called once per frame
    void Update () {
        if (!stopwatchdiag)
        {
            //stopwatchdiag = GameObject.FindGameObjectWithTag("Canvas").transform.Find("StopwatchDiag").gameObject;
            if (!stopwatchdiag)
            {
                stopwatchdiag = GameObject.FindGameObjectWithTag("StopwatchDiag");
            }
                if (stopwatchdiag.activeSelf)
            {
                stopwatchdiag.SetActive(false);
            }


        }

        if (ItemInventory.hasStopwatch)
        {
            
            if (Input.GetButtonUp("StopTime"))
            {
                if (!unavailable)
                {
                    if (!usedup)
                    {
                        StartCoroutine(TimeSlow());
                    }
                    if (usedup)
                    {
                        StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().stopwatchusedup());

                    }
                }
            }
            if (Input.GetAxis("StopTime") < 0)
            {
                if (!unavailable)
                {
                    if (!usedup)
                    {
                        StartCoroutine(TimeSlow());

                        StartCoroutine(waitbeforeopenagain());
                    }
                    if(usedup)
                    {
                        StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().stopwatchusedup());
                        StartCoroutine(waitbeforeopenagain());

                    }
                }

            }

        }
        if(useCounter >= lifetimeUses)
        {
            usedup = true;
        }
		
	}
}
