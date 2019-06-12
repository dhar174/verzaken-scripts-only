using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveGun : MonoBehaviour {
    public bool CaveMound;

    public GameObject gun;
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

    private IEnumerator Creategun()
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
            GameObject gunclone = Instantiate(gun, transform.position + direction * distance, gun.transform.rotation) as GameObject;
            gunclone.transform.parent = null;
            weaponstats = gunclone.GetComponent<WeaponStats>();
            weaponstats.WeaponStrength = Random.Range(10, 20) * levelmultiplier;
            rend = gunclone.GetComponentsInChildren<Renderer>();

            if (CaveMound)
            {
                Vector3 fixPos = new Vector3(1, -2, 1);
                gunclone.transform.localPosition = gunclone.transform.position + fixPos;

            }
            weaponismade = true;
            Destroy(gameObject, 1);

            StopCoroutine(Creategun());
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
                    
                    StartCoroutine(Creategun());


                    StopCoroutine(Creategun());
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

                    StartCoroutine(Creategun());
                    gameObject.GetComponent<Collider>().enabled = false;
                    gameObject.GetComponentInChildren<Renderer>().enabled = false;


                    StopCoroutine(Creategun());
                }

            }
            if (!canMine)
            {
                //Debug.Log("Cannot Mine");
            }
        }
    }
}
