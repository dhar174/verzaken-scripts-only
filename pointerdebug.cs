using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VRTK;

public class pointerdebug : MonoBehaviour {
    private VRTK_UIPointer laserPointer;

    // Use this for initialization
    void OnEnable () {
        laserPointer = GetComponent<VRTK_UIPointer>();
        laserPointer.UIPointerElementClick -= HandleTriggerClicked;
        laserPointer.UIPointerElementClick += HandleTriggerClicked;
        laserPointer.SelectionButtonPressed += HandleSelectionPress;
        laserPointer.UIPointerElementEnter -= HandlePointerIn;
        laserPointer.UIPointerElementEnter += HandlePointerIn;
        laserPointer.UIPointerElementExit -= HandlePointerOut;
        laserPointer.UIPointerElementExit += HandlePointerOut;
        if (GetComponent<VRTK_UIPointer>() == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerUIPointerEvents_ListenerExample", "VRTK_UIPointer", "the Controller Alias"));
            return;
        }




        //Setup controller event listeners
        //GetComponent<VRTK_UIPointer>().UIPointerElementEnter += VRTK_ControllerUIPointerEvents_ListenerExample_UIPointerElementEnter;

    }

    public void HandleTriggerClicked(object sender, UIPointerEventArgs e)
    {
        print("Clicked" + e.currentTarget.name + "UIPointerArgs");
        if (GameObject.Find("[VRTK][AUTOGEN][RightController][StraightPointerRenderer_Cursor]") != null)
        {
            if (!GameObject.Find("[VRTK][AUTOGEN][RightController][StraightPointerRenderer_Cursor]").GetComponent<cursordebug>())
            {
                GameObject.Find("[VRTK][AUTOGEN][RightController][StraightPointerRenderer_Cursor]").AddComponent<cursordebug>();
            }
        }
    }

    public void HandleSelectionPress(object sender,ControllerInteractionEventArgs e)
    {
        print("Clicked" + e + "controllerInteractionArgs");

    }

    public void HandlePointerIn(object sender, UIPointerEventArgs e)
    {
        print("UI Pointer entered " + e.currentTarget.name + " on Controller index [" + VRTK_ControllerReference.GetRealIndex(e.controllerReference) + "] and the state was " + e.isActive + " ### World Position: " + e.raycastResult.worldPosition);
        if (GetComponent<VRTK_Pointer>())
        {
            GetComponent<VRTK_Pointer>().Toggle(true);
        }
    }
    public void HandlePointerOut(object sender, UIPointerEventArgs e)
    {
        VRTK_Logger.Info("UI Pointer exited " + e.previousTarget.name + " on Controller index [" + VRTK_ControllerReference.GetRealIndex(e.controllerReference) + "] and the state was " + e.isActive);
        if (GetComponent<VRTK_Pointer>())
        {
            GetComponent<VRTK_Pointer>().Toggle(false);
        }
    }

    public void CollisionDetected(GameObject o)
    {
        print("Cursor collided with" + o.name);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
