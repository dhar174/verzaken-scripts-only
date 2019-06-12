using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnBossDefeat : MonoBehaviour {
    //public GameObject[] spinners;
    public static bool boss1dead;
    public static bool boss2dead;
    public bool triggeronce;
	// Use this for initialization
	void Start () {
        //spinners = GameObject.FindGameObjectsWithTag("SpinBoss");
	}
	
	// Update is called once per frame
	void Update () {
        if (boss1dead)
        {
            if (boss2dead)
            {
                if (!triggeronce)
                {

                    gameObject.GetComponent<openTreasureDoor>().openSesame();
                    triggeronce = true;
                }
            }

        }
    }
}
