using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class GrowlManager : MonoBehaviour {
    public GameObject[] enemies1;
    public GameObject[] enemies2;
    public GameObject[] enemies3;
    public GameObject[] enemies4;

    public int randomvalue1;


    // Use this for initialization
    void Start() {
      enemies1 = GameObject.FindGameObjectsWithTag("Monsters");
      enemies2 = GameObject.FindGameObjectsWithTag("Bbbot");
      enemies3 = GameObject.FindGameObjectsWithTag("Robospider");
      enemies4 = GameObject.FindGameObjectsWithTag("FloatingEyebot");
       
        StartCoroutine(RandomNumber());
        
    }


    public IEnumerator RandomNumber()
    {
        randomvalue1 = Random.Range(0, 4);
        if (randomvalue1 == 0)
        {
            StartCoroutine("GrowlsManager");
        }
        if (randomvalue1 == 1)
        {
            StartCoroutine("GrowlsManager2");
        }
        if (randomvalue1 == 2)
        {
            StartCoroutine("GrowlsManager3");
        }
        if (randomvalue1 == 3)
        {
            StartCoroutine("GrowlsManager4");
        }

        StopCoroutine(RandomNumber());
        yield return null;
    }

    public IEnumerator GrowlsManager()
    {
        int randIndex = Random.Range(0, enemies1.Length);

        yield return new WaitForSeconds(Random.Range(30, 200));
        //foreach (GameObject GO in enemies1)
        //{

          GameObject GO =  enemies1[randIndex];

        //GO.GetComponent<BasicAI>().currentgrowl = GO.GetComponent<BasicAI>().growls[GO.GetComponent<BasicAI>().soundhashInd];
        GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");
        if (GO.GetComponent<BasicAI>().soundhashInd >= GO.GetComponent<BasicAI>().growls.Length)
                {
                    GO.GetComponent<BasicAI>().soundhashInd = 0;
                }
                //sound.PlayOneShot(growls[Random.Range(0, growls.Length)], 1f);




                
                PlayGrowlAt(GO.GetComponent<BasicAI>().currentgrowl, GO.GetComponent<BasicAI>().pos);
            Debug.Log("Growl Played");
            StartCoroutine(RandomNumber());
            GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");

            StopCoroutine(GrowlsManager());
            

            yield return null;
        //}
        

       // yield return null;
    }

   public IEnumerator GrowlsManager2()
    {
        int randIndex = Random.Range(0, enemies2.Length);

        yield return new WaitForSeconds(Random.Range(30, 200));
        //foreach (GameObject GO in enemies1)
        //{

        GameObject GO = enemies2[randIndex];

        //GO.GetComponent<BasicAI>().currentgrowl = GO.GetComponent<BasicAI>().growls[GO.GetComponent<BasicAI>().soundhashInd];
        GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");
        if (GO.GetComponent<BasicAI>().soundhashInd >= GO.GetComponent<BasicAI>().growls.Length)
            {
                GO.GetComponent<BasicAI>().soundhashInd = 0;
            }
            //sound.PlayOneShot(growls[Random.Range(0, growls.Length)], 1f);





            PlayGrowlAt(GO.GetComponent<BasicAI>().currentgrowl, GO.GetComponent<BasicAI>().pos);
            Debug.Log("Growl Played");
            StartCoroutine(RandomNumber());
            GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");

            StopCoroutine(GrowlsManager2());


        

        yield return null;
        //}


        //yield return null;
    }

   public IEnumerator GrowlsManager3()
    {
        int randIndex = Random.Range(0, enemies3.Length);

        yield return new WaitForSeconds(Random.Range(30, 200));
        //foreach (GameObject GO in enemies1)
        //{

        GameObject GO = enemies3[randIndex];

        // GO.GetComponent<BasicAI>().currentgrowl = GO.GetComponent<BasicAI>().growls[GO.GetComponent<BasicAI>().soundhashInd];
        GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");
        if (GO.GetComponent<BasicAI>().soundhashInd >= GO.GetComponent<BasicAI>().growls.Length)
            {
                GO.GetComponent<BasicAI>().soundhashInd = 0;
            }
            //sound.PlayOneShot(growls[Random.Range(0, growls.Length)], 1f);





            PlayGrowlAt(GO.GetComponent<BasicAI>().currentgrowl, GO.GetComponent<BasicAI>().pos);
            Debug.Log("Growl Played");
            StartCoroutine(RandomNumber());
            GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");

            StopCoroutine(GrowlsManager3());

        

        yield return null;
        //}


        //yield return null;
    }

   public IEnumerator GrowlsManager4()
    {
        int randIndex = Random.Range(0, enemies4.Length);

        yield return new WaitForSeconds(Random.Range(30, 200));
        //foreach (GameObject GO in enemies1)
        //{

        GameObject GO = enemies4[randIndex];

        //GO.GetComponent<BasicAI>().currentgrowl = GO.GetComponent<BasicAI>().growls[GO.GetComponent<BasicAI>().soundhashInd];
        GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");
        if (GO.GetComponent<BasicAI>().soundhashInd >= GO.GetComponent<BasicAI>().growls.Length)
            {
                GO.GetComponent<BasicAI>().soundhashInd = 0;
            }
            //sound.PlayOneShot(growls[Random.Range(0, growls.Length)], 1f);





            PlayGrowlAt(GO.GetComponent<BasicAI>().currentgrowl, GO.GetComponent<BasicAI>().pos);
            Debug.Log("Growl Played");
            StartCoroutine(RandomNumber());
            GO.GetComponent<BasicAI>().StartCoroutine("RandomGrowl");

            StopCoroutine(GrowlsManager4());

        

        yield return null;
        //}


        //yield return null;
    }





    public AudioSource PlayGrowlAt(AudioClip currentgrowl1, Vector3 pos)
    {
        GameObject tempGRR = new GameObject("TempGrowl"); // create the temp object
        tempGRR.transform.SetParent(gameObject.transform);
        tempGRR.transform.position = pos; // set its position
        AudioSource bSource = tempGRR.AddComponent<AudioSource>(); // add an audio source
        GameObject.Find("TempGrowl").GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Logarithmic;
        bSource.clip = currentgrowl1; // define the clip
        bSource.rolloffMode.Equals(AudioRolloffMode.Logarithmic);                     // set other aSource properties here, if desired
        bSource.Play(); // start the sound

        Destroy(tempGRR, 2f);
        //Destroy(tempGO, 0); // destroy object after clip duration
        return bSource; // return the AudioSource reference
    }

    // Update is called once per frame
    void Update () {
		
	}
}
