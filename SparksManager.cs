using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksManager : MonoBehaviour {
    public  GameObject[] sparks;
    private  int index2;
    public  List<GameObject> currSparks = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;
    private  int currIndex;
    // Use this for initialization
    void Start()
    {
        sparks = GameObject.FindGameObjectsWithTag("Spark");
        foreach (GameObject g in sparks)
        {
            g.SetActive(false);
        }
        index2 = 0;

    }

    public void GiveSparks(ContactPoint contact, Quaternion sparkrot, Vector3 sparkpos)
    {
        GameObject now = GetPooledObject();
        now.SetActive(true);
        currSparks.Add(now);
        now.transform.position = sparkpos;
        now.transform.rotation = sparkrot;
        StartCoroutine(ReturnSparks(now));

    }

    

    public  GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < sparks.Length; i++)
        {
            //2
            
                return sparks[i];
            
        }
        //3   
        return null;
    }

    public  IEnumerator ReturnSparks(GameObject nowSpark)
    {
        yield return new WaitForSeconds(.4f);
        nowSpark.SetActive(false);
        currSparks.Remove(nowSpark);
        
        index2++;
        if (index2 > sparks.Length)
        {
            index2 = 0;
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
