using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class RotateCharacter : MonoBehaviour {
    public bool goingRight;
    public bool goingLeft;


    // Use this for initialization
    void Awake()
    {
        

    }

    public void RotatePlayerRight()
    {
        if (!goingLeft)
        {
            Vector3 destination = new Vector3(0, 90, 0);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, destination, Time.deltaTime);
        }


    }

    public void RotatePlayerLeft()
    {

        if (!goingRight)
        {
            Vector3 destination = new Vector3(0, -90, 0);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, destination, Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetAxis("Mouse X") > .3)
        {
            if (CrossPlatformInputManager.GetAxis("Jump") > -.3 && CrossPlatformInputManager.GetAxis("Jump") < .3)
            {
                goingRight = true;

                if (CrossPlatformInputManager.GetButtonDown("PressTouchpad"))
                {
                    RotatePlayerRight();
                    print("RotatedRight");
                }
            }
        }
        if (CrossPlatformInputManager.GetAxis("Mouse X") < -.3)
        {
            if (CrossPlatformInputManager.GetAxis("Jump") > -.3 && CrossPlatformInputManager.GetAxis("Jump") < .3)
            {
                goingLeft = true;
                if (CrossPlatformInputManager.GetButtonDown("PressTouchpad"))
                {
                    RotatePlayerLeft();
                    
                    print("RotatedLeft");
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
      
    }
}
