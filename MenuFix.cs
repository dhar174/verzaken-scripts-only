﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.EventSystems;

public class MenuFix : MonoBehaviour {

    public GameObject EventSystem;
    public VRTK_UIPointer PointerController;

    private VRTK_VRInputModule[] inputModule;

    private void Start()
    {
        StartCoroutine(LateStart(1));
        PointerController = GameObject.Find("RightController").GetComponent<VRTK_UIPointer>();
    }

    private void Update()
    {
        if (inputModule != null)
        {
            if (inputModule.Length > 0)
            {
                inputModule[0].enabled = true;
                if (inputModule[0].pointers.Count == 0)
                    inputModule[0].pointers.Add(PointerController);
            }
            else
                inputModule = EventSystem.GetComponents<VRTK_VRInputModule>();
        }
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        EventSystem = GameObject.Find("EventSystem");
        EventSystem.SetActive(true);
        EventSystem.GetComponent<EventSystem>().enabled = false;
        inputModule = EventSystem.GetComponents<VRTK_VRInputModule>();
    }
}
