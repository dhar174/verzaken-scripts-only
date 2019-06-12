using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VRTK;

public class VRUI_input2 : MonoBehaviour {
    private VRTK_UIPointer laserPointer;
    // private SteamVR_TrackedController trackedController;

    private void OnEnable()
    {
        print("eNabled");
        //GetComponent<VRTK_UIPointer>().activationMode = VRTK_UIPointer.ActivationMethods.AlwaysOn;
        laserPointer = GetComponent<VRTK_UIPointer>();
        laserPointer.UIPointerElementEnter -= HandlePointerIn;
        laserPointer.UIPointerElementEnter += HandlePointerIn;
        laserPointer.UIPointerElementExit -= HandlePointerOut;
        laserPointer.UIPointerElementExit += HandlePointerOut;


        laserPointer.UIPointerElementClick -= HandleTriggerClicked;
        laserPointer.UIPointerElementClick += HandleTriggerClicked;
    }

    private void HandleTriggerClicked(object sender, UIPointerEventArgs e)
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {

            ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }
    }

    private void HandlePointerIn(object sender, UIPointerEventArgs e)
    {
        var button = e.currentTarget.GetComponent<Button>();
        if (button != null)
        {
            button.Select();
           // EventSystem.current.SetSelectedGameObject(null);
          //  button.Select();
          //  EventSystem.current.SetSelectedGameObject(e.currentTarget);
          //  button.Select();




            //Debug.Log("HandlePointerIn", e.currentTarget.gameObject);
        }
        else
        {
            //print("Button " + e.currentTarget.gameObject.name + " is null");
            
        }
    }




    private void HandlePointerOut(object sender, UIPointerEventArgs e)
    {

       // var button = e.previousTarget.GetComponent<Button>();
       // if (button != null)
        //{


            EventSystem.current.SetSelectedGameObject(null);
            //Debug.Log("HandlePointerOut");
       // }
    }
}
