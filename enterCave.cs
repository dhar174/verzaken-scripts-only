using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;


public class enterCave : MonoBehaviour {
    public NextIsland nxtIsland;
    public CharacterStats cstats;

    // Use this for initialization
    void Start () {
        if (!nxtIsland)
        {
            nxtIsland = GameObject.FindGameObjectWithTag("Portal").GetComponent<NextIsland>();
        }
        cstats =    GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nxtIsland)
            {
                NextIsland.levelRestarted = true;
                nxtIsland.islevelrestarted = NextIsland.levelRestarted;
            }
            if (GameModeScript.GameMode == 1)
            {
                //cstats.Save();
                //Temporarily commented out of VR version

                if (LevelProgression.MasterLevelMultiplier == 4)
                {
                    GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = false;

                    SteamVR_LoadLevel.Begin("smallcave1");
                    //SceneManager.LoadScene(2);
                }
                if (LevelProgression.MasterLevelMultiplier == 9)
                {
                    GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = false;

                    SteamVR_LoadLevel.Begin("bosstest");
                    //SceneManager.LoadScene("bosstest");
                }
                if (LevelProgression.MasterLevelMultiplier == 14)
                {
                    GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = false;

                    SteamVR_LoadLevel.Begin("smallcave2");
                    //SceneManager.LoadScene("smallcave2");
                }
                if (LevelProgression.MasterLevelMultiplier == 19)
                {
                    GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = false;

                    SteamVR_LoadLevel.Begin("bosscave2");
                    //SceneManager.LoadScene("bosscave2");
                }
                if (LevelProgression.MasterLevelMultiplier == 24)
                {
                    GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = false;

                    SteamVR_LoadLevel.Begin("smallcave3");
                   // SceneManager.LoadScene("smallcave3");
                }
                if (LevelProgression.MasterLevelMultiplier == 29)
                {
                    //SteamVR_LoadLevel.Begin("finaldungeon");
                    GameObject.Find("RightController").GetComponent<AirsigPickaxe>().enabled = false;

                    //SceneManager.LoadScene("finaldungeon");
                    StartCoroutine(loadFinal());
                }
            }
        }
    }

    public IEnumerator loadFinal()
    {
        if (PopupManager.showedLoading)
        {
            SceneManager.LoadScene("finaldungeon");
            StopCoroutine(loadFinal());
        }
        else
        {

            yield return new WaitForSeconds(2);
           
            StartCoroutine(loadFinal());
            yield return null;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!nxtIsland)
        {

        }
    }
}
