using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour {
    public bool CaveMound;

    public GameObject[] weapons;
    public int weaponIndex;
    //public int weaponCounter;
    //public int weaponMax;
    private Transform thispilelocation;
    public WeaponStats weaponstats;

    private bool weaponismade;

    private int pileHitCounter;
    private int pileHitMax;

    public GameObject gameconsole;
    public GameObject toytrain;
    public GameObject pottery;
    public GameObject crucible;
    public GameObject statuette;
    public GameObject telephone;
    public GameObject goblet;
    public GameObject cap;
    public GameObject horn;
    public GameObject bottle;

    public bool artifactmade;

    public GameObject rubble2;

    public Material[] swordMaterialRef;
    public Material[] hammerMaterialRef;
    public Material[] maceMaterialRef;

    private Renderer[] rend;
    private int rendererIndex;
    private int materialIndex;

    public PopupManager popupscript;

    public int levelmultiplier;

    public bool canMine;
    //public int materialCounter;

    public Vector3 direction;
    public float distance;

    public int randomArtifact;

    public AudioSource audiosource;
    public AudioClip mine;
    public AudioClip crumble;


    // Use this for initialization
    void Start () {
        thispilelocation = gameObject.transform;
        pileHitCounter = 0;
        pileHitMax = Random.Range(1, 5);
        weaponismade = false;
        canMine = false;
        levelmultiplier = LevelProgression.MasterLevelMultiplier;
        
        randomArtifact = Random.Range(0, 101);
        audiosource = gameObject.GetComponent<AudioSource>();

    }

    private IEnumerator CreateTreasure()
    {
        if (!popupscript)
        {
            popupscript = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
        }
        GameObject rubble = Instantiate(rubble2, transform.position + direction * distance, rubble2.transform.rotation) as GameObject;
        yield return new WaitForSeconds(2f);
        Collider[] pilecolls = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider c in pilecolls)
        {
            c.enabled = false;
        }
        Renderer[] pilerend = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in pilerend)
        {
            r.enabled = false;
        }

        if (randomArtifact >= 70)
        {
            if (!artifactmade)
            {
                if (CaveMound)
                {
                    direction = gameObject.transform.right;
                    distance = 1;
                }
                if (!CaveMound)
                {
                    direction = gameObject.transform.up;
                    distance = 1;
                }
                weaponismade = true;

                if (!ItemInventory.has3doconsole)
                {
                    GameObject artifact = Instantiate(gameconsole, transform.position + direction * distance, gameconsole.transform.rotation) as GameObject;
                    artifact.transform.parent = null;
                    artifactmade = true;
                    StopCoroutine(CreateTreasure());
                }
                else
                {
                    if (!ItemInventory.hasPottery)
                    {
                        GameObject artifact = Instantiate(pottery, transform.position + direction * distance, pottery.transform.rotation) as GameObject;
                        artifact.transform.parent = null;
                        artifactmade = true;
                        StopCoroutine(CreateTreasure());

                    }
                    else
                    {
                        if (!ItemInventory.hasCrucible)
                        {
                            GameObject artifact = Instantiate(crucible, transform.position + direction * distance, crucible.transform.rotation) as GameObject;
                            artifact.transform.parent = null;
                            artifactmade = true;
                            StopCoroutine(CreateTreasure());


                        }
                        else
                        {
                            if (!ItemInventory.hasStatuette)
                            {
                                GameObject artifact = Instantiate(statuette, transform.position + direction * distance, statuette.transform.rotation) as GameObject;
                                artifact.transform.parent = null;
                                artifactmade = true;
                                StopCoroutine(CreateTreasure());


                            }
                            else
                            {
                                if (!ItemInventory.hasToytrain)
                                {
                                    GameObject artifact = Instantiate(toytrain, transform.position + direction * distance, toytrain.transform.rotation) as GameObject;
                                    artifact.transform.parent = null;
                                    artifactmade = true;

                                    StopCoroutine(CreateTreasure());

                                }
                                else
                                {
                                    if (!ItemInventory.hasVintagephone)
                                    {
                                        GameObject artifact = Instantiate(telephone, transform.position + direction * distance, telephone.transform.rotation) as GameObject;
                                        artifact.transform.parent = null;
                                        artifactmade = true;
                                        StopCoroutine(CreateTreasure());


                                    }
                                    else
                                    {
                                        if (!ItemInventory.hasGoblet)
                                        {
                                            GameObject artifact = Instantiate(goblet, transform.position + direction * distance, goblet.transform.rotation) as GameObject;
                                            artifact.transform.parent = null;
                                            artifactmade = true;

                                            StopCoroutine(CreateTreasure());

                                        }
                                        else
                                        {
                                            if (!ItemInventory.hasBaseballcap)
                                            {
                                                GameObject artifact = Instantiate(cap, transform.position + direction * distance, cap.transform.rotation) as GameObject;
                                                artifact.transform.parent = null;
                                                artifactmade = true;
                                                StopCoroutine(CreateTreasure());

                                            }
                                            else
                                            {
                                                if (!ItemInventory.hasHuntinghorn)
                                                {
                                                    GameObject artifact = Instantiate(horn, transform.position + direction * distance, horn.transform.rotation) as GameObject;
                                                    artifact.transform.parent = null;
                                                    artifactmade = true;
                                                    StopCoroutine(CreateTreasure());

                                                }
                                                else
                                                {
                                                    if (!ItemInventory.hasOldbottle)
                                                    {
                                                        GameObject artifact = Instantiate(bottle, transform.position + direction * distance, bottle.transform.rotation) as GameObject;
                                                        artifact.transform.parent = null;
                                                        artifactmade = true;
                                                        StopCoroutine(CreateTreasure());

                                                    }
                                                    else
                                                    {
                                                        weaponismade = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (!weaponismade)
        {
            weaponIndex = Random.Range(0, weapons.Length);

            if (CaveMound)
            {
                direction = gameObject.transform.right;
                distance = 1;
            }
            if (!CaveMound)
            {
                direction = gameObject.transform.up;
                distance = 1;
            }

             GameObject newweapon = Instantiate(weapons[weaponIndex], transform.position + direction * distance, weapons[weaponIndex].transform.rotation) as GameObject;


            //weaponismade = true;
            //yield return new WaitForFixedUpdate();
            newweapon.transform.parent = null;
            weaponstats = newweapon.GetComponent<WeaponStats>();
            weaponstats.WeaponStrength = Random.Range(10, 20) * levelmultiplier;
            materialIndex = Random.Range(0, swordMaterialRef.Length);
            weaponstats.matInt = materialIndex;

            rend = newweapon.GetComponentsInChildren<Renderer>();
            if (CaveMound)
            {
                Vector3 fixPos = new Vector3(0, -1, 0);
                //Vector3 fixPos = gameObject.transform.position + (gameObject.transform.right * 1.1f );
                newweapon.transform.localPosition = newweapon.transform.position + fixPos;
               
            }

            if (newweapon.name == "battleaxe(Clone)")
            {


                Renderer axerend = newweapon.transform.Find("pCylinder8").GetComponent<Renderer>();


                

                axerend.sharedMaterial = hammerMaterialRef[materialIndex];
                Debug.Log("Created" + newweapon.name);
            }
            if (newweapon.name == "spear(Clone)")
            {

                
                rendererIndex = 0;
                foreach (Renderer i in rend)
                {
                    rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex++;


                }
                //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                rendererIndex = 0;
                   


                //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                Debug.Log("Created" + newweapon.name);
            }
            if (newweapon.name == "lowpolysword(Clone)"){

                rendererIndex = 0;
                foreach (Renderer i in rend)
                {
                    rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex++;


                }
                //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                rendererIndex = 0;



                //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                //Debug.Log("Created" + newweapon.name);

                rend[rendererIndex].material = swordMaterialRef[materialIndex];
                Debug.Log("Created" + newweapon.name);
            }
            if (newweapon.name == "lowpolyhammer(Clone)")
            {
                rendererIndex = 0;
                foreach (Renderer i in rend)
                {
                    rend[rendererIndex].sharedMaterial = hammerMaterialRef[materialIndex];
                    rendererIndex++;


                }
                //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                rendererIndex = 0;
                //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                //Debug.Log("Created" + newweapon.name);

                //rend[rendererIndex].material = hammerMaterialRef[materialIndex];
                Debug.Log("Created" + newweapon.name);
            }
            if (newweapon.name == "lowpolymace(Clone)")
            {
                rendererIndex = 0;
                foreach (Renderer i in rend)
                {
                    rend[rendererIndex].sharedMaterial = maceMaterialRef[materialIndex];
                    rendererIndex++;


                }
                //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                rendererIndex = 0;



                //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                //Debug.Log("Created" + newweapon.name);

                //rend[rendererIndex].material = maceMaterialRef[materialIndex];
                Debug.Log("Created" + newweapon.name);
            }
            if (newweapon.name == "dualdaggers(Clone)")
            {

                rend = newweapon.transform.Find("dagger1").GetComponentsInChildren<Renderer>();
                rendererIndex = 0;
                foreach (Renderer i in rend)
                {
                    rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex++;


                }
                //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                rendererIndex = 0;

                Renderer[] rend2 = newweapon.transform.Find("dagger2").GetComponentsInChildren<Renderer>();

                foreach (Renderer i in rend2)
                {
                    rend2[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex++;


                }
                rendererIndex = 0;


               



                //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                //Debug.Log("Created" + newweapon.name);

                //rend[rendererIndex].material = maceMaterialRef[materialIndex];
                Debug.Log("Created" + newweapon.name);
            }
            //Debug.Log("Created" + newweapon.name);
            newweapon.transform.SetParent(null);
            weaponismade = true;
            yield return new WaitForSecondsRealtime(3);
            GameObject.Find("MoundLimiter").GetComponent<MoundLimit>().PopulateMoundList();
            Destroy(gameObject,1);
            StopCoroutine(CreateTreasure());
            
            yield return null;
        }
        weaponismade = true;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "pickaxe" || collision.gameObject.name == "pickaxe(Clone)")
        {
            if (canMine)
            {
                audiosource.clip = mine;
                audiosource.Play();
                pileHitCounter += 1;
                if (pileHitCounter > pileHitMax)
                {
                    audiosource.Stop();
                    audiosource.clip = crumble;
                    audiosource.Play();
                    StartCoroutine(CreateTreasure());


                    StopCoroutine(CreateTreasure());
                    canMine = false;
                }

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {


        //if (other.gameObject.tag == "Enemies")
       // {
       //     Physics.IgnoreCollision(other, GetComponent<Collider>());
       // }
        if (other.CompareTag("Player"))
        {
            if (!PopupManager.firstmined)
            {
                if (!popupscript)
                {
                    popupscript = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
                }
                StartCoroutine(popupscript.firstmine());
                PopupManager.firstmined = true;
            }
            canMine = true;
        }
       


    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canMine = false;
        }
    }


    // Update is called once per frame
    void Update () {

        
        
    }
}
