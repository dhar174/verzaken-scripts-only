using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSequence : MonoBehaviour {
    public GameObject player;
    public Camera playercam;
    public Camera endCam;
    public Animator camAnim;
    public GameObject endDiag;
    public GameObject charRagdoll;
    public Transform ragdollTransform;
    public AudioSource music;
    public AudioClip finalsong;
    public AudioClip finalspeech;
    public GameObject EndConsole;

    public static int finalTrigger;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        EndConsole = GameObject.FindGameObjectWithTag("Canvas2").transform.Find("EndConsole").gameObject;

        playercam = player.GetComponentInChildren<Camera>();
        endCam = GameObject.FindGameObjectWithTag("endCam").GetComponent<Camera>();
        camAnim = endCam.gameObject.GetComponent<Animator>();
        endCam.gameObject.GetComponent<AudioListener>().enabled = false;
        endCam.enabled = false;
        endDiag = GameObject.FindGameObjectWithTag("Canvas2").transform.Find("EndDiag").gameObject;
        endDiag.SetActive(false);
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
	}


    public void EndSequence()
    {
        if (EndConsole.activeSelf)
        {
            EndConsole.SetActive(false);
        }


        if (finalTrigger == 0)
        {
            music.Stop();
            music.clip = finalsong;
            music.Play();
            fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            fpscontroller.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;

            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            endDiag.SetActive(true);
            StartCoroutine(ChangeTextThree());
        }


        if (finalTrigger < 5 && finalTrigger > 0)
        {
            music.Stop();
            music.clip = finalsong;
            music.Play();
            fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            fpscontroller.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;

            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            endDiag.SetActive(true);
            StartCoroutine(ChangeTextTwo());


            //print("Animation Triggered");



            //endCam = Camera.main;
            //endCam.gameObject.tag = "MainCamera";

        }

        if (finalTrigger >= 5)
        {
            //music.Stop();
            //music.clip = finalsong;
            //music.Play();
            //playercam.enabled = false;
            //player.GetComponentInChildren<AudioListener>().enabled = false;
            //endCam.gameObject.GetComponent<AudioListener>().enabled = true;
            //endCam.enabled = true;

            //camAnim.SetBool("PlayAnimation", true);

            //GameObject character = Instantiate(charRagdoll, ragdollTransform.position, ragdollTransform.rotation) as GameObject;



            //print("Animation Triggered");



            //endCam = Camera.main;
            //endCam.gameObject.tag = "MainCamera";
           SceneManager.LoadScene("finalheaven");

        }


    }

    public IEnumerator WaitForFinalScene()
    {
        if (music == null)
        {
            music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        }
        music.gameObject.GetComponent<RandomMusic>().enabled = false;
        music.volume = .7f;
        music.loop = false;
        music.Stop();
        music.clip=finalspeech;
        music.Play();
        yield return new WaitForSeconds(226);
        CutsceneFinished();
    }

    public void CutsceneFinished()
    {

        music.Stop();
        music.clip = finalsong;
        music.Play();
        endDiag.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "你毁了中央大脑和关闭整个网络....";
            endDiag.GetComponentInChildren<Text>().fontSize = 14;
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Du haben das zentrale Gehirn zerstört und schloß die gesamte Maschine Netz nach unten.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Вы уничтожили центральный мозг и отключили всю сеть машин.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Has destruido el cerebro central y apagar toda la red de la máquina.";
        }
        StartCoroutine(ChangeTextOne());
    }

    public IEnumerator ChangeTextOne()
    {
        yield return new WaitForSecondsRealtime(5);

        endDiag.GetComponentInChildren<Text>().text = "The biologicals have, in fact, been gone for millenia.....How did you not realize you were one of the machines?";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "该生物制剂有，其实已经走了几千年.....你怎么会不知道你是一台机器？";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Die Biologika haben, in der Tat, für millenia gegangen ..... Wie hast du nicht erkennen, waren Sie einer der Maschinen?";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Биологические существа, по сути, исчезли тысячелетиями назад ... Как вы не видели, что вы были одной из машин?";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Los seres biológicos, de hecho, se habían extinguido hace milenios ... ¿Cómo no has visto que eras una de las máquinas?";
        }
        yield return new WaitForSecondsRealtime(10);


        endDiag.GetComponentInChildren<Text>().text = "This must have been the purpose for which you were built.....as a failsafe";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "这一定是他们为什么构建你.....作为故障保护。";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Dies muss das Ziel gewesen sein, für die Sie wurden gebaut ..... als ausfallsicher";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Это, должно быть, была цель, для которой вы были построены ..... как предотвращение отказа.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Este debe haber sido el propósito por el cual usted fue creado ... como un seguro a prueba de fallas.";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = "Now......now this part of the galaxy will remain silent for millenia to come, thanks to you....";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "现在......现在这个星系的一部分将保持沉默几千年来，因为你....";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Nun ...... nun dieser Teil der Galaxie wird schweigen für millenia zu kommen, dank dir ....";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Теперь ... теперь эта часть галактики останется безмолвной в течение тысячелетий, благодаря вам ....";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Ahora ... ahora esta parte de la galaxia permanecerá en silencio durante milenios, gracias a ti ...";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = "THE END";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "结束";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "DAS ENDE";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "КОНЕЦ";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "EL FIN";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = "Designed, Produced and Published by Interfusion Games";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "设计，制作和出版 interFusion Games";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Entwickelt, produziert und veröffentlicht von Interfusion Spiele";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Разработан, изготовлен и Опубликовано Interfusion Игры";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseñado, producido y publicado por Interfusion Games";
        }
        yield return new WaitForSecondsRealtime(3);
        endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modeling by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "艺术设计，用户界面设计，三维建模是由 金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modellierung von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D-моделирование Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Arte diseño, la interfaz de usuario de diseño, modelado 3D de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Original Sound Track by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "原声带由金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Original Tonspur von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Оригинальная звуковая дорожка Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Banda Sonora Original de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "All Programming by Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "所有编程由查尔斯 Charles Niswander";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Alle Programmierung von Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Все программирование Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Toda la programación de Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Design and Concept by Kimberly Tregoning and Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "设计理念是“金伯利Tregoning”和“查尔斯Niswander”完成";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Design und Konzept von Kimberly Tregoning und Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дизайн и концепция Кимберли Tregoning и Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseño y concepto por Kimberly Tregoning y Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Special Thanks to Zeke Stephenson!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Zeke Stephenson！";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Besonderer Dank an Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Особая благодарность Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "¡Gracias especiales a Zeke Stephenson!";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = "... You can accomplish anything, even when resources seem limited. Because the potential of what is inside of us is unlimited.";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "...即使资源似乎有限，您也可以完成任何事情。 因为我们内在的潜力是无限的。";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Sie können alles erreichen, selbst wenn die Ressourcen begrenzt scheinen. Weil das Potential dessen, was in uns ist, unbegrenzt ist.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Вы можете добиться чего угодно, даже если ресурсы кажутся ограниченными. Поскольку потенциал того, что находится внутри нас неограничено.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Puedes lograr cualquier cosa, incluso cuando los recursos parecen limitados. Debido a que el potencial de lo que está dentro de nosotros es ilimitado.";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Extra Special Thanks To Emmagine, Ally and Robbie- We love you!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Emmagine，Ally和Robbie-我们爱你！";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Extra Spezielle dank Emmagine, Ally und Robbie- Wir lieben dich!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дополнительная Особая благодарность Emmagine, Ally и Robbie- Мы любим тебя!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Gracias especiales adicionales a Emmagine, Ally y Robbie- ¡Te amamos!";
        }
        yield return new WaitForSecondsRealtime(4);
        

        Application.Quit();


    }

    public IEnumerator ChangeTextTwo()
    {
        yield return new WaitForSecondsRealtime(5);

        endDiag.GetComponentInChildren<Text>().text = "You try to click 'Initialize Destruct Sequence' but nothing happens....Then you start to feel a buzzing in your head. What's going on?";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "您尝试点击“初始化序列自毁”，但没有任何反应....然后你开始觉得在你的脑袋嗡嗡的感觉。 什么是出现？";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Sie versuchen, ‚initialisieren Destruct Sequenz‘ klicken, aber es passiert nichts .... Dann starten Sie ein Brummen im Kopf fühlen. Was passiert?";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Вы пытаетесь нажать кнопку «Initialize самоуничтожения последовательности», но ничего не происходит .... Тогда вы начинаете чувствовать жужжание в голове. Что происходит?";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Intenta hacer clic en 'Inicializar Destruct Secuencia', pero no pasa nada .... Entonces se empieza a sentir un zumbido en la cabeza. ¿Qué está pasando?";
        }
        yield return new WaitForSecondsRealtime(10);


        endDiag.GetComponentInChildren<Text>().text = "You hear a voice in your head.....";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "你听到一个在你脑海里说话的声音.....";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Du hörst eine Stimme in deinem Kopf .....";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Вы слышите голос в голове .....";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Oyes una voz en tu cabeza .....";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = " 'You may be the failsafe... But this is not over yet... Even that which reverts to primal ways seeks to survive. Even more so' ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "“虽然你是失败预防......这还没有结束。 即使是以原始方式回归的东西仍然寻求生存。 更是如此。'";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Du bist vielleicht der Failsafe...Aber dieser Krieg ist noch nicht vorbei ... Auch das, was zur Erbsünde zurückkehrt, versucht immer noch zu überleben.Umso mehr'";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы можете быть Отказоустойчивым ... Но эта война еще не закончена ... Даже то, что возвращается к первородному греху, все еще стремится выжить. Даже более того'";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Usted puede ser el Fallo seguro ... Pero esta guerra aún no ha terminado ... Incluso lo que vuelve al pecado original todavía busca sobrevivir. Más aún'";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'If it is the destiny of the Great Machine Race to be destroyed....then so be it. But not today, and not so easily. ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "“如果这是大机械赛的命运被摧毁....那就这样吧。 但不是今天，也不是那么容易。";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Wenn es das Schicksal der Großen Maschinenrasse ist, zerstört zu werden .... dann sei es so. Aber nicht heute und nicht so leicht.‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Если это судьба Великой Расы машины должны быть уничтожены .... то пусть так и будет. Но не сегодня, и не так легко.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Si es el destino de la Gran Carrera de Máquinas ser destruido ... entonces que así sea. Pero no hoy, y no tan fácilmente '.";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'You must find the Keys and return...Only then can the Central AI Hub be shut down and the Machine Race be put out of our misery....Please, do this for us...' ";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "“你必须找到钥匙，然后回来......只有这样，中央AI中心才能关闭，机器竞赛将摆脱我们的痛苦......请为我们做这件事......”";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "‚Sie müssen die Schlüssel finden und zurück ... Nur dann kann der Zentral AI Hub herunterfahren und die Maschine Rennen aus unserem Elend sein werden gestellt .... Bitte, tun dies für uns ...‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы должны найти Ключи и вернуться ... Только тогда Центральный центр АИ будет закрыт, а машинная гонка будет устранена из наших страданий ... Пожалуйста, сделайте это для нас ...»";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Debes encontrar las Llaves y regresar ... Solo entonces se puede cerrar el Centro de Inteligencia Artificial Central y sacar a la Carrera de Máquinas de nuestra miseria ... Por favor, haz esto por nosotros ...'";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'The Keys appear as particular ancient artifacts. Be merciful and....End our misery.' ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "“多个键看起来像特定的古代文物。 要慈悲....结束我们的痛苦。”";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Die Schlüssel erscheinen als besondere antike Artefakte. Seien Sie barmherzig und .... beenden unser Elend.‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Ключи выглядят как особые древние артефакты. Будь милостив и .... Конец наши страдания.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Las teclas aparecen como particulares artefactos antiguos. Sé misericordioso y .... Terminar nuestra miseria '.";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = " 'You did not gather all the Keys. REBOOTING...' ";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "“你没有收集所有的钥匙。正在重新启动...”";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "‚Du hast alle Schlüssel nicht sammeln. Neubooten ... '";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы не собрали все Ключи. перезагрузите ...";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'No reuniste todas las llaves. REINICIAR...'";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "THE END?......Certainly not.";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "结束了吗？......当然不是。";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "DAS ENDE? ...... Sicherlich nicht.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "КОНЕЦ? ...... Конечно нет.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "¿EL FIN? ...... Ciertamente no.";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = "Designed, Produced and Published by Interfusion Games";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "设计，制作和出版 interFusion Games";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Entwickelt, produziert und veröffentlicht von Interfusion Spiele";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Разработан, изготовлен и Опубликовано Interfusion Игры";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseñado, producido y publicado por Interfusion Games";
        }
        yield return new WaitForSecondsRealtime(3);
        endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modeling by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "艺术设计，用户界面设计，三维建模是由 金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modellierung von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D-моделирование Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Arte diseño, la interfaz de usuario de diseño, modelado 3D de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Original Sound Track by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "原声带由金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Original Tonspur von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Оригинальная звуковая дорожка Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Banda Sonora Original de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "All Programming by Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "所有编程由查尔斯 Charles Niswander";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Alle Programmierung von Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Все программирование Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Toda la programación de Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Design and Concept by Kimberly Tregoning and Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "设计理念是“金伯利Tregoning”和“查尔斯Niswander”完成";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Design und Konzept von Kimberly Tregoning und Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дизайн и концепция Кимберли Tregoning и Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseño y concepto por Kimberly Tregoning y Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Special Thanks to Zeke Stephenson!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Zeke Stephenson！";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Besonderer Dank an Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Особая благодарность Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "¡Gracias especiales a Zeke Stephenson!";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = "... You can accomplish anything, even when resources seem limited. Because the potential of what is inside of us is unlimited.";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "...即使资源似乎有限，您也可以完成任何事情。 因为我们内在的潜力是无限的。";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Sie können alles erreichen, selbst wenn die Ressourcen begrenzt scheinen. Weil das Potential dessen, was in uns ist, unbegrenzt ist.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Вы можете добиться чего угодно, даже если ресурсы кажутся ограниченными. Поскольку потенциал того, что находится внутри нас неограничено.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Puedes lograr cualquier cosa, incluso cuando los recursos parecen limitados. Debido a que el potencial de lo que está dentro de nosotros es ilimitado.";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Extra Special Thanks To Emmagine, Ally and Robbie- We love you!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Emmagine，Ally和Robbie-我们爱你！";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Extra Spezielle dank Emmagine, Ally und Robbie- Wir lieben dich!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дополнительная Особая благодарность Emmagine, Ally и Robbie- Мы любим тебя!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Gracias especiales adicionales a Emmagine, Ally y Robbie- ¡Te amamos!";
        }
        yield return new WaitForSecondsRealtime(4);

        LevelProgression.MasterLevelMultiplier = 1;
        GameObject.Find("BtnManager").GetComponent<BtnManager>().Continue();
        LevelProgression.MasterLevelMultiplier = 1;



    }

    public IEnumerator ChangeTextThree()
    {
        yield return new WaitForSecondsRealtime(5);

        endDiag.GetComponentInChildren<Text>().text = "You try to click 'Initialize Destruct Sequence' but nothing happens....Then you start to feel a buzzing in your head. What's going on?";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "您尝试点击“初始化序列自毁”，但没有任何反应....然后你开始觉得在你的脑袋嗡嗡的感觉。 什么是出现？";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Sie versuchen, ‚initialisieren Destruct Sequenz‘ klicken, aber es passiert nichts .... Dann starten Sie ein Brummen im Kopf fühlen. Was passiert?";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Вы пытаетесь нажать кнопку «Initialize самоуничтожения последовательности», но ничего не происходит .... Тогда вы начинаете чувствовать жужжание в голове. Что происходит?";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Intenta hacer clic en 'Inicializar Destruct Secuencia', pero no pasa nada .... Entonces se empieza a sentir un zumbido en la cabeza. ¿Qué está pasando?";
        }
        yield return new WaitForSecondsRealtime(10);


        endDiag.GetComponentInChildren<Text>().text = "Suddenly you can see nothing, hear nothing.... Then, a voice in your head...";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "突然，你什么都看不到，什么也听不见......然后，你的脑袋里有一个声音。";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Plötzlich kann man nichts sehen, nichts hören .... Dann eine Stimme in deinem Kopf ...";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Внезапно вы ничего не видите, ничего не слышите ... Тогда голос в голове ...";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "De repente se puede ver nada, no escuchar nada .... A continuación, una voz en su cabeza ...";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = " 'You may be the failsafe... But this is not over yet... Even that which reverts to primal ways seeks to survive. Even more so' ";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "“虽然你是失败预防......这还没有结束。 即使是以原始方式回归的东西仍然寻求生存。 更是如此。'";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Du bist vielleicht der Failsafe...Aber dieser Krieg ist noch nicht vorbei ... Auch das, was zur Erbsünde zurückkehrt, versucht immer noch zu überleben.Umso mehr'";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы можете быть Отказоустойчивым ... Но эта война еще не закончена ... Даже то, что возвращается к первородному греху, все еще стремится выжить. Даже более того'";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Usted puede ser el Fallo seguro ... Pero esta guerra aún no ha terminado ... Incluso lo que vuelve al pecado original todavía busca sobrevivir. Más aún'";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'If it is the destiny of the Great Machine Race to be destroyed....then so be it. But not today, and not so easily. ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "“如果这是大机械赛的命运被摧毁....那就这样吧。 但不是今天，也不是那么容易。";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Wenn es das Schicksal der Großen Maschinenrasse ist, zerstört zu werden .... dann sei es so. Aber nicht heute und nicht so leicht.‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Если это судьба Великой Расы машины должны быть уничтожены .... то пусть так и будет. Но не сегодня, и не так легко.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Si es el destino de la Gran Carrera de Máquinas ser destruido ... entonces que así sea. Pero no hoy, y no tan fácilmente '.";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'You must find the Keys and return...Only then can the Central AI Hub be shut down and the Machine Race be put out of our misery....Please, do this for us...' ";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "“你必须找到钥匙，然后回来......只有这样，中央AI中心才能关闭，机器竞赛将摆脱我们的痛苦......请为我们做这件事......”";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "‚Sie müssen die Schlüssel finden und zurück ... Nur dann kann der Zentral AI Hub herunterfahren und die Maschine Rennen aus unserem Elend sein werden gestellt .... Bitte, tun dies für uns ...‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы должны найти Ключи и вернуться ... Только тогда Центральный центр АИ будет закрыт, а машинная гонка будет устранена из наших страданий ... Пожалуйста, сделайте это для нас ...»";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Debes encontrar las Llaves y regresar ... Solo entonces se puede cerrar el Centro de Inteligencia Artificial Central y sacar a la Carrera de Máquinas de nuestra miseria ... Por favor, haz esto por nosotros ...'";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'The Keys appear as particular ancient artifacts. Be merciful and....End our misery.' ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "“多个键看起来像特定的古代文物。 要慈悲....结束我们的痛苦。”";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Die Schlüssel erscheinen als besondere antike Artefakte. Seien Sie barmherzig und .... beenden unser Elend.‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Ключи выглядят как особые древние артефакты. Будь милостив и .... Конец наши страдания.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Las teclas aparecen como particulares artefactos antiguos. Sé misericordioso y .... Terminar nuestra miseria '.";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = " 'You gathered ZERO Keys... REBOOTING...' ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "'你收集了0个键。重新引导”";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Du hast ZERO Keys gesammelt ... REBOOTING ...'";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы собрали ZERO Keys ... REBOOTING ...»";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Has recogido ZERO Keys ... REINICIANDO ...'";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "THE END?......Certainly not.";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "结束了吗？......当然不是。";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "DAS ENDE? ...... Sicherlich nicht.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "КОНЕЦ? ...... Конечно нет.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "¿EL FIN? ...... Ciertamente no.";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = "Designed, Produced and Published by Interfusion Games";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "设计，制作和出版 interFusion Games";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Entwickelt, produziert und veröffentlicht von Interfusion Spiele";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Разработан, изготовлен и Опубликовано Interfusion Игры";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseñado, producido y publicado por Interfusion Games";
        }
        yield return new WaitForSecondsRealtime(3);
        endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modeling by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "艺术设计，用户界面设计，三维建模是由 金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modellierung von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D-моделирование Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Arte diseño, la interfaz de usuario de diseño, modelado 3D de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Original Sound Track by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "原声带由金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Original Tonspur von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Оригинальная звуковая дорожка Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Banda Sonora Original de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "All Programming by Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "所有编程由查尔斯 Charles Niswander";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Alle Programmierung von Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Все программирование Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Toda la programación de Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Design and Concept by Kimberly Tregoning and Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "设计理念是“金伯利Tregoning”和“查尔斯Niswander”完成";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Design und Konzept von Kimberly Tregoning und Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дизайн и концепция Кимберли Tregoning и Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseño y concepto por Kimberly Tregoning y Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Special Thanks to Zeke Stephenson!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Zeke Stephenson！";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Besonderer Dank an Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Особая благодарность Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "¡Gracias especiales a Zeke Stephenson!";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = "... You can accomplish anything, even when resources seem limited. Because the potential of what is inside of us is unlimited.";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "...即使资源似乎有限，您也可以完成任何事情。 因为我们内在的潜力是无限的。";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Sie können alles erreichen, selbst wenn die Ressourcen begrenzt scheinen. Weil das Potential dessen, was in uns ist, unbegrenzt ist.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Вы можете добиться чего угодно, даже если ресурсы кажутся ограниченными. Поскольку потенциал того, что находится внутри нас неограничено.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Puedes lograr cualquier cosa, incluso cuando los recursos parecen limitados. Debido a que el potencial de lo que está dentro de nosotros es ilimitado.";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Extra Special Thanks To Emmagine, Ally and Robbie- We love you!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Emmagine，Ally和Robbie-我们爱你！";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Extra Spezielle dank Emmagine, Ally und Robbie- Wir lieben dich!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дополнительная Особая благодарность Emmagine, Ally и Robbie- Мы любим тебя!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Gracias especiales adicionales a Emmagine, Ally y Robbie- ¡Te amamos!";
        }
        yield return new WaitForSecondsRealtime(4);

        PlayerSave.DeletePlayer();
        GameObject.Find("BtnManager").GetComponent<BtnManager>().NewGame();

        


    }

    public void RebootIt()
    {
        StartCoroutine(RebootText());
    }

    public IEnumerator RebootText()
    {

       // EndConsole.SetActive(false);

        music.Stop();
        music.clip = finalsong;
        music.Play();
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        endDiag.SetActive(true);
        yield return new WaitForSecondsRealtime(5);

        endDiag.GetComponentInChildren<Text>().text = "You click Reboot....Then you start to feel a buzzing in your head. What's going on?";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "您单击重新启动....然后你开始觉得在你的脑袋嗡嗡的。 什么是出现？";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Sie Reboot klicken .... Dann Sie ein Summen im Kopf beginnen zu fühlen. Was passiert?";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Вы нажимаете кнопку Reboot .... Затем вы начинаете чувствовать себя жужжание в голове. Что происходит?";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Hace clic en Reiniciar .... Entonces se empieza a sentir un zumbido en la cabeza. ¿Qué está pasando?";
        }
        yield return new WaitForSecondsRealtime(10);


        endDiag.GetComponentInChildren<Text>().text = "Suddenly you can see nothing, hear nothing....Then, a voice in your head...";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "突然，你什么都看不到，什么也听不见......然后，你的脑袋里有一个声音。";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Plötzlich kann man nichts sehen, nichts hören .... Dann eine Stimme in deinem Kopf ...";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Внезапно вы ничего не видите, ничего не слышите ... Тогда голос в голове ...";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "De repente se puede ver nada, no escuchar nada .... A continuación, una voz en su cabeza ...";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = " 'You may be the failsafe... But this is not over yet... Even that which reverts to primal ways seeks to survive. Even more so' ";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "“虽然你是失败预防......这还没有结束。 即使是以原始方式回归的东西仍然寻求生存。 更是如此。'";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Du bist vielleicht der Failsafe...Aber dieser Krieg ist noch nicht vorbei ... Auch das, was zur Erbsünde zurückkehrt, versucht immer noch zu überleben.Umso mehr'";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы можете быть Отказоустойчивым ... Но эта война еще не закончена ... Даже то, что возвращается к первородному греху, все еще стремится выжить. Даже более того'";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Usted puede ser el Fallo seguro ... Pero esta guerra aún no ha terminado ... Incluso lo que vuelve al pecado original todavía busca sobrevivir. Más aún'";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'If it is the destiny of the Great Machine Race to be destroyed....then so be it. But not today, and not so easily. ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "“如果这是大机械赛的命运被摧毁....那就这样吧。 但不是今天，也不是那么容易。";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Wenn es das Schicksal der Großen Maschinenrasse ist, zerstört zu werden .... dann sei es so. Aber nicht heute und nicht so leicht.‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Если это судьба Великой Расы машины должны быть уничтожены .... то пусть так и будет. Но не сегодня, и не так легко.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Si es el destino de la Gran Carrera de Máquinas ser destruido ... entonces que así sea. Pero no hoy, y no tan fácilmente '.";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'You must find the Keys and return...Only then can the Central AI Hub be shut down and the Machine Race be put out of our misery....Please, do this for us...' ";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "“你必须找到钥匙，然后回来......只有这样，中央AI中心才能关闭，机器竞赛将摆脱我们的痛苦......请为我们做这件事......”";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "‚Sie müssen die Schlüssel finden und zurück ... Nur dann kann der Zentral AI Hub herunterfahren und die Maschine Rennen aus unserem Elend sein werden gestellt .... Bitte, tun dies für uns ...‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы должны найти Ключи и вернуться ... Только тогда Центральный центр АИ будет закрыт, а машинная гонка будет устранена из наших страданий ... Пожалуйста, сделайте это для нас ...»";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Debes encontrar las Llaves y regresar ... Solo entonces se puede cerrar el Centro de Inteligencia Artificial Central y sacar a la Carrera de Máquinas de nuestra miseria ... Por favor, haz esto por nosotros ...'";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = " 'The Keys appear as particular ancient artifacts. Be merciful and....End our misery.' ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "“多个键看起来像特定的古代文物。 要慈悲....结束我们的痛苦。”";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Die Schlüssel erscheinen als besondere antike Artefakte. Seien Sie barmherzig und .... beenden unser Elend.‘";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Ключи выглядят как особые древние артефакты. Будь милостив и .... Конец наши страдания.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Las teclas aparecen como particulares artefactos antiguos. Sé misericordioso y .... Terminar nuestra miseria '.";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = " 'You gathered ZERO Keys... REBOOTING...' ";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "'你收集了0个键。重新引导”";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Du hast ZERO Keys gesammelt ... REBOOTING ...'";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "«Вы собрали ZERO Keys ... REBOOTING ...»";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "'Has recogido ZERO Keys ... REINICIANDO ...'";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "THE END?......Certainly not.";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "结束了吗？......当然不是。";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "DAS ENDE? ...... Sicherlich nicht.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "КОНЕЦ? ...... Конечно нет.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "¿EL FIN? ...... Ciertamente no.";
        }
        yield return new WaitForSecondsRealtime(12);
        endDiag.GetComponentInChildren<Text>().text = "Designed, Produced and Published by Interfusion Games";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "设计，制作和出版 interFusion Games";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Entwickelt, produziert und veröffentlicht von Interfusion Spiele";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Разработан, изготовлен и Опубликовано Interfusion Игры";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseñado, producido y publicado por Interfusion Games";
        }
        yield return new WaitForSecondsRealtime(3);
        endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modeling by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {

            endDiag.GetComponentInChildren<Text>().text = "艺术设计，用户界面设计，三维建模是由 金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D Modellierung von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Art Design, UI Design, 3D-моделирование Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Arte diseño, la interfaz de usuario de diseño, modelado 3D de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Original Sound Track by Kimberly Tregoning";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "原声带由金伯利 Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Original Tonspur von Kimberly Tregoning";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Оригинальная звуковая дорожка Кимберли Tregoning";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Banda Sonora Original de Kimberly Tregoning";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "All Programming by Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "所有编程由查尔斯 Charles Niswander";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Alle Programmierung von Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Все программирование Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Toda la programación de Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Design and Concept by Kimberly Tregoning and Charles Niswander";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "设计理念是“金伯利Tregoning”和“查尔斯Niswander”完成";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Design und Konzept von Kimberly Tregoning und Charles Niswander";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дизайн и концепция Кимберли Tregoning и Чарльз Niswander";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Diseño y concepto por Kimberly Tregoning y Charles Niswander";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Special Thanks to Zeke Stephenson!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Zeke Stephenson！";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Besonderer Dank an Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Особая благодарность Zeke Stephenson!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "¡Gracias especiales a Zeke Stephenson!";
        }
        yield return new WaitForSecondsRealtime(10);
        endDiag.GetComponentInChildren<Text>().text = "... You can accomplish anything, even when resources seem limited. Because the potential of what is inside of us is unlimited.";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "...即使资源似乎有限，您也可以完成任何事情。 因为我们内在的潜力是无限的。";
        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Sie können alles erreichen, selbst wenn die Ressourcen begrenzt scheinen. Weil das Potential dessen, was in uns ist, unbegrenzt ist.";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Вы можете добиться чего угодно, даже если ресурсы кажутся ограниченными. Поскольку потенциал того, что находится внутри нас неограничено.";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "... Puedes lograr cualquier cosa, incluso cuando los recursos parecen limitados. Debido a que el potencial de lo que está dentro de nosotros es ilimitado.";
        }
        yield return new WaitForSecondsRealtime(4);
        endDiag.GetComponentInChildren<Text>().text = "Extra Special Thanks To Emmagine, Ally and Robbie- We love you!";
        if (LanguageChange.LangNum == 1)
        {
            endDiag.GetComponentInChildren<Text>().text = "特别感谢Emmagine，Ally和Robbie-我们爱你！";

        }
        if (LanguageChange.LangNum == 2)
        {
            endDiag.GetComponentInChildren<Text>().text = "Extra Spezielle dank Emmagine, Ally und Robbie- Wir lieben dich!";
        }
        if (LanguageChange.LangNum == 3)
        {
            endDiag.GetComponentInChildren<Text>().text = "Дополнительная Особая благодарность Emmagine, Ally и Robbie- Мы любим тебя!";
        }
        if (LanguageChange.LangNum == 4)
        {
            endDiag.GetComponentInChildren<Text>().text = "Gracias especiales adicionales a Emmagine, Ally y Robbie- ¡Te amamos!";
        }
        yield return new WaitForSecondsRealtime(4);

        PlayerSave.DeletePlayer();
        GameObject.Find("BtnManager").GetComponent<BtnManager>().NewGame();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
