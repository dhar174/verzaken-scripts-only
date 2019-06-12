using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplosionManager : MonoBehaviour {
    public static GameObject[] splosions;
    private static int index1;
	// Use this for initialization
	void Start () {
        splosions = GameObject.FindGameObjectsWithTag("Splosion");
        foreach(GameObject g in splosions)
        {
            g.SetActive(false);
        }
        index1 = 0;
        
	}

    public static void GiveSplosion(Vector3 pos)
    {
        splosions[index1].transform.position = pos;
        
    }

    public static void Blowsplosion()
    {
        splosions[index1].SetActive(true);

    }


    public  IEnumerator ReturnSplosion()
    {
        yield return new WaitForSeconds(10);
        splosions[index1].SetActive(false);
        splosions[index1].transform.GetChild(1).gameObject.SetActive(true);
        index1++;
        if (index1 > splosions.Length)
        {
            index1 = 0;
        }
        StopCoroutine(ReturnSplosion());
    }

	// Update is called once per frame
	void Update () {
		
	}
}
