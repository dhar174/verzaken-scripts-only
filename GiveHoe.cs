using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHoe : MonoBehaviour {
  



    public bool CaveMound;

    public GameObject hoe;
    //public int weaponCounter;
    //public int weaponMax;
    private Transform thispilelocation;

    private bool weaponismade;

    private int pileHitCounter;
    private int pileHitMax;


    public WeaponStats weaponstats;
    private Renderer[] rend;


    public int levelmultiplier;

    public bool canMine;

    public Vector3 direction;
    public float distance;

    // Use this for initialization
    void Start()
    {
        thispilelocation = gameObject.transform;
        pileHitCounter = 0;
        pileHitMax = Random.Range(1, 5);
        weaponismade = false;
        canMine = false;
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
    }

    private IEnumerator Createhoe()
    {
        if (!weaponismade)
        {
            if (CaveMound)
            {
                direction = gameObject.transform.right;
                distance = 2;
            }
            if (!CaveMound)
            {
                direction = gameObject.transform.up;
                distance = 1;
            }
            GameObject hoeclone = Instantiate(hoe, transform.position + direction * distance, hoe.transform.rotation) as GameObject;
            hoeclone.transform.parent = null;
            weaponstats = hoeclone.GetComponent<WeaponStats>();
            weaponstats.WeaponStrength = Random.Range(10, 20) * levelmultiplier;
            rend = hoeclone.GetComponentsInChildren<Renderer>();

            if (CaveMound)
            {
                Vector3 fixPos = new Vector3(1, -2, 1);
                hoeclone.transform.localPosition = hoeclone.transform.position + fixPos;

            }
            weaponismade = true;
            Destroy(gameObject, 1);

            StopCoroutine(Createhoe());
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

                    StartCoroutine(Createhoe());


                    StopCoroutine(Createhoe());
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

                    StartCoroutine(Createhoe());
                    gameObject.GetComponent<Collider>().enabled = false;
                    gameObject.GetComponentInChildren<Renderer>().enabled = false;


                    StopCoroutine(Createhoe());
                }

            }
            if (!canMine)
            {
                //Debug.Log("Cannot Mine");
            }
        }
    }
}
