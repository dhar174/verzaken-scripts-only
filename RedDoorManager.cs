using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedDoorManager : MonoBehaviour {
    public GameObject redDoorPanel;
    public GameObject EndDiag;
    public GameObject EndConsole;
	// Use this for initialization
	void Start () {
        StartCoroutine(wait());
        
	}

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(0f);
        
        
        if (SceneManager.GetActiveScene().name != "smallcave2")
        {
            if (LevelProgression.MasterLevelMultiplier == 1)
            {
                redDoorPanel = GameObject.Find("RedDoorPanel").gameObject;
                redDoorPanel.SetActive(false);
            }
        }
        else
        {
            redDoorPanel = GameObject.Find("RedDoorPanel").gameObject;
            redDoorPanel.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name != "finaldungeon")
        {
            if (LevelProgression.MasterLevelMultiplier == 1)
            {
                if (GameObject.Find("EndDiag").gameObject)
                {
                    EndDiag = GameObject.Find("EndDiag").gameObject;
                }
                if (GameObject.Find("EndConsole").gameObject)
                {
                    EndConsole = GameObject.Find("EndConsole").gameObject;
                    EndDiag.SetActive(false);
                    EndConsole.SetActive(false);
                }
            }
        }
        else
        {
             Destroy(this);
            //GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>().MenuOff();
        }
        StopCoroutine(wait());
    }


    public void ActivateRed()
    {
        redDoorPanel.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
