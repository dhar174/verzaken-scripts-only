using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSnorkel : MonoBehaviour {
    //private ItemInventory itemScript;
    public GameObject[] ponds;

	// Use this for initialization
	void Start () {
        //itemScript = GameObject.FindGameObjectWithTag("ItemStage").GetComponent<ItemInventory>();
        
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().snorkel());

            ItemInventory.hasSnorkel = true;
            ponds = GameObject.FindGameObjectsWithTag("Pond");
            foreach (GameObject go in ponds)
            {
                go.GetComponent<PondTeleport>().SwitchPondOn();
            }
            Destroy(gameObject);
        }
    }

    
}
