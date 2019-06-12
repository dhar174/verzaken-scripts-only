using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TileBehavior : MonoBehaviour {

    public GameObject[] Tiles;
    public int n;
    public int ncounter;
    //public float firsttilex;
    //public float firsttiley;
    //public float firsttilez;
    public GameObject currenttile;
    public bool sort;
    public Material[] materials;
    public Renderer rend;
    public int matindex;
    public int tilelengthcheck;
    // Use this for initialization
    void Start () {



        
        n = 0;
        matindex = 0;
        
        //Tiles = GameObject.FindGameObjectsWithTag("Tiles");
        
        
        //currenttile = Tiles[n];

        //firsttilex = Tiles[0].transform.position.x;
        //firsttiley = Tiles[0].transform.position.y;
        //firsttilez = Tiles[0].transform.position.z;

        sort = true;
        StartCoroutine("DistributeTiles");
    }



    IEnumerator DistributeTiles()
    {



        while (sort)
        {
            n = Random.Range(0, Tiles.Length);
            currenttile = Tiles[n];
            rend = currenttile.GetComponentInChildren<Renderer>();
            matindex = Random.Range(0, materials.Length);
            
            //currenttile += n;
            //n = currenttile += n;
            yield return new WaitForSecondsRealtime(1);
            Debug.Log("Instantiate Now");
            //print("Hello");
            currenttile.transform.position = new Vector3(currenttile.transform.position.x + (n + Random.Range(1,30)), 0, currenttile.transform.position.z + (n + Random.Range(1,30)));
            ncounter = ncounter += 1;
            
            rend.material = materials[matindex];
            
        }

       
        //if(n >= Tiles.Length)
        //{
            //StopCoroutine("DistributeTiles");
        //}
    
        yield return null;
        
    }
    

	// Update is called once per frame
	void Update () {
        //currenttile = Tiles[n];
        if (ncounter >= Tiles.Length)
        {
            sort = false;
            StopCoroutine("DistributeTiles");
        }
        tilelengthcheck = Tiles.Length;
    }
}
