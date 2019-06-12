using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceWeapon : MonoBehaviour {
    public GameObject playersWeapon;
    private Transform playersWeaponTransform;
    private Transform maceTransform;
    private Transform hammerTransform;
    private Transform speartransform;
    private Transform battleaxeTransform;
    private Transform scytheTransform;
    private Transform gunTransform;
    private Transform hoeTransform;
    private Transform forkTransform;
    private Transform dualdaggersTransform;
    private Transform hammerandsickleTransform;

    public GameObject workingHammerandSickle;




    public Animator maceAnimator;
    public Animator swordAnimator;
    public Animator hammerAnimator;
    public Animator scytheAnimator;
    public Animator gunAnimator;
    public Animator hoeAnimator;
    public Animator forkAnimator;
    public Animator dagger1Animator;
    public Animator dagger2Animator;



    public GameObject weaponcontainer;
    public SwitchWeapons switchWeaponsScript;

    public static GameObject newWeapon;

    public GameObject[] weaponsarray;

    //reference to this weapon
    public GameObject pickedupWeapon;

    public GameObject[] heldWeapons;

    public GameObject keepweapon;

    public GameObject weaponZeroRW;
    public GameObject weaponOneRW;

    public ReplaceWeapon thiss;

    


	// Use this for initialization
	void Start () {
        pickedupWeapon = gameObject;

        
        maceTransform = GameObject.Find("MaceTransform").GetComponent<Transform>();
        hammerTransform = GameObject.Find("HammerTransform").GetComponent<Transform>();
        battleaxeTransform = GameObject.Find("BattleAxeTransform").GetComponent<Transform>();
        scytheTransform = GameObject.Find("ScytheTransform").GetComponent<Transform>();
        hoeTransform = GameObject.Find("HoeTransform").GetComponent<Transform>();
        forkTransform = GameObject.Find("ForkTransform").GetComponent<Transform>();
        dualdaggersTransform = GameObject.Find("DualDaggersTransform").GetComponent<Transform>();
        gunTransform = GameObject.Find("GunTransform").GetComponent<Transform>();
        hammerandsickleTransform = GameObject.Find("HammerandSickleTransform").GetComponent<Transform>();





        maceAnimator = GameObject.Find("lowpolymaceanimator").GetComponent<Animator>();
        swordAnimator = GameObject.Find("lowpolyswordanimator").GetComponent<Animator>();
        hammerAnimator = GameObject.Find("lowpolyhammeranimator").GetComponent<Animator>();
        scytheAnimator = GameObject.Find("scytheanimator").GetComponent<Animator>();
        hoeAnimator = GameObject.Find("hoeanimator").GetComponent<Animator>();
        forkAnimator = GameObject.Find("forkanimator").GetComponent<Animator>();
        dagger1Animator = GameObject.Find("dagger1animator").GetComponent<Animator>();
        gunAnimator = GameObject.Find("gunanimator").GetComponent<Animator>();
        dagger2Animator = GameObject.Find("dagger2animator").GetComponent<Animator>();




        speartransform = GameObject.Find("SpearTransform").GetComponent<Transform>();
        weaponcontainer = GameObject.FindGameObjectWithTag("WeaponContainer");
        switchWeaponsScript = weaponcontainer.GetComponent<SwitchWeapons>();
        playersWeapon = switchWeaponsScript.gameObject.transform.GetChild(0).gameObject;
        weaponsarray = switchWeaponsScript.weapons;
        weaponZeroRW = switchWeaponsScript.weaponZero;
        weaponOneRW = switchWeaponsScript.weaponOne;
        thiss = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!PopupManager.firstweaponfound)
            {
                StartCoroutine(GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>().firstweapon());
                PopupManager.firstweaponfound = true;
            }

            playersWeapon = switchWeaponsScript.gameObject.transform.GetChild(0).gameObject;
            //switchWeaponsScript.pickaxeActive = false;
            if (SwitchWeapons.pickaxeActive)
            {
                switchWeaponsScript.PutAwayPickaxe();
                SwitchWeapons.pickaxeActive = false;
            }


            //gameObject.transform.parent = playersWeapon.transform.parent;
            //gameObject.transform.rotation = playersWeapon.transform.rotation;
            //gameObject.transform.position = playersWeapon.transform.position;
            //Destroy(playersWeapon);
            //gameObject.transform.SetAsFirstSibling();

            //weaponZeroRW = switchWeaponsScript.weaponZero;
            //weaponOneRW = switchWeaponsScript.weaponOne;




            if (gameObject.name == "spear(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = speartransform.transform.rotation;
                gameObject.transform.position = speartransform.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("spear", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);


                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 7;

                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "lowpolysword(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = playersWeapon.transform.rotation;
                gameObject.transform.position = playersWeapon.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("sword1proto2", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);



                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 1;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();
                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "lowpolymace(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = maceTransform.rotation;
                gameObject.transform.position = maceTransform.position;

                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolymace", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);
                gameObject.GetComponent<WeaponStats>().weaponType = 2;


                //weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;
                switchWeaponsScript.ChangeWeapon();

                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;
                // gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;
                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;
            }
            if (gameObject.name == "lowpolyhammer(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = playersWeapon.transform.rotation;
                gameObject.transform.position = playersWeapon.transform.position;

                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolyhammer", typeof(RuntimeAnimatorController)));
                //keepweapon = switchWeaponsScript.weaponOne;

                Destroy(playersWeapon);
                gameObject.GetComponent<WeaponStats>().weaponType = 3;


                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                // gameObject.AddComponent<keepWeapon>();


                Destroy(thiss);




                //switchWeaponsScript.weaponOne = keepweapon;
                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;



            }
            if (gameObject.name == "battleaxe(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = battleaxeTransform.transform.rotation;
                gameObject.transform.position = battleaxeTransform.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("battleaxe", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);


                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 4;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "scythe(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = scytheTransform.transform.rotation;
                gameObject.transform.position = scytheTransform.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("scythe", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);


                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 5;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "lowpolypistol(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = gunTransform.transform.rotation;
                gameObject.transform.position = gunTransform.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolypistol", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);


                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 6;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "hoe(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = hoeTransform.transform.rotation;
                gameObject.transform.position = hoeTransform.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("hoe", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);


                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 8;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "fork(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = gunTransform.transform.rotation;
                gameObject.transform.position = gunTransform.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("fork", typeof(RuntimeAnimatorController)));

                Destroy(playersWeapon);


                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 9;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "dualdaggers(Clone)")
            {
                gameObject.transform.parent = playersWeapon.transform.parent;
                gameObject.transform.rotation = dualdaggersTransform.transform.rotation;
                gameObject.transform.position = dualdaggersTransform.transform.position;
                gameObject.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                gameObject.transform.Find("dagger1").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("dagger1", typeof(RuntimeAnimatorController)));
                gameObject.transform.Find("dagger2").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("dagger2", typeof(RuntimeAnimatorController)));


                Destroy(playersWeapon);


                newWeapon = gameObject;
                newWeapon.GetComponent<WeaponStats>().weaponType = 11;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = gameObject;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(thiss);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
            if (gameObject.name == "hammerandsickledisplay(Clone)")
            {
                GameObject sickle = Instantiate(workingHammerandSickle, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                sickle.transform.parent = playersWeapon.transform.parent;
                sickle.transform.rotation = hammerandsickleTransform.transform.rotation;
                sickle.transform.position = hammerandsickleTransform.transform.position;
                sickle.transform.SetAsFirstSibling();

                //switchWeaponsScript.RepopulateArray();

                sickle.gameObject.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("hammerandsickle", typeof(RuntimeAnimatorController)));



                Destroy(playersWeapon);


                newWeapon = sickle;
                newWeapon.GetComponent<WeaponStats>().weaponType = 12;


                //switchWeaponsScript.ChangeWeapon();

                //switchWeaponsScript.ChangeWeapon();

                // weaponsarray[1] = weaponsarray[0];
                //keepweapon = switchWeaponsScript.weaponOne;

                switchWeaponsScript.weaponZero = sickle;
                switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                switchWeaponsScript.ChangeWeapon();
                switchWeaponsScript.fixSlot1 = true;
                SwitchWeapons.weaponZeroActive = true;

                //gameObject.AddComponent<keepWeapon>();

                Destroy(gameObject);

                //switchWeaponsScript.weaponOne = keepweapon;                //weaponsarray[1] = weaponcontainer.transform.GetChild(1).gameObject;

            }
        }
    }

    //put weapons into array, limit it to 2 and make sure they are the correct weapons
    //public void CheckWeapons()
    //{

   // }



    // Update is called once per frame
    void Update () {
		
	}
}
