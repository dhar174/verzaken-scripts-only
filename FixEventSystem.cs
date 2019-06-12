using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixEventSystem : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);
        print("Event System Fixed");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
