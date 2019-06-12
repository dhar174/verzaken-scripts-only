using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveSnorkel : MonoBehaviour {
    public bool CaveMound;

    public GameObject snorkel;
    //public int weaponCounter;
    //public int weaponMax;
    private Transform thispilelocation;

    private bool weaponismade;

    public int pileHitCounter;
    private int pileHitMax;


   

    public int levelmultiplier;

    public bool canMine;

    public Vector3 direction;
    public float distance;

    // Use this for initialization
    void Start () {
        thispilelocation = gameObject.transform;
        pileHitCounter = 0;
        pileHitMax = Random.Range(1, 5);
        weaponismade = false;
        canMine = false;
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
    }

    private IEnumerator CreateSnorkel()
    {
        if (!weaponismade)
        {
            if (CaveMound)
            {
                direction = gameObject.transform.right;
                distance = 1;
            }
            if (!CaveMound)
            {
                direction = gameObject.transform.up;
                distance = 1;
            }
            GameObject snorkelclone = Instantiate(snorkel, transform.position + direction * distance, snorkel.transform.rotation) as GameObject;


            if (CaveMound)
            {
                Vector3 fixPos = new Vector3(-.75f, -2, 0);
                snorkelclone.transform.localPosition = snorkelclone.transform.position + fixPos;

            }
            weaponismade = true;
            Destroy(gameObject, 1);

            StopCoroutine(CreateSnorkel());
            yield return null;
        }
        weaponismade = true;
        yield return null;
    }

    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject.tag == "Enemies")
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
        }
        if (other.tag == "Player")
        {
            canMine = true;
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canMine = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "pickaxe" || collision.gameObject.name == "pickaxe(Clone)")
        {
            if (canMine)
            {

                pileHitCounter += 1;
                if (pileHitCounter > pileHitMax)
                {

                    StartCoroutine(CreateSnorkel());


                    StopCoroutine(CreateSnorkel());
                    canMine = false;
                }

            }
        }
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Mine"))
        {

            if (canMine)
            {

                pileHitCounter += 1;
                if (pileHitCounter > pileHitMax)
                {

                    StartCoroutine(CreateSnorkel());
                    gameObject.GetComponent<Collider>().enabled = false;
                    gameObject.GetComponentInChildren<Renderer>().enabled = false;


                    StopCoroutine(CreateSnorkel());
                }

            }
            if (!canMine)
            {
                //Debug.Log("Cannot Mine");
            }
        }
    }
}
