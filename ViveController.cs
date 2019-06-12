using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViveController : MonoBehaviour {
    private SteamVR_TrackedObject trackedObject;
    private GameObject collidingObject;
    
    private GameObject objectInHand;

    public GameObject pointerend;

    private Vector3[] objPosArray = new Vector3[15];
    private int objPosIndex = 0;
    private Vector3 throwVelocity;
    private Vector3 objPosAvg = Vector3.zero;

    public float thrust =50;

    public bool holdingObject;
    public static bool dontGesture = false;

    public bool holdingSymbol;

    public ViveController rightGrab;

    public GameObject lastSymbol;
    public bool doneGettingSymbol = false;

    public Vector3 screenPos;
    public Vector3 canvasPos;

    public bool symbolIsGrabbed;

    private SteamVR_ControllerManager controlMan;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)trackedObject.index); }
    }
    void Awake() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        //controlMan = GameObject.Find("[CameraRig]").GetComponent<SteamVR_ControllerManager>();
        if (!rightGrab)
        {
            rightGrab = GameObject.Find("Controller (right)").GetComponent<ViveController>();
        }
    }
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>() ||  objectInHand)
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
        if (other.CompareTag("CanGrab"))
        {
            dontGesture = true;
        }
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        if (!Pause.gamePaused)
        {
            dontGesture = false;
        }

        if (!holdingSymbol)
        {
            collidingObject = null;
        }
    }



    private void GrabObject()
    {
        if (collidingObject.GetComponent<Rigidbody>())
        {
            if (collidingObject.GetComponent<Rigidbody>().isKinematic)
            {
                collidingObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        objectInHand = collidingObject;
        holdingObject = true;
        objectInHand.GetComponent<Rigidbody>().useGravity = false;
        //objectInHand.transform.SetParent(gameObject.transform);
        //objectInHand.GetComponent<Rigidbody>().isKinematic = true;

        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        objectInHand.transform.SetParent(gameObject.transform);
        objectInHand.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z, gameObject.transform.localRotation.w);
        //objectInHand.transform.position = new Vector3(gameObject.transform.Find("Model").transform.position.x, gameObject.transform.Find("Model").transform.position.y, gameObject.transform.Find("Model").transform.position.z);
        gameObject.transform.Find("Model").gameObject.SetActive(false);
        if (objectInHand.name == "pickaxe")
        {
            objectInHand.GetComponent<pickaxeControl>().SwingPickaxe();
        }
        if (objectInHand.name == "pickaxe(Clone)")
        {
            objectInHand.GetComponent<pickaxeControl>().SwingPickaxe();
        }
    }

    private FixedJoint AddSymbolJoint()
    {
        FixedJoint fx = GameObject.Find("RightController").GetComponentInChildren<Rigidbody>().gameObject.AddComponent<FixedJoint>();
        //fx.breakForce = 60000;
        //fx.breakTorque = 60000;
        return fx;
    }

    public GameObject FindSymbol()
    {
        GameObject symb = null;
        symb = GameObject.Find("RightController").GetComponentInChildren<SphereCollider>().gameObject.GetComponent<PassCollision>().touchedSymbol;
        //StartCoroutine(GetSymbol());
        return symb;

    }

    public void GetSymbol()
    {
        GameObject.Find("RightController").GetComponentInChildren<Rigidbody>().gameObject.AddComponent<PassCollision>();

        
    }

    public void GrabSymbol()
    {
        print("grabbing symbol");
        
        if (!GameObject.Find("RightController").GetComponentInChildren<SphereCollider>().gameObject.GetComponent<PassCollision>())
        {
            PassCollision pc = GameObject.Find("RightController").GetComponentInChildren<SphereCollider>().gameObject.AddComponent<PassCollision>() as PassCollision;
            pointerend = pc.gameObject;
        }

        //StartCoroutine(GetSymbol());
        collidingObject = FindSymbol();
        if (collidingObject.CompareTag("PuzzleSymbol") || collidingObject.CompareTag("CorrectSymbol"))
        {
            if (collidingObject.GetComponent<Rigidbody>()!=null)
            {
                if (collidingObject.GetComponent<Rigidbody>().isKinematic)
                {
                    collidingObject.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            else
            {
                collidingObject.AddComponent<Rigidbody>();
                collidingObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            lastSymbol = collidingObject;
            holdingObject = true;
            lastSymbol.GetComponent<Rigidbody>().useGravity = false;
            //objectInHand.transform.SetParent(gameObject.transform);
            //objectInHand.GetComponent<Rigidbody>().isKinematic = true;

            CheckSymbol.inHand = true;

            collidingObject = null;
            var joint = AddSymbolJoint();
            joint.connectedBody = lastSymbol.GetComponent<Rigidbody>();

            //Vector3 worldPos = pointerend.gameObject.transform.position;

           // screenPos = Camera.main.WorldToScreenPoint(worldPos);
           // canvasPos = new Vector3(screenPos.x - Camera.main.pixelWidth / 2, screenPos.y - Camera.main.pixelHeight / 2, lastSymbol.transform.localPosition.z);
           // lastSymbol.transform.localPosition = canvasPos;

            symbolIsGrabbed = true;

           //Vector3 temp = Input.mousePosition;
           //temp.z = GameObject.Find("puzzleone").transform.position.z; // Set this to be the distance you want the object to be placed in front of the camera.
           //lastSymbol.transform.position = Camera.main.WorldToScreenPoint(temp);


            //objectInHand.transform.SetParent(gameObject.transform);
            //objectInHand.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z, gameObject.transform.localRotation.w);
            //objectInHand.transform.position = new Vector3(gameObject.transform.Find("Model").transform.position.x, gameObject.transform.Find("Model").transform.position.y, gameObject.transform.Find("Model").transform.position.z);
            //gameObject.transform.Find("Model").gameObject.SetActive(false);
        }
        print("Symbol Grabbed");
       
    }

    public void GrabOther(GameObject pick)
    {
        //pick = Instantiate(pickPrefab, rightGrab.gameObject.transform.position, rightGrab.gameObject.transform.rotation);

        if (pick.GetComponent<Rigidbody>())
        {
            if (pick.GetComponent<Rigidbody>().isKinematic)
            {
                pick.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        objectInHand = pick;
        holdingObject = true;
        objectInHand.GetComponent<Rigidbody>().useGravity = false;
        objectInHand.transform.SetParent(gameObject.transform);
        //objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        objectInHand.transform.localRotation = new Quaternion(gameObject.transform.localRotation.x, -gameObject.transform.localRotation.y, (gameObject.transform.localRotation.z-25), gameObject.transform.localRotation.w);
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        //objectInHand.transform.SetParent(gameObject.transform);
        //objectInHand.transform.position = new Vector3(gameObject.transform.Find("Model").transform.position.x, gameObject.transform.Find("Model").transform.position.y, gameObject.transform.Find("Model").transform.position.z);
        gameObject.transform.Find("Model").gameObject.SetActive(false);
        pick.GetComponent<pickaxeControl>().SwingPickaxe();

    }


    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        //fx.breakForce = 60000;
        //fx.breakTorque = 60000;
        return fx;
    }

    private void ReleaseObject()
    {
        objectInHand.transform.SetParent(null);

        if (GetComponent<FixedJoint>())
        {
            objectInHand.GetComponent<Rigidbody>().useGravity = true;

            objectInHand.GetComponent<Rigidbody>().isKinematic = false;

            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            for (int i = 0; i < 13; i++)
            {
                objPosAvg += objPosArray[i];
            }
            objPosAvg /= 13;
            throwVelocity = objectInHand.transform.position - objPosAvg;

            throwVelocity = new Vector3(throwVelocity.x, (throwVelocity.y - Physics.gravity.y), throwVelocity.z);

            
            //print(throwVelocity);
            objectInHand.GetComponent<Rigidbody>().angularVelocity =device.angularVelocity;
            objectInHand.GetComponent<Rigidbody>().velocity = device.velocity;
        }


        
        objectInHand.GetComponent<Rigidbody>().AddForce(device.velocity*thrust, ForceMode.Force);
        //print(objectInHand.name + objectInHand.GetComponent<Rigidbody>().velocity);

        //objectInHand.transform.SetParent(null);
        objectInHand = null;
        holdingObject = false;
        dontGesture = false;
        gameObject.transform.Find("Model").gameObject.SetActive(true);

    }

    public void ReleaseSymbol()
    {
        lastSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("PuzzleCanvasOne").transform.Find("Panel").transform);
        print("Released Symbol");
        if (GetComponent<FixedJoint>())
        {
           

            

            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            
        }
        CheckSymbol.inHand = false;
        lastSymbol = null;
        holdingObject = false;
        symbolIsGrabbed = false;
        holdingSymbol = false;

    }

    // Update is called once per frame
    void Update () {
        //device = SteamVR_Controller.Input((int)trackedObject.index);
        if(device.GetAxis().x !=0 || device.GetAxis().y != 0)
        {

        }
        //if (device.GetPressDown(SteamVR_Controller.ButtonMask.))
        //  {

        //}

        if (device.GetHairTrigger())
        {
            if (symbolIsGrabbed)
            {
                Vector3 worldPos = pointerend.gameObject.transform.position;

                screenPos = RectTransformUtility.WorldToScreenPoint(GameObject.FindGameObjectWithTag("PuzzCam").GetComponent<Camera>(), worldPos);
                canvasPos = new Vector3(screenPos.x - GameObject.FindGameObjectWithTag("PuzzCam").GetComponent<Camera>().pixelWidth / 2, screenPos.y - GameObject.FindGameObjectWithTag("PuzzCam").GetComponent<Camera>().pixelHeight / 2, lastSymbol.transform.localPosition.z);
                lastSymbol.transform.localPosition = canvasPos;
            }
        }
        if (device.GetHairTriggerDown())
        {
           if (objectInHand)
           {
                if (objectInHand.gameObject.CompareTag("PuzzleSymbol") || objectInHand.gameObject.CompareTag("CorrectSymbol"))
                {



                }
                else
                {
                    objectInHand.transform.SetParent(null);
                }
                //dontGesture = true;
                    
            }
            else
            {
                if (collidingObject)
                {
                    if (collidingObject.CompareTag("PuzzleSymbol") || collidingObject.CompareTag("CorrectSymbol"))
                    {
                        GrabSymbol();
                    }
                }
            }
        }

        if (!holdingObject)
        {
            dontGesture = false;
        }
        else
        {
            if (holdingObject)
            {
                dontGesture = true;
            }
        }

        if (device.GetHairTriggerUp())
        {
            if (objectInHand)
            {


                if (!Pause.gamePaused)
                {
                    ReleaseObject();
                }

                
            }
            if (lastSymbol)
            {
                

                    ReleaseSymbol();

                
            }
        }


       // if (device.GetHairTriggerDown() && !objectInHand)
      //  {

            //if (collidingObject != null)
           // {
               // if (collidingObject.CompareTag("PuzzleSymbol") || collidingObject.CompareTag("CorrectSymbol"))
               // {
                 //   GrabSymbol();
                //}
            //}
      //  }

            if (device.GetHairTriggerUp() && !objectInHand)
        {
            if (collidingObject)
            {
                if (collidingObject.CompareTag("CanGrab"))
                {
                    if (!collidingObject.gameObject.GetComponent<WeaponStats>())
                    {
                        collidingObject.gameObject.AddComponent<WeaponStats>();
                        collidingObject.gameObject.AddComponent<WeaponStats>().WeaponStrength = (LevelProgression.MasterLevelMultiplier * Random.Range(3, 10));

                    }
                    GrabObject();
                }
                else
                {
                    if (collidingObject.CompareTag("Rock"))
                    {
                        collidingObject.gameObject.AddComponent<WeaponStats>();
                        collidingObject.gameObject.AddComponent<WeaponStats>().WeaponStrength = (LevelProgression.MasterLevelMultiplier * Random.Range(3,10));


                        GrabObject();
                        
                    }
                    else
                    {
                        if (collidingObject.CompareTag("YellowCube"))
                        {
                            collidingObject.gameObject.AddComponent<WeaponStats>();
                            collidingObject.gameObject.AddComponent<WeaponStats>().WeaponStrength = (LevelProgression.MasterLevelMultiplier * Random.Range(3, 10));

                            GrabObject();

                        }
                        else
                        {
                            if (collidingObject.CompareTag("RedCube"))
                            {
                                collidingObject.gameObject.AddComponent<WeaponStats>();
                                collidingObject.gameObject.AddComponent<WeaponStats>().WeaponStrength = (LevelProgression.MasterLevelMultiplier * Random.Range(3, 10));

                                GrabObject();

                            }
                            else
                            {
                                if (collidingObject.CompareTag("GreenCube"))
                                {
                                    collidingObject.gameObject.AddComponent<WeaponStats>();
                                    collidingObject.gameObject.AddComponent<WeaponStats>().WeaponStrength = (LevelProgression.MasterLevelMultiplier * Random.Range(3, 10));

                                    GrabObject();

                                }
                                else
                                {
                                    if (collidingObject.CompareTag("PuzzleSymbol") || collidingObject.CompareTag("CorrectSymbol"))
                                    {
                                        //GrabSymbol();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

      

       // if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
       // {
            //Debug.Log(gameObject.name + " Grip Press");
       // }

        // 5
       

        if (objectInHand  && !objectInHand.gameObject.CompareTag("PuzzleSymbol")&& !objectInHand.gameObject.CompareTag("CorrectSymbol"))
        {
            objPosArray[objPosIndex] = objectInHand.transform.position;
            objPosIndex++;
            if (objPosIndex == 15)
            {
                objPosIndex = 0;
            }
        }

        if (holdingSymbol)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = GameObject.FindGameObjectWithTag("PuzzleCanvasOne").transform.position.z; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }

    }
    //Bernie Should Have Won
}
