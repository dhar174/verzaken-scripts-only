using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleSparks : MonoBehaviour {
    public float time;


    // Use this for initialization
    void OnEnable()
    {
        Timer();
    }

    public void Timer()
    {
        
        //StartCoroutine(GameObject.Find("SparkManager").GetComponent<SparksManager>().ReturnSparks());
    }
}
