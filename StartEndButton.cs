using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndButton : MonoBehaviour {
    public GameObject EndConsole;
    private Pause pausescript;

    // Use this for initialization
    void Start () {
       EndConsole = GameObject.FindGameObjectWithTag("Canvas2").transform.Find("EndConsole").gameObject;
        //EndConsole.SetActive(false);
        pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

    }


    public void StartEndSequence()
    {
        
        pausescript.MenuOff();

        GameObject.FindGameObjectWithTag("endCam").GetComponent<FinalSequence>().EndSequence();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EndConsole.SetActive(false);

    }
    public void StartReboot()
    {
        pausescript.MenuOff();

        StartCoroutine(GameObject.FindGameObjectWithTag("endCam").GetComponent<FinalSequence>().RebootText());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EndConsole.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
