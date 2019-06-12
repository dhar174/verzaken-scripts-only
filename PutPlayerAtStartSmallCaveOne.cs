using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPlayerAtStartSmallCaveOne : MonoBehaviour {
    public Transform player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = gameObject.transform.position;
        StartCoroutine(PutPlayer());
    }

    public IEnumerator PutPlayer()
    {

        yield return new WaitForFixedUpdate();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = gameObject.transform.position;
        StopCoroutine(PutPlayer());
        yield return null;
    }
}
