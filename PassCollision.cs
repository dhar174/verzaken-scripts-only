using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCollision : MonoBehaviour {
    public GameObject touchedSymbol;
	// Use this for initialization
	void Start () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PuzzleSymbol") || other.gameObject.CompareTag("CorrectSymbol"))
        {
            touchedSymbol = other.gameObject;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PuzzleSymbol") || other.gameObject.CompareTag("CorrectSymbol"))
        {
            touchedSymbol = other.gameObject;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
