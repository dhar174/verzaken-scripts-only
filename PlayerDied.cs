using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class PlayerDied : MonoBehaviour
    {


        //public new Vector3 startPosition;
        public static Text gameovertext;
        public static Panelfade s_panelfade;
        public GameObject m_panelfade;
        public static Image deathpanel;
        private GameObject player;
        public Animation fadein;
        private Rigidbody rb;
        public GameObject RawImage;
        public CharacterStats playerstats;

        public static bool playerisdead;
        // Use this for initialization
        void Start()
        {

            playerisdead = false;
            player = GameObject.FindGameObjectWithTag("Player");
            //startPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            playerstats = player.GetComponent<CharacterStats>();


            gameovertext = GameObject.Find("GameOverText").GetComponent<Text>();

            gameovertext.enabled = false;

            deathpanel = GameObject.Find("DeathPanel").GetComponent<Image>();

            deathpanel.enabled = false;

            m_panelfade = GameObject.Find("PanelFade");

        }

        // Update is called once per frame
        void Update()
        {

            if (playerisdead)
            {
                //RawImage = GameObject.Find("RawImage");
                //RawImage.SetActive(false);
                StartCoroutine("DeathSequence");
                //playerisdead = false;

            }
            if (!playerisdead)
            {
                //RawImage = GameObject.Find("RawImage");
                //RawImage.SetActive(true);
                //RawImage = GameObject.Find("RawImage");
                //RawImage.SetActive(true);
                StopCoroutine("DeathSequence");
            }


        }

        IEnumerator DeathSequence()
        {

            //playerisdead = false;
            //gameovertext.enabled = true;
            deathpanel.enabled = true;

            //deathpanel.GetComponent<Image>().CrossFadeColor(Color.black, 2.0f, false, false);



            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            //player.SetActive(false);


            yield return new WaitForSeconds(1f);
            // deathpanel.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
            //fadein.Play("DeathpanelFadeOut");
            yield return new WaitForSeconds(1f);
            //deathpanel.enabled = false;
            //gameovertext.enabled = false;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            //rb = player.GetComponent<Rigidbody>();
            Destroy(player.transform.parent.root.gameObject);
            //playerisdead = false;
            //Resetvalue();
            ResetLevel();


            StopAllCoroutines();
            StopCoroutine("DeathSequence");
            yield return null;
        }


        public void ResetLevel()
        {
            StopCoroutine("DeathSequence");
            playerisdead = false;
            // Destroy(player.GetComponent<keepWeapon>());
            player.GetComponent<FirstPerson.FirstPersonController>().enabled = true;
            playerstats.playerCurrentHealth = CharacterStats.playerBaseHealth;
            LevelProgression.diedNOTportal = true;
            Destroy(GameObject.Find("BtnManager"));
            GameModeScript.gameisstarted = false;
            Destroy(GameObject.Find("GameModeManager"));
            player.GetComponentInChildren<Camera>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<FirstPerson.FirstPersonController>().enabled = false;
            player.GetComponentInChildren<AudioListener>().enabled = false;

            //System.Diagnostics.Process.Start(Application.dataPath.Replace("Verzaken_Data", "Verzaken.exe")); //new program 
            //Application.Quit(); 

            //kill current process
            //Destroy(player);
            //SceneManager.LoadScene("menuscene");
            Application.Quit();

        }

        void Resetvalue()
        {

            playerisdead = false;
        }



    }

}