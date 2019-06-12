using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;



public class healthpickup : MonoBehaviour {
    public GameObject player;
    public int buffAmount;
    

    public GameObject mainCamera;
    public Renderer rend;
    private GameObject thisbuff;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rend = gameObject.GetComponentInChildren<Renderer>();
        thisbuff = gameObject;
        if (LevelProgression.MasterLevelMultiplier >= 1)
        {
            buffAmount = Random.Range(10, 30) * LevelProgression.MasterLevelMultiplier;
        }

        if (LevelProgression.MasterLevelMultiplier < 1)
        {
            buffAmount = Random.Range(10, 30) * 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.SetParent(player.transform);

            StartCoroutine(HealthAdd());
            Renderer[] rends = thisbuff.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rends)
            {
                r.enabled = false;
            }
        }
    }

    public IEnumerator HealthAdd()
    {
        player.GetComponent<CharacterStats>().AddHealth(buffAmount);
       // rend.enabled = false;
        yield return new WaitForSecondsRealtime(5);
        player.GetComponent<CharacterStats>().HealthOff();

        Destroy(gameObject);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
