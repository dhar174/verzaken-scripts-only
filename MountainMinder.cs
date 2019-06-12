using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMinder : MonoBehaviour {

    public bool mustfixmountains;
    public GameObject[] mountainarray;

    // Use this for initialization
    void Start () {
        mustfixmountains = false;
        StartCoroutine(countmountains());

    }

    public IEnumerator countmountains()
    {
        mountainarray = GameObject.FindGameObjectsWithTag("Mountains");
        yield return null;
    }

    
}
