using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondTeleport : MonoBehaviour {
    public GameObject[] ponds;
    public Transform playerTransform;
    public GameObject otherPond;
    private int pondIndex;
    public Collider[] colls;
    public GameObject pondParticle;
    public PopupManager popup;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;
    public static bool teleportHasntRun;
    public static bool firstpondwasUsed;

    // Use this for initialization
    void Start () {
        ponds = GameObject.FindGameObjectsWithTag("Pond");
        if (ItemInventory.hasSnorkel)
        {
            colls = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider col in colls)
            {
                col.isTrigger = true;
            }
        }
        popup = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();

        pondParticle = gameObject.transform.Find("PondParticle").gameObject;
        pondParticle.SetActive(false);
        teleportHasntRun = true;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pondIndex = Random.Range(0, ponds.Length);
        otherPond = ponds[pondIndex];
        if(Vector3.Distance(otherPond.transform.position, gameObject.transform.position) < 3)
        {
            checkPonds();
        }
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

	}

    public void checkPonds()
    {
        pondIndex = Random.Range(0, ponds.Length);
        otherPond = ponds[pondIndex];
        if (Vector3.Distance(otherPond.transform.position, gameObject.transform.position) < 3)
        {
            checkPonds();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleportHasntRun)
            {
                StartCoroutine(Teleport());
                teleportHasntRun = false;
                if (!firstpondwasUsed)
                {
                    StartCoroutine(popup.firstteleport());
                    firstpondwasUsed = true;
                }
            }

        }
    }

    public IEnumerator Teleport()
    {
        pondParticle.SetActive(true);
        fpscontroller.enabled = false;
        playerTransform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        pondParticle.transform.position = playerTransform.position;
        yield return new WaitForSecondsRealtime(2);
        playerTransform.position = otherPond.transform.position;
        fpscontroller.enabled = true;
        playerTransform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        yield return new WaitForSecondsRealtime(1);
        pondParticle.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        teleportHasntRun = true;



    }


    public void SwitchPondOn()
    {
       colls = gameObject.GetComponentsInChildren<Collider>();
        foreach(Collider col in colls)
        {
            col.isTrigger = true;
        }

    }



    // Update is called once per frame
    void Update () {
		
	}
}
