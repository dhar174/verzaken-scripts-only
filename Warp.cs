using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Warp : MonoBehaviour {
    public bool level5;
    public Pause pausescript;
    public bool AllItems;

    // Use this for initialization
    void Start () {
        pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

        if (level5)
        {
            GameObject alias = GameObject.Find("RightController").gameObject;
            alias.SetActive(false);
            pausescript.MenuOff();
            //VRTK.VRTK_SDKManager.instance.UnloadSDKSetup();
           // SceneManager.LoadScene("finaldungeon");
            //SteamVR_LoadLevel.Begin("finaldungeon");
            pausescript.MenuOn();
            pausescript.MenuOff();
            //alias.SetActive(true);
            //alias.SetActive(false);
            //alias.SetActive(true);
            //alias.SetActive(false);
            //alias.SetActive(true);
            StartCoroutine(fixer());

        }
        if (AllItems)
        {
           ItemInventory.hasMicrocontroller =true;
            ItemInventory.hasTNT = true;
            ItemInventory.hasStopwatch = true;
            ItemInventory.hasBattery = true;
            ItemInventory.hasSnorkel = true;
            ItemInventory.hasAtlas = true;
            ItemInventory.hasDiskette = true;
            ItemInventory.hasHeadphones = true;
            ItemInventory.hasRAM = true;
            ItemInventory.hasPottery = true;
            ItemInventory.hasSprocket = true;
            ItemInventory.hasSnibbet = true;
            ItemInventory.hasCrucible = true;
            ItemInventory.hasStatuette = true;
            ItemInventory.hasToytrain = true;
            ItemInventory.hasVintagephone = true;
            ItemInventory.hasGoblet = true;
            ItemInventory.hasBaseballcap = true;
            ItemInventory.has3doconsole = true;
            ItemInventory.hasHuntinghorn = true;
            ItemInventory.hasOldbottle = true;
        }
    }


    public IEnumerator fixer()
    {
        if (PopupManager.showedLoading)
        {
            SceneManager.LoadScene("finaldungeon");
            StopCoroutine(fixer());
        }
        else
        {

            yield return new WaitForSeconds(1);
            pausescript.enabled = false;
            pausescript.enabled = true;
            pausescript.MenuOff();
            StartCoroutine(fixer());
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
