using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IgnorePlayerCollider : MonoBehaviour {
    public GameObject player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
