using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;



    public class strengthpowerup : MonoBehaviour {
        public GameObject player;
        public int buffAmount;
        
        public GameObject mainCamera;
    private GameObject thisbuff;


    // Use this for initialization
           void Start() {
            player = GameObject.FindGameObjectWithTag("Player");
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        thisbuff = gameObject;

            
             buffAmount = Random.Range(10, 30 * LevelProgression.MasterLevelMultiplier);

           }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.transform.SetParent(player.transform);
                
               StartCoroutine(StrengthBuff());
            gameObject.GetComponent<Collider>().enabled = false;
            Renderer[] rends = thisbuff.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rends)
            {
                r.enabled = false;
            }

        }
    }

        public IEnumerator StrengthBuff()
        {
            player.GetComponent<CharacterStats>().StrengthBuff(buffAmount);
          //m_profile = Instantiate(filters.profile);
          //profile = filters;
          //m_profile.colorGrading.enabled = true;
           //m_profile.colorGrading.settings.channelMixer.
            yield return new WaitForSecondsRealtime(15);
            player.GetComponent<CharacterStats>().StrengthBuffOff(buffAmount);
            Destroy(gameObject);
        }

        // Update is called once per frame
        void Update() {
                  
        }
    }
