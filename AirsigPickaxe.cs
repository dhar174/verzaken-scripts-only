using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AirSig;

public class AirsigPickaxe : MonoBehaviour {

    public AirSigManager airsigManager;
    public bool triggered;
    //public List<string> gesture;
    AirSigManager.OnDeveloperDefinedMatch
    developerGesture;
    // Use this for initialization
    public ViveController rightGrab;
    public GameObject pick;
    public GameObject pickPrefab;
    void HandleOnDeveloperDefinedMatch(
    long gestureId, string gesture, float score)
    {
        // handle match or fail to match
        if (!rightGrab.holdingObject)
        {
            print("not holding object");
            if (!ViveController.dontGesture)
            {
                print("dontgesture is false");
                if (!Pause.gamePaused)
                {
                    print("game is not paused");
                    if (gesture == "Pickaxe")
                    {
                        print("Gesture equalled pickaxe");
                        //pick = Instantiate(pickPrefab, rightGrab.gameObject.transform.position, rightGrab.gameObject.transform.rotation);
                        triggered = true;
                        //rightGrab.GrabOther();
                    }
                }
            }
        }


    }
    void OnEnable () {
        if (!rightGrab)
        {
            rightGrab = GameObject.Find("Controller (right)").GetComponent<ViveController>();
        }
        //if (!airsigManager)
       // {
            airsigManager = GameObject.Find("AirSigManager").GetComponent<AirSigManager>();
       // }
        airsigManager.SetMode(AirSigManager.Mode.DeveloperDefined);
        //airsigManager.SetDeveloperDefinedTarget(List<string> "Pickaxe");
        airsigManager.SetClassifier(
        "Pickaxe", "");
       airsigManager.SetTriggerStartKeys(
       AirSigManager.Controller.RIGHT_HAND,
       SteamVR_Controller.ButtonMask.Trigger,
       AirSigManager.PressOrTouch.PRESS);
        airsigManager.SetDeveloperDefinedTarget(
        new List<string> {
            "Pickaxe",
              "DOWN" }
    );
        developerGesture =
     new AirSigManager.OnDeveloperDefinedMatch(
        HandleOnDeveloperDefinedMatch);
        airsigManager.onDeveloperDefinedMatch +=
            developerGesture;
    }
	
    public void CreatePickaxe()
    {
        if (pick == null)
        {
            print("pickaxe was null so it was created");
            pick = Instantiate(pickPrefab, rightGrab.gameObject.transform.position, rightGrab.gameObject.transform.rotation);
            rightGrab.GrabOther(pick);
        }
        else
        {
            print("pickaxe is being teleported");
            pick.transform.position = rightGrab.gameObject.transform.position;
            rightGrab.GrabOther(pick);

        }


        //print("Step 3: Profit!");
    }

	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            print("pickaxe triggered");
            CreatePickaxe();
            triggered = false;

        }
        if (!airsigManager)
        {
            airsigManager = GameObject.Find("AirSigManager").GetComponent<AirSigManager>();
        }
        
    }
}
