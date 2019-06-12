using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PutPlayerAtCaveStart : MonoBehaviour {
    public Transform player;
    public bool loaded=false;
    public ArmSwinger arm;
    public GameObject vrcam;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("[VRTK]"))
        {
            player = GameObject.Find("[VRTK]").transform;

            player.position = gameObject.transform.position;
        }

        arm = GameObject.FindGameObjectWithTag("Player").GetComponent<ArmSwinger>();
        //arm.anglePreventionsPaused = true;
        //arm.playAreaHeightAdjustmentPaused = true;
        //arm.preventionsPaused = true;
        //arm.wallClipPreventionPaused = true;
        StartCoroutine(PutPlayer());
	}

    public IEnumerator PutPlayer()
    {

        yield return new WaitForSeconds(1);
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position; ;

            player.position = gameObject.transform.position;
        }
        StopCoroutine(PutPlayer());
        yield return null;
    }

    private void Update()
    {
        if (vrcam == null)
        {
            vrcam = GameObject.FindGameObjectWithTag("Player");
        }
        if(vrcam.transform.parent==null)
        {
            print("fixing deparenting");
            vrcam.transform.SetParent(player.Find("SteamVR").transform);
        }

    }


}
