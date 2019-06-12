using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class BtnManager : MonoBehaviour {
    public CharacterStats cstats;
    public GameModeScript gameModeScript;

    public int levelValueFromSave;

    public bool continued=false;
    public bool runonce;
    public bool runonce2;

    public GameObject playerprefab;
    public GameObject[] players;
    public GameObject player;
    public bool createdplayer;
    public SoundManager soundmanager;


    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //Cursor.lockState = CursorLockMode.Confined;

        //Cursor.lockState = CursorLockMode.None;
       // Cursor.lockState = CursorLockMode.Confined;
       // Cursor.visible = true;
        //Debug.Log("pooped");
        soundmanager = GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>();


    }

   

    public void NewGame()
    {
        LevelProgression.MasterLevelMultiplier = 0;

        players = GameObject.FindGameObjectsWithTag("Player");
       // foreach(GameObject go in players)
      //  {
      //      Destroy(go);
      //      print("Destroyed Player GameObjects");
     //   }
        soundmanager.PlayMenuSound();
        PopupManager.firstgame = true;
        //CharacterStats.menuscene = false;
        SceneManager.LoadScene("testscene");
        player = GameObject.FindGameObjectWithTag("Player");
        cstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        cstats.NewGame();
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            print("no player found, creating now...");
            if (!createdplayer)
            {
                GameObject PlayerCharacter = Instantiate(playerprefab, new Vector3(110, 1, 349), playerprefab.transform.rotation) as GameObject;
                createdplayer = true;
                print("Created Player, Yo");
                player = PlayerCharacter;
            }

        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().enabled == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().enabled = true;
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>())
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled == false)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>())
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled == false)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioListener>().enabled == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioListener>().enabled = true;
        }
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
        ItemInventory.firstrundone = false;
       // SwitchWeapons.pickaxeActive = true;
    }

    public void Continue()
    {
        soundmanager.PlayMenuSound();

        //Debug.Log("Clicked Continue");
        //GameObject.FindGameObjectWithTag("ObjectDistributor").GetComponent<ObjectPopulation>()
        PopupManager.firstgame = false;
        if (GameObject.FindGameObjectWithTag("PopupManager"))
        {
            GameObject.FindGameObjectWithTag("PopUpManager").GetComponent<PopupManager>().deactivateBox();
        }
        gameModeScript = GameObject.Find("GameModeManager").GetComponent<GameModeScript>();
        cstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        //CharacterStats.menuscene = false;
        cstats.Load();
        LevelProgression.MasterLevelMultiplier = cstats.levelMultiplier;

        continued = true;
        if (!runonce)
        {
            StartCoroutine(LoadCaves());
            runonce = true;
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().enabled == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().enabled = true;
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>())
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled == false)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>())
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled == false)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioListener>().enabled == false)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioListener>().enabled = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public IEnumerator LoadCaves()
    {
        yield return new WaitForSeconds(1);
        LevelProgression.MasterLevelMultiplier = cstats.levelMultiplier;
        levelValueFromSave = cstats.levelMultiplier;
            if (levelValueFromSave == 5)
            {
                SceneManager.LoadScene("smallcave1");
                //LevelProgression.MasterLevelMultiplier += 1;
            }
           else
           {
              if (LevelProgression.MasterLevelMultiplier == 10)
              {
                SceneManager.LoadScene("bosstest");
                //LevelProgression.MasterLevelMultiplier += 1;
            }
            else
            {
                if (LevelProgression.MasterLevelMultiplier == 15)
                {
                    SceneManager.LoadScene("smallcave2");
                  //  LevelProgression.MasterLevelMultiplier += 1;
                }
                else
                {
                    if (LevelProgression.MasterLevelMultiplier == 20)
                    {
                        SceneManager.LoadScene("bosscave2");
                      //  LevelProgression.MasterLevelMultiplier += 1;
                    }
                    else
                    {
                        if (LevelProgression.MasterLevelMultiplier == 25)
                        {
                            SceneManager.LoadScene("smallcave3");
                           // LevelProgression.MasterLevelMultiplier += 1;
                        }
                        else
                        {
                            LevelProgression.MasterLevelMultiplier = cstats.levelMultiplier;
                            print("Loaded Overworld Island");
                            SceneManager.LoadScene("testscene");
                            Vector3 fix = new Vector3(0, 60, 0);
                            player.transform.position += fix;
                            print("fixed player?");
                           
                        }
                    }
                }
            }
           // SwitchWeapons.pickaxeActive = true;

        }


        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            if (!createdplayer)
            {
                GameObject PlayerCharacter = Instantiate(playerprefab, new Vector3(110, 1, 349), playerprefab.transform.rotation) as GameObject;
                createdplayer = true;
                player = PlayerCharacter;
            }

        }


        cstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        cstats.Load();
        StopCoroutine(LoadCaves());
        StopAllCoroutines();
    }


    public void ExitGame()
    {
        soundmanager.PlayMenuSound();

        Application.Quit();
    }

    private void Update()
    {
        if (continued)
        {
            if (!cstats)
            {
                if (player)
                {
                    cstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
                    cstats.Load();
                }

            }
        }
        if (!player)
        {
          if(GameObject.FindGameObjectWithTag("Player"))
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }
    }
}

