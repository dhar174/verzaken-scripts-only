using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


public class SpeedBuff : MonoBehaviour {
    public GameObject player;
    public int buffAmount;
   
    public GameObject mainCamera;

    public GameObject thisbuff;

    // Use this for initialization
    void Start()
    {
        thisbuff = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");


       
        buffAmount = Random.Range(1, 10);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.SetParent(player.transform);
            

            StartCoroutine(SpeedJumpBuff());
            thisbuff.GetComponent<Collider>().enabled = false;
            Renderer[] rends = thisbuff.GetComponentsInChildren<Renderer>();
            foreach(Renderer r in rends)
            {
                r.enabled = false;
            }

        }
    }

    public IEnumerator SpeedJumpBuff()
    {
        player.GetComponent<CharacterStats>().SpeedJumpBuff(buffAmount);
        //m_profile = Instantiate(filters.profile);
        //profile = filters;
        //m_profile.colorGrading.enabled = true;
        //m_profile.colorGrading.settings.channelMixer.
        yield return new WaitForSecondsRealtime(15);
        player.GetComponent<CharacterStats>().SpeedBuffOff(buffAmount);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
