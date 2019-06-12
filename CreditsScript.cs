using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour {

    // Use this for initialization

    public void Awake()
    {
        if (LanguageChange.LangNum == 1)
        {
            gameObject.GetComponentInChildren<Text>().fontSize = 22;
            gameObject.GetComponentInChildren<Text>().text = "设计，制作和出版 interFusion Games" +
                "艺术设计，用户界面设计，三维建模是由 金伯利 Kimberly Tregoning" +
                "原声带由金伯利 Kimberly Tregoning" +
                "所有编程由查尔斯 Charles Niswander" +
                "设计理念是“金伯利Tregoning”和“查尔斯Niswander”完成" +
                "特别感谢Zeke Stephenson！" +
                "...即使资源似乎有限，您也可以完成任何事情。 因为我们内在的潜力是无限的。" +
                "特别感谢Emmagine，Ally和Robbie-我们爱你！";
        }
        if (LanguageChange.LangNum == 2)
        {
            gameObject.GetComponentInChildren<Text>().text= "Entwickelt, produziert und veröffentlicht von Interfusion Spiele"+
           "Art Design, UI Design, 3D Modellierung von Kimberly Tregoning" +
                  "Original Tonspur von Kimberly Tregoning" +
           "Alle Programmierung von Charles Niswander" +
            "Design und Konzept von Kimberly Tregoning und Charles Niswander" +
          "Besonderer Dank an Zeke Stephenson!" +
          "...Sie können alles erreichen, selbst wenn die Ressourcen begrenzt scheinen. Weil das Potential dessen, was in uns ist, unbegrenzt ist." +
            "Extra Spezielle dank Emmagine, Ally und Robbie-Wir lieben dich!";
        }
        if (LanguageChange.LangNum == 3)
        {
            gameObject.GetComponentInChildren<Text>().text = "Разработан, изготовлен и Опубликовано Interfusion Игры" +
            "Art Design, UI Design, 3D - моделирование Кимберли Tregoning" +
            "Оригинальная звуковая дорожка Кимберли Tregoning" +
             "Все программирование Чарльз Niswander" +
            "Дизайн и концепция Кимберли Tregoning и Чарльз Niswander" +
           "Особая благодарность Zeke Stephenson!" +
          "...Вы можете добиться чего угодно, даже если ресурсы кажутся ограниченными. Поскольку потенциал того, что находится внутри нас неограничено." +
             "Дополнительная Особая благодарность Emmagine, Ally и Robbie-Мы любим тебя!";
        }
        if (LanguageChange.LangNum == 4)
        {
            gameObject.GetComponentInChildren<Text>().text = "Diseñado, producido y publicado por Interfusion Games" +
            "Arte diseño, la interfaz de usuario de diseño, modelado 3D de Kimberly Tregoning" +
            "Banda Sonora Original de Kimberly Tregoning" +
           "Toda la programación realizada por Charles Niswander" +
            "Diseño y concepto por Kimberly Tregoning y Charles Niswander" +
              "¡Gracias especiales a Zeke Stephenson!" +
              "...Puedes lograr cualquier cosa, incluso cuando los recursos parecen limitados. Debido a que el potencial de lo que está dentro de nosotros es ilimitado." +
           "Gracias especiales adicionales a Emmagine, Ally y Robbie - ¡Te amamos!";
        }
        gameObject.SetActive(false);
    }

    void Start () {
		
	}
    public void OpenCredits()
    {
        if (GameObject.Find("Menu").transform.Find("Panel").gameObject.activeSelf)
        {
            GameObject.Find("Menu").transform.Find("Panel").gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
        if (LanguageChange.LangNum == 1)
        {
            //gameObject.GetComponentInChildren<Text>().fontSize = 22;
            gameObject.GetComponentInChildren<Text>().text = "设计，制作和出版 interFusion Games" +
                "艺术设计，用户界面设计，三维建模是由 金伯利 Kimberly Tregoning" +
                "原声带由金伯利 Kimberly Tregoning" +
                "所有编程由查尔斯 Charles Niswander" +
                "设计理念是“金伯利Tregoning”和“查尔斯Niswander”完成" +
                "特别感谢Zeke Stephenson！" +
                "...即使资源似乎有限，您也可以完成任何事情。 因为我们内在的潜力是无限的。" +
                "特别感谢Emmagine，Ally和Robbie-我们爱你！";
        }
        if (LanguageChange.LangNum == 2)
        {
            gameObject.GetComponentInChildren<Text>().text = "Entwickelt, produziert und veröffentlicht von Interfusion Spiele" +
           "Art Design, UI Design, 3D Modellierung von Kimberly Tregoning" +
                  "Original Tonspur von Kimberly Tregoning" +
           "Alle Programmierung von Charles Niswander" +
            "Design und Konzept von Kimberly Tregoning und Charles Niswander" +
          "Besonderer Dank an Zeke Stephenson!" +
          "...Sie können alles erreichen, selbst wenn die Ressourcen begrenzt scheinen. Weil das Potential dessen, was in uns ist, unbegrenzt ist." +
            "Extra Spezielle dank Emmagine, Ally und Robbie-Wir lieben dich!";
        }
        if (LanguageChange.LangNum == 3)
        {
            gameObject.GetComponentInChildren<Text>().text = "Разработан, изготовлен и Опубликовано Interfusion Игры" +
            "Art Design, UI Design, 3D - моделирование Кимберли Tregoning" +
            "Оригинальная звуковая дорожка Кимберли Tregoning" +
             "Все программирование Чарльз Niswander" +
            "Дизайн и концепция Кимберли Tregoning и Чарльз Niswander" +
           "Особая благодарность Zeke Stephenson!" +
          "...Вы можете добиться чего угодно, даже если ресурсы кажутся ограниченными. Поскольку потенциал того, что находится внутри нас неограничено." +
             "Дополнительная Особая благодарность Emmagine, Ally и Robbie-Мы любим тебя!";
        }
        if (LanguageChange.LangNum == 4)
        {
            gameObject.GetComponentInChildren<Text>().text = "Diseñado, producido y publicado por Interfusion Games" +
            "Arte diseño, la interfaz de usuario de diseño, modelado 3D de Kimberly Tregoning" +
            "Banda Sonora Original de Kimberly Tregoning" +
           "Toda la programación realizada por Charles Niswander" +
            "Diseño y concepto por Kimberly Tregoning y Charles Niswander" +
              "¡Gracias especiales a Zeke Stephenson!" +
              "...Puedes lograr cualquier cosa, incluso cuando los recursos parecen limitados. Debido a que el potencial de lo que está dentro de nosotros es ilimitado." +
           "Gracias especiales adicionales a Emmagine, Ally y Robbie - ¡Te amamos!";
        }
        StartCoroutine(Disappear());

    }
    public IEnumerator Disappear()
    {
        yield return new WaitForSecondsRealtime(15);
        gameObject.SetActive(false);
        GameObject.Find("Menu").transform.Find("Panel").gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
