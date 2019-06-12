using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class ObjectPopulation : MonoBehaviour {

    public GameObject[] piles;
    public GameObject[] trees;
    public GameObject[] treeGroups;
    public GameObject[] rocks;
    public GameObject[] smallGrasses;
    public GameObject[] expensiveGrasses;
    public GameObject[] monsters;
    public GameObject[] mountains;
    public GameObject[] mountainsbrown;
    public GameObject[] ponds;

    public Material[] brownMTmats;

    public GameObject playerGO;
    public Vector3 playerPOSvector3;
    public Vector2 playerPOSvector2;

    private pickaxeControl pickaxescript;



    public GameObject portal;
    public GameObject[] sprites;
    public GameObject[] navpoints;
    public Quaternion portalRotation;
    public Quaternion caveRotation;


    private GameObject caveOpening;
    public GameObject caveOpeningBrown;
    public GameObject caveOpeningGreenOriginal;

    public int navpointIndex;
    public int navpointCounter;
    public int navpointMax;
    public bool populatenavpoints;

    public int pilesindex;
    public int pilescounter;
    public int pilesmax;
    public bool populatepiles;

    public int spriteindex;
    public int spritecounter;
    public int spritemax;
    public bool populatesprites;

    public int monsterIndex;
    public int monsterCounter;
    public int monsterMax;

    public int mountainIndex;
    public int mountainCounter;
    public int mountainMax;

    public int whichMountains;

    //public bool fixmountains;

    public int treesIndex;
    public int treesCounter;
    public int treesMax;

    public int treeGroupIndex;
    public int treeGroupCounter;
    public int treeGroupMax;
    public bool populateTreeGroups;

    public int rocksIndex;
    public int rocksCounter;
    public int rocksMax;

    public int smallGrassIndex;
    public int smallGrassCounter;
    public int smallGrassMax;

    public int radialGrassIndex;
    public int radialGrassCounter;
    public int radialGrassMax;
    public List<GameObject> radiusGrasses = new List<GameObject>();

    public int bigGrassIndex;
    public int bigGrassCounter;
    public int bigGrassMax;

    public bool populateSmallGrasses;
    public bool populateGrassinRadius;
    public bool fullgrass;
    public bool populateExpensiveGrasses;


    public Transform spawnLocation;

    
    public bool populatetrees;
    public bool populaterocks;
    public bool populatemonsters;
    public bool populatemountains;
    public bool populatevillages;
    float posx;
    float posz;
    private Vector3 pos;
    private RectTransform rectTransform;
    private Vector3 p = new Vector3();

    public GameObject center;
    public MountainMinder Mountainminder;
    public bool mountainisfixed;

    private int portalCounter;
    public bool populateportals;

    public bool populateCaveOpening;
    public int  caveCounter;

    public bool populateponds;
    public int pondCounter;
    public int pondMax;
    public int pondIndex;

    public int levelmultiplier;

    public bool continued;

    public  GameObject loadscreen;

    public  Pause pause;

    // Use this for initialization
    void Start () {
        populateportals = true;
        pause = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();

        GameObject m = GameObject.FindGameObjectWithTag("MountainManager");

        whichMountains = Random.Range(1, 3);

        loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");

        levelmultiplier = LevelProgression.MasterLevelMultiplier;
        Debug.Log("ObjPop thinks island is " + levelmultiplier);

        if(levelmultiplier <= 10)
        {
            //this is where we manipulate enemy number (monsterMax) according to level.
        }
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerPOSvector3 = playerGO.transform.position;

        if(levelmultiplier <= 3)
        {
            populateCaveOpening = false;
        }
        if(levelmultiplier == 4)
        {
            
            populateCaveOpening = true;
        }
        if (levelmultiplier > 4 && levelmultiplier < 9)
        {
            populateCaveOpening = false;
        }
        if (levelmultiplier == 9)
        {
            populateCaveOpening = true;
        }
        if (levelmultiplier > 9 && levelmultiplier < 14)
        {
            populateCaveOpening = false;
        }
        if (levelmultiplier == 14)
        {
            populateCaveOpening = true;
        }
        if (levelmultiplier > 14 && levelmultiplier < 19)
        {
            populateCaveOpening = false;
        }
        if (levelmultiplier == 19)
        {
            populateCaveOpening = true;
        }
        if (levelmultiplier > 19 && levelmultiplier < 24)
        {
            populateCaveOpening = false;
        }
        if (levelmultiplier == 24)
        {
            populateCaveOpening = true;
        }
        if (levelmultiplier > 24 && levelmultiplier < 29)
        {
            populateCaveOpening = false;
        }
        if (levelmultiplier == 29)
        {
            populateCaveOpening = true;
        }
       // pickaxescript = GameObject.Find("pickaxe").GetComponent<pickaxeControl>();
        //pickaxescript.enabled = false;

        fullgrass = false;
        Mountainminder = m.GetComponent<MountainMinder>();
        //fixmountains = GameObject.FindGameObjectWithTag("MountainManager").GetComponent<MountainMinder>().mustfixmountains;
        center = GameObject.Find("Center");
        //StartCoroutine(portalplacement());
        StartCoroutine(StartDelayed());
        StartCoroutine(smallGrassgeneration());
        StartCoroutine(pilegeneration());
        StartCoroutine(spritegenerator());
        StartCoroutine(treegeneration());
        StartCoroutine(treeGroupgeneration());
        StartCoroutine(monstergeneration());
        //StartCoroutine(mountaingeneration());
        StartCoroutine(rockgeneration());
        StartCoroutine(navpointgeneration());
        StartCoroutine(pondgeneration());
        if (populateGrassinRadius)
        {
            StartCoroutine(RadialGrass());
        }

        Physics.defaultSolverIterations = 5;
        Physics.defaultSolverVelocityIterations = 1;

	}
    public void StartNow() { }
    public IEnumerator StartDelayed()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(portalplacement());

    }


    IEnumerator mountaingeneration()
    {
        
        while (populatemountains)
        {
           // pickaxescript.enabled = false;
            spawnLocation.transform.position = center.transform.position;
            mountainIndex = Random.Range(0, mountains.Length);
            //yield return new WaitForSecondsRealtime(1);
            GameObject thismountain = Instantiate(mountains[mountainIndex], spawnLocation) as GameObject;
         
            thismountain.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thismountain.transform.parent = null;
            yield return new WaitForFixedUpdate();

            if (mountainCounter >= mountainMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populatemountains = false;
                MountainRules.mountainsDone = true;

                yield return new WaitForFixedUpdate();

                StopCoroutine(mountaingeneration());
                loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");

                if (!loadscreen)
                {
                    loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");
                    //yield return null;
                }
                else
                {
                    loadscreen.SetActive(false);
                    PopupManager.showedLoading = true;
                }

                //loadscreen.SetActive(false);
              //  pickaxescript.enabled = true;
               // PopupManager.showedLoading = true;

            }
            while (Mountainminder.mustfixmountains == true)
            {
                thismountain.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
                yield return new WaitForFixedUpdate();

                if (mountainisfixed)
                {
                    //yield return new WaitForEndOfFrame();
                    Mountainminder.mustfixmountains = false;
                    yield return new WaitForFixedUpdate();

                    //yield return null;
                }
                //Destroy(thismountain);

                //  yield return new WaitForSecondsRealtime(3);
                //yield return new WaitForEndOfFrame();


                //mountainisfixed = true;
                //mountainCounter = mountainCounter -= 1;
                //Mountainminder.mustfixmountains = false;
                //yield return null;

            }
            mountainCounter = mountainCounter += 1;
            Mountainminder.mustfixmountains = false;
        }
        yield return null;
    }

    IEnumerator brownmountaingeneration()
    {
        while (populatemountains)
        {
            
            
            //pickaxescript.enabled = false;
            spawnLocation.transform.position = center.transform.position;
            mountainIndex = Random.Range(0, mountains.Length);
            //yield return new WaitForSecondsRealtime(1);
            GameObject thismountain = Instantiate(mountainsbrown[mountainIndex], spawnLocation) as GameObject;

            thismountain.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thismountain.transform.parent = null;
            yield return new WaitForFixedUpdate();

            if (mountainCounter >= mountainMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populatemountains = false;
                MountainRules.mountainsDone = true;
                yield return new WaitForFixedUpdate();
               // pickaxescript.enabled = true;

                StopCoroutine(brownmountaingeneration());
               
                    //loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");

                
                //loadscreen.SetActive(false);
                //PopupManager.showedLoading = true;

                if (!loadscreen)
                {
                    loadscreen = GameObject.FindGameObjectWithTag("LoadScreen");
                }



                if (loadscreen != null)
                {
                    loadscreen.SetActive(false);
                    PopupManager.showedLoading = true;
                }


            }
            while (Mountainminder.mustfixmountains == true)
            {
                thismountain.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
                yield return new WaitForFixedUpdate();

                if (mountainisfixed)
                {
                    Mountainminder.mustfixmountains = false;
                    yield return new WaitForFixedUpdate();
                    //yield return null;
                }
                //Destroy(thismountain);

                //  yield return new WaitForSecondsRealtime(3);
                //yield return new WaitForEndOfFrame();


                //mountainisfixed = true;
                //mountainCounter = mountainCounter -= 1;
                //Mountainminder.mustfixmountains = false;
                //yield return null;

            }
            mountainCounter = mountainCounter += 1;
            Mountainminder.mustfixmountains = false;
        }
        
        yield return null;
    }

    IEnumerator treegeneration()
    {
        while (populatetrees)
        {
            spawnLocation.transform.position = center.transform.position;
            treesIndex = Random.Range(0, trees.Length);
            GameObject thistree = Instantiate(trees[treesIndex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thistree.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thistree.transform.parent = null;
            treesCounter = treesCounter += 1;

            if (treesCounter >= treesMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populatetrees = false;
                StopCoroutine(treegeneration());

            }
        }
        yield return null;
    }

    IEnumerator treeGroupgeneration()
    {
        while (populateTreeGroups)
        {
            spawnLocation.transform.position = center.transform.position;
            treeGroupIndex = Random.Range(0, trees.Length);
            GameObject thistreegroup = Instantiate(treeGroups[treeGroupIndex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thistreegroup.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thistreegroup.transform.parent = null;
            treeGroupCounter = treeGroupCounter += 1;

            if (treeGroupCounter >= treeGroupMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populateTreeGroups = false;
                StopCoroutine(treeGroupgeneration());

            }
        }
        yield return null;
    }

    IEnumerator pondgeneration()
    {
        while (populateponds)
        {
            spawnLocation.transform.position = center.transform.position;
            pondIndex = Random.Range(0, ponds.Length);
            GameObject thispond = Instantiate(ponds[pondIndex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thispond.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thispond.transform.parent = null;
            pondCounter = pondCounter += 1;

            if (pondCounter >= pondMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populateponds = false;
                StopCoroutine(pondgeneration());

            }
        }
        yield return null;
    }

    IEnumerator portalplacement()
    {
        while (populateportals)
        {
            spawnLocation.transform.position = center.transform.position;
            portalRotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);
            GameObject thisportal = Instantiate(portal, spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thisportal.transform.position = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
            thisportal.transform.rotation = portalRotation;
            thisportal.transform.parent = null;
            
            portalCounter= portalCounter += 1;

            levelmultiplier = LevelProgression.MasterLevelMultiplier;
            Debug.Log("ObjPop thinks island is " + levelmultiplier);

            if (levelmultiplier <= 3)
            {
                populateCaveOpening = false;
            }
            if (levelmultiplier > 4 && levelmultiplier < 9)
            {
                populateCaveOpening = false;
            }
            if (levelmultiplier == 4)
            {

                populateCaveOpening = true;
            }
            
            if (levelmultiplier > 9 && levelmultiplier < 14)
            {
                populateCaveOpening = false;
            }
            if (levelmultiplier == 9)
            {
                populateCaveOpening = true;
            }
            if (levelmultiplier > 14 && levelmultiplier < 19)
            {
                populateCaveOpening = false;
            }
            if (levelmultiplier == 14)
            {
                populateCaveOpening = true;
            }
            if (levelmultiplier > 19 && levelmultiplier < 24)
            {
                populateCaveOpening = false;
            }
            if (levelmultiplier == 19)
            {
                populateCaveOpening = true;
            }
            if (levelmultiplier > 24 && levelmultiplier < 29)
            {
                populateCaveOpening = false;
            }
            if (levelmultiplier == 24)
            {
                populateCaveOpening = true;
            }
            
            if (levelmultiplier == 29)
            {
                populateCaveOpening = true;
            }

            if (populateCaveOpening)
            {
                Destroy(thisportal);
                spawnLocation.transform.position = center.transform.position;
                caveRotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);

                if(whichMountains == 1)
                {
                    caveOpening = caveOpeningGreenOriginal;
                }

                if(whichMountains == 2)
                {
                    caveOpening = caveOpeningBrown;
                }
                GameObject thiscave = Instantiate(caveOpening, spawnLocation) as GameObject;
                //rectTransform = thispile.GetComponent<RectTransform>();
                //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
                thiscave.transform.position = new Vector3(Random.Range(-450, 450), 0, Random.Range(-450, 450));
                thiscave.transform.rotation = portalRotation;
                thiscave.transform.parent = null;

                caveCounter = caveCounter += 1;
                if (caveCounter >= 1)
                {
                    populateCaveOpening = false;
                }
            }

            if (portalCounter >= 1)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populateportals = false;
                GameObject.Find("MoundLimiter").GetComponent<MoundLimit>().PopulateMoundList();
               
                if(whichMountains == 1)
                {
                    StartCoroutine(mountaingeneration());
                    GameObject mountainWallsbrown = GameObject.Find("Mountain Walls Brown");
                    GameObject mountainWallsgreen = GameObject.Find("Mountain Walls Green");
                    mountainWallsgreen.SetActive(true);
                    mountainWallsbrown.SetActive(false);
                }
                //StartCoroutine(mountaingeneration());
                if(whichMountains == 2)
                {
                    StartCoroutine(brownmountaingeneration());
                    GameObject mountainWallsbrown = GameObject.Find("Mountain Walls Brown");
                    GameObject mountainWallsgreen = GameObject.Find("Mountain Walls Green");
                    mountainWallsgreen.SetActive(false);
                    mountainWallsbrown.SetActive(true);
                    


                    
                }
                StopCoroutine(portalplacement());



            }
            
        }
        yield return null;
    }


    IEnumerator navpointgeneration()
    {
        while (populatenavpoints)
        {
            spawnLocation.transform.position = center.transform.position;
            navpointIndex = Random.Range(0, navpoints.Length);
            GameObject thisnavpoint = Instantiate(navpoints[navpointIndex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thisnavpoint.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thisnavpoint.transform.parent = null;
            navpointCounter = navpointCounter += 1;

            if (navpointCounter >= navpointMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populatenavpoints = false;
                StopCoroutine(navpointgeneration());

            }
        }
        yield return null;
    }


    IEnumerator rockgeneration()
    {
        while (populaterocks)
        {
            spawnLocation.transform.position = center.transform.position;
            rocksIndex = Random.Range(0, rocks.Length);
            GameObject thisrock = Instantiate(rocks[rocksIndex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thisrock.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thisrock.transform.parent = null;
            rocksCounter = rocksCounter += 1;

            if (rocksCounter >= rocksMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populaterocks = false;
                StopCoroutine(rockgeneration());

            }
        }
        yield return null;
    }

    IEnumerator smallGrassgeneration()
    {
        while (populateSmallGrasses)
        {
            spawnLocation.transform.position = center.transform.position;
            smallGrassIndex = Random.Range(0, rocks.Length);
            GameObject thisGrass = Instantiate(smallGrasses[smallGrassIndex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thisGrass.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thisGrass.transform.parent = null;
            smallGrassCounter = smallGrassCounter += 1;

            if (smallGrassCounter >= smallGrassMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populateSmallGrasses = false;
                StopCoroutine(smallGrassgeneration());

            }
        }
        




        yield return null;
    }

    IEnumerator RadialGrass()
    {

        //StartCoroutine(DestroyGrassOutOfBounds());
        while (!fullgrass)
        {
            GameObject thisradialGrass = Instantiate(smallGrasses[radialGrassIndex], Random.insideUnitSphere * 100 + playerPOSvector3, Quaternion.identity) as GameObject;
            thisradialGrass.transform.position = new Vector3(thisradialGrass.transform.position.x,0, thisradialGrass.transform.position.z);
            radialGrassCounter = radialGrassCounter += 1;
            radiusGrasses.Add(thisradialGrass);
            if (radialGrassCounter >= radialGrassMax)
            {

                fullgrass = true;
                populateGrassinRadius = true;
                StopCoroutine(RadialGrass());

            }

        }
        
        
        yield return null;
    }

    public void RadialGrassPostLoad()
    {
        if (!fullgrass)
        {
            GameObject thisradialGrass = Instantiate(smallGrasses[radialGrassIndex], Random.insideUnitSphere * 100 + playerPOSvector3, Quaternion.identity) as GameObject;
           
            thisradialGrass.transform.position = new Vector3(thisradialGrass.transform.position.x, 0, thisradialGrass.transform.position.z);

            if (Vector3.Distance(thisradialGrass.transform.position, playerPOSvector3) < 40)
            {
                Destroy(thisradialGrass);
                RadialGrassPostLoad();
            }
            if (Vector3.Distance(thisradialGrass.transform.position, playerPOSvector3) >= 40)
            {
                radialGrassCounter = radialGrassCounter += 1;
                radiusGrasses.Add(thisradialGrass);
            }

           
            if (radialGrassCounter >= radialGrassMax)
            {

                fullgrass = true;
                populateGrassinRadius = true;
               

            }
        }

    }


   // IEnumerator DestroyGrassOutOfBounds()
 //   {
  //      while (populateGrassinRadius)
  //      {
  //          if (radialGrassCounter < radialGrassMax)
  //          {

  //              fullgrass = false;
  //              populateGrassinRadius = false;

   //         }
   //         foreach (GameObject RG in radiusGrasses)
   //         {
   //             if (Vector3.Distance(RG.transform.position, playerGO.transform.position) > 10)
   //             {
    //                Destroy(RG);
     //               radialGrassCounter = radialGrassCounter -= 1;
    //                Debug.Log("Grass Destroyed");
    //                fullgrass = false;
                   
    //            }
     //       }
    //    }
  //      yield return null;
  //  }


    IEnumerator monstergeneration()
    {
        while (populatemonsters)
        {
            spawnLocation.transform.position = center.transform.position;
            monsterIndex= Random.Range(0, monsters.Length);
            GameObject thismonster = Instantiate(monsters[monsterIndex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thismonster.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thismonster.transform.parent = null;
            monsterCounter = monsterCounter += 1;

            if (monsterCounter >= monsterMax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populatemonsters = false;
                StopCoroutine(monstergeneration());

            }
        }
        yield return null;
    }

    IEnumerator pilegeneration()
    {
        while (populatepiles)
        {
           
            posx = Random.Range(-500, 500);
            posz = Random.Range(-500, 500);
            pos = new Vector3(posx, 0, posz);
            //Instantiate(spawnLocation, pos);
            spawnLocation.transform.position = center.transform.position;
            pilesindex = Random.Range(0, piles.Length);
            GameObject thispile = Instantiate (piles[pilesindex], spawnLocation) as GameObject;
            //rectTransform = thispile.GetComponent<RectTransform>();
            //p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thispile.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thispile.transform.parent = null;
            pilescounter = pilescounter += 1;
            
            if(pilescounter >= pilesmax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populatepiles = false;
                StopCoroutine(pilegeneration());

            }


        }
        yield return null;



    }

    IEnumerator spritegenerator()
    {
        while (populatesprites)
        {
            spawnLocation.transform.position = center.transform.position;
            spriteindex = Random.Range(0, sprites.Length);
            GameObject thisSprite = Instantiate(sprites[spriteindex], spawnLocation) as GameObject;
            rectTransform = thisSprite.GetComponent<RectTransform>();
            p = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            thisSprite.transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));
            thisSprite.transform.parent = null;
            spritecounter = spritecounter += 1;

            if (spritecounter >= spritemax)
            {
                //spawnLocation.transform.position = new Vector3(-470, 0, -513);
                populatesprites = false;
                StopCoroutine(spritegenerator());

            }
        }
        yield return null;
    }




	// Update is called once per frame
	void Update () {

        if (playerGO)
        {
            playerPOSvector3 = playerGO.transform.position;
            playerPOSvector2 = new Vector2(playerPOSvector3.x, playerPOSvector3.y);
        }
        if (!playerGO)
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");

        }
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
        if (populateGrassinRadius)
        {
            if (radialGrassCounter < radialGrassMax)
            {

                fullgrass = false;
                populateGrassinRadius = true;

            }
           // foreach (GameObject RG in radiusGrasses)
           // {
           //     if (Vector3.Distance(RG.transform.position, playerGO.transform.position) > 10)
           //     {
           //         radiusGrasses.Remove(RG);
           //         Destroy(RG);
                   
           //         radialGrassCounter = radialGrassCounter -= 1;
           //         Debug.Log("Grass Destroyed");
           //         fullgrass = false;

           //     }
           // }
            for (int i = 0; i < radiusGrasses.Count; i++)
            {
                GameObject removedGrass = radiusGrasses[i];
                if (Vector3.Distance(removedGrass.transform.position, playerGO.transform.position) > 101)
                {
                    
                    radiusGrasses.Remove(radiusGrasses[i]);
                    Destroy(removedGrass);

                    radialGrassCounter = radialGrassCounter -= 1;
                    
                    fullgrass = false;
                    RadialGrassPostLoad();
                }
            }
        }
    }
}
