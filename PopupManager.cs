using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour {
    public GameObject popupDiag;
    public Text popuptext;
    public GameObject button;

    public static bool firstgame;

    public static bool firstboxDone;

    public static bool firstenemyEncountered;

    public static bool firstusedPickaxe;

    public static bool firstmined;

    public static bool firstweaponfound;

    public static bool firstartifactfound;

    public static bool firstteleportpopup;
    public static bool secondlevelpopup;

    public SwitchToMenuController switchControllerMode;

    public CharacterStats cstats;

    public Pause pausescript;

    public SoundManager soundmanager;

    public AudioClip floppy;

    public RawImage artifactImage;

    public RenderTexture[] artifactRenders;

    public GameObject ItemDisplay;

    public static bool showedLoading;

    public FadePanels fadepanel;
    private void OnEnable()
    {
        if (!fadepanel)
        {
            fadepanel = GameObject.FindGameObjectWithTag("Canvas").GetComponent<FadePanels>();
        }

        if (!soundmanager)
        {
            soundmanager = GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>();
        }

        if (!ItemDisplay)
        {
            ItemDisplay = GameObject.FindGameObjectWithTag("ItemStage");
        }
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }

        popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        popuptext = popupDiag.GetComponentInChildren<Text>();
    }

   

    // Use this for initialization
    void Start() {

        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
        popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");
        if (!popuptext)
        {
            popuptext = popupDiag.GetComponentInChildren<Text>();
        }

        if (!button)
        {
            button = popupDiag.transform.Find("ContinueButton").gameObject;
        }

        if (!pausescript)
        {
            pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();
        }
        if (!artifactImage)
        {
            artifactImage = GameObject.FindGameObjectWithTag("ArtifactImage").GetComponent<RawImage>();
        }
        artifactImage.enabled = false;
        if (!firstgame)
        {
            deactivateBox();
        }
      //  if (firstgame)
       // {
           
                StartCoroutine(waitforloading());
            
       // }
        if (!soundmanager)
        {
            soundmanager = GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>();
        }
        if (!ItemDisplay)
        {
            ItemDisplay = GameObject.FindGameObjectWithTag("ItemStage");
        }
        cstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        if (GameModeScript.GameMode == 1)
        {
            if (cstats.firstgameint == 1)
            {
                firstgame = true;
            }
            if (cstats.firstboxint == 1)
            {
                firstboxDone = true;
            }
            if (cstats.firstenemyint == 1)
            {
                firstenemyEncountered = true;
            }
            if (cstats.firstpickaxeint == 1)
            {
                firstusedPickaxe = true;
            }
            if (cstats.firstteleportint == 1)
            {
                firstteleportpopup = true;
            }
            if (cstats.firstweaponfoundint == 1)
            {
                firstweaponfound = true;
            }
            if (cstats.firstartifactint == 1)
            {
                firstartifactfound = true;
            }
            if (cstats.firstmineint == 1)
            {
                firstmined = true;
            }
            if (cstats.secondlevelpopupint == 1)
            {
                secondlevelpopup = true;
            }
            StartCoroutine(CheckAgainRoutine());
        }
        if (GameModeScript.GameMode == 0)
        {
            firstgame = true;
            firstboxDone = true;
            firstenemyEncountered = true;
            firstusedPickaxe = true;
            firstteleportpopup = true;
            firstweaponfound = true;
            firstartifactfound = true;
            firstmined = true;
            secondlevelpopup = true;

        }


    }

    public IEnumerator CheckAgainRoutine()
    {
        yield return new WaitForSeconds(.1f);
        CheckAgain();

    }

    public void CheckAgain()
    {
        if (!firstgame)
        {
            deactivateBox();
        }
        //if (firstgame)
        //{
            StartCoroutine(waitforloading());
        //}
        if (!soundmanager)
        {
            soundmanager = GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>();
        }
        if (!ItemDisplay)
        {
            ItemDisplay = GameObject.FindGameObjectWithTag("ItemStage");
        }
        cstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        if (cstats.firstgameint == 1)
        {
            firstgame = true;
        }
        if (cstats.firstboxint == 1)
        {
            firstboxDone = true;
        }
        if (cstats.firstenemyint == 1)
        {
            firstenemyEncountered = true;
        }
        if (cstats.firstpickaxeint == 1)
        {
            firstusedPickaxe = true;
        }
        if (cstats.firstteleportint == 1)
        {
            firstteleportpopup = true;
        }
        if (cstats.firstweaponfoundint == 1)
        {
            firstweaponfound = true;
        }
        if (cstats.firstartifactint == 1)
        {
            firstartifactfound = true;
        }
        if (cstats.firstmineint == 1)
        {
            firstmined = true;
        }
        if (cstats.secondlevelpopupint == 1)
        {
            secondlevelpopup = true;
        }
    }

    public void deactivateBox()
    {
        //switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        if (!button.activeSelf)
        {
            button.SetActive(true);
        }
       // if (switchControllerMode!=null)
       // {
           
                //switchControllerMode.GameMode();
            

       // }
       // else
       // {
            //switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
            //switchControllerMode.GameMode();
       //     deactivateBox();
       // }
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        StopAllCoroutines();
        popupDiag.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        if (fpscontroller)
        {
            fpscontroller.enabled = true;
        }
        if (artifactImage.isActiveAndEnabled)
        {
            artifactImage.enabled = false;
        }
        if (ItemDisplay)
        {
            if (ItemDisplay.activeSelf)
            {
                ItemDisplay.SetActive(false);
            }
        }
        else
        {
            ItemDisplay = GameObject.FindGameObjectWithTag("ItemStage");

        }
        artifactImage.enabled = false;

        pausescript.MenuOff();

    }

    public IEnumerator waitforloading()
    {
        if (SceneManager.GetActiveScene().name == "testscene")
        {
            while (!showedLoading)
            {
                TimeStop.unavailable = true;
                ItemInventory.unavailable = true;
                StartScreen.unavailable = true;
                WeaponInventory.unavailable = true;
                yield return new WaitForSeconds(1);

            }
            if (showedLoading)
            {
                if (GameModeScript.GameMode == 1)
                {
                    if (firstgame)
                    {
                        StartCoroutine(firstbox1());
                    }
                }
                else
                {
                    if (LevelProgression.MasterLevelMultiplier != 2)
                    {

                        deactivateBox();
                    }
                }

            }
        }
        else
        {
            showedLoading = true;
            deactivateBox();
            GameObject.FindGameObjectWithTag("LoadScreen").SetActive(false);
        }

    }

    public IEnumerator firstbox1()
    {
        print("Running Firstbox");

        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
             //switchControllerMode.MenuMode();;
            button.SetActive(false);
            FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
            fpscontroller.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            TimeStop.unavailable = true;
            ItemInventory.unavailable = true;
            StartScreen.unavailable = true;
            WeaponInventory.unavailable = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            pausescript.MenuOn();
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "你睁开你的眼睛，恢复知觉....你从此之前不记得任何东西。";
        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Du öffnest deine Augen und kommst zu .... Du erinnerst dich an nichts von vor diesem Moment.";
        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Вы открываете глаза и пробуждаетесь ... Вы ничего не помните до этого момента.";
        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Abre los ojos y despierta ... No recuerda nada de antes de este momento.";
        }
        yield return new WaitForSecondsRealtime(3);

            popuptext.text = "Where are you? What is this place, and why are you here? More importantly...WHO are you?!?";
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Wo bist du? Was ist dieser Ort, und warum bist du hier? Noch wichtiger ... WER bist du?!?";
        }
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "你在哪？ 这是什么地方，你为什么在这里？ 更重要的是...你是谁？";
        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Где ты? Что это за место, и почему вы здесь? Что еще важнее ... КТО вы?!?";
        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "¿Dónde está usted? ¿Qué es este lugar, y por qué estás aquí? Más importante aún ... ¿QUIÉN eres tú?!?";
        }
        yield return new WaitForSecondsRealtime(5);
        popuptext.text = "Well... Might as well explore...maybe head towards that light in the distance...";
        yield return new WaitForSecondsRealtime(5);
        popuptext.text = "Using the Right controller to reach toward your back. Hold trigger and pull forward, like drawing a sword.";
        button.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

            firstgame = false;
            showedLoading = false;
            print("inside FirstBox");
            StopCoroutine(firstbox1());
        
       
        yield return null;

    }

    public IEnumerator firstenemy()
    {
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        popupDiag.SetActive(true);
        popuptext.text = "There seems to be no reasoning with these machines. They seem to just want to hurt you. You will have to defend yourself.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "似乎没有与这些机器谈判。 他们似乎只是想伤害你。 你将不得不为自己辩护。";
        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Es scheint mit diesen Maschinen keine Argumentation zu sein. Sie scheinen nur um dich verletzen zu wollen. Du wirst dich verteidigen müssen.";
        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Там, кажется, нет рассуждений с этими машинами. Кажется, что они просто хотят причинить вам вред. Вам придется защищаться.";
        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "No parece haber ningún razonamiento con estas máquinas.Parece que solo quieren lastimarte.Tendrás que defenderte.";
        }
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(5);

        firstenemyEncountered = true;
    }

    public IEnumerator firstteleport()
    {
        if (!firstteleportpopup)
        {
            FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
            fpscontroller.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            TimeStop.unavailable = true;
            ItemInventory.unavailable = true;
            StartScreen.unavailable = true;
            WeaponInventory.unavailable = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            pausescript.MenuOn();
            popupDiag.SetActive(true);
            popuptext.text = "What's happening? The Snorkel seems to be causing a strange effect with the pond. Are you teleporting? Is this even a real pond?";
            if (LanguageChange.LangNum == 1)
            {
                popuptext.text = "发生什么事？ 通气管似乎导致与池塘奇效。 你被瞬间移动？ 这是即使是真正的池塘？";

            }
            if (LanguageChange.LangNum == 2)
            {
                popuptext.text = "Was passiert? Der Schnorchel scheint eine seltsame Wirkung mit dem Teich zu verursachen. Sind teleporting Sie? Ist das auch ein echter Teich?";

            }
            if (LanguageChange.LangNum == 3)
            {
                popuptext.text = "Что творится? Snorkel, кажется, вызывает странный эффект с прудом. Вы телепортируетесь? Это даже настоящий пруд?";

            }
            if (LanguageChange.LangNum == 4)
            {
                popuptext.text = "¿Lo que está sucediendo? El tubo respirador parece estar causando un efecto extraño con el estanque. ¿Te estás teletransportando? ¿Es esto incluso un estanque real?";

            }
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);
            firstteleportpopup = true; ;

            yield return new WaitForSecondsRealtime(5);
        }

         
    }

    public void secondlevel()
    {
       
            if (!secondlevelpopup)
            {
                if (!switchControllerMode)
                {
                    switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
                }
                        //switchControllerMode.MenuMode();;
                //GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);
                secondlevelpopup = true;

                FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
                fpscontroller.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                TimeStop.unavailable = true;
                ItemInventory.unavailable = true;
                StartScreen.unavailable = true;
                WeaponInventory.unavailable = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
              if (showedLoading)
              {
                pausescript.MenuOn();
              }

                // popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");
                // popuptext = popupDiag.GetComponentInChildren<Text>();

                //popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

                if (popupDiag)
                {
                    popupDiag.SetActive(true);
                }
                else
                {
                    popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");
                    //StartCoroutine(secondlevel());
                    //yield return null;

                }
                if (popuptext)
                {
                    popuptext = popupDiag.GetComponentInChildren<Text>();
                }
                else
                {
                    popuptext = popupDiag.GetComponentInChildren<Text>();
                    //StartCoroutine(secondlevel());

                    //yield return null;

                }

                //popuptext = popupDiag.GetComponentInChildren<Text>();
                popuptext.text = "This area is similiar to the last, but different... You wonder what you'll find if you proceed far enough? Maybe by the 4th or 5th island you'll find something besides another portal...There's got to be more.";
                if (LanguageChange.LangNum == 1)
                {
                    popuptext.text = "这个区域与最后一个类似，但不同...你想知道如果你继续下去，你会发现什么？ 也许到了第四或第五个岛，你会发现除了另一个门户之外的东西...还有更多。";

                }
                if (LanguageChange.LangNum == 2)
                {
                    popuptext.text = "Dieser Bereich ist dem letzten ähnlich, aber anders ... Sie fragen sich, was Sie finden werden, wenn Sie weit genug fortfahren? Vielleicht finden Sie auf der 4. oder 5. Insel etwas anderes als ein anderes Portal ... Es muss mehr geben.";

                }
                if (LanguageChange.LangNum == 3)
                {
                    popuptext.text = "Этот район похож на последний, но разные ... Вы задаетесь вопросом, что вы найдете, если вы приступите достаточно далеко? Может быть, на 4-м или 5-м острове вы найдете что-то помимо другого портала ... Там должно быть больше.";

                }
                if (LanguageChange.LangNum == 4)
                {
                    popuptext.text = "Esta zona es similar a la anterior, pero diferente ... Uno se pregunta lo que encontrará si continúa lo suficiente? Tal vez por la 4ª o 5ª isla encontrará algo más que otro portal ... Tiene que haber más.";

                }
                //button.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"));

                //yield return new WaitForSecondsRealtime(2);
                //StopCoroutine(secondlevel());
            }
        
    }

    public IEnumerator firstpickaxe()
    {
        if (!firstusedPickaxe)
        {
            if (!popupDiag)
            {
                popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

            }
            popupDiag.SetActive(true);

            FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
            fpscontroller.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            TimeStop.unavailable = true;
            ItemInventory.unavailable = true;
            StartScreen.unavailable = true;
            WeaponInventory.unavailable = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            pausescript.MenuOn();
            popuptext.text = "This is not much of a weapon, perhaps it has another use...";
            if (LanguageChange.LangNum == 1)
            {
                popuptext.text = "这不是一个非常有效的武器，也许它有另一个用途...";

            }
            if (LanguageChange.LangNum == 2)
            {
                popuptext.text = "Das ist keine große Waffe, vielleicht hat es eine andere Verwendung ...";

            }
            if (LanguageChange.LangNum == 3)
            {
                popuptext.text = "Это не так много оружия, возможно, у него есть другое применение ...";

            }
            if (LanguageChange.LangNum == 4)
            {
                popuptext.text = "Esto no es mucho de un arma, tal vez tiene otro uso ...";

            }

            yield return new WaitForSecondsRealtime(2);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);
            //popuptext.fontSize -= 4;
            popuptext.text = "If you reach behind your back with the Right Controller and pull forward while holding Trigger, your pickaxe will be brought to you.";
        }

        firstusedPickaxe = true;
    }
    public IEnumerator firstmine()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        popuptext.text = "You notice an object in the rubble. Maybe you can dig it out? Press Attack or 'E' on the keyboard or 'Y' on the gamepad to mine!";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "你注意到瓦砾中的一个物体。 也许你可以把它挖出来？ 按下键盘上的“Attack”或“E”按钮，或者按下游戏手柄上的“Y”键开始工作！";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Sie bemerken ein Objekt in den Trümmern. Vielleicht kannst du es ausgraben? Drücke Attack oder 'E' auf der Tastatur oder 'Y' auf dem Gamepad, um zu minen!";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Вы заметили объект в щебень. Может быть, вы можете выкопать его? Нажмите «Атака» или «E» на клавиатуре или «Y» на геймпаде, чтобы мой!";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Se nota un objeto entre los escombros. Tal vez puedas desenterrarlo? ¡Presione Attack o 'E' en el teclado o 'Y' en el gamepad para el mío!";

        }
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(5);

        firstmined = true;
    }
    public IEnumerator firstweapon()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        popuptext.text = "You found an ancient weapon. Press Select/Tab to see how strong it is. Use 'Q' or the mouse Scroll Wheel to change between weapons- but you can only manage to hold 2 at once! Hit 'E' key or 'Y' gamepad button to switch back to your pickaxe.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "你发现了一个古老的武器。 按Select / Tab键，看看它是多么强大。 使用“Q”或鼠标滚轮在不同的武器之间切换 - 但你只能设法一次举行2！ 按'E'键或'Y'游戏手柄按钮切换回您的镐。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Du hast eine uralte Waffe gefunden. Drücken Sie Select / Tab, um zu sehen, wie stark es ist. Mit ‚Q‘ oder dem Mausrad zwischen Waffen- ändern, aber Sie können nur verwalten 2 auf einmal zu halten! Drücken Sie die Taste 'E' oder 'Y', um zur Spitzhacke zurückzukehren.";
                    }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Вы нашли древнее оружие. Нажмите Select / Tab, чтобы увидеть, насколько он силен. Используйте «Q» или колесо прокрутки мыши для переключения между но оружейного может управлять только держать 2 сразу! Нажмите кнопку «E» или кнопку «Y», чтобы переключиться обратно на кирку.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Encontraste un arma antigua. Presione Seleccionar / Tab para ver qué tan fuerte es. Use 'Q' o la rueda del ratón para cambiar entre las armas-, pero sólo se puede gestionar para contener 2 a la vez! Hit botón de mando de juegos 'E' o la tecla 'Y' para cambiar de nuevo a su piqueta.";

        }
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(5);

        firstweaponfound = true;
    }
    public IEnumerator firstartifact()
    {
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        ItemDisplay.SetActive(true);
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[13];
        popuptext.text = "You found an ancient artifact. Press Up or i for a look at your collection.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "你发现了一个古老的神器。 按“向上”或“我”采取看看您的收藏。";
        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Du hast ein uraltes Artefakt gefunden. Drücken Sie oben oder i für einen Blick auf Ihre Sammlung.";
        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Вы нашли древний артефакт. Нажмите Up или i, чтобы посмотреть на свою коллекцию.";
        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Encontraste un artefacto antiguo. Pulse Arriba o i para un vistazo a su colección.";
        }
        //yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);

        firstartifactfound = true;
    }

    public IEnumerator microcontroller()
    {
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[9];
        popuptext.text = "It seems to be some sort of microcontroller or CPU, presumably for a robot. Better hang onto it.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "这似乎是某种形式的微控制器或CPU的，机器人的大概一个组成部分。 这将是最好保留它。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Es scheint eine Art Mikrocontroller oder CPU zu sein, vermutlich für einen Roboter. Besser auf sie hängen.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Кажется, это какой-то микроконтроллер или процессор, предположительно для робота. Лучше повесить на него.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Parece ser una especie de microcontrolador o CPU, presumiblemente para un robot. Mejor mantenerla.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);

    }
    public IEnumerator dynamite()
    {

        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");
        }

        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[5];
        popuptext.text = "It appears to be some sort of explosive.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "这似乎是某种爆炸性的。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Es scheint eine Art von Sprengstoff zu sein.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Это, кажется, какое-то взрывчатое вещество.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Parece ser algún tipo de explosivo.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);



    }
    public IEnumerator stopwatch()
    {
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[18];
        popuptext.text = "Looks like those bots are outta time! ...But, who knows if it still works?";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "看起来这些机器人正在运行的时间了！ 按“T”或D-Pad Down键可以达到特殊效果...但是，谁知道它会工作多少次？";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Sieht aus wie diese Bots outta Zeit sind! Drücken Sie T oder D-Pad nach unten für einen besonderen Effekt ... Aber, wer weiß, wie oft es funktionieren wird?";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Похоже, эти боты сбились время! Нажмите T или D-Pad Down для особого эффекта ... Но кто знает, сколько раз он будет работать?";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "¡Parece que esos bots están fuera de tiempo! Presione T o D-Pad Down para obtener un efecto especial ... Pero, ¿quién sabe cuántas veces funcionará?";

        }
        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator stopwatchusedup()
    {
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[18];
        popuptext.text = "It doesn't seem to be working anymore...";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "它似乎并没有被工作了...";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Es scheint nicht mehr zu funktionieren...";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Это, кажется, не будет работать больше ...";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "No parece estar funcionando ya ...";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator snorkel()
    {
        ItemDisplay.SetActive(true);
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[14];
        popuptext.text = "What use would you have for this?";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "可这可能有什么用处？";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Welchen Nutzen hättest du dafür?";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Какую пользу вы бы для этого?";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "¿Qué uso tendrías para esto?";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator atlasbook()
    {
        ItemDisplay.SetActive(true);
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[1];
        popuptext.text = "This will help you detect enemies.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "这将帮助您导航。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Dies wird Ihnen helfen, zu navigieren.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Это поможет вам перемещаться.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Esto te ayudará a navegar.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator diskette()
    {
        ItemDisplay.SetActive(true);
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[4];
        popuptext.text = "This tech looks ancient. You wonder if it works? Better hang on to it.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "这项技术看起来过时的。 你好奇，如果它的工作原理。 这将是明智的保持。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Diese Technologie sieht uralt aus. Du fragst dich, ob es funktioniert? Besser hängen an ihm.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Эта технология выглядит древней. Вы задаетесь вопросом, работает ли это? Лучше повесить на него.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Esta tecnología parece antigua. Uno se pregunta si funciona? Mejor agárrate a eso.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator headphones()
    {
        ItemDisplay.SetActive(true);
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[7];
        popuptext.text = "Music is good for the soul.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "音乐对灵魂有好处。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Musik ist gut für die Seele.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Музыка хороша для души.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "La música es buena para el alma.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator RAM()
    {
        ItemDisplay.SetActive(true);
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[12];
        popuptext.text = "Ha! Memory IS RAM!!!";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "哈哈！ 存储器和RAM都是一样的东西！";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Ha! Speicher ist RAM !!!";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Ха! Память RAM !!!";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "¡Ja! Memoria es RAM !!!";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator pottery()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        ItemDisplay.SetActive(true);

        soundmanager.PlayChaching();

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[11];
        popuptext.text = "Looks like a really old pot.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "看起来像一个真正的老锅。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Sieht aus wie ein wirklich alter Topf.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Похоже, действительно старый горшок.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Se ve como una olla muy viejo.";

        }
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator sprocket()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[16];
        popuptext.text = "A piece of machinery....Guess you should hang onto it.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "一个机器组件....猜猜你应该保留它。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Ein Stück von Maschinen .... Erraten Sie auf sie hängen sollte.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Часть машин .... Думаю, вы должны повесить на него.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Una pieza de maquinaria ... Supongo que deberías quedármelo.";

        }


        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator snibbet()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[15];
        popuptext.text = "A type of computer plange.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "一个snibbet。 这是一个类型的计算机plange的。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Eine Art von Computer Plange.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Тип компьютера Plange.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Un tipo de plange de computadora.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator crucible()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        if (soundmanager != null)
        {
            soundmanager.PlayChaching();
        }
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[3];
        popuptext.text = "An artifact relating to alchemy and herbal medicine.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "有关炼金术和草药的神器。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Ein Artefakt in Bezug auf Alchemie und Kräutermedizin.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Артефакт, относящийся к алхимии и фитотерапии.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Un artefacto relacionado con la alquimia y la medicina herbal.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator statuette()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[17];
        popuptext.text = "An ancient idol of some kind?";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "某种类型的古偶像？";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Ein altes Idol irgendeine Art?";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Древний идол какой-то?";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "¿Un antiguo ídolo de algún tipo?";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator toytrain()
    {
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[19];
        popuptext.text = "A child's toy from times long past.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "一个孩子的玩具从很久以前。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Ein Kinderspielzeug aus längst vergangenen Zeiten.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "детская игрушка со времен давно минувших.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Juguete de un niño de tiempos pasados.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator telephone()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        soundmanager.PlayChaching();
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[20];
        popuptext.text = "A primitive type of communication technology. Interesting.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "通信技术的一种原始类型。 有意思。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Eine primitive Form der Kommunikationstechnologie. Interessant.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Первобытная форма коммуникационных технологий. Интересно.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Una forma primitiva de la tecnología de comunicación. Interesante.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator goblet()
    {
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[6];
        popuptext.text = "Not sure if it's the Grail or a common wine cup. But it's made of gold!";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "不知道这是圣杯或普通酒杯。 但它是由黄金制成的！";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Nicht sicher, ob es der Gral oder ein normaler Weinbecher ist. Aber es ist aus Gold gemacht!！";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Не уверен, что это Грааль или обычная винная чашка. Но он сделан из золота!！";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "No estoy seguro de si es el Grial o una copa de vino normal. ¡Pero está hecho de oro!";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator baseballcap()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[2];
        popuptext.text = "In ancient times, people wore many different types of cranial adornments.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "在古代，人们穿着许多不同类型的颅装饰品。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "In alten Zeiten trugen die Menschen viele verschiedene Arten von Schädelverzierungen.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "В древние времена люди носили много разных видов черепных украшений.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "En la antigüedad, la gente llevaba muchos tipos diferentes de adornos craneales.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator console()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[0];
        popuptext.text = "The early days of 3D simulation technology were full of optimistic enthusiasm! THIS is a valuable artifact!";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "三维仿真技术的早期时代充满了乐观的热情！ 这是一个有价值的神器！";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Die Anfänge der 3D-Simulationstechnologie waren voller optimistischer Begeisterung! Dies ist ein wertvolles Artefakt!";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Первые технологии 3D-моделирования были полны оптимистического энтузиазма! Это ценный артефакт!";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "¡Los primeros días de la tecnología de simulación 3D estaban llenos de entusiasmo optimista! Este es un valioso artefacto!";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator huntinghorn()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        ItemInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[8];
        popuptext.text = "A primitive wind instrument.";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "一个原始管乐器。";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Ein primitives Blasinstrument.";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Примитивный духовой инструмент.";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Un instrumento de viento primitivo.";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    public IEnumerator oldbottle()
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        soundmanager.PlayChaching();
        ItemDisplay.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        artifactImage.enabled = true;
        artifactImage.texture = artifactRenders[10];
        popuptext.text = "Aw, it's empty...";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "噢，这是空的...";

        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Oh, es ist leer ...";

        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Оу, это пустое ...";

        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Aw, está vacío ...";

        }

        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }

    public IEnumerator placeartifact(string name)
    {
        if (!popupDiag)
        {
            popupDiag = GameObject.FindGameObjectWithTag("PopupDiag");

        }
        popupDiag.SetActive(true);
        if (!switchControllerMode)
        {
            switchControllerMode = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SwitchToMenuController>();
        }
                //switchControllerMode.MenuMode();;

        FirstPersonController fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pausescript.MenuOn();
        popuptext.text = "You place the "+ name +" on the strange pedestal...";
        if (LanguageChange.LangNum == 1)
        {
            popuptext.text = "你放置神器" + name + "在陌生的支架顶部...";
        }
        if (LanguageChange.LangNum == 2)
        {
            popuptext.text = "Du platzierst die" + name + "auf dem seltsamen Sockel ...";
        }
        if (LanguageChange.LangNum == 3)
        {
            popuptext.text = "Вы поместите" + name + "на странном пьедестале ...";
        }
        if (LanguageChange.LangNum == 4)
        {
            popuptext.text = "Usted coloca el" + name + "en el extraño pedestal ...";
        }
        if (name=="Kill Disk")
        {
            soundmanager.PlayDisk(floppy);
        }
        yield return new WaitForSecondsRealtime(1);

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"), null);

        yield return new WaitForSecondsRealtime(4);


    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Cancel"))
        {
            deactivateBox();

            
           
          


         }

    }
}
