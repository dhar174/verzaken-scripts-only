using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWall : MonoBehaviour {
    public int pileHitCounter;
    private int pileHitMax;
    public bool canMine;
    public Transform player;

    public AudioSource audiosource;
    public AudioClip mine;
    public AudioClip crumble;

    // Use this for initialization
    void Start () {
        pileHitCounter = 0;
        pileHitMax = Random.Range(1, 5);
        canMine = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        audiosource = gameObject.GetComponent<AudioSource>();
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
                audiosource.clip = mine;
                audiosource.Play();
                pileHitCounter += 1;
                if (pileHitCounter > pileHitMax)
                {
                    audiosource.Stop();
                    audiosource.clip = crumble;
                    audiosource.Play();
                    
                    canMine = false;
                    Destroy(gameObject, .2f);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, gameObject.transform.position) < 35)
        {

            if (Input.GetButtonDown("Mine"))
            {

                if (canMine)
                {

                    pileHitCounter += 1;
                    if (pileHitCounter > pileHitMax)
                    {

                        Destroy(gameObject, .2f);
                    }

                }
                if (!canMine)
                {
                    //Debug.Log("Cannot Mine");
                }
            }
        }
    }
}
