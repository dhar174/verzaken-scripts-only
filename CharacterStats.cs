using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;



    namespace UnityStandardAssets.Characters.ThirdPerson
    {
        public class CharacterStats : MonoBehaviour
        {
             public Text bufftext;
            public static int playerBaseHealth;
        public int baseHealthCheck;

        public static bool menuscene;

            public int playerCurrentHealth;
            public int playerXP;

        public AudioSource sound;
        public AudioClip pickup;
        public AudioClip levelup;
            public bool wasHit = false;

            public float timebetweenHits;

            public int levelMultiplier;
        public bool refresh = false;


            public static int currentPlayerLevel;
        public int playerLevelCheck;

            public Text levelText;
            public Text strengthText;
            public Text speedInt;
            public Text jumpInt;
            public Text strengthInt;
            public Text speedText;
            public Text jumpText;
            public Text lvlupDistributeText;

            public bool lvlUpScreenActive;

           public bool addonetoSpeed;
           public bool addonetoJump;

            private FirstPerson.FirstPersonController fpscontroller;

            public static int StrengthStat;
            public static int SpeedStat;
            public static int JumpStat;
            public int lvlUpPoints;

            public int strengthcheck;
            public int speedcheck;
            public int jumpcheck;
            


            public static Text XPtext;
            public Text hpText;

            public BasicAI basicAIscript;

            public int XPtoNextLevel;

          public bool justLeveled;

          public Text islandtext;

            public int attackBonus;

        public int weapon1Type;
        public int weapon2Type;
        public int weapon1powerSave;
        public int weapon2powerSave;
        public int weapon1Mat;
        public int weapon2Mat;

        public GameObject playersWeapon;
        public GameObject playersWeapon2;

        private Transform playersWeaponTransform;
        private Transform maceTransform;
        private Transform hammerTransform;
        private Transform speartransform;
        private Transform battleaxeTransform;
        private Transform scytheTransform;
        private Transform gunTransform;
        private Transform hoeTransform;

        public Animator maceAnimator;
        public Animator swordAnimator;
        public Animator hammerAnimator;
        public Animator scytheAnimator;
        public Animator gunAnimator;
        public Animator hoeAnimator;
        public Transform forkTransform;
        public Transform dualdaggersTransform;
        public Transform hammerandsickleTransform;

        public static GameObject newWeapon1;
        public static GameObject newWeapon2;


        public GameObject[] weaponsarray;

        //reference to this weapon
        public GameObject pickedupWeapon;

        public GameObject[] heldWeapons;

        public GameObject keepweapon;

        public GameObject weaponZeroRW;
        public GameObject weaponOneRW;

        public GameObject weaponcontainer;
        public SwitchWeapons switchWeaponsScript;


        public SaveHelper savehelper;

        public int storedlevel;
        public int itemInvBool1;
        public int itemInvBool2;
        public int itemInvBool3;
        public int itemInvBool4;
        public int itemInvBool5;
        public int itemInvBool6;
        public int itemInvBool7;
        public int itemInvBool8;
        public int itemInvBool9;
        public int itemInvBool10;

        public int itemInvBool11;
        public int itemInvBool12;
        public int itemInvBool13;
        public int itemInvBool14;
        public int itemInvBool15;
        public int itemInvBool16;
        public int itemInvBool17;
        public int itemInvBool18;
        public int itemInvBool19;
        public int itemInvBool20;
        public int itemInvBool21;
        public int totalscore;
        private bool playedyet;

        public RectTransform spriteRect;
        //public RectTransform healthHolder;

        public float originalscale;
        public float newscale;
        public float scalePercentage;

        //public bool scaledone;
        public int dropbuff;
        private bool buffisdropped;

        public int healthPercentage;
        public float floatingPercentage;

        public int firstgameint;
        public int firstboxint;
        public int firstenemyint;
        public int firstpickaxeint;
        public int firstmineint;
        public int firstweaponfoundint;
        public int firstartifactint;
        public int firstteleportint;
        public int secondlevelpopupint;

        public GameObject popupdiag;

        // Use this for initialization
        void Awake()
            {
            popupdiag = GameObject.FindGameObjectWithTag("PopupDiag");
            spriteRect = GameObject.Find("HealthBar").gameObject.GetComponent<RectTransform>();

            savehelper = gameObject.GetComponent<SaveHelper>();


            bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
                bufftext.enabled = false;
                levelMultiplier = LevelProgression.MasterLevelMultiplier;
                XPtoNextLevel = 300 * levelMultiplier;
                playerXP = 0;
                levelText = GameObject.Find("Level").GetComponent<Text>();

            sound = gameObject.GetComponent<AudioSource>();

            
                StrengthStat = Random.Range(1, 10);
                addonetoSpeed = false;
                addonetoJump = false;
                attackBonus = StrengthStat;
            islandtext = GameObject.Find("Island").GetComponent<Text>();
            XPtext = GameObject.Find("XP").GetComponent<Text>();
                hpText = GameObject.Find("HealthInteger").GetComponent<Text>();
                if (playerBaseHealth == 0)
                {
                    playerBaseHealth = 100;
                }
                playerCurrentHealth = playerBaseHealth;
                if (timebetweenHits == 0)
                {
                    timebetweenHits = .8f;
                }
                if (currentPlayerLevel == 0)
                {
                    currentPlayerLevel = 1;
                }

                playerLevelCheck = currentPlayerLevel;
                strengthcheck = StrengthStat;
                speedcheck = SpeedStat;
                jumpcheck = JumpStat;

            //healthHolder = gameObject.transform.Find("HealthBar").GetComponent<Transform>();
            originalscale = spriteRect.localScale.x;


        }

           
          public void Save()
          {

            if (PopupManager.firstgame)
            {
                firstgameint = 1;

            }
            else
            {
                if (!PopupManager.firstgame)
                {
                    firstgameint = 0;
                }
            }
            if (PopupManager.firstboxDone)
            {
                firstboxint = 1;

            }
            else
            {
                if (!PopupManager.firstboxDone)
                {
                    firstboxint = 0;
                }
            }
            if (PopupManager.firstenemyEncountered)
            {
                firstenemyint = 1;

            }
            else
            {
                if (!PopupManager.firstenemyEncountered)
                {
                    firstenemyint = 0;
                }
            }
            if (PopupManager.firstusedPickaxe)
            {
                firstpickaxeint = 1;

            }
            else
            {
                if (!PopupManager.firstusedPickaxe)
                {
                    firstpickaxeint = 0;
                }
            }
            if (PopupManager.firstmined)
            {
                firstmineint = 1;

            }
            else
            {
                if (!PopupManager.firstmined)
                {
                    firstmineint = 0;
                }
            }
            if (PopupManager.firstweaponfound)
            {
                firstweaponfoundint = 1;

            }
            else
            {
                if (!PopupManager.firstweaponfound)
                {
                    firstweaponfoundint = 0;
                }
            }
            if (PopupManager.firstartifactfound)
            {
                firstartifactint = 1;

            }
            else
            {
                if (!PopupManager.firstartifactfound)
                {
                    firstartifactint = 0;
                }
            }
            if (PopupManager.firstteleportpopup)
            {
                firstteleportint = 1;

            }
            else
            {
                if (!PopupManager.firstteleportpopup)
                {
                    firstteleportint = 0;
                }
            }
            if (PopupManager.secondlevelpopup)
            {
                secondlevelpopupint = 1;

            }
            else
            {
                if (!PopupManager.secondlevelpopup)
                {
                    secondlevelpopupint = 0;
                }
            }

            if (GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(0).GetComponent<WeaponStats>())
            {
                weapon1Type = GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(0).GetComponent<WeaponStats>().weaponType;
            }
            if (GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(0).GetComponent<WeaponStats>())
            {
                weapon1powerSave = GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(0).GetComponent<WeaponStats>().WeaponStrength;
            }
            if (GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(1).GetComponent<WeaponStats>())
            {
                weapon2powerSave = GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(1).GetComponent<WeaponStats>().WeaponStrength;
            }
            if (GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(1).GetComponent<WeaponStats>())
            {
                weapon2Type = GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(1).GetComponent<WeaponStats>().weaponType;
            }
            if (GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(0).GetComponent<WeaponStats>())
            {
                weapon1Mat = GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(0).GetComponent<WeaponStats>().matInt;
            }
            if (GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(1).GetComponent<WeaponStats>())
            {
                weapon2Mat = GameObject.FindGameObjectWithTag("WeaponContainer").transform.GetChild(1).GetComponent<WeaponStats>().matInt;
            }

            if (ItemInventory.hasMicrocontroller)
            {
                itemInvBool1 = 1;
            }
            else
            {
                if (!ItemInventory.hasMicrocontroller)
                {
                    itemInvBool1 = 0;
                }
            }
            
            if (ItemInventory.hasTNT)
            {
                itemInvBool2 = 1;
            }
            else
            {
                if (!ItemInventory.hasTNT)
                {
                    itemInvBool2 = 0;
                }
            }
            
            
            if (ItemInventory.hasStopwatch)
            {
                itemInvBool3 = 1;
            }
            else
            {
                if (!ItemInventory.hasStopwatch)
                {
                    itemInvBool3 = 0;
                }
            }
            
            
            
            if (ItemInventory.hasBattery)
            {
                itemInvBool4 = 1;
            }
            else
            {
                if (!ItemInventory.hasBattery)
                {
                    itemInvBool4 = 0;
                }
            }
           
            
            if (ItemInventory.hasSnorkel)
            {
                itemInvBool5 = 1;
            }
            else
            {
                if (!ItemInventory.hasSnorkel)
                {
                    itemInvBool5 = 0;
                }
            }
            
           
            if (ItemInventory.hasAtlas)
            {
                itemInvBool6 = 1;
            }
            else
            {
                if (!ItemInventory.hasAtlas)
                {
                    itemInvBool6 = 0;
                }
            }
           
            
            if (ItemInventory.hasDiskette)
            {
                itemInvBool7 = 1;
            }
            else
            {
                if (!ItemInventory.hasDiskette)
                {
                    itemInvBool7 = 0;
                }
            }
            
            
            if (ItemInventory.hasHeadphones)
            {
                itemInvBool8 = 1;
            }
            else
            {
                if (!ItemInventory.hasHeadphones)
                {
                    itemInvBool8 = 0;
                }
            }
            
            
            if (ItemInventory.hasRAM)
            {
                itemInvBool9 = 1;
            }
            else
            {
                if (!ItemInventory.hasRAM)
                {
                    itemInvBool9 = 0;
                }
            }
            
            
            if (ItemInventory.hasPottery)
            {
                itemInvBool10 = 1;
            }
            else
            {
                if (!ItemInventory.hasPottery)
                {
                    itemInvBool10 = 0;
                }
            }
            
            
            if (ItemInventory.hasSprocket)
            {
                itemInvBool11 = 1;
            }
            else
            {
                if (!ItemInventory.hasSprocket)
                {
                    itemInvBool11 = 0;
                }
            }
            
            
            if (ItemInventory.hasSnibbet)
            {
                itemInvBool12 = 1;
            }
            else
            {
                if (!ItemInventory.hasSnibbet)
                {
                    itemInvBool12 = 0;
                }
            }
            
            
            if (ItemInventory.hasCrucible)
            {
                itemInvBool13 = 1;
            }
            else
            {
                if (!ItemInventory.hasCrucible)
                {
                    itemInvBool13 = 0;
                }
            }
            
            
            if (ItemInventory.hasStatuette)
            {
                itemInvBool14 = 1;
            }
            else
            {
                if (!ItemInventory.hasStatuette)
                {
                    itemInvBool14 = 0;
                }
            }
            
            
            if (ItemInventory.hasToytrain)
            {
                itemInvBool15 = 1;
            }
            else
            {
                if (!ItemInventory.hasToytrain)
                {
                    itemInvBool15 = 0;
                }
            }
            
            
            if (ItemInventory.hasVintagephone)
            {
                itemInvBool16 = 1;
            }
            else
            {
                if (!ItemInventory.hasVintagephone)
                {
                    itemInvBool16 = 0;
                }
            }
            
            if (ItemInventory.hasGoblet)
            {
                itemInvBool17 = 1;
            }
            else
            {
                if (!ItemInventory.hasGoblet)
                {
                    itemInvBool17 = 0;
                }
            }
           
            
            if (ItemInventory.hasBaseballcap)
            {
                itemInvBool18 = 1;
            }
            else
            {
                if (!ItemInventory.hasBaseballcap)
                {
                    itemInvBool18 = 0;
                }
            }
            
            
            if (ItemInventory.has3doconsole)
            {
                itemInvBool19 = 1;
            }
            else
            {
                if (!ItemInventory.has3doconsole)
                {
                    itemInvBool19 = 0;
                }
            }
            
            
            if (ItemInventory.hasHuntinghorn)
            {
                itemInvBool20 = 1;
            }
            else
            {
                if (!ItemInventory.hasHuntinghorn)
                {
                    itemInvBool20 = 0;
                }
            }
            
           
            if (ItemInventory.hasOldbottle)
            {
                itemInvBool21 = 1;
            }
            else
            {
                if (!ItemInventory.hasOldbottle)
                {
                    itemInvBool21 = 0;
                }
            }
            
            





            PlayerSave.SavePlayer(this);
           }

           public void NewGame()
        {
            playerLevelCheck = 1;
            baseHealthCheck = 100;
            strengthcheck = StrengthStat;
            speedcheck = SpeedStat;
            jumpcheck = JumpStat;


            playerXP = 0;

            levelMultiplier = 0;
            storedlevel = 0;

            
            currentPlayerLevel = 1;
            playerBaseHealth = baseHealthCheck;
            StrengthStat = strengthcheck;
            SpeedStat = speedcheck;
            JumpStat = jumpcheck;
            weapon1Type = 0;
            weapon2Type = 0;
            weapon1powerSave = 0;
            weapon2powerSave = 0;
            weapon1Mat = 0;
            weapon2Mat = 0;
            itemInvBool1 = 0;
            itemInvBool2 = 0;
            itemInvBool3 = 0;
            itemInvBool4 = 0;
            itemInvBool5 = 0;
            itemInvBool6 = 0;
            itemInvBool7 = 0;
            itemInvBool8 = 0;
            itemInvBool9 = 0;
            itemInvBool10 = 0;
            itemInvBool11 = 0;
            itemInvBool12 = 0;
            itemInvBool13 = 0;
            itemInvBool14 = 0;
            itemInvBool15 = 0;
            itemInvBool16 = 0;
            itemInvBool17 = 0;
            itemInvBool18 = 0;
            itemInvBool19 = 0;
            itemInvBool20 = 0;
            itemInvBool21 = 0;

            firstgameint = 0;
            firstboxint = 0;
            firstenemyint = 0;
            firstpickaxeint = 0;
            firstmineint = 0;
            firstweaponfoundint = 0;
            firstartifactint = 0;
            firstteleportint = 0;
            secondlevelpopupint = 0;
            refresh = true;
            StartCoroutine(RestoreWeapons());

        }

          public void Load()
          {
            print("Load Called");
            int[] loadedStats = PlayerSave.LoadPlayer();
            //levelMultiplier = loadedStats[6];

            playerLevelCheck = loadedStats[0];
            baseHealthCheck = loadedStats[1];
            strengthcheck = loadedStats[2];
            speedcheck = loadedStats[3];
            jumpcheck = loadedStats[4];


            playerXP = loadedStats[5];

            levelMultiplier = loadedStats[6];
            storedlevel = loadedStats[6];

            LevelProgression.MasterLevelMultiplier = loadedStats[6];
            currentPlayerLevel = playerLevelCheck;
            playerBaseHealth = baseHealthCheck;
            StrengthStat = strengthcheck;
            SpeedStat = speedcheck;
            JumpStat = jumpcheck;
            weapon1Type = loadedStats[7];
            weapon2Type = loadedStats[8];
            weapon1powerSave = loadedStats[9];
            weapon2powerSave = loadedStats[10];
            weapon1Mat = loadedStats[11];
            weapon2Mat = loadedStats[12];
             itemInvBool1=loadedStats[13];
             itemInvBool2= loadedStats[14];
             itemInvBool3= loadedStats[15];
             itemInvBool4= loadedStats[16];
             itemInvBool5= loadedStats[17];
             itemInvBool6= loadedStats[18];
             itemInvBool7= loadedStats[19];
             itemInvBool8= loadedStats[20];
             itemInvBool9= loadedStats[21];
             itemInvBool10= loadedStats[22];
             itemInvBool11= loadedStats[23];
             itemInvBool12= loadedStats[24];
             itemInvBool13= loadedStats[25];
             itemInvBool14= loadedStats[26];
             itemInvBool15= loadedStats[27];
             itemInvBool16= loadedStats[28];
             itemInvBool17= loadedStats[29];
             itemInvBool18= loadedStats[30];
             itemInvBool19= loadedStats[31];
             itemInvBool20= loadedStats[32];
             itemInvBool21= loadedStats[33];

            firstgameint = loadedStats[34];
            firstboxint = loadedStats[35];
            firstenemyint = loadedStats[36];
            firstpickaxeint = loadedStats[37];
            firstmineint = loadedStats[38];
            firstweaponfoundint = loadedStats[39];
            firstartifactint = loadedStats[40];
            firstteleportint = loadedStats[41];
            secondlevelpopupint = loadedStats[42];

            



            //StartCoroutine(RestoreWeapons());
            StartCoroutine(RestoreWeapons());
            ItemInventory.firstrundone = true;
            if (itemInvBool1==1)
            {
                ItemInventory.hasMicrocontroller = true;
            }
            else
            {
                if (itemInvBool1 == 0)
                {
                    ItemInventory.hasMicrocontroller = false;
                }
            }
            
            if (itemInvBool2==1)
            {
                ItemInventory.hasTNT = true;
            }
            else
            {
                if (itemInvBool2 == 0)
                {
                    ItemInventory.hasTNT = false;
                }
            }
           
            if (itemInvBool3 == 1)
            {
                ItemInventory.hasStopwatch = true;
            }
            else
            {
                if (itemInvBool3 == 0)
                {
                    ItemInventory.hasStopwatch = false;
                }
            }
            
            if (itemInvBool4 == 1)
            {
                ItemInventory.hasBattery = true;
            }
            else
            {
                if (itemInvBool4 == 0)
                {
                    ItemInventory.hasBattery = false;
                }
            }
           
            if (itemInvBool5 == 1)
            {
                ItemInventory.hasSnorkel = true;
            }
            else
            {
                if (itemInvBool5 == 0)
                {
                    ItemInventory.hasSnorkel = false;
                }
            }
            
            
            if (itemInvBool6 == 1)
            {
                ItemInventory.hasAtlas = true;
            }
            else
            {
                if (itemInvBool6 == 0)
                {
                    ItemInventory.hasAtlas = false;
                }
            }
            
            if (itemInvBool7 == 1)
            {
                ItemInventory.hasDiskette = true;
            }
            else
            {
                if (itemInvBool7 == 0)
                {
                    ItemInventory.hasDiskette = false;
                }
            }
            
            if (itemInvBool8 == 1)
            {
                ItemInventory.hasHeadphones = true;
            }
            else
            {
                if (itemInvBool8 == 0)
                {
                    ItemInventory.hasHeadphones = false;
                }
            }
            
            if (itemInvBool9 == 1)
            {
                ItemInventory.hasRAM = true;
            }
            else
            {
                if (itemInvBool9 == 0)
                {
                    ItemInventory.hasRAM = false;
                }
            }
            
            if (itemInvBool10 == 1)
            {
                ItemInventory.hasPottery = true;
            }
            else
            {
                if (itemInvBool10 == 0)
                {
                    ItemInventory.hasPottery = false;
                }
            }
            
            if (itemInvBool11 == 1)
            {
                ItemInventory.hasSprocket = true;
            }
            else
            {
                if (itemInvBool11 == 0)
                {
                    ItemInventory.hasSprocket = false;
                }
            }
           
            if (itemInvBool12 == 1)
            {
                ItemInventory.hasSnibbet = true;
            }
            else
            {
                if (itemInvBool12 == 0)
                {
                    ItemInventory.hasSnibbet = false;
                }
            }
            
            if (itemInvBool13 == 1)
            {
                ItemInventory.hasCrucible = true;
            }
            else
            {
                if (itemInvBool13 == 0)
                {
                    ItemInventory.hasCrucible = false;
                }
            }
            
            if (itemInvBool14 == 1)
            {
                ItemInventory.hasStatuette = true;
            }
            else
            {
                if (itemInvBool14 == 0)
                {
                    ItemInventory.hasStatuette = false;
                }
            }
            
            if (itemInvBool15 == 1)
            {
                ItemInventory.hasToytrain = true;
            }
            else
            {
                if (itemInvBool15 == 0)
                {
                    ItemInventory.hasToytrain = false;
                }
            }
           
            if (itemInvBool16 == 1)
            {
                ItemInventory.hasVintagephone = true;
            }
            else
            {
                if (itemInvBool16 == 0)
                {
                    ItemInventory.hasVintagephone = false;
                }
            }
            
            if (itemInvBool17 == 1)
            {
                ItemInventory.hasGoblet = true;
            }
            else
            {
                if (itemInvBool17 == 0)
                {
                    ItemInventory.hasGoblet = false;
                }
            }
            
            if (itemInvBool18 == 1)
            {
                ItemInventory.hasBaseballcap = true;
            }
            else
            {
                if (itemInvBool18 == 0)
                {
                    ItemInventory.hasBaseballcap = false;
                }
            }
            
            if (itemInvBool19 == 1)
            {
                ItemInventory.has3doconsole = true;
            }
            else
            {
                if (itemInvBool19 == 0)
                {
                    ItemInventory.has3doconsole = false;
                }
            }
            
            if (itemInvBool20 == 1)
            {
                ItemInventory.hasHuntinghorn = true;
            }
            else
            {
                if (itemInvBool20 == 0)
                {
                    ItemInventory.hasHuntinghorn = false;
                }
            }
            
            if (itemInvBool21 == 1)
            {
                ItemInventory.hasOldbottle = true;
            }
            else
            {
                if (itemInvBool21 == 0)
                {
                    ItemInventory.hasOldbottle = false;
                }
            }


            if (firstgameint == 1)
            {
                PopupManager.firstgame = true;
            }
            if (firstboxint == 1)
            {
                PopupManager.firstboxDone = true;
            }
            if (firstenemyint == 1)
            {
                PopupManager.firstenemyEncountered = true;
            }
            if (firstpickaxeint == 1)
            {
                PopupManager.firstusedPickaxe = true;
            }
            if (firstteleportint == 1)
            {
                PopupManager.firstteleportpopup = true;
            }
            if (firstweaponfoundint == 1)
            {
                PopupManager.firstweaponfound = true;
            }
            if (firstartifactint == 1)
            {
                PopupManager.firstartifactfound = true;
            }
            if (firstmineint == 1)
            {
                PopupManager.firstmined = true;
            }
            if (secondlevelpopupint == 1)
            {
                PopupManager.secondlevelpopup = true;
            }


            ItemInventory.firstrundone = true;

            Debug.Log("Stats Retrieved");
            //StartCoroutine(setlevel());


          }

           public IEnumerator setlevel()
        {
            yield return new WaitForSecondsRealtime(1);
            levelMultiplier = storedlevel+1;

            LevelProgression.MasterLevelMultiplier = levelMultiplier;
        }



           private IEnumerator RestoreWeapons()
           {
            //yield return new WaitForSecondsRealtime(5f);
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


            speartransform = GameObject.Find("SpearTransform").GetComponent<Transform>();
            weaponcontainer = GameObject.FindGameObjectWithTag("WeaponContainer");
            switchWeaponsScript = weaponcontainer.GetComponent<SwitchWeapons>();
            playersWeapon = switchWeaponsScript.gameObject.transform.GetChild(0).gameObject;
            playersWeapon2 = switchWeaponsScript.gameObject.transform.GetChild(1).gameObject;

            weaponsarray = switchWeaponsScript.weapons;
            weaponZeroRW = switchWeaponsScript.weaponZero;
            weaponOneRW = switchWeaponsScript.weaponOne;


            bool weapon1ismade = false;
            bool weapon2ismade = false;
            if (!weapon1ismade)
            {
                int weaponIndex;
                weaponIndex = weapon1Type;
                WeaponStats weaponstats;
                int materialIndex;
                Renderer[] rend;

                yield return new WaitForSecondsRealtime(.1f);

                GameObject newweapon = Instantiate(savehelper.weapons[weaponIndex], transform.position, savehelper.weapons[weaponIndex].transform.rotation) as GameObject;
                Destroy(newweapon.GetComponent<ReplaceWeapon>());

                


                //weaponismade = true;
                //yield return new WaitForFixedUpdate();
                if (newweapon)
                {
                    newweapon.transform.parent = null;
                    
                
                
                 weaponstats = newweapon.GetComponent<WeaponStats>();
                
                
                    weaponstats.WeaponStrength = weapon1powerSave;
                }
                materialIndex = weapon1Mat;

                rend = newweapon.GetComponentsInChildren<Renderer>();
                int rendererIndex;
                //switchWeaponsScript.pickaxeActive = false;
                //if (SwitchWeapons.pickaxeActive)
                //{
                    //GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>().PutAwayPickaxe();
                    //SwitchWeapons.pickaxeActive = false;
               // }

                if (newweapon.name == "EmptyWeapon(Clone)")
                {

                    rendererIndex = 0;
                    foreach (Renderer i in rend)
                    {
                        rend[rendererIndex].sharedMaterial = savehelper.swordMaterialRef[materialIndex];
                        rendererIndex++;


                    }
                    //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex = 0;



                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    //Debug.Log("Created" + newweapon.name);


                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = playersWeapon.transform.rotation;
                    newweapon.transform.position = playersWeapon.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("sword1proto2", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);



                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 1;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = newweapon;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    Debug.Log("Created" + newweapon.name);
                }


                if (newweapon.name == "battleaxe(Clone)")
                {


                    Renderer axerend = newweapon.transform.Find("pCylinder8").GetComponent<Renderer>();



                    axerend.sharedMaterial = savehelper.hammerMaterialRef[materialIndex];

                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = battleaxeTransform.transform.rotation;
                    newweapon.transform.position = battleaxeTransform.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("battleaxe", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);


                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 4;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = gameObject;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;
                    Debug.Log("Created" + newweapon.name);
                }
                if (newweapon.name == "spear(Clone)")
                {


                    rendererIndex = 0;
                    foreach (Renderer i in rend)
                    {
                        rend[rendererIndex].sharedMaterial = savehelper.swordMaterialRef[materialIndex];
                        rendererIndex++;


                    }
                    //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex = 0;

                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = speartransform.transform.rotation;
                    newweapon.transform.position = speartransform.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("spear", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);


                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 7;

                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = gameObject;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;



                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    Debug.Log("Created" + newweapon.name);
                }
                if (newweapon.name == "lowpolysword(Clone)")
                {

                    rendererIndex = 0;
                    foreach (Renderer i in rend)
                    {
                        rend[rendererIndex].sharedMaterial = savehelper.swordMaterialRef[materialIndex];
                        rendererIndex++;


                    }
                    //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex = 0;



                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    //Debug.Log("Created" + newweapon.name);

                    rend[rendererIndex].material = savehelper.swordMaterialRef[materialIndex];
                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = playersWeapon.transform.rotation;
                    newweapon.transform.position = playersWeapon.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("sword1proto2", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);



                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 1;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = newweapon;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    Debug.Log("Created" + newweapon.name);
                }
                if (newweapon.name == "lowpolyhammer(Clone)")
                {

                    rendererIndex = 0;
                    foreach (Renderer i in rend)
                    {
                        rend[rendererIndex].sharedMaterial = savehelper.hammerMaterialRef[materialIndex];
                        rendererIndex++;


                    }
                    //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex = 0;

                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = hammerTransform.transform.rotation;
                    newweapon.transform.position = hammerTransform.transform.position;

                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolyhammer", typeof(RuntimeAnimatorController)));
                    //keepweapon = switchWeaponsScript.weaponOne;

                    Destroy(playersWeapon);
                    newweapon.GetComponent<WeaponStats>().weaponType = 3;


                    switchWeaponsScript.weaponZero = gameObject;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;


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
                        rend[rendererIndex].sharedMaterial = savehelper.maceMaterialRef[materialIndex];
                        rendererIndex++;


                    }
                    //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                    rendererIndex = 0;

                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = maceTransform.rotation;
                    newweapon.transform.position = maceTransform.position;

                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolymace", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);
                    newweapon.GetComponent<WeaponStats>().weaponType = 2;


                    //weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = gameObject;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;
                    switchWeaponsScript.ChangeWeapon();

                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    //Debug.Log("Created" + newweapon.name);

                    //rend[rendererIndex].material = maceMaterialRef[materialIndex];
                    Debug.Log("Created" + newweapon.name);
                }
                if (newweapon.name == "fork(Clone)")
                {

                    



                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    //Debug.Log("Created" + newweapon.name);

                    
                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = forkTransform.transform.rotation;
                    newweapon.transform.position = forkTransform.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("fork", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);



                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 9;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = newweapon;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    Debug.Log("Created" + newweapon.name);
                }
                if (newweapon.name == "scythe(Clone)")
                {





                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    //Debug.Log("Created" + newweapon.name);


                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = scytheTransform.transform.rotation;
                    newweapon.transform.position = scytheTransform.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("scythe", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);



                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 5;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = newweapon;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    Debug.Log("Created" + newweapon.name);
                }
                if (newweapon.name == "gun(Clone)")
                {





                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    //Debug.Log("Created" + newweapon.name);


                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = gunTransform.transform.rotation;
                    newweapon.transform.position = gunTransform.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolypistol", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);



                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 6;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = newweapon;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    Debug.Log("Created" + newweapon.name);
                }
                if (newweapon.name == "hoe(Clone)")
                {





                    //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                    //Debug.Log("Created" + newweapon.name);


                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = hoeTransform.transform.rotation;
                    newweapon.transform.position = hoeTransform.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("hoe", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);



                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 8;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = newweapon;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    Debug.Log("Created" + newweapon.name);
                }
                
                if (newweapon.name == "hammerandsickle(Clone)")
                {

                    
                    newweapon.transform.parent = playersWeapon.transform.parent;
                    newweapon.transform.rotation = hammerandsickleTransform.transform.rotation;
                    newweapon.transform.position = hammerandsickleTransform.transform.position;
                    newweapon.transform.SetAsFirstSibling();

                    //switchWeaponsScript.RepopulateArray();

                    newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("hammerandsickle", typeof(RuntimeAnimatorController)));

                    Destroy(playersWeapon);



                    newWeapon1 = newweapon;
                    newWeapon1.GetComponent<WeaponStats>().weaponType = 11;


                    //switchWeaponsScript.ChangeWeapon();

                    //switchWeaponsScript.ChangeWeapon();

                    // weaponsarray[1] = weaponsarray[0];
                    //keepweapon = switchWeaponsScript.weaponOne;

                    switchWeaponsScript.weaponZero = newweapon;
                    switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                    switchWeaponsScript.ChangeWeapon();
                    switchWeaponsScript.fixSlot1 = true;
                    SwitchWeapons.weaponZeroActive = true;

                    Debug.Log("Created" + newweapon.name);
                }

                //Debug.Log("Created" + newweapon.name);
                weapon1ismade = true;
                if (weapon1ismade) {
                    //yield return new WaitForSecondsRealtime(5f);

                    if (!weapon2ismade)
                    {
                        int weapon2Index;
                        weapon2Index = weapon2Type;
                        WeaponStats weaponstats2;
                        int material2Index;
                        Renderer[] rend2;

                        GameObject newweapon2 = Instantiate(savehelper.weapons[weapon2Index], transform.position, savehelper.weapons[weapon2Index].transform.rotation) as GameObject;
                        Destroy(newweapon2.GetComponent<ReplaceWeapon>());


                        //weaponismade = true;
                        //yield return new WaitForFixedUpdate();
                        newweapon2.transform.parent = null;
                        weaponstats2 = newweapon2.GetComponent<WeaponStats>();
                        weaponstats2.WeaponStrength = weapon2powerSave;
                        material2Index = weapon2Mat;
                        rend2 = newweapon2.GetComponentsInChildren<Renderer>();
                        int renderer2Index;
                        //switchWeaponsScript.pickaxeActive = false;
                       
                        if (newweapon2.name == "battleaxe(Clone)")
                        {


                            Renderer axerend = newweapon2.transform.Find("pCylinder8").GetComponent<Renderer>();



                            axerend.sharedMaterial = savehelper.hammerMaterialRef[material2Index];

                            newweapon2.transform.parent = playersWeapon2.transform.parent;
                            newweapon2.transform.rotation = battleaxeTransform.transform.rotation;
                            newweapon2.transform.position = battleaxeTransform.transform.position;
                            newweapon2.transform.SetSiblingIndex(1);

                            //switchWeaponsScript.RepopulateArray();

                            newweapon2.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("battleaxe", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon2);


                            newWeapon2 = newweapon2;
                            newWeapon2.GetComponent<WeaponStats>().weaponType = 4;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                           // switchWeaponsScript.weaponZero = gameObject;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;
                            Debug.Log("Created" + newweapon2.name);
                        }
                        if (newweapon2.name == "spear(Clone)")
                        {


                            renderer2Index = 0;
                            foreach (Renderer i in rend2)
                            {
                                rend2[renderer2Index].sharedMaterial = savehelper.swordMaterialRef[material2Index];
                                renderer2Index++;


                            }
                            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                            renderer2Index = 0;

                            newweapon2.transform.parent = playersWeapon2.transform.parent;
                            newweapon2.transform.rotation = speartransform.transform.rotation;
                            newweapon2.transform.position = speartransform.transform.position;
                            newweapon2.transform.SetSiblingIndex(1);

                            //switchWeaponsScript.RepopulateArray();

                            newweapon2.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("spear", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon2);


                            newWeapon2 = newweapon2;
                            newWeapon2.GetComponent<WeaponStats>().weaponType = 7;

                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                           // switchWeaponsScript.weaponZero = gameObject;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;



                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            Debug.Log("Created" + newweapon2.name);
                        }
                        if (newweapon2.name == "lowpolysword(Clone)")
                        {

                            renderer2Index = 0;
                            foreach (Renderer i in rend2)
                            {
                                rend[renderer2Index].sharedMaterial = savehelper.swordMaterialRef[material2Index];
                                renderer2Index++;


                            }
                            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                            rendererIndex = 0;



                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);


                            newweapon2.transform.parent = playersWeapon2.transform.parent;
                            newweapon2.transform.rotation = playersWeapon2.transform.rotation;
                            newweapon2.transform.position = playersWeapon2.transform.position;
                            newweapon2.transform.SetSiblingIndex(1);

                            //switchWeaponsScript.RepopulateArray();

                            newweapon2.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("sword1proto2", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon2);



                            newWeapon2 = newweapon2;
                            newWeapon2.GetComponent<WeaponStats>().weaponType = 1;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                           // switchWeaponsScript.weaponZero = gameObject;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            Debug.Log("Created" + newweapon2.name);
                        }
                        if (newweapon2.name == "lowpolyhammer(Clone)")
                        {

                            renderer2Index = 0;
                            foreach (Renderer i in rend2)
                            {
                                rend2[renderer2Index].sharedMaterial = savehelper.hammerMaterialRef[material2Index];
                                renderer2Index++;


                            }
                            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                            renderer2Index = 0;

                            newweapon2.transform.parent = playersWeapon2.transform.parent;
                            newweapon2.transform.rotation = hammerTransform.transform.rotation;
                            newweapon2.transform.position = hammerTransform.transform.position;

                            newweapon2.transform.parent = playersWeapon2.transform.parent;
                            newweapon2.transform.SetSiblingIndex(1);

                            //switchWeaponsScript.RepopulateArray();

                            newweapon2.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolyhammer", typeof(RuntimeAnimatorController)));
                            //keepweapon = switchWeaponsScript.weaponOne;

                            Destroy(playersWeapon2);
                            newweapon2.GetComponent<WeaponStats>().weaponType = 3;


                            //switchWeaponsScript.weaponZero = gameObject;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;


                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);

                            //rend[rendererIndex].material = hammerMaterialRef[materialIndex];
                            Debug.Log("Created" + newweapon2.name);
                        }
                        if (newweapon2.name == "lowpolymace(Clone)")
                        {
                            renderer2Index = 0;
                            foreach (Renderer i in rend2)
                            {
                                rend2[renderer2Index].sharedMaterial = savehelper.maceMaterialRef[material2Index];
                                renderer2Index++;


                            }
                            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                            renderer2Index = 0;

                            newweapon2.transform.parent = playersWeapon2.transform.parent;
                            newweapon2.transform.rotation = maceTransform.rotation;
                            newweapon2.transform.position = maceTransform.position;

                            //newweapon2.transform.parent = playersWeapon.transform.parent;
                            newweapon2.transform.SetSiblingIndex(1);

                            //switchWeaponsScript.RepopulateArray();

                            newweapon2.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolymace", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon2);
                            //Destroy(playersWeapon);

                            newweapon2.GetComponent<WeaponStats>().weaponType = 2;


                            weaponsarray[1] = weaponsarray[0];
                            keepweapon = switchWeaponsScript.weaponOne;

                            //switchWeaponsScript.weaponZero = newweapon2;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;
                            switchWeaponsScript.ChangeWeapon();

                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);

                            //rend[rendererIndex].material = maceMaterialRef[materialIndex];
                            Debug.Log("Created" + newweapon2.name);
                        }
                        if (newweapon.name == "fork(Clone)")
                        {





                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);


                            newweapon.transform.parent = playersWeapon2.transform.parent;
                            newweapon.transform.rotation = forkTransform.transform.rotation;
                            newweapon.transform.position = forkTransform.transform.position;
                            newweapon.transform.SetAsFirstSibling();

                            //switchWeaponsScript.RepopulateArray();

                            newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("fork", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon);



                            newWeapon1 = newweapon;
                            newWeapon1.GetComponent<WeaponStats>().weaponType = 9;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                            switchWeaponsScript.weaponZero = newweapon;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            Debug.Log("Created" + newweapon.name);
                        }
                        if (newweapon.name == "scythe(Clone)")
                        {





                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);


                            newweapon.transform.parent = playersWeapon2.transform.parent;
                            newweapon.transform.rotation = scytheTransform.transform.rotation;
                            newweapon.transform.position = scytheTransform.transform.position;
                            newweapon.transform.SetAsFirstSibling();

                            //switchWeaponsScript.RepopulateArray();

                            newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("scythe", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon);



                            newWeapon1 = newweapon;
                            newWeapon1.GetComponent<WeaponStats>().weaponType = 5;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                            switchWeaponsScript.weaponZero = newweapon;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            Debug.Log("Created" + newweapon.name);
                        }
                        if (newweapon.name == "gun(Clone)")
                        {





                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);


                            newweapon.transform.parent = playersWeapon2.transform.parent;
                            newweapon.transform.rotation = gunTransform.transform.rotation;
                            newweapon.transform.position = gunTransform.transform.position;
                            newweapon.transform.SetAsFirstSibling();

                            //switchWeaponsScript.RepopulateArray();

                            newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("lowpolypistol", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon);



                            newWeapon1 = newweapon;
                            newWeapon1.GetComponent<WeaponStats>().weaponType = 6;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                            switchWeaponsScript.weaponZero = newweapon;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            Debug.Log("Created" + newweapon.name);
                        }
                        if (newweapon.name == "hoe(Clone)")
                        {





                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);


                            newweapon.transform.parent = playersWeapon2.transform.parent;
                            newweapon.transform.rotation = hoeTransform.transform.rotation;
                            newweapon.transform.position = hoeTransform.transform.position;
                            newweapon.transform.SetAsFirstSibling();

                            //switchWeaponsScript.RepopulateArray();

                            newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("hoe", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon);



                            newWeapon1 = newweapon;
                            newWeapon1.GetComponent<WeaponStats>().weaponType = 8;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                            switchWeaponsScript.weaponZero = newweapon;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            Debug.Log("Created" + newweapon.name);
                        }
                        if (newweapon.name == "dualdaggers(Clone)")
                        {

                            rendererIndex = 0;
                            foreach (Renderer i in rend)
                            {
                                rend[rendererIndex].sharedMaterial = savehelper.swordMaterialRef[materialIndex];
                                rendererIndex++;


                            }
                            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
                            rendererIndex = 0;



                            //rend[rendererIndex].material = swordMaterialRef[materialIndex];
                            //Debug.Log("Created" + newweapon.name);

                            rend[rendererIndex].material = savehelper.swordMaterialRef[materialIndex];
                            newweapon.transform.parent = playersWeapon2.transform.parent;
                            newweapon.transform.rotation = dualdaggersTransform.transform.rotation;
                            newweapon.transform.position = dualdaggersTransform.transform.position;
                            newweapon.transform.SetAsFirstSibling();

                            //switchWeaponsScript.RepopulateArray();

                            newweapon.transform.Find("dagger1").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("dagger1", typeof(RuntimeAnimatorController)));
                            newweapon.transform.Find("dagger2").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("dagger2", typeof(RuntimeAnimatorController)));


                            Destroy(playersWeapon);



                            newWeapon1 = newweapon;
                            newWeapon1.GetComponent<WeaponStats>().weaponType = 1;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                            switchWeaponsScript.weaponZero = newweapon;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            Debug.Log("Created" + newweapon.name);
                        }
                        if (newweapon.name == "hammerandsickle(Clone)")
                        {


                            newweapon.transform.parent = playersWeapon2.transform.parent;
                            newweapon.transform.rotation = hammerandsickleTransform.transform.rotation;
                            newweapon.transform.position = hammerandsickleTransform.transform.position;
                            newweapon.transform.SetAsFirstSibling();

                            //switchWeaponsScript.RepopulateArray();

                            newweapon.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("hammerandsickle", typeof(RuntimeAnimatorController)));

                            Destroy(playersWeapon);



                            newWeapon1 = newweapon;
                            newWeapon1.GetComponent<WeaponStats>().weaponType = 12;


                            //switchWeaponsScript.ChangeWeapon();

                            //switchWeaponsScript.ChangeWeapon();

                            // weaponsarray[1] = weaponsarray[0];
                            //keepweapon = switchWeaponsScript.weaponOne;

                            switchWeaponsScript.weaponZero = newweapon;
                            switchWeaponsScript.weaponOne = weaponcontainer.transform.GetChild(1).gameObject;

                            switchWeaponsScript.ChangeWeapon();
                            switchWeaponsScript.fixSlot1 = true;
                            SwitchWeapons.weaponZeroActive = true;

                            Debug.Log("Created" + newweapon.name);
                        }
                        weapon2ismade = true;

                        switchWeaponsScript.SwitchMainWeapons() ;


                        switchWeaponsScript.ChangeWeapon();

                        switchWeaponsScript.fixSlot1 = true;
                        SwitchWeapons.weaponZeroActive = true;
                        switchWeaponsScript.SwitchMainWeapons();


                        switchWeaponsScript.ChangeWeapon();

                        switchWeaponsScript.fixSlot1 = true;
                        SwitchWeapons.weaponZeroActive = true;


                    }
                    if (refresh)
                    {
                        GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>().SwitchToPickaxe();
                        refresh = false;
                    }
                    StopCoroutine(RestoreWeapons());
                }
            }
               
            yield return null;
           }

          private IEnumerator RefadePanel()
        {
            yield return new WaitForSecondsRealtime(2);
            FadePanels.panelFade = true;
            StopCoroutine(RefadePanel());
        }


        private void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.tag == "Robospider")
                {
                    collision.gameObject.GetComponent<BasicAI>().hitplayer = true;
                    int dmg = collision.gameObject.GetComponent<BasicAI>().enemyStrength;
                    if (!wasHit)
                    {
                        playerCurrentHealth = playerCurrentHealth - dmg;
                        ChangeScale();
                      FadePanels.panelFade = false;
                      StartCoroutine(RefadePanel());
                    }
                    StartCoroutine(WaitOnHit());
                }
                if (collision.gameObject.tag == "Bbbot")
                {
                    collision.gameObject.GetComponent<BasicAI>().hitplayer = true;
                    int dmg = collision.gameObject.GetComponent<BasicAI>().enemyStrength;

                    if (!wasHit)
                    {
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                    playerCurrentHealth = playerCurrentHealth - dmg;
                      ChangeScale();
                }
                    StartCoroutine(WaitOnHit());
                }
                if (collision.gameObject.tag == "Monsters")
                {
                    int dmg = collision.gameObject.GetComponent<BasicAI>().enemyStrength;
                    if (!wasHit)
                    {
                        playerCurrentHealth = playerCurrentHealth - dmg;
                        ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                    StartCoroutine(WaitOnHit());
                }

               if (collision.gameObject.CompareTag("BossTowerSpear"))
               {
                collision.gameObject.transform.root.GetComponent<BossTowerAI>().hitplayer = true;
                int dmg = collision.gameObject.transform.root.GetComponentInChildren<BossTowerAI>().enemyStrength;
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                StartCoroutine(WaitOnHit());
               }
            if (collision.gameObject.CompareTag("BossTowerBall"))
            {
                collision.gameObject.transform.root.GetComponent<BossTowerAI>().hitplayer = true;
                int dmg = collision.gameObject.transform.root.GetComponentInChildren<BossTowerAI>().enemyStrength;
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                StartCoroutine(WaitOnHit());
            }
            if (collision.gameObject.CompareTag("BossBotArm"))
            {
                collision.gameObject.transform.root.GetComponentInChildren<BossTowerAI>().hitplayer = true;
                int dmg = collision.gameObject.transform.root.GetComponentInChildren<BossTowerAI>().enemyStrength;
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                StartCoroutine(WaitOnHit());
            }
            if (collision.gameObject.transform.root.CompareTag("Roboscorpion"))
            {
                     //print("Scorpion Hit You");

                   int dmg = collision.gameObject.GetComponent<BasicAI>().enemyStrength;
                if (!wasHit)
                {
                    //print("Scorpion Damaged You");
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                
                 StartCoroutine(WaitOnHit());
            }
            if (collision.gameObject.CompareTag("GuardBot"))
            {
                  int dmg = collision.gameObject.GetComponent<BasicAI>().enemyStrength;
                  if (!wasHit)
                  {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                   StartCoroutine(WaitOnHit());
            }
            if (collision.gameObject.tag == "SpinBoss")
            {
                int dmg = collision.gameObject.GetComponent<SpinbossAI>().enemyStrength;
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                StartCoroutine(WaitOnHit());
            }
            if (collision.gameObject.CompareTag("TwoWheel"))
            {
                int dmg = collision.gameObject.GetComponent<BasicAI>().enemyStrength;
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                StartCoroutine(WaitOnHit());
            }
            if (collision.gameObject.CompareTag("WalkerBot"))
            {
                int dmg = collision.gameObject.GetComponent<BasicAI>().enemyStrength;
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    ChangeScale();
                    FadePanels.panelFade = false;
                    StartCoroutine(RefadePanel());
                }
                StartCoroutine(WaitOnHit());
            }


        }


           private void OnParticleCollision(GameObject other)
           {

            Debug.Log("Particle Collision");
            if (other.CompareTag("EyebotGun"))
            {
                //int dmg = other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<BasicAI>().enemyStrength;
                int dmg = other.transform.parent.root.GetComponentInChildren<BasicAI>().enemyStrength;
                Debug.Log("Damage Should Be Taken");          
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    Debug.Log("Damage REALLY should have been taken");
                    ChangeScale();
                }
                StartCoroutine(WaitOnHit());
            }
            if (other.CompareTag("BossBrain"))
            {
                //int dmg = other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<BasicAI>().enemyStrength;
                int dmg = other.transform.parent.root.GetComponentInChildren<BossBrainHealth>().enemyStrength;
                Debug.Log("Damage Should Be Taken");
                if (!wasHit)
                {
                    playerCurrentHealth = playerCurrentHealth - dmg;
                    Debug.Log("Damage REALLY should have been taken");
                    ChangeScale();
                }
                StartCoroutine(WaitOnHit());
            }
        }

        public IEnumerator WaitOnHit()
            {
                wasHit = true;
                yield return new WaitForSeconds(timebetweenHits);
                wasHit = false;
                StopCoroutine(WaitOnHit());
                yield return null;
            }

            public void SpeedJumpBuff(int buff)
            {
            bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
            SpeedStat = SpeedStat+buff;
               JumpStat = JumpStat+buff;
             bufftext.enabled = true;
             bufftext.text = "Speed" +
             " +" + buff + "! ";
             bufftext.GetComponent<Animation>().Play();

            sound.clip = pickup;
            sound.Play();
                gameObject.GetComponent<FirstPerson.FirstPersonController>().m_WalkSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_WalkSpeed + buff;
                gameObject.GetComponent<FirstPerson.FirstPersonController>().m_RunSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_RunSpeed + buff;
                //addonetoSpeed = false;
               

              
              
                gameObject.GetComponent<FirstPerson.FirstPersonController>().m_JumpSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_JumpSpeed + buff;
                //addonetoJump = false;
              


            }
             
            public void SpeedBuffOff(int buff)
            {
            bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
            SpeedStat = SpeedStat-buff;
              JumpStat = JumpStat-buff;
              bufftext.enabled = false;
            gameObject.GetComponent<FirstPerson.FirstPersonController>().m_WalkSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_WalkSpeed - buff;
            gameObject.GetComponent<FirstPerson.FirstPersonController>().m_RunSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_RunSpeed - buff;
            gameObject.GetComponent<FirstPerson.FirstPersonController>().m_JumpSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_JumpSpeed - buff;

        }

        public void StrengthBuff(int buff)
            {
            bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
            StrengthStat = StrengthStat+buff;
               bufftext.enabled = true;
               bufftext.text = "Strength" +
                " +" +buff +"! " ;
               bufftext.GetComponent<Animation>().Play();
            sound.clip = pickup;
            sound.Play();
        }
            public void StrengthBuffOff(int buff)
            {
              bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
               StrengthStat = StrengthStat-buff;
              bufftext.enabled = false;
            }
        public void XPGain(int xp)
        {
            bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
            bufftext.enabled = true;
            if (GameModeScript.GameMode == 1)
            {
                bufftext.text = "Gained XP" +
                 " +" + xp + "! ";
            }
            if (GameModeScript.GameMode == 0)
            {
                bufftext.text = 
                 xp + " Points! ";
            }
            bufftext.GetComponent<Animation>().Play();
            StartCoroutine(waitfortext());
            
        }
          public IEnumerator waitfortext()
        {
            yield return new WaitForSecondsRealtime(3);
            XPStop();
            StopCoroutine(waitfortext());
        }
        public void XPStop()
        {
            bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
            bufftext.enabled = false;
        }

        public void AddHealth(int health)
             {
            sound.clip = pickup;
            sound.Play();
            if (currentPlayerLevel == 1)
                 {
                   playerCurrentHealth = playerCurrentHealth + (health * levelMultiplier);
                   if(playerCurrentHealth > playerBaseHealth)
                   {
                    playerCurrentHealth = playerBaseHealth;
                   }

                 }
                 if(currentPlayerLevel > 1)
                 {
                  playerCurrentHealth = playerCurrentHealth + (health * currentPlayerLevel);
                    if (playerCurrentHealth > playerBaseHealth)
                    {
                      playerCurrentHealth = playerBaseHealth;
                    }
                 }
            if (!bufftext)
            {
                bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();

            }
            if (bufftext)
            {
                bufftext.enabled = true;
            }
                  bufftext.text = "Healed" +
                        " +" + health + "! ";
                   bufftext.GetComponent<Animation>().Play();
            StartCoroutine(waitfortexttwo());
        }
            public void AddMaxHealth(int health)
            {
              sound.clip = pickup;
              sound.Play();
              if (currentPlayerLevel == 1)
              {
                playerBaseHealth = (playerBaseHealth + health);
                playerCurrentHealth = playerBaseHealth;
              }
              if (currentPlayerLevel > 1)
              {
                playerBaseHealth = playerBaseHealth + health;
                playerCurrentHealth = playerBaseHealth;
              }
          
                if (!bufftext)
                {
                  bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();

                }
                if (bufftext)
                {
                  bufftext.enabled = true;
                }
               bufftext.text = "Max Health" +
                   " +" + (health) + "! ";
                bufftext.GetComponent<Animation>().Play();
               StartCoroutine(waitfortexttwo());
            }

        public IEnumerator waitfortexttwo()
        {
            yield return new WaitForSecondsRealtime(3);
            HealthOff();
            StopCoroutine(waitfortexttwo());
        }
        public void HealthOff()
        {
            bufftext = GameObject.FindGameObjectWithTag("BuffText").GetComponent<Text>();
            
            bufftext.enabled = false;
        }

      

        public void LevelUp()
        {

            if (lvlUpScreenActive)
            {
                GameObject.FindGameObjectWithTag("StartManager").GetComponent<LevelProgression>().LvlUpScreenActivate();
                lvlupDistributeText = GameObject.Find("DistributePoints").GetComponent<Text>();
                speedInt = GameObject.Find("SpeedInt").GetComponent<Text>();
                speedText = GameObject.Find("SpeedText").GetComponent<Text>();
                strengthInt = GameObject.Find("StrengthInt").GetComponent<Text>();
                strengthText = GameObject.Find("StrengthText").GetComponent<Text>();
                jumpInt = GameObject.Find("JumpPowerInt").GetComponent<Text>();
                jumpText = GameObject.Find("JumpPowerText").GetComponent<Text>();



                speedInt.text = "" + SpeedStat;
                strengthInt.text = "" + StrengthStat;
                jumpInt.text = "" + JumpStat;

                if (LanguageChange.LangNum == 0)
                {
                    lvlupDistributeText.text = "You Have " + lvlUpPoints + " Point(s) to Distribute";
                }
                else
                {
                    if (LanguageChange.LangNum == 1)
                    {
                        lvlupDistributeText.text = "你有 " + lvlUpPoints + "点分配";
                        speedText.text = "速";
                        strengthText.text = "力量";
                        jumpText.text = "跳跃高度";
                        GameObject.Find("MaxHealthText").GetComponent<Text>().text = "总 身体 增添";
                        GameObject.Find("LevelUpScreen").transform.Find("Text (1)").GetComponent<Text>().text = "垫平!";
                        GameObject.Find("LevelUpScreen").transform.Find("Button (6)").GetComponentInChildren<Text>().text = "完";



                    }
                    else
                    {
                        if (LanguageChange.LangNum == 2)
                        {
                            lvlupDistributeText.text = "Sie haben" + lvlUpPoints + "Punkte zu verteilen";

                            speedText.text = "Geschwindigkeit";
                            strengthText.text = "Festigkeit";
                            jumpText.text = "Springen";
                            GameObject.Find("MaxHealthText").GetComponent<Text>().text = "Raise Max Gesundheit";
                            GameObject.Find("LevelUpScreen").transform.Find("Text (1)").GetComponent<Text>().text = "Aufleveln!!";
                            GameObject.Find("LevelUpScreen").transform.Find("Button (6)").GetComponentInChildren<Text>().text = "Fertig";



                        }
                        else
                        {
                            if (LanguageChange.LangNum == 3)
                            {
                                lvlupDistributeText.text = "У вас есть" + lvlUpPoints + "очки для распространения";
                                speedText.text = "скорость";
                                strengthText.text = "Прочность";
                                jumpText.text = "Прыгать";
                                GameObject.Find("MaxHealthText").GetComponent<Text>().text = "Повышение максимального здоровья";
                                GameObject.Find("LevelUpScreen").transform.Find("Text (1)").GetComponent<Text>().text = "Уровень вверх!!";
                                GameObject.Find("LevelUpScreen").transform.Find("Button (6)").GetComponentInChildren<Text>().text = "Закончено";



                            }
                            else
                            {

                                if (LanguageChange.LangNum == 4)
                                {
                                    lvlupDistributeText.text = "Tienes puntos" + lvlUpPoints + "para distribuir";
                                    speedText.text = "Rapidez";
                                    strengthText.text = "Pujanza";
                                    jumpText.text = "Brincar";
                                    GameObject.Find("MaxHealthText").GetComponent<Text>().text = "Elevar Max Salud";
                                    GameObject.Find("LevelUpScreen").transform.Find("Text (1)").GetComponent<Text>().text = "¡Elevar a mismo nivel!!";
                                    GameObject.Find("LevelUpScreen").transform.Find("Button (6)").GetComponentInChildren<Text>().text = "Acabado";



                                }
                            }

                        }

                    }


                }

            }

        }
            
           public void BeginLevelUp()
           {

            justLeveled = true;
            fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPerson.FirstPersonController>();
            fpscontroller.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            lvlUpPoints = 1;
            lvlUpScreenActive = true;
            LevelUp();
           }
            
            public void AddLevel()
            {
              currentPlayerLevel = currentPlayerLevel +1;
             playerLevelCheck = currentPlayerLevel;
              if (addonetoSpeed)
              {
                gameObject.GetComponent<FirstPerson.FirstPersonController>().m_WalkSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_WalkSpeed + 1;
                gameObject.GetComponent<FirstPerson.FirstPersonController>().m_RunSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_RunSpeed + 1;
                addonetoSpeed = false;
              }
            playedyet = false;
              if (addonetoJump)
              {
                gameObject.GetComponent<FirstPerson.FirstPersonController>().m_JumpSpeed = gameObject.GetComponent<FirstPerson.FirstPersonController>().m_JumpSpeed + 1;
                addonetoJump = false;
              }
              justLeveled = false;
              //GameObject.FindGameObjectWithTag("StartManager").GetComponent<LevelProgression>().LvlUpScreenOff();

             }
          public void ChangeScale()
        {
            spriteRect.localScale = new Vector3(newscale, 1f, 1f);
        }

        // Update is called once per frame
        void Update()
        {

            

            levelMultiplier = LevelProgression.MasterLevelMultiplier;
            if (levelMultiplier==2)
            {
                //popupdiag.SetActive(true);
            }

                playerLevelCheck = currentPlayerLevel;
            strengthcheck = StrengthStat;
            jumpcheck = JumpStat;
            speedcheck = SpeedStat;
            baseHealthCheck = playerBaseHealth;


            floatingPercentage = (float)healthPercentage;
            healthPercentage = (int)floatingPercentage;
            if (playerBaseHealth > 0)
            {
                healthPercentage = (playerCurrentHealth * 100) / playerBaseHealth;
            }
            newscale = originalscale * (floatingPercentage / 100f);
            if (!spriteRect)
            {
                if (GameObject.FindGameObjectWithTag("Canvas").transform.Find("HealthBar"))
                {
                    spriteRect = GameObject.FindGameObjectWithTag("Canvas").transform.Find("HealthBar").gameObject.GetComponent<RectTransform>();
                }
            }
            if (!XPtext)
                {
                    XPtext = GameObject.Find("XP").GetComponent<Text>();
                }
            if (!islandtext)
            {
                islandtext = GameObject.Find("Island").GetComponent<Text>();
            }


            if (hpText == null)
                {
                    hpText = GameObject.Find("HealthInteger").GetComponent<Text>();
                }
               if (levelText == null)
               {
                levelText = GameObject.Find("Level").GetComponent<Text>();
               }
            if (GameModeScript.GameMode == 1)
            {
                XPtext.text = "XP:" + playerXP;
            }
            if (GameModeScript.GameMode == 0)
            {
                if (LanguageChange.LangNum == 0)
                {
                    XPtext.text = "Score:" + totalscore;
                }
                else
                {
                    if (LanguageChange.LangNum == 1)
                    {
                        XPtext.text = "得分了" + totalscore;
                        XPtext.fontSize = 12;
                    }
                    else
                    {
                        if (LanguageChange.LangNum == 2)
                        {
                            XPtext.text = "Partitur" + totalscore;
                            XPtext.fontSize = 12;
                        }
                        else
                        {
                            if (LanguageChange.LangNum == 3)
                            {
                                XPtext.text = "счет" + totalscore;
                                XPtext.fontSize = 12;
                            }
                            else
                            {
                                if (LanguageChange.LangNum == 4)
                                {
                                    XPtext.text = "Puntos" + totalscore;
                                    XPtext.fontSize = 12;
                                }
                            }
                        }
                    }
                }
                
                
                
                
            }
            hpText.text = "" + playerCurrentHealth + "/" + playerBaseHealth;
            if (LanguageChange.LangNum == 0)
            {
                
                levelText.text = "Player Lvl:" + currentPlayerLevel;
                islandtext.text = "Island #:" + levelMultiplier;
            }
            else
            {
                if (LanguageChange.LangNum == 1)
                {
                    levelText.text = "玩家等级" + currentPlayerLevel;
                    levelText.fontSize = 12;
                    islandtext.text = "岛＃:" + levelMultiplier;
                    islandtext.fontSize = 12;
                }
                else
                {
                    if (LanguageChange.LangNum == 2)
                    {
                        levelText.text = "Spieler Level" + currentPlayerLevel;
                        levelText.fontSize = 12;
                        islandtext.text = "Insel #:" + levelMultiplier;
                        islandtext.fontSize = 12;
                    }
                    else
                    {
                        if (LanguageChange.LangNum == 3)
                        {
                            levelText.text = "Уровень игрока" + currentPlayerLevel;
                            levelText.fontSize = 12;
                            islandtext.text = "Остров №:" + levelMultiplier;
                            islandtext.fontSize = 12;
                        }
                        else
                        {
                            if (LanguageChange.LangNum == 4)
                            {
                                levelText.text = "Nivel jugador" + currentPlayerLevel;
                                levelText.fontSize = 12;
                                islandtext.text = "Island＃:" + levelMultiplier;
                                islandtext.fontSize = 12;
                            }
                        }
                    }
                }
               
                
            }
                if (playerCurrentHealth <= 0)
                {
                    PlayerDied.playerisdead = true;
                }
            XPtoNextLevel = 300 * (currentPlayerLevel * currentPlayerLevel);
            if (playerXP >= XPtoNextLevel)
                {
                    //play a sound?

                    if (GameModeScript.GameMode == 1)
                    {
                        if (!justLeveled)
                        {
                           if (!playedyet)
                           {
                            sound.clip = levelup;
                            sound.Play();
                            playedyet = true;
                           }
                            BeginLevelUp();
                        }
                    }


                }
            
            }
        }
    }

