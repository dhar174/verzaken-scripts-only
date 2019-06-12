using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeAtlas : MonoBehaviour {
    public GameObject minimap;

	// Use this for initialization
	void Start () {
        minimap = GameObject.FindGameObjectWithTag("Minimap");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().atlasbook());

            ItemInventory.hasAtlas = true;
            GameObject.FindGameObjectWithTag("MinimapCam").GetComponent<Camera>().enabled = true;
            minimap.GetComponent<RawImage>().enabled = true;
            Destroy(gameObject, .5f);
        }
    }
}
