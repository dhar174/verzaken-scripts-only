using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRelativeYaxis : MonoBehaviour {
    public Vector3 originalPos;
    public float distFromOrigPosUp;
    public float distFromOrigPosDown;

    public Vector3 recentPos;
    public float maxDistance;
    public int count;
    public int time;
    public float distance;
    public int timesFixed;
    public int timesFixedXonly;
    
	// Use this for initialization
	void Start () {
        originalPos = transform.localPosition;
        if (maxDistance == 0)
        {
            maxDistance = .5f;
        }
        if (time == 0)
        {
            time = 120;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.localPosition.x <= (originalPos.x - maxDistance))
        {
            distFromOrigPosUp = originalPos.x - transform.localPosition.x;
            transform.localPosition = new Vector3(originalPos.x, transform.localPosition.y, transform.localPosition.z);
            timesFixedXonly++;
        }
        if (transform.localPosition.x >= (originalPos.x + maxDistance))
        {
            distFromOrigPosDown = originalPos.x + transform.localPosition.x;

            transform.localPosition = new Vector3(originalPos.x, transform.localPosition.y, transform.localPosition.z);
            timesFixedXonly++;
        }
        count++;
        if (count == 12)
        {
            count = 0;
            distance = Vector3.Distance(transform.localPosition, recentPos);
            if (Vector3.Distance(transform.position, recentPos)<=100)
            {
                
                transform.localPosition = recentPos;
                timesFixed++;
            }
           
            
                recentPos = transform.localPosition;
            
        }
    }
}
