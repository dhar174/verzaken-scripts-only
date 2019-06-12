using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixControllerModel : MonoBehaviour {
    public GameObject model;
	// Use this for initialization
	void Start () {
        if (!model)
        {
            model = gameObject.transform.Find("Model").gameObject;
        }
	}
    public void FixModel()
    {
        
            model.SetActive(true);
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
