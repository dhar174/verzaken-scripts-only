using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameModeScript : MonoBehaviour {


    public static int GameMode;   // 0= Arcade, 1=Classic/Story

    public static bool gameisstarted;

    public int gamemodecheck;
    public bool gamestartedcheck;

    public BtnManager btnman;
    public GameObject menupanel1;
    public GameObject menupanel2;


    // Use this for initialization
    void Start () {
        btnman = GameObject.Find("BtnManager").GetComponent<BtnManager>();
        if (GameObject.FindGameObjectWithTag("MenuPanel1"))
        {
            menupanel1 = GameObject.FindGameObjectWithTag("MenuPanel1");
        }
        if(GameObject.FindGameObjectWithTag("MenuPanel2")){
            menupanel2 = GameObject.FindGameObjectWithTag("MenuPanel2");
        }
        if (GameObject.FindGameObjectWithTag("MenuPanel2"))
        {
            menupanel2.SetActive(false);
        }



        if (!gameisstarted)
        {
            //this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            gameisstarted = true;
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }

    }


    public void SetClassicMode()
    {
        GameMode = 1;
        menupanel1.SetActive(false);
        menupanel2.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("NewGameButton"), null);


    }

    public void SetArcadeMode()
    {
        GameMode = 0;
    }
	
	// Update is called once per frame
	void Update () {
        gamemodecheck = GameMode;
        gamestartedcheck = gameisstarted;
	}
}
