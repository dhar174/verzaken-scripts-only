using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteLookAt : MonoBehaviour {
    public RectTransform rectTransform;
    public Vector3 p = new Vector3();
    public HealthAndDamage thisHealthandDamage;
    public float newscale;

    public GameObject player;
    

	// Use this for initialization
	void Start () {
        rectTransform = gameObject.GetComponent<RectTransform>();
        thisHealthandDamage = gameObject.GetComponentInParent<HealthAndDamage>();
        newscale = thisHealthandDamage.newscale;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (!Camera.main)
        {

            Camera MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            MainCam = Camera.main;
        }
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 100)
        {
            if (Camera.main)
            {
                transform.LookAt(Camera.main.transform.position, Vector3.up);
                transform.Rotate(new Vector3(0, 180, 0));
                //transform.localScale = new Vector3(newscale, newscale, newscale);
                p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            }

        }
        //Debug.Log(p);

    }
}
