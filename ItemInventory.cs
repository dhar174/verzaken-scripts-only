using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ItemInventory : MonoBehaviour {
    public GameObject[] items;

    public static bool unavailable;

    public static bool hasMicrocontroller;
    public static  bool hasTNT;
    public static  bool hasStopwatch;
    public static bool hasBattery;
    public static bool hasSnorkel;
    public static bool hasAtlas;
    public static bool hasDiskette;
    public static bool hasHeadphones;
    public static bool hasRAM;
    public static bool hasPottery;
    public static bool hasSprocket;
    public static bool hasSnibbet;
    public static bool hasCrucible;
    public static bool hasStatuette;
    public static bool hasToytrain;
    public static bool hasVintagephone;
    public static bool hasGoblet;
    public static bool hasBaseballcap;
    public static bool has3doconsole;
    public static bool hasHuntinghorn;
    public static bool hasOldbottle;

    public  bool hasMicrocontrollerCheck;
    public  bool hasTNTCheck;
    public  bool hasStopwatchCheck;
    public  bool hasBatteryCheck;
    public  bool hasSnorkelCheck;
    public  bool hasAtlasCheck;
    public  bool hasDisketteCheck;
    public  bool hasHeadphonesCheck;
    public  bool hasRAMCheck;
    public  bool hasPotteryCheck;
    public  bool hasSprocketCheck;
    public  bool hasSnibbetCheck;
    public  bool hasCrucibleCheck;
    public  bool hasStatuetteCheck;
    public  bool hasToytrainCheck;
    public  bool hasVintagephoneCheck;
    public  bool hasGobletCheck;
    public  bool hasBaseballcapCheck;
    public  bool has3doconsoleCheck;
    public  bool hasHuntinghornCheck;
    public bool hasOldbottleCheck;



    public bool hasKeycard;

    public Transform[] itemSlots;

    public RawImage[] rendTextures;

    

    public GameObject itemPanel;


    public bool iScreenActive = false;


    public GameObject itemScreen;
    public Pause pauseScript;
    public Canvas canvas2;

    public GameObject itemStage;

    public static bool firstrundone=false;

    public GameObject player;
    // Use this for initialization
    void Start () {

        itemStage = GameObject.FindGameObjectWithTag("ItemStage");
        itemScreen = GameObject.FindGameObjectWithTag("ItemScreen");
        pauseScript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();
        canvas2 = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<Canvas>();
        player = GameObject.FindGameObjectWithTag("Player");
        itemPanel = GameObject.FindGameObjectWithTag("ItemPanel");

        itemSlots = itemPanel.transform.GetComponentsInChildren<Transform>();
        rendTextures = itemPanel.GetComponentsInChildren<RawImage>();
        if (firstrundone)
        {
            if (itemStage.activeSelf)
            {
                itemStage.SetActive(false);
            }
            itemScreen.SetActive(false);
        }
        if (!firstrundone)
        {
            
            hasMicrocontroller = false;
            hasTNT = false;
            hasStopwatch = false;
            hasBattery = false;
            hasSnorkel = false;
            hasAtlas = false;
            hasDiskette = false;
            hasHeadphones = false;
            hasRAM = false;
            hasPottery = false;
            hasSprocket = false;
            hasSnibbet = false;
            hasCrucible = false;
            hasStatuette = false;
            hasToytrain = false;
            hasVintagephone = false;
            hasGoblet = false;
            hasBaseballcap = false;
            has3doconsole = false;
            hasHuntinghorn = false;
            hasOldbottle = false;

            if (player.GetComponent<CharacterStats>().itemInvBool1 == 1)
            {
                ItemInventory.hasMicrocontroller = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool1 == 0)
                {
                    ItemInventory.hasMicrocontroller = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool2 == 1)
            {
                ItemInventory.hasTNT = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool2 == 0)
                {
                    ItemInventory.hasTNT = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool3 == 1)
            {
                ItemInventory.hasStopwatch = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool3 == 0)
                {
                    ItemInventory.hasStopwatch = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool4 == 1)
            {
                ItemInventory.hasBattery = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool4 == 0)
                {
                    ItemInventory.hasBattery = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool5 == 1)
            {
                ItemInventory.hasSnorkel = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool5 == 0)
                {
                    ItemInventory.hasSnorkel = false;
                }
            }


            if (player.GetComponent<CharacterStats>().itemInvBool6 == 1)
            {
                ItemInventory.hasAtlas = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool6 == 0)
                {
                    ItemInventory.hasAtlas = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool7 == 1)
            {
                ItemInventory.hasDiskette = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool7 == 0)
                {
                    ItemInventory.hasDiskette = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool8 == 1)
            {
                ItemInventory.hasHeadphones = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool8 == 0)
                {
                    ItemInventory.hasHeadphones = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool9 == 1)
            {
                ItemInventory.hasRAM = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool9 == 0)
                {
                    ItemInventory.hasRAM = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool10 == 1)
            {
                ItemInventory.hasPottery = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool10 == 0)
                {
                    ItemInventory.hasPottery = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool11 == 1)
            {
                ItemInventory.hasSprocket = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool11 == 0)
                {
                    ItemInventory.hasSprocket = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool12 == 1)
            {
                ItemInventory.hasSnibbet = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool12 == 0)
                {
                    ItemInventory.hasSnibbet = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool13 == 1)
            {
                ItemInventory.hasCrucible = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool13 == 0)
                {
                    ItemInventory.hasCrucible = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool14 == 1)
            {
                ItemInventory.hasStatuette = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool14 == 0)
                {
                    ItemInventory.hasStatuette = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool15 == 1)
            {
                ItemInventory.hasToytrain = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool15 == 0)
                {
                    ItemInventory.hasToytrain = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool16 == 1)
            {
                ItemInventory.hasVintagephone = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool16 == 0)
                {
                    ItemInventory.hasVintagephone = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool17 == 1)
            {
                ItemInventory.hasGoblet = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool17 == 0)
                {
                    ItemInventory.hasGoblet = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool18 == 1)
            {
                ItemInventory.hasBaseballcap = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool18 == 0)
                {
                    ItemInventory.hasBaseballcap = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool19 == 1)
            {
                ItemInventory.has3doconsole = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool19 == 0)
                {
                    ItemInventory.has3doconsole = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool20 == 1)
            {
                ItemInventory.hasHuntinghorn = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool20 == 0)
                {
                    ItemInventory.hasHuntinghorn = false;
                }
            }

            if (player.GetComponent<CharacterStats>().itemInvBool21 == 1)
            {
                ItemInventory.hasOldbottle = true;
            }
            else
            {
                if (player.GetComponent<CharacterStats>().itemInvBool21 == 0)
                {
                    ItemInventory.hasOldbottle = false;
                }
            }








            itemStage.SetActive(false);
            itemScreen.SetActive(false);
            firstrundone = true;
        }
        


    }

    public void OpenItems()
    {
        if (!itemStage)
        {
            itemStage = GameObject.FindGameObjectWithTag("ItemStage");

        }
        if (!itemScreen)
        {
            itemScreen = GameObject.FindGameObjectWithTag("ItemScreen");
        }
        if (!canvas2)
        {
            canvas2 = GameObject.FindGameObjectWithTag("Canvas2").GetComponent<Canvas>();
        }
        // canvas2.renderMode = RenderMode.WorldSpace;
        // canvas2.worldCamera = Camera.main;
        // canvas2.renderMode = RenderMode.ScreenSpaceCamera;

        // foreach(RawImage ri in rendTextures)
        //   {
        //  ri.enabled = false;
        //   }

        itemStage.SetActive(true);
        itemScreen.SetActive(true);

        if (hasMicrocontroller)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[0].enabled = true;



        }

        if (hasTNT)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[1].enabled = true;



        }

        if (hasStopwatch)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[2].enabled = true;



        }

        if (hasBattery)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[3].enabled = true;



        }

        if (hasSnorkel)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[4].enabled = true;



        }

        if (hasAtlas)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[5].enabled = true;



        }

        if (hasDiskette)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[6].enabled = true;



        }

        if (hasHeadphones)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[7].enabled = true;



        }

        if (hasRAM)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[8].enabled = true;



        }

        if (hasPottery)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[9].enabled = true;



        }

        if (hasSprocket)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[10].enabled = true;



        }
        if (hasSnibbet)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[11].enabled = true;



        }
        if (hasCrucible)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[12].enabled = true;



        }
        if (hasStatuette)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[13].enabled = true;



        }
        if (hasToytrain)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[14].enabled = true;



        }
        if (hasVintagephone)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[15].enabled = true;



        }
        if (hasGoblet)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[16].enabled = true;



        }
        if (hasBaseballcap)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[17].enabled = true;



        }
        if (has3doconsole)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[18].enabled = true;



        }
        if (hasHuntinghorn)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[19].enabled = true;



        }
        if (hasOldbottle)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[20].enabled = true;



        }
        if (!hasMicrocontroller)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[0].enabled = false;



        }

        if (!hasTNT)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[1].enabled = false;



        }

        if (!hasStopwatch)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[2].enabled = false;



        }

        if (!hasBattery)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[3].enabled = false;



        }

        if (!hasSnorkel)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[4].enabled = false;



        }

        if (!hasAtlas)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[5].enabled = false;



        }

        if (!hasDiskette)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[6].enabled = false;



        }

        if (!hasHeadphones)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[7].enabled = false;



        }

        if (!hasRAM)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[8].enabled = false;



        }

        if (!hasPottery)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[9].enabled = false;



        }

        if (!hasSprocket)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[10].enabled = false;



        }
        if (!hasSnibbet)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[11].enabled = false;



        }
        if (!hasCrucible)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[12].enabled = false;



        }
        if (!hasStatuette)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[13].enabled = false;



        }
        if (!hasToytrain)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[14].enabled = false;



        }
        if (!hasVintagephone)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[15].enabled = false;



        }
        if (!hasGoblet)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[16].enabled = false;



        }
        if (!hasBaseballcap)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[17].enabled = false;



        }
        if (!has3doconsole)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[18].enabled = false;



        }
        if (!hasHuntinghorn)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[19].enabled = false;



        }
        if (!hasOldbottle)
        {
            //GameObject item1clone = Instantiate(items[0], itemSlots[2]) as GameObject;
            // item1clone.transform.localScale = new Vector3(1500, 1500, 1500);

            rendTextures[20].enabled = false;



        }
        

        if (!iScreenActive)
        {
            iScreenActive = true;
        }

        if (LanguageChange.LangNum == 1)
        {
            GameObject.Find("ItemScreen").transform.Find("ItemPanel").GetComponentInChildren<Text>().text = "文物 集";
        }
        if (LanguageChange.LangNum == 2)
        {
            GameObject.Find("ItemScreen").transform.Find("ItemPanel").GetComponentInChildren<Text>().text = "Artefakte Gesammelte";
        }
        if (LanguageChange.LangNum == 3)
        {
            GameObject.Find("ItemScreen").transform.Find("ItemPanel").GetComponentInChildren<Text>().text = "Артефакты Собранный";
        }
        if (LanguageChange.LangNum == 4)
        {
            GameObject.Find("ItemScreen").transform.Find("ItemPanel").GetComponentInChildren<Text>().text = "Artefactos Recolectados";
        }

    }

    public void Closeitems()
    {
        // print("Close pressed");
        itemScreen.SetActive(false);
        iScreenActive = false;
        //Destroy(weapon1clonereference);
        //Destroy(weapon2clonereference);
        pauseScript.MenuOff();
    }

    public IEnumerator waitbeforeopenagain()
    {
        unavailable = true;
        yield return new WaitForSecondsRealtime(2);
        unavailable = false;
        StopCoroutine(waitbeforeopenagain());
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("ArtifactScreen"))
        {
            if (!unavailable)
            {
                if (!iScreenActive)
                {
                    OpenItems();
                }
                else
                {
                    Closeitems();

                }
            }

        }
        if (Input.GetAxis("ArtifactScreen") > 0)
        {
            if (!unavailable)
            {
                if (!iScreenActive)
                {
                    OpenItems();
                    StartCoroutine(waitbeforeopenagain());
                }
                else
                {
                    Closeitems();
                    StartCoroutine(waitbeforeopenagain());

                }
            }

        }
        if (Input.GetButtonUp("Cancel"))
        {
            if (!unavailable)
            {
                if(iScreenActive)
                {
                    Closeitems();
                    StartCoroutine(waitbeforeopenagain());

                }
            }
        }

        hasMicrocontrollerCheck =hasMicrocontroller;
      hasTNTCheck = hasTNT;
      hasStopwatchCheck=hasStopwatch;
      hasBatteryCheck=hasBattery;
      hasSnorkelCheck=hasSnorkel;
      hasAtlasCheck=hasAtlas;
      hasDisketteCheck=hasDiskette;
      hasHeadphonesCheck=hasHeadphones;
      hasRAMCheck=hasRAM;
      hasPotteryCheck=hasPottery;
      hasSprocketCheck=hasSprocket;
      hasSnibbetCheck=hasSnibbet;
      hasCrucibleCheck= hasCrucible;
      hasStatuetteCheck= hasStatuette;
      hasToytrainCheck= hasToytrain;
      hasVintagephoneCheck= hasVintagephone;
      hasGobletCheck= hasGoblet;
      hasBaseballcapCheck= hasBaseballcap;
      has3doconsoleCheck= has3doconsole;
      hasHuntinghornCheck= hasHuntinghorn;
        hasOldbottleCheck = hasOldbottle;
    }
}
