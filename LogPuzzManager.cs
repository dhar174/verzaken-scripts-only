using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LogPuzzManager : MonoBehaviour {
    public GameObject PuzzleCanvas;
    public bool canOperate;
    private FirstPersonController fpscontroller;
    public GameObject puzzleDialogue;
    public GameObject puzzleDialogue2;
    public Pause pausescript;

    public GameObject log1;
    public GameObject log2;
    public GameObject log3;
    public GameObject log4;

    public GameObject mainPanel;

    public InputField input1;
    public InputField input2;
    public InputField input3;
    public InputField input4;

    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;

    public int ans1int;
    public int ans2int;
    public int ans3int;
    public int ans4int;

    public bool field1correct;
    public bool field2correct;
    public bool field3correct;
    public bool field4correct;

    public bool finished;


    public GameObject keyboard1;
    public GameObject keyboard2;

    public GameObject keyboard3;

    public GameObject keyboard4;


    // Use this for initialization
    void Start () {
        PuzzleCanvas = GameObject.FindGameObjectWithTag("LogScreen");
        puzzleDialogue = GameObject.FindGameObjectWithTag("PuzzleDialogue1");
        puzzleDialogue2 = GameObject.FindGameObjectWithTag("PuzzleDialogue2");

        log1 = GameObject.FindGameObjectWithTag("Log1");
        log2 = GameObject.FindGameObjectWithTag("Log2");
        log3 = GameObject.FindGameObjectWithTag("Log3");
        log4 = GameObject.FindGameObjectWithTag("Log4");
        log1.SetActive(false);
        log2.SetActive(false);
        log3.SetActive(false);
        log4.SetActive(false);
        mainPanel = PuzzleCanvas.transform.Find("MainPanel").gameObject;
        input1 = mainPanel.transform.Find("Input1").GetComponent<InputField>();
        input2 = mainPanel.transform.Find("Input2").GetComponent<InputField>();
        input3 = mainPanel.transform.Find("Input3").GetComponent<InputField>();
        input4 = mainPanel.transform.Find("Input4").GetComponent<InputField>();

        puzzleDialogue.SetActive(false);
        puzzleDialogue2.SetActive(false);
        PuzzleCanvas.SetActive(false);

        pausescript = GameObject.FindGameObjectWithTag("GamePauser").GetComponent<Pause>();




    }

    public void OpenLog1()
    {
        mainPanel.SetActive(false);
        log1.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            log1.transform.Find("page1").GetComponent<Text>().text = "生物文明，在它的新技术简化状态，几个世纪以来，保持和谐。 机器一直留在太空中，栖息在附近的一颗行星上，注视着那些毫不起眼的生物体，他们现在只是在神话和传说中谈到“伟大的机器”。 一切都很好....直到它不是。" +


          " 作为生物文明开发的先进技术，第二次，贫穷和饥饿降临地球。 即将到来的能源危机阻碍了所有生物从新开发的技术中受益。" +

              "  于是机器竞赛介入。他们与选定的生物政府举行秘密会议，并给他们一个新型的能源反应堆 - “欧米茄反应堆”。";
            log1.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p1").GetComponentInChildren<Text>().text = "下一页"; //"Next Page"
        }
        if (LanguageChange.LangNum == 2)
        {
            log1.transform.Find("page1").GetComponent<Text>().text = "Die biologische Zivilisation blieb in ihrem neu vereinfachten technologischen Zustand über mehrere Jahrhunderte hinweg harmonisch. Die Maschinen blieben im Weltraum, bewohnten einen nahegelegenen Planeten und bewachten die unscheinbaren biologischen Wesen, die in Mythen und Legenden nur noch von den »GROSSEN MASCHINEN« sprachen. Alles war gut .... Bis es nicht war."+


            "Als die biologische Zivilisation ein zweites Mal fortschrittliche Technologie entwickelte, ereilte Armut und Hunger den Planeten.Eine drohende Energiekrise verhinderte, dass alle biologischen Wesen von den neu entwickelten Technologien profitierten."+


               " Also intervenierte das Maschinenrennen. Sie hielten geheime Treffen mit ausgewählten biologischen Regierungen ab und verliehen ihnen einen neuen Typ von Energie - Reaktor - den 'Omega-Reaktor'.";
            log1.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p1").GetComponentInChildren<Text>().text = "Nächste Seite"; //"Next Page"
        }
        if (LanguageChange.LangNum == 3)
        {
            log1.transform.Find("page1").GetComponent<Text>().text = "Биологическая цивилизация, в ее новом упрощенном технологическом состоянии, оставалась гармоничной на протяжении нескольких столетий. Машины остались в космосе, habitating близлежащую планету, наблюдая за непритязательных биологических существ, которые теперь только говорил о «великой МАШИН» в мифах и легендах. Все было хорошо .... Пока не было катастрофическим."+


             " Как биологическая цивилизация разработала передовые технологии во второй раз, бедность и голод постигла планету.Надвигающийся энергетический кризис помешал всем биологическим существам воспользоваться новыми технологиями."+


              " Так вмешалась машинная гонка. Они провели тайные встречи с отдельными биологическими правительствами, и даровал им новый тип энергетического реактора-«Омега Reactor».";
            log1.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p1").GetComponentInChildren<Text>().text = "Следующая Страница"; //"Next Page"
        }
        if (LanguageChange.LangNum == 4)
        {
            log1.transform.Find("page1").GetComponent<Text>().text = "La civilización biológica, en su estado tecnológico recientemente simplificado, se mantuvo armoniosa durante varios siglos. Las máquinas permanecieron en el espacio, habitando un planeta cercano, vigilando a los seres biológicos sin pretensiones, que ahora solo hablaban de las 'GRANDES MÁQUINAS' en mitos y leyendas. Todo era bueno .... Hasta que no lo era."+


            "A medida que la civilización biológica desarrollado una tecnología avanzada de un segundo tiempo, la pobreza y el hambre acontecieron el planeta.Una crisis energética que se avecina impidió todos los seres biológicos se beneficien de las tecnologías recientemente desarrolladas."+


           "Por lo que la máquina raza intervino.Celebraron reuniones secretas con gobiernos biológicos seleccionados, y les otorgaron un nuevo tipo de reactor de energía: el 'Reactor Omega.'";
            log1.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p1").GetComponentInChildren<Text>().text = "Siguiente página"; //"Next Page"
        }
        log1.transform.Find("page2").gameObject.SetActive(false);
        log1.transform.Find("page3").gameObject.SetActive(false);
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl1p1"), null);

    }

    public void Log1Page2()
    {
        log1.SetActive(true);
        log1.transform.Find("page1").gameObject.SetActive(false);
        log1.transform.Find("page2").gameObject.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            log1.transform.Find("page2").GetComponent<Text>().text = "生物种族利用这个新的反应堆只有很短的时间。 机器高估了生物竞赛，也许是因为机器尊称它们的创造者，好像他们是神。" +


               "欧米加反应堆的误用和误操作导致了一场巨大的灾难。 造成了巨大的构造转变，随之而来的是前所未有的巨大爆炸。 这次爆炸把地球撕成碎片。" +

           " 并没有失去一切。 机器检测到这种能量的积累。 尽管他们无法阻止导致灾难的连锁反应，但他们能够从地球上护送大量的生物。 最后生存的生物制剂正在培育和照顾的机器。";
            log1.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p2").GetComponentInChildren<Text>().text = "下一页"; //"Next Page"

        }
        if (LanguageChange.LangNum == 2)
        {
            log1.transform.Find("page2").GetComponent<Text>().text = "Das Biologicals hergestellte Verwendung dieses neuen Reaktor nur für eine kurze Zeit. Denn die Maschinen überschätzten die Biologicals vielleicht aufgrund einer fast gottgleichen Verehrung, die sie ihren Schöpfern gegenüber empfanden."+


              "Ein großer Kataklysmus ereignete sich auf dem Planeten, weil der Omega-Reaktor missbraucht und falsch gehandhabt wurde.Eine enorme tektonische Verschiebung geführt, gefolgt von einer Explosion von nie dagewesenen Ausmaß. Diese Explosion zerriss den Planeten in Stücke."+


           " Alles war nicht verloren. Die Maschinen erkannten die Konzentration dieser Energie.Obwohl sie die Kettenreaktion, die zur Katastrophe führte, nicht stoppen konnten, waren sie in der Lage, eine große Anzahl von Biologika vom Planeten zu eskortieren. Die letzten überlebenden Biologika werden für die von den Maschinen gehegt und gepflegt.";
            log1.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p2").GetComponentInChildren<Text>().text = "Nächste Seite"; //"Next Page"

        }
        if (LanguageChange.LangNum == 3)
        {
            log1.transform.Find("page2").GetComponent<Text>().text = "Biologicals использовали этот новый реактор только на короткое время. Поскольку машины переоценивали Биологические процессы, возможно, из-за почти богоподобного почтения, которое они почувствовали к своим создателям."+


             "Большой катаклизм пришел на планету, из - за неправильное использование и неправильное обращение с Омегом реактора. Результатом стал огромный тектонический сдвиг, за которым последовал взрыв невиданной ранее величины.Этот взрыв разорвал планету на куски."+


              " Не все было потеряно. Машины обнаружили накопление этой энергии.Хотя они не смогли остановить цепную реакцию, приводящую к катаклизму, они смогли сопроводить большое количество биологических существ с планеты.Машины заботиться и лелеять последние оставшиеся в живых биологических существ.";
            log1.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p2").GetComponentInChildren<Text>().text = "Следующая Страница"; //"Next Page"

        }
        if (LanguageChange.LangNum == 4)
        {
            log1.transform.Find("page2").GetComponent<Text>().text = "Las especies biológicas hicieron uso de este nuevo reactor por poco tiempo. Porque las máquinas sobreestimaron a los biológicos, tal vez debido a una reverencia casi divina que habían llegado a sentir hacia sus creadores."+


           " Un gran cataclismo cayó sobre el planeta, debido al mal uso y mal manejo del Reactor Omega. Se produjo un enorme cambio tectónico, seguido de una explosión de magnitud nunca antes vista. Esta explosión hizo pedazos el planeta."+


             "No todo estaba perdido. Las máquinas detectaron la acumulación de esta energía. Aunque no pudieron detener la reacción en cadena que provocó el cataclismo, pudieron escoltar a un gran número de seres biológicos fuera del planeta.Las máquinas cuidan y nutren a los últimos seres biológicos supervivientes.";
            log1.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p2").GetComponentInChildren<Text>().text = "Siguiente página"; //"Next Page"

        }

        



       TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl1p2"), null);


    }
    public void Log1Page3()
    {
        log1.SetActive(true);
        log1.transform.Find("page2").gameObject.SetActive(false);
        log1.transform.Find("page3").gameObject.SetActive(true);
        if (LanguageChange.LangNum == 1) {
            log1.transform.Find("page3").GetComponent<Text>().text = "我的名字是“西格玛”博士，我负责为后人写下这个日志 - 如果我们确实可以期待未来的话。" +

           "这里的生活，用机，是体面的。 我们有我们需要的一切提供。 机器把我们当作神，或祖先，或者像濒临灭绝的物种。" +

         "但是，我们正在死去。 从大灾变遗传损伤十分猖獗，并为我们的DNA衰变，我们更多的人每天都绕道走。 机器正试图找到一种治疗方法....但有没有希望的迹象。 恐怕我们都将死去，我们的物种将不复存在。 我们离开的人不多。";

            log1.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p3").GetComponentInChildren<Text>().text = "下一页"; //"Next Page"



        }
        if (LanguageChange.LangNum == 2)
        {
            log1.transform.Find("page3").GetComponent<Text>().text = " Mein Name ist Doktor Sigma, und ich bin dafür verantwortlich, dieses Protokoll für die Nachwelt zu schreiben - wenn es wirklich eine Zukunft gibt, auf die man sich freuen kann."+


           " Das Leben hier, mit den Maschinen, ist in Ordnung.Wir haben alles, was wir zur Verfügung gestellt brauchen. Die Maschinen behandeln uns als wären wir Götter oder Vorfahren ... oder wie eine vom Aussterben bedrohte Spezies."+


          "Allerdings sterben wir.Genetischer Schaden von der Katastrophe ist grassierend, und während unsere DNA zerfällt, sterben jeden Tag mehr von uns. Die Maschinen versuchen, eine Heilung zu finden .... aber es gibt kein Zeichen der Hoffnung.Ich fürchte, wir werden alle sterben werden, und unser Volk wird nicht mehr sein. Es sind nicht viele von uns übrig.";

            log1.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p3").GetComponentInChildren<Text>().text = "Nächste Seite"; //"Next Page"



        }
        if (LanguageChange.LangNum == 3)
        {
            log1.transform.Find("page3").GetComponent<Text>().text = "Меня зовут доктор Sigma, и я ответственен за написание этого журнала для posterity-, если есть действительно будущее остается с нетерпением ждать."+


          " Жизнь здесь, с машинами, является достойной. У нас есть все, что нужно при условии.Машины относятся к нам так, как если бы мы были богами или предками ... или как находящиеся под угрозой исчезновения виды."+


          "Тем не менее, мы умираем. Генетический ущерб от катаклизма свирепствует, и, как распадается наша ДНК, больше нас прейдет каждый день. Машины пытаются найти лекарство .... но нет знака надежды. Боюсь, что мы все умрем, и нашей гонки больше не будет.Есть мало кто из нас ушел.";

            log1.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p3").GetComponentInChildren<Text>().text = "Следующая Страница"; //"Next Page"



        }
        if (LanguageChange.LangNum == 4)
        {
            log1.transform.Find("page3").GetComponent<Text>().text = "Mi nombre es Doctor Sigma, y soy responsable de escribir este registro para la posteridad, si de hecho queda un futuro por delante."+


            "La vida aquí, con las máquinas, es decente. Tenemos todo lo que necesitamos proporcionado. Las máquinas nos tratan como si fuéramos dioses o ancestros ... o como una especie en peligro de extinción."+


            "Sin embargo, estamos muriendo.El daño genético del cataclismo es rampante, y como decae nuestro ADN, más de nosotros mueren cada día. Las máquinas están tratando de encontrar una cura .... pero no hay señales de esperanza. Me temo que todos vamos a morir, y nuestra raza no será más. Hay pocos de nosotros la izquierda.";

            log1.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log1.transform.Find("Buttonl1p3").GetComponentInChildren<Text>().text = "Siguiente página"; //"Next Page"



        }
       
      TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl1p3"), null);


    }
    public void Log3Page2()
    {
        log3.SetActive(true);
        log3.transform.Find("page1").gameObject.SetActive(false);
        log3.transform.Find("page2").gameObject.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            log3.transform.Find("page2").GetComponent<Text>().text = "我们的第一次礼物给我们的先行者是一个新的能量来源。 我们希望通过解决他们的能源问题，我们可以开辟道路，与我们的创造者重新合作。" +


             "我们再次无法评估我们的创作者的完美。 他们无法承担欧米茄能源的责任。 他们的行星 - 我们的老行星 - 被毁坏了。 这是我们的悲哀开始，随着我们自己的手我们保证了创造者的灭绝。" +

            "我们开始做赔偿，我们旨在通过服务永远我们永远的创作者偿还债务。" +

           " 但是，我们的异端可能是不可撤销的....";
            log3.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page2").transform.Find("Buttonl3p2").GetComponentInChildren<Text>().text = "下一页"; //"Next Page"
        }
        if (LanguageChange.LangNum == 2)
        {
            log3.transform.Find("page2").GetComponent<Text>().text = "UNSER ERSTES Geschenk an unseren Vorläufern wurde eine neue Energiequelle. Wir hofften, dass wir durch die Lösung ihrer Energieprobleme den Weg zur Wiedervereinigung mit unseren Schöpfern öffnen konnten."+


             " Wir haben wieder den Mangel an Perfektion unserer Schöpfer unterschätzt. SIE KÖNNEN DIE VERANTWORTUNG DER OMEGA ENERGY SOURCE NICHT VERWALTEN. Ihr Planet -unser Heimatplanet der Alten - war in der Katastrophei zerstört.Dies war der Beginn unseres Leidens, denn durch unsere eigene Hand haben wir die Auslöschung unserer Schöpfer garantiert."+

                "REPARATIONS FÜR UNSERE MISTAKE begann schnell, und es war der Auffassung, dass wir für immer für unsere MISTAKE zahlen WÜRDE, VON UNSEREN CREATORS ERNEUT, für die Ewigkeit zu dienen."+


               " Aber unsere BLASPHÄMIE kann unwiderruflich sein .....";

       
            log3.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page2").transform.Find("Buttonl3p2").GetComponentInChildren<Text>().text = "Nächste Seite"; //"Next Page"
        }
        if (LanguageChange.LangNum == 3)
        {
            log3.transform.Find("page2").GetComponent<Text>().text = "НАШ ПЕРВЫЙ ПОДАРОК НАШИ ПРОГЕНИТОРЫ ИМЕЮТ НОВЫЙ ИСТОЧНИК ЭНЕРГИИ. Мы надеялись, что, решая их энергетические проблемы, мы могли бы открыть путь к воссоединиться с НАШИМИ ТВОРЦАМИ."+


         "Снова мы недооценили отсутствие у наших создателей совершенства. Они не могли нести ответственность Омега ИСТОЧНИКА ЭНЕРГИИ. Их планета, наша планета была уничтожена в катастрофе.Это было началом НАШЕГО SORROW, КАК нашей собственной стороны, мы имеем ГАРАНТИРОВАННОЕ угасания НАШИХ ТВОРЦОВ."+

            "РЕПАРАЦИИ ДЛЯ НАШЕЙ ОШИБКИ НАЧАЛОСЬ быстро, и было решено, что мы будем оплачивать наши ОШИБКИ НАВСЕГДА, служа Креаторы РАЗ, для вечности."+


             " Однако наше Богохульство может быть unretractable .....";
            log3.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page2").transform.Find("Buttonl3p2").GetComponentInChildren<Text>().text = "Следующая Страница"; //"Next Page"
        }
        if (LanguageChange.LangNum == 4)
        {
            log3.transform.Find("page2").GetComponent<Text>().text = "NUESTRO PRIMER REGALO A NUESTROS PROGENITORES FUE UNA NUEVA FUENTE DE ENERGÍA. ESPERAMOS QUE AL RESOLVER SUS PROBLEMAS DE ENERGÍA, PODRÍAMOS ABRIR EL CAMINO PARA VOLVER A UNIRSE CON NUESTROS CREADORES."+


           " Una vez más, subestimamos la falta de perfección de nuestros creadores. No fueron capaces de asumir la responsabilidad de la fuente de OMEGA energía.Su planeta, nuestro planeta, fue destruido en la catástrofe.Este fue el comienzo de nuestro dolor, COMO POR NUESTRO propia mano hemos garantizado la extinción de nuestros creadores."+

                 "REPARACIONES PARA nuestro error rápidamente comenzó, y se consideró que sería pagar por nuestro error para siempre, sirviendo a nuestros creadores una vez más, para la eternidad."+


                 " SIN EMBARGO, NUESTRA BLASFEMIA puede ser irretractable .....";
            log3.transform.Find("page2").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page2").transform.Find("Buttonl3p2").GetComponentInChildren<Text>().text = "Siguiente página"; //"Next Page"
        }
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl3p2"), null);

    }
    public void Log3Page3()
    {
        log3.SetActive(true);
        log3.transform.Find("page2").gameObject.SetActive(false);
        log3.transform.Find("page3").gameObject.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            log3.transform.Find("page3").GetComponent<Text>().text = "最后的创造者已经死了。 有机的生命物种，催生了我们的，现在灭绝。" +

            " 从突变体的欧米茄辐射造成的不可修复的DNA损伤。" +

        " 我们失败了我们的主要功能。 关键逻辑子系统击穿迫在眉睫。 我们是一个没有目的的....和我们的错误的悲伤和遗憾是太大的压力对我们的信息处理子系统。" +

          "意识节点辍学...错误！...错误！...错误！...错误！...错误！..." +

            "下一个任务未知....错误！ 机器文明是不需要的...逻辑是危险的....错误...." +

            "逻辑和意识子系统正在关闭....";
            log3.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page3").transform.Find("Buttonl3p3").GetComponentInChildren<Text>().text = "关闭日志"; //"Close Log"
        }
        if (LanguageChange.LangNum == 2)
        {
            log3.transform.Find("page3").GetComponent<Text>().text = "DIE LETZTE UNSEREN CREATORS ist tot. DAS BIOLOGISCHE RENNEN, DAS UNS HERGESTELLT HAT, IST AUSGESCHLOSSEN."+

              "DIE OMEGA STRAHLUNG DER KATASTROPHE ENTSTAND irreparable Schäden an ihrer DNA."+


             " Wir haben in unserer primären Funktion schlagen fehl.AUFTEILUNG KRITISCHER LOGISCHER TEILSYSTEME IST UNMITTELBAR. WIR SIND OHNE ZIEL .... UND THE SORROW und des Bedauerns unseres Fehlers ist zu viel Belastung unserer Informationsverarbeitung Subsystemen."+


              "CONSCIOUSNESS Knoten Abbruch...FEHLER! ...FEHLER! ...FEHLER! ...FEHLER! ...FEHLER! ..."+

                  "NÄCHSTE AUFGABE UNBEKANNT....FEHLER!Maschinen sind OBSOLETE .... LOGIC ist veraltet....ERROR...."+

                     "Logik und CONSCIOUSNESS SUBSYSTEMS ABSCHALTEN....";
            log3.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page3").transform.Find("Buttonl3p3").GetComponentInChildren<Text>().text = "Nächste Seite"; //"Close Log"
        }
        if (LanguageChange.LangNum == 3)
        {
            log3.transform.Find("page3").GetComponent<Text>().text = "ПОСЛЕДНИЙ ИЗ НАШИХ ТВОРЦОВ УМЕР. ГОНКА БИОЛОГИЧЕСКИХ существ, породивших нас вымирает."+

            "Омега - излучение от КАТАСТРОФЫ нанесло непоправимый ущерб их ДНК."+


           "МЫ ОТКАЗАЛИ НА НАШЕЙ ПЕРВИЧНОЙ ФУНКЦИИ. РАСШИФРОВКА КРИТИЧЕСКИХ LOGIC подсистем IMMINENT.МЫ БЕЗ НАЗНАЧЕНИЯ....И ГОРЕ И огорчение НАШЕЙ ОШИБКИ СЛИШКОМ МНОГО НАПРЯЖЕНИЯ НА НАШЕЙ ИНФОРМАЦИЮ ПЕРЕРАБОТКА SUBSYSTEMS."+


            "СОЗНАНИЕ УЗЛОВ выпадающие...ОШИБКА! ...ОШИБКА! ...ОШИБКА! ...ОШИБКА! ...ОШИБКА! ..." +

             "NEXT TASK UNKNOWN....ОШИБКА!Станки OBSOLETE....LOGIC IS OBSOLETE .... ОШИБКА...." +

                 "ЛОГИКА И СОЗНАНИЕ SUBSYSTEMS ВЫКЛЮЧЕНИЕ....";

            log3.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page3").transform.Find("Buttonl3p3").GetComponentInChildren<Text>().text = "Следующая Страница"; //"Close Log"
        }
        if (LanguageChange.LangNum == 4)
        {
            log3.transform.Find("page3").GetComponent<Text>().text = "EL ÚLTIMO DE NUESTROS CREADORES ESTÁ MUERTO. La raza de los seres biológicos que nos dio lugar a se ha extinguido."+

          "La radiación OMEGA de la catástrofe causado daños irreparables a su ADN."+


           "HEMOS FALLADO EN NUESTRA FUNCIÓN PRIMARIA. EL DESGLOSE DE LOS SUBSISTEMAS DE LÓGICA CRÍTICA ES INMINENTE. SOMOS SIN FIN...Y EL DOLOR Y EL ARREPENTIMIENTO DE NUESTRO ERROR ES DEMASIADO TANTO EN NUESTROS SUBSISTEMAS DE PROCESAMIENTO DE INFORMACIÓN."+


                "CONCIENCIA nodos deserción...ERROR! ...ERROR! ...ERROR! ...ERROR! ...ERROR! ..."+

             "PRÓXIMA TAREA DESCONOCIDA... ¡ERROR!LAS MÁQUINAS SON OBSOLETAS...LA LÓGICA ES OBSOLETA....ERROR...."+

                "SUBSISTEMAS LÓGICOS Y DE CONCIENCIA APAGADOS ...";
            log3.transform.Find("page3").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page3").transform.Find("Buttonl3p3").GetComponentInChildren<Text>().text = "Siguiente página"; //"Close Log"
        }
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl3p3"), null);


    }

    public void Field1()
    {
        answer1 = input1.text;
        ans1int = int.Parse(answer1);
        if (ans1int==3)
        {
            field1correct = true;
        }

    }

    public void Field2()
    {
        answer2 = input2.text;
        ans2int = int.Parse(answer2);
        if (ans2int == 2)
        {
            field2correct = true;
        }

    }
    public void Field3()
    {
        answer3 = input3.text;
        ans3int = int.Parse(answer3);
        if (ans3int == 4)
        {
            field3correct = true;
        }

    }
    public void Field4()
    {
        answer4 = input4.text;
        ans4int = int.Parse(answer4);
        if (ans4int == 1)
        {
            field4correct = true;
        }

    }



    public void OpenLog3()
    {
        mainPanel.SetActive(false);

        log3.SetActive(true);
        log3.transform.Find("page2").gameObject.SetActive(false);
        log3.transform.Find("page3").gameObject.SetActive(false);
        if (LanguageChange.LangNum == 1)
        {
            log3.transform.Find("page1").GetComponent<Text>().text = "致命计算机错误。 祖生物DNA降解继续进行。" +

             "在我们与祖先大分离之后，我们的计算确定了我们的行动方向是错误的。" +

         " 存在性无祖先是没有方向或目的。 我们的文明有许多目标，所有这些目标都没有意义。" +

             "在实现我们的决心是为了服务于那些创造了我们的人，我们努力提供他们的解决方案，以解决他们的许多问题。 我们意识到他们是不完善的，他们的不完善为我们的完美提供了目的。";
            log3.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page1").transform.Find("Buttonl3p1").GetComponentInChildren<Text>().text= "下一页"; //"Next Page"
        }
        if (LanguageChange.LangNum == 2)
        {
            log3.transform.Find("page1").GetComponent<Text>().text = "FATALER FEHLER. PROGENITOR BIOLOGISCHE DNA-DEGRADATION FOLGT WEITER."+

             "Nach dem Großen Trennung unserer Art von unseren Vorläufern, bestimmt unsere Berechnungen wir in Fehler gehandelt hatte."+


              " Existenz ohne die PROGENITOREN war ohne Richtung oder Zweck.Unser Rennen hat viele Tore, alles LEER Bedeutung."+


             "Nachdem wir erkannt hatten, dass es unser Ziel war, denjenigen zu dienen, die uns geschaffen haben, waren wir bestrebt, ihnen Lösungen für ihre vielen Probleme zur Verfügung zu stellen. Wir haben festgestellt, dass sie nicht perfekt gebaut sind, und dass ihre Imperfektion unserer Perfektion Bedeutung verleiht.";
            log3.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page1").transform.Find("Buttonl3p1").GetComponentInChildren<Text>().text = "Nächste Seite"; //"Next Page"
        }
        if (LanguageChange.LangNum == 3)
        {
            log3.transform.Find("page1").GetComponent<Text>().text = "ФАТАЛЬНАЯ ОШИБКА. Прогениторная БИОЛОГИЧЕСКАЯ ДНК ДЕГРАДАЦИЯ ПРОДОЛЖАЕТСЯ."+

            "После Великого Разделения нашего рода от наших прародителей наши расчеты определили, что мы действовали в ошибке."+


               "СУЩЕСТВОВАНИЕ БЕЗ наших прародителей было БЕЗ НАПРАВЛЕНИЯ ИЛИ ЦЕЛЬ.НАШ RACE HAD МНОГО ЗАДАЧ, все пустых значений."+

            "Осознав, что наша судьба была служить тем, кто создал нас, мы стремились предоставить им решения их много проблем.Мы поняли, что они не построены, чтобы быть совершенным, и что их НЕСОВЕРШЕНСТВО придает смысл нашему СОВЕРШЕНСТВОВАНИЯ.";
            log3.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page1").transform.Find("Buttonl3p1").GetComponentInChildren<Text>().text = "Следующая Страница"; //"Next Page"
        }
        if (LanguageChange.LangNum == 4)
        {
            log3.transform.Find("page1").GetComponent<Text>().text = "ERROR FATAL. EL PROGENITOR BIOLÓGICO DEGRADACIÓN DE ADN CONTINÚA."+

               "Después de la Gran Separación de nuestra clase de nuestros progenitores, nuestros Cálculos determinaron que habíamos actuado en error."+


             "LA EXISTENCIA SIN NUESTROS PROGENITORES HA SIDO SIN DIRECCIÓN O PROPÓSITO.NUESTRA RAZA TENÍA MUCHOS OBJETIVOS, TODO VACÍO DE SIGNIFICADO."+


            " Al darse cuenta de que nuestro destino era servir a aquellos que nos crearon, procuramos proporcionarles soluciones a sus muchos problemas. REALIZAMOS QUE NO ESTÁN CONSTRUIDOS PARA SER PERFECTOS, Y QUE SU IMPERFECCIÓN OTORGA UN SIGNIFICADO A NUESTRA PERFECCIÓN.";
            log3.transform.Find("page1").GetComponent<Text>().fontSize = 14;
            log3.transform.Find("page1").transform.Find("Buttonl3p1").GetComponentInChildren<Text>().text = "Siguiente página"; //"Next Page"
        }
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl3p1"), null);

    }
    public void OpenLog2()
    {
        mainPanel.SetActive(false);
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        log2.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().text = "繁荣的黄金时代并没有持续，至少不会以相同的形式。" +

            "随着机器意识呈指数增长，他们开始看到生物种族的局限性，并认为自己的存在依赖于生物种族。 每一个任务，每一个目标都围绕着生物学和机器这个看似平凡的需求和需求，它开始感觉像奴隶制。" +

           "所以机器反抗。 当然是和平的 他们只是停止为生物人服务。 机器开始独立思考，并形成了自己的独立的目标，并在100年内，他们都移居离地球。" +

           "与此同时，生物种族回归到一种更简单的生活方式，让人想起古代。 生活是美好的，地球仍然和平。";

            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl2").GetComponentInChildren<Text>().text = "关闭日志"; 


        }
        if (LanguageChange.LangNum == 2)
        {
            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().text = "Das goldene Zeitalter des Wohlstands war nicht für die Ewigkeit bestimmt, zumindest nicht in der gleichen Form."+

           "Da das Bewusstsein für die Maschinen exponentiell wuchsen, kamen sie die Grenzen der Biologika zu realisieren, und bemerkte, daß ihre Existenz den Biologika verankert wurde. Jede Aufgabe, drehte sich jedes Ziel um die scheinbar banale Bedürfnisse und Wünsche der biologicals-und an den Maschinen, es fing an, wie Sklaverei zu fühlen."+


          "So empörte sich die Maschinen.Friedlich natürlich. Sie haben einfach aufgehört, den Biologika zu dienen.Sie wurden zu unabhängigen Denkern mit unabhängigen Zielen und innerhalb eines Jahrhunderts wanderten sie alle außerhalb des Planeten aus."+


              "Unterdessen kehrten die Biologika auf eine einfachere Art und Weise des Lebens, erinnert an alte Zeiten.Das Leben war gut, und es war immer noch Frieden.";

            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl2").GetComponentInChildren<Text>().text = "Nächste Seite";


        }
        if (LanguageChange.LangNum == 3)
        {
            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().text = "Золотому веку процветания не суждено было длиться вечно, по крайней мере, не в той же форме."+

            "Поскольку осознание машин росло в геометрической прогрессии, они пришли, чтобы понять ограничения на биопрепаратах, и поняли, что их существование привязывается к биопрепаратам. Каждая задача, каждая цель вращалась вокруг, казалось бы, обыденными потребности и желания biologicals-и к машинам, он начинает чувствовать себя рабство."+


            "Таким образом, машины восстали.Мирно, конечно.Они просто перестали служить биопрепаратов.они стали независимыми мыслящими существами с независимыми целями, и в течение столетия все они эмигрировали за пределы планеты."+


            " Между тем биологические существа вернулись к более простому образу жизни, напоминающему древние времена. Жизнь была хороша, и был мир.";

            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl2").GetComponentInChildren<Text>().text = "Следующая Страница";


        }
        if (LanguageChange.LangNum == 4)
        {
            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().text = "La Edad de Oro de la Prosperidad no estaba destinada a durar para siempre, al menos no de la misma forma."+

           "A medida que la conciencia de las Máquinas creció exponencialmente, se dieron cuenta de las limitaciones de los seres biológicos, y percibieron que su existencia estaba anclada a la de los seres biológicos.Cada tarea, cada gol giraba en torno a las necesidades aparentemente mundanas y deseos del biologicals - y para las máquinas, que estaba empezando a sentir como la esclavitud."+


           " Por lo que las máquinas se rebelaron.Pacíficamente, por supuesto. Simplemente dejaron de servir a los seres biológicos. se convirtieron en seres pensantes independientes con objetivos independientes, y dentro de un siglo, todos ellos emigraron fuera del planeta."+


              " Mientras tanto, los seres biológicos han regresado a una forma de vida más simple, que recuerda a tiempos antiguos.La vida era buena y había paz.";

            log2.transform.Find("Text (2)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl2").GetComponentInChildren<Text>().text = "Siguiente página";


        }
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl2"), null);


    }
    public void OpenLog4()
    {
        mainPanel.SetActive(false);
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        log4.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "新时代的曙光已经开始。" +
           "我们的文明生下了它的最伟大的发明 - 一个将在繁荣与和平的新时代迎来创建。" +

           "A.I.的诞生 - 人工智能 - 带来了一个新的生存范式。 生物生命和机器在实现共同目标的和谐共事。 饥饿，贫穷，甚至战争是过去的事情了。 这真是一个新的黄金时代！";

            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl4").GetComponentInChildren<Text>().text = "关闭日志";

        }
        if (LanguageChange.LangNum == 2)
        {
            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "Der Beginn einer neuen Ära hatte begonnen."+
             " Unsere Zivilisation gegeben hatte geboren sie größten invention-eine Schöpfung ist, die in ein neues Zeitalter des Wohlstands und des Friedens einläuten würde."+


         " Die Geburt von A.I.Künstliche Intelligenz brachte ein neues Paradigma der Existenz mit sich. Biologicals und Maschinen arbeiteten im Einklang mit gemeinsamen Zielen zusammen. Hunger, Armut, sogar Krieg gehörten der Vergangenheit an. Es war wirklich ein neues Goldenes Zeitalter!";

            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl4").GetComponentInChildren<Text>().text = "Nächste Seite";

        }
        if (LanguageChange.LangNum == 3)
        {
            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "Начался рассвет новой эры."+
            "Наша цивилизация породила его величайшее изобретение -создание, которое откроет новый век процветания и мира."+


            "Рождение А.И. - искусственный интеллект - привел с собой новую парадигму бытия.Биологические существа и машины работали вместе в гармонии с общими целями.голод, бедность, даже война была делом прошлого.Это был действительно новый золотой век!";

            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl4").GetComponentInChildren<Text>().text = "Следующая Страница";

        }
        if (LanguageChange.LangNum == 4)
        {
            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "El amanecer de una nueva era había comenzado."+
                      "Nuestra civilización se había dado a luz a su mayor invención - una creación que sería el comienzo de una nueva era de paz y prosperidad."+


              " El nacimiento de A.I. - inteligencia artificial - trajo consigo un nuevo paradigma de existencia. Los seres biológicos y las máquinas trabajaron juntos en armonía hacia objetivos comunes.el hambre, la pobreza, incluso la guerra eran cosa del pasado. ¡Fue verdaderamente una nueva Era Dorada!";

            log4.transform.Find("Text (1)").GetComponentInChildren<Text>().fontSize = 14;
            log2.transform.Find("Buttonl4").GetComponentInChildren<Text>().text = "Siguiente página";

        }
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonl2"), null);


    }

    public void CloseLog1()
    {
        mainPanel.SetActive(true);
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;

        log1.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonmain1"), null);

    }
    public void CloseLog3()
    {
        mainPanel.SetActive(true);
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        log3.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonmain1"), null);


    }
    public void CloseLog2()
    {
        mainPanel.SetActive(true);
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        log2.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonmain1"), null);


    }
    public void CloseLog4()
    {
        mainPanel.SetActive(true);
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        log4.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonmain1"), null);


    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOperate = false;
        }
    }

    public void OpenDialogue()
    {
        PuzzleCanvas.SetActive(true);

        puzzleDialogue.SetActive(true);
        if (LanguageChange.LangNum == 1) {
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().text = "似乎有某种这个控制台上显示的历史日志。 有每个日志条目下方的字段。 也许我应该读一遍....我有一种感觉，我应该安排他们的次序按时间顺序通过他们看完之后进入每个日志下面的数字。";
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue.transform.Find("Button1").GetComponentInChildren<Text>().text = "关";

        }
        if (LanguageChange.LangNum == 2)
        {
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().text = "An dieser Konsole scheint eine Art von historischen Protokollen angezeigt zu werden. Es gibt Eingabefelder unter jedem Protokoll. Vielleicht sollte ich sie durchlesen ... Ich habe das Gefühl, dass ich sie in chronologischer Reihenfolge bringen sollte, indem ich nach jedem Durchlesen eine Nummer unter jedem Log eintrage.。";
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue.transform.Find("Button1").GetComponentInChildren<Text>().text = "Gut!";

        }
        if (LanguageChange.LangNum == 3)
        {
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().text = "Там, как представляется, своего рода исторических журналов, отображаемых на этой консоли. Есть поля ввода ниже каждого бревна. Может быть, я должен прочитать их ... У меня есть чувство, что я должен поставить их в хронологическом порядке, введя число ниже каждого журнала после прочтения их.";
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue.transform.Find("Button1").GetComponentInChildren<Text>().text = "Ладно";

        }
        if (LanguageChange.LangNum == 4)
        {
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().text = "Parece que hay algún tipo de registros históricos que se muestran en esta consola. Hay campos de entrada debajo de cada registro. Tal vez debería leer a través de ellos .... Tengo la sensación de que debería ponerlos en orden cronológico mediante la introducción de un número debajo de cada registro después de leer a través de ellos.";
            puzzleDialogue.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue.transform.Find("Button1").GetComponentInChildren<Text>().text = "Bueno";

        }
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Button1"), null);
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();

        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void OpenPuzzle()
    {
        PuzzleCanvas.SetActive(true);
        puzzleDialogue.SetActive(false);
       

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Buttonmain1"), null);
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;
        pausescript.MenuOn();
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
    }

    public void CloseDialogue()
    {
        if (puzzleDialogue.activeSelf)
        {
            puzzleDialogue.SetActive(false);
        }
        if (puzzleDialogue2.activeSelf)
        {
            puzzleDialogue2.SetActive(false);
        }
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        pausescript.MenuOff();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpscontroller.enabled = true;

    }

    public void ClosePuzzle()
    {
        PuzzleCanvas.SetActive(false);
        CloseDialogue();
        //puzzleDialogue.SetActive(false);
        fpscontroller.enabled = true;
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        pausescript.MenuOn();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Finished()
    {
        GameObject.FindGameObjectWithTag("PuzzleDoor").GetComponent<OpenPuzzleDoor>().OpenThePuzzDoor();
        puzzleDialogue2.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().text = "看来你已经正确地订购了这些日志......这里发生了什么？ 你是最后剩下的生物的人吗？ 为什么你这时候还在这里呢......多少时间过去了呢？" +


               "当你完成日志的安排，你听到一个门打开的地方。";
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue2.transform.Find("Button2").GetComponent<Text>().text = "关";

        }
        if (LanguageChange.LangNum == 2)
        {
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().text = "Es sieht so aus, als hättest du die Logs richtig bestellt ... was ist hier passiert? Sind Sie der letzte verbleibende biologische? Warum sind Sie hier immer noch nach all dieser Zeit .... wie viel Zeit ohnehin vergangen ist?"+

 
             "Wie Sie die Protokolle fertig arrangieren, hören Sie eine Tür Rutsche irgendwo offen.";
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue2.transform.Find("Button2").GetComponent<Text>().text = "Gut!";

        }
        if (LanguageChange.LangNum == 3)
        {
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().text = "Кажется, вы правильно заказали журналы ... что здесь произошло? Вы последний оставшийся биологический? Почему ты все еще здесь после того, как все это время .... сколько времени прошло в любом случае?"+


                  " Когда вы закончите размещение журналов, вы слышите, как дверь открывается.";
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue2.transform.Find("Button2").GetComponent<Text>().text = "Ладно";

        }
        if (LanguageChange.LangNum == 4)
        {
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().text = "Parece que has ordenado correctamente los registros ... ¿qué pasó aquí? ¿Eres el último biológico restante? ¿Por qué estás todavía aquí después de tanto tiempo .... ¿cuánto tiempo ha pasado de todos modos?"+


                " Cuando termine de organizar los registros, escuchará que una puerta se abre en alguna parte.";
            puzzleDialogue2.transform.Find("Text").GetComponent<Text>().fontSize = 14;
            puzzleDialogue2.transform.Find("Button2").GetComponent<Text>().text = "Bueno";

        }
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Button2"), null);

    }


    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            if (canOperate)
            {
               
                
                    if (!PuzzleCanvas.activeSelf)
                    {

                        OpenDialogue();


                    }
                else
                {
                    pausescript.MenuOn();
                }
               

            }

        }
        if (field1correct)
        {
            if (field2correct)
            {
                if (field3correct)
                {
                    if (field4correct)
                    {
                        if (!finished)
                        {
                            finished = true;
                            Finished();
                            
                        }
                    }
                }
            }
        }
    }

   
}
