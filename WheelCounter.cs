using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCounter : MonoBehaviour
{
    public static int wheelsLeft;
    public BossTowerAI Boss;
    public Collider[] wheelColls1;
    public Collider[] wheelColls2;
    public Collider[] wheelColls3;

    public Collider[] wheelColls4;

    public bool allFinished;



    // Use this for initialization
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("BossBotTower").GetComponent<BossTowerAI>();
        wheelsLeft = 4;
        wheelColls1 = GameObject.Find("Bone.019").GetComponents<Collider>();
        wheelColls2 = GameObject.Find("Bone.020").GetComponents<Collider>();
        wheelColls3 = GameObject.Find("Bone.021").GetComponents<Collider>();
        wheelColls4 = GameObject.Find("Bone.022").GetComponents<Collider>();




    }

    // Update is called once per frame
    void Update()
    {

        if (wheelsLeft == 0)
        {
            if (!allFinished)
            {
                Debug.Log("All wheels Gone");
                Destroy(GameObject.FindGameObjectWithTag("BossWheels").gameObject, 1f);
                BossTowerAI.wheelsDestroyed = true;
                BossTowerAI.BossStage = 3;
                foreach (Collider c in wheelColls1)
                {
                    c.enabled = false;
                }
                foreach (Collider c in wheelColls2)
                {
                    c.enabled = false;
                }
                foreach (Collider c in wheelColls3)
                {
                    c.enabled = false;
                }
                foreach (Collider c in wheelColls4)
                {
                    c.enabled = false;
                }
                

                allFinished = true;
                Boss.BossIsDead();
                

            }
        }
    }
}
            
    

