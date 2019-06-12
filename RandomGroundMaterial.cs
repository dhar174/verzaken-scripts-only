using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGroundMaterial : MonoBehaviour {
    public Material[] groundmaterials;
    public Renderer groundRend;
    private int materialIndex;
	// Use this for initialization
	void Start () {
        groundRend = gameObject.GetComponent<Renderer>();
        materialIndex = Random.Range(0, groundmaterials.Length);

        groundRend.material = groundmaterials[materialIndex];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
