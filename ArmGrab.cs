using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGrab : MonoBehaviour {
    public GameObject player;
    public FixedJoint fj;
    public BossTowerAI bossScript;
    public GameObject grabber;

    public bool hasPlayer;
    public static bool letgo;
    public static bool currentlyGrabbing;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        bossScript = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<BossTowerAI>();
       fj = gameObject.GetComponent<FixedJoint>();
        grabber = GameObject.FindGameObjectWithTag("Grabber");
	}

    public void OnTriggerEnter(Collider other)
    {
        if (!currentlyGrabbing)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Debug.Log("Grabber was Triggered");

                // hj = gameObject.AddComponent<HingeJoint>();
                // fj.connectedBody = other.gameObject.GetComponent<Rigidbody>();
                //player.GetComponent<Rigidbody>().isKinematic = true;
                //player.GetComponent<Rigidbody>().detectCollisions = true;
                // gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //  gameObject.GetComponent<Rigidbody>().detectCollisions = true;


                // FixedJoint fixedJoint = player.AddComponent<FixedJoint>();
                // fixedJoint.anchor = grabber.transform.position;
                //  fixedJoint.connectedBody = gameObject.GetComponent<Rigidbody>();

                // player.GetComponent<Rigidbody>().mass = 0.00001f;
                // player.GetComponent<Collider>().material.bounciness = 0;
                //player.GetComponent<Rigidbody>().freezeRotation = true;
                //player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                letgo = false;
                bossScript.Grab();
                hasPlayer = true;
                // StartCoroutine(TakePlayer());
            }
        }

    }

    public IEnumerator TakePlayer()
    {
        while (hasPlayer)
        {
           
            player.transform.position = grabber.transform.position;
            yield return new WaitForSecondsRealtime(10f);
            if (letgo)
            {
                hasPlayer = false;
            }
           
        }
        //yield return new WaitForSecondsRealtime(.5f);
        //hasPlayer = false;
        //letgo = false;
        if (letgo)
        {
            hasPlayer = false;
            StopCoroutine(TakePlayer());
        }
        //StopCoroutine(TakePlayer());

        yield return null;
    }

        public void Unstick()
        {
           player.GetComponent<Rigidbody>().isKinematic = true;
           player.GetComponent<Rigidbody>().detectCollisions = false;
            Destroy(fj);
           gameObject.GetComponent<Rigidbody>().mass = 1;
        }
    

    // Update is called once per frame
    void Update () {
		if(hasPlayer)
        {
            
          
            player.transform.SetParent(grabber.transform);
            player.transform.localPosition = grabber.transform.localPosition;

            if (letgo)
            {
                hasPlayer = false;
            }

        }
        if (letgo)
        {
            hasPlayer = false;
            player.transform.SetParent(null);
            player.GetComponent<keepWeapon>().ReDDOL();
            StopCoroutine(TakePlayer());
        }
    }
}
