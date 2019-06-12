using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    public void AimGun(Transform player)
    {
        gameObject.transform.LookAt(player, Vector3.forward);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
