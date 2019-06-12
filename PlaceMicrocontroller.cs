using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMicrocontroller : MonoBehaviour {
    public GameObject artifact;
    public GameObject anchor;
    public PopupManager popup;
    public string artifactName;
    public Animator anim;

    public bool alreadyPlaced;

    public static int artifactsCollected;

	// Use this for initialization
	void Start () {
		popup= GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!alreadyPlaced)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                StartCoroutine(popup.placeartifact(artifactName));
                GameObject placedartifact = Instantiate(artifact, anchor.transform.position, artifact.transform.rotation) as GameObject;
                FinalSequence.finalTrigger++;
               
                artifactsCollected = artifactsCollected + 1;
                alreadyPlaced = true;
            }

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
