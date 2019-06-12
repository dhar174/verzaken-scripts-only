using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;



public class RotateRoom : MonoBehaviour {
    public Vector3 startRot;
    public Vector3 currentRot;
    public Vector3 targetRot;

    public bool rotating;

    public float angle = 0.0f;

    private FirstPersonController fpscontroller;

    private GameObject player;

    public GameObject sun;

    // Use this for initialization
    void Start () {
       
        if (sun.activeSelf)
        {
            sun.SetActive(false);
        }
	}


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fpscontroller = other.GetComponent<FirstPersonController>();
            player = other.gameObject;

            if (!rotating)
            {
                angle = getNextRightAngle(angle);
                StartCoroutine(RotateIt(angle));
            }
        }
    }

    public IEnumerator HoldPlayer()
    {
        //StartCoroutine(RotateIt(angle));
        yield return new WaitForSecondsRealtime(1);

        //if(rotating)
        //{
        //    fpscontroller.enabled = false;
        //    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        // }

    }

    public IEnumerator RotateIt(float nextstep)
    {
        //transform.Rotate(0, 90* Time.deltaTime, 0);
        //currentRot = transform.eulerAngles;
        //print("Shouldve Rotated");

        //if(currentRot.y == targetRot.y)
        //{
        //    StopAllCoroutines();
        //    StopCoroutine(RotateIt());
        // }
        // if(currentRot != startRot)
        // {
        //    StartCoroutine(RotateIt());
        // }
        yield return new WaitForSeconds(0);
        rotating = true;
        float step = 200 * Time.smoothDeltaTime;
        Quaternion fromAngle = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0, nextstep, 0));
        while (transform.rotation != newRotation)
        {//the original angle from the input key dot with 90 degree < !=  0 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, step);//newRotation;
            yield return null;

        }
        rotating = false;
        yield return new WaitForSecondsRealtime(.3f);
        fpscontroller.enabled = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }

    float getNextRightAngle(float oAngle)
    {
        oAngle = oAngle - 90;
        return oAngle;
    }

    // Update is called once per frame
    void Update () {
        
	}
}
