using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class FadePanels : MonoBehaviour {
    public Image panel1;
    public Image panel2;
    public static bool panelFade;
   
    private float alpha;
    
    
	// Use this for initialization
	void Start () {
        if (!panel1)
        {
           panel1= GameObject.Find("whitepanel1").GetComponent<Image>();
        }
        if (!panel2)
        {
            panel2 = GameObject.Find("whitepanel2").GetComponent<Image>();
        }
	}
	
    public void TurnPanelsOff()
    {
        panelFade = true;
    }
    public void TurnPanelsOn()
    {
        panelFade = false;
    }


	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonUp("Submit"))
        {
            if (panelFade)
            {
                TurnPanelsOn();

            }
            else
            {
                if (!panelFade)
                {
                    TurnPanelsOff();
                }
            }
        }
	}
    private void FixedUpdate()
    {
        if (panelFade)
        {
            if (alpha > 0)
            {
                alpha--;
                panel1.CrossFadeAlpha(alpha, 1, false);
                panel2.CrossFadeAlpha(alpha, 1, false);

            }
        }
        if (!panelFade)
        {
            if (alpha != 64)
            {
                alpha = 64;
                panel1.CrossFadeAlpha(alpha, 1, false);
                panel2.CrossFadeAlpha(alpha, 1, false);
            }
        }
    }
}
