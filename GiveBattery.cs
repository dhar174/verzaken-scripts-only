using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBattery : MonoBehaviour {
    public bool CaveMound;

    public GameObject battery;
    //public int weaponCounter;
    //public int weaponMax;
    private Transform thispilelocation;

    private bool weaponismade;

    private int pileHitCounter;
    private int pileHitMax;




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

    private IEnumerator CreateBattery()
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
            GameObject batteryclone = Instantiate(battery, transform.position + direction * distance, battery.transform.rotation) as GameObject;



            if (CaveMound)
            {
                Vector3 fixPos = new Vector3(1, -2, 1);
                batteryclone.transform.localPosition = batteryclone.transform.position + fixPos;

            }
            weaponismade = true;
            Destroy(gameObject, 1);

            StopCoroutine(CreateBattery());
            yield return null;
        }
        weaponismade = true;
        yield return null;
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

                    StartCoroutine(CreateBattery());


                    StopCoroutine(CreateBattery());
                    canMine = false;
                }

            }
        }
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

                    StartCoroutine(CreateBattery());
                    gameObject.GetComponent<Collider>().enabled = false;
                    gameObject.GetComponentInChildren<Renderer>().enabled = false;


                    StopCoroutine(CreateBattery());
                }

            }
            if (!canMine)
            {
                //Debug.Log("Cannot Mine");
            }
        }
    }
}
