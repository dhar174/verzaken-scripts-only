using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LanguageChange : MonoBehaviour {
    public Text LScreenText;
    public Text ExitButton;
    public Text ResumeGameButton;
    public Text RetroToggleText;
    public Text PixelationSliderText;
    public Text ClippingSliderText;
    public Text PauseText;
    public Text GameOverText;
    public Text LoadText;

    public Text ClassicButton;
    public Text ArcadeButton;
    public Text ExitGame;
    public Text newGameButton;
    public Text continueButton;
    public Text creditsbutton;
    


    public static int LangNum;


    public Dropdown myDropdown;

    public void Awake()
    {
        if (GameObject.Find("LangText") != null)
        {
            LScreenText = GameObject.Find("LangText").GetComponent<Text>();
        }
        if (!GameObject.FindGameObjectWithTag("MenuIndicator"))
        {
            ExitButton = GameObject.Find("Exit Button").GetComponentInChildren<Text>();
            ResumeGameButton = GameObject.Find("ResumeGameButton").GetComponentInChildren<Text>();
            RetroToggleText = GameObject.Find("RetroToggle").transform.Find("Label").GetComponent<Text>();
            PixelationSliderText = GameObject.Find("PixelationSliderText").GetComponent<Text>();
            ClippingSliderText = GameObject.Find("ClippingSliderText").GetComponent<Text>();
            PauseText = GameObject.Find("PauseText").GetComponent<Text>();
            GameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
            LoadText = GameObject.Find("LoadText").GetComponent<Text>();
        }
        else
        {
            ClassicButton = GameObject.Find("Menu").transform.Find("Panel").transform.Find("Button").GetComponentInChildren<Text>();
            ArcadeButton= GameObject.Find("Menu").transform.Find("Panel").transform.Find("Button (2)").GetComponentInChildren<Text>();
            ExitGame= GameObject.Find("Menu").transform.Find("Panel").transform.Find("Button (1)").GetComponentInChildren<Text>();
            newGameButton= GameObject.Find("Menu").transform.Find("Panel (1)").transform.Find("NewGameButton").GetComponentInChildren<Text>();
            continueButton= GameObject.Find("Menu").transform.Find("Panel (1)").transform.Find("ContinueButton").GetComponentInChildren<Text>();
            creditsbutton = GameObject.Find("Menu").transform.Find("Panel").transform.Find("Credits").GetComponentInChildren<Text>();
        }


        myDropdown = gameObject.GetComponent<Dropdown>();

        myDropdown.onValueChanged.AddListener(delegate {
            SwitchLanguage(myDropdown);
        });
    }

    // Use this for initialization
    void Start () {
        
        
    }
	
    public void SwitchLanguage(Dropdown target)
    {
        var val = target.value;
        if (val == 0)
        {
            //english
            LangNum = 0;
            SwitchEng();

        }
        if (val == 1)
        {
            //Chinese Simplified
            LangNum = 1;
            SwitchChiS();
        }
        if (val == 2)
        {
            //German
            LangNum = 2;
            SwitchGerman();
        }
        if (val == 3)
        {
            //Russian
            LangNum = 3;
            SwitchRussian();
        }
        if (val == 4)
        {
            //Spanish
            LangNum = 4;
            SwitchSpanish();

        }
       

    }


    public void SwitchEng()
    {
        if (LScreenText)
        {
            LScreenText.text = "Languages";
        }
        if (!GameObject.FindGameObjectWithTag("MenuIndicator"))
        {
            ExitButton.text = "Exit Game";
            RetroToggleText.text = "Toggle Retro Effects";
            PixelationSliderText.text = "Pixelation Level";
            ClippingSliderText.text = "View Distance";
            PauseText.text = "Paused";
            ResumeGameButton.text = "Resume Game";
            GameOverText.text = "Try Again";
            LoadText.text = "Generating Overworld";

        }
        else
        {
            if (GameObject.Find("Menu").transform.Find("Panel"))
            {
                ClassicButton.text = "Classic Mode";
                ArcadeButton.text = "Arcade Mode";
                ExitGame.text = "Exit Game";
                creditsbutton.text = "Credits";
            }
            if (GameObject.Find("Menu").transform.Find("Panel (1)"))
            {
                newGameButton.text = "New Game";
                continueButton.text = "Continue Game";
            }
        }
    }

    public void SwitchGerman()
    {
        if (LScreenText)
        {
            LScreenText.text = "Sprachen";
        }
        if (!GameObject.FindGameObjectWithTag("MenuIndicator"))
        {
            ExitButton.text = "Spiel verlassen";
            ExitButton.fontSize = 16;
            RetroToggleText.text = "Toggle Retro-Effekte";
            PixelationSliderText.text = "Pixelierungsgrad";
            
            ClippingSliderText.text = "Ansicht Entfernung";
            PauseText.text = "Pausiert";
            ResumeGameButton.text = "Spiel fortsetzen";
            ResumeGameButton.fontSize = 16;
            GameOverText.text = "Versuch es noch einmal";
            LoadText.text = "Generieren von Überwelt";

        }
        else
        {
            if (GameObject.Find("Menu").transform.Find("Panel"))
            {
                ClassicButton.text = "Klassischer Modus";
                ClassicButton.fontSize = 16;
                ArcadeButton.text = "Arcade-Modus";
                ArcadeButton.fontSize = 16;
                ExitGame.text = "Spiel verlassen";
                ExitGame.fontSize = 16;
                creditsbutton.text = "Kredite";
            }
            if (GameObject.Find("Menu").transform.Find("Panel (1)"))
            {
                newGameButton.text = "Neues Spiel";
                continueButton.text = "Spiel fortsetzen";
            }
        }
    }
    public void SwitchRussian()
    {
        if (LScreenText)
        {
            LScreenText.text = "Языки";
        }
        if (!GameObject.FindGameObjectWithTag("MenuIndicator"))
        {
            ExitButton.text = "Выход из игры";
            RetroToggleText.text = "Переключить Ретро эффекты";
            PixelationSliderText.text = "пикселизация Уровень";
            ClippingSliderText.text = "Просмотр Расстояние";
            PauseText.text = "Приостановлено";
            ResumeGameButton.text = "Возобновить игру";
            GameOverText.text = "Попробуй снова";
            LoadText.text = "Создание Overworld";

        }
        else
        {
            if (GameObject.Find("Menu").transform.Find("Panel"))
            {
                ClassicButton.text = "Классический режим";
                ArcadeButton.text = "Аркадный режим";
                ExitGame.text = "Выход из игры";
                creditsbutton.text = "кредиты";
            }
            if (GameObject.Find("Menu").transform.Find("Panel (1)"))
            {
                newGameButton.text = "Новая игра";
                continueButton.text = "Продолжить предыдущую игру";
            }
        }
    }

    public void SwitchSpanish()
    {
        if (LScreenText)
        {
            LScreenText.text = "Idiomas";
        }
        if (!GameObject.FindGameObjectWithTag("MenuIndicator"))
        {
            ExitButton.text = "Salir del Juego";
            RetroToggleText.text = "Alternar Efectos Retro";
            PixelationSliderText.text = "Nivel de pixelación";
            ClippingSliderText.text = "Ver Distancia";
            PauseText.text = "En Pausa";
            ResumeGameButton.text = "Reanudar Juego";
            GameOverText.text = "Volver a Probar";
            LoadText.text = "Generando Overworld";

        }
        else
        {
            if (GameObject.Find("Menu").transform.Find("Panel"))
            {
                ClassicButton.text = "Modo Clásico";
                ArcadeButton.text = "Modo Arcade";
                ExitGame.text = "Salir del Juego";
                creditsbutton.text = "Créditos";
            }
            if (GameObject.Find("Menu").transform.Find("Panel (1)"))
            {
                newGameButton.text = "Nuevo Juego";
                continueButton.text = "Continuar Juego";
            }
        }
    }

    public void SwitchBrazilianPortuguese()
    {

    }
    public void SwitchFrench()
    {

    }

    public void SwitchKorean()
    {

    }

    public void SwitchThai()
    {

    }
    public void SwitchTurkish()
    {

    }
    public void SwitchPolish()
    {

    }

    public void SwitchJapanese()
    {

    }

    public void SwitchChiS()
    {
        if (LScreenText)
        {
            LScreenText.text = "种语言";

        }
        if (!GameObject.FindGameObjectWithTag("MenuIndicator"))
        {
            ExitButton.text = "退出游戏";
            RetroToggleText.text = "切换复古效果";
            PixelationSliderText.text = "像素级别";
            ClippingSliderText.text = "查看距离";
            PauseText.text = "游戏暂停";
            ResumeGameButton.text = "游戏继续";
            GameOverText.text = "再试一次";
            LoadText.text = "生成游戏世界";
        }
        else
        {
            if (GameObject.Find("Menu").transform.Find("Panel"))
            {
                ClassicButton.text = "经典模式";
                ArcadeButton.text = "街机模式";
                ExitGame.text = "退出游戏";
                creditsbutton.text = "生产队";
            }
            if (GameObject.Find("Menu").transform.Find("Panel (1)"))
            {
                newGameButton.text = "新游戏";
                continueButton.text = "继续以前的游戏";
            }
        }





    }








    // Update is called once per frame
    void Update () {
		
	}
}
