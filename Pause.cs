using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Pixelation.Scripts;
using VRTK;


public class Pause : MonoBehaviour {


    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontrollerScript;
    private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    public static bool gamePaused;
    public bool pauseCheck;
    public Rigidbody[] rbArray;
    public VRTK_StraightPointerRenderer straightRenderer;
    public VRTK_Pointer pointer;
    

   // public Pixelation pixel;

    public  bool pixeloff;

    void OnEnable()
    {
        fpscontrollerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        //pixel = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Pixelation>();
        if(!pointer){
            pointer = GameObject.Find("RightController").GetComponent<VRTK_Pointer>();
        }
        straightRenderer = GameObject.Find("RightController").GetComponent<VRTK_StraightPointerRenderer>();
      //  pointer.enabled = false;
       // straightRenderer.enabled = false;

    }


    public void MenuOn()
    {
        print("Menu On");
        ViveController.dontGesture = true;
        if(fpscontrollerScript == null)
        {
            fpscontrollerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        }
        if (pointer)
        {
            pointer.enabled = true;
        }
        straightRenderer.enabled = true;
        //VRTK_TransformFollow tFollow = GameObject.Find("[VRTK][AUTOGEN][RightController][BasePointerRenderer_Origin_Smoothed]").GetComponent<VRTK_TransformFollow>();
        //tFollow.moment = VRTK_TransformFollow.FollowMoment.OnLateUpdate;
        //VRTK_TransformFollow.FollowMoment == 0;

        //  if (pixel == null)
        //  {
        //       pixel = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Pixelation>();
        //   }
        fpscontrollerScript.enabled = false;
        //if (pixel.enabled)
       // {
        //    pixel.enabled = false;
       // }
        //m_TimeScaleRef = Time.timeScale;
        //Time.timeScale = 0f;

        //rbArray = GameObject.FindObjectsOfType<Rigidbody>();
        


        //m_VolumeRef = AudioListener.volume;
        AudioListener.volume = .2f;

        gamePaused = true;
        pauseCheck = gamePaused;
    }


    public void MenuOff()
    {
        ViveController.dontGesture = false;
        if (fpscontrollerScript)
        {
            fpscontrollerScript.enabled = true;
        }
        if (pointer)
        {
            pointer.enabled = false;
        }
        straightRenderer.enabled = false;

        //if (!pixel.enabled)

        //   pixel.enabled = true;

       // Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        gamePaused = false;
        pauseCheck = gamePaused;
       
       


    }


    private void Update()
    {
       // if (gamePaused)
       // {
            //foreach (Rigidbody rb in rbArray)
           // {
                //rb.Sleep();
           // }
      //  }
    }
}
