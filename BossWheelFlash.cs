using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWheelFlash : MonoBehaviour {
    public bool flashing;
    [SerializeField] private Renderer rend;
    [SerializeField] private BossWheelHealth wheelHealth;
    private bool wheelsDieOnce;

    public GameObject particle;

    // Use this for initialization
    void Start () {

        rend = gameObject.GetComponent<Renderer>();

        if (!wheelHealth)
        {
            if (gameObject.name == "pSphere4")
            {
                wheelHealth = GameObject.Find("Bone.019").GetComponent<BossWheelHealth>();
            }
            wheelsDieOnce = false;
            if (gameObject.name == "pSphere1")
            {
                wheelHealth = GameObject.Find("Bone.020").GetComponent<BossWheelHealth>();
            }

            if (gameObject.name == "pSphere2")
            {
                wheelHealth = GameObject.Find("Bone.021").GetComponent<BossWheelHealth>();
            }

            if (gameObject.name == "pSphere3")
            {
                wheelHealth = GameObject.Find("Bone.022").GetComponent<BossWheelHealth>();
            }
        }
        if (!particle)
        {
            particle = wheelHealth.gameObject.GetComponentInChildren<ParticleSystem>().gameObject;
        }
        particle.SetActive(false);
    }

    public IEnumerator FlashWheel()
    {
        rend = gameObject.GetComponent<Renderer>();
        //Color originalColor = rend[0].material.color;
        while (flashing)
        {





            Color originalColor = rend.material.color;



            Material mat = rend.material;
            Color baseColor = Color.red;
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(1);
            mat.SetColor("_EmissionColor", finalColor);
            mat.color = Color.red;
            if (!particle.activeSelf)
            {
                particle.SetActive(true);
            }
           







            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];

            yield return new WaitForSeconds(wheelHealth.flashwait);





            // yield return new WaitForSeconds(.5f);
            //Color originalColor = rend[rendererIndex].material.color;
            mat = rend.material;
            particle.SetActive(false);
            
            

            finalColor = originalColor * Mathf.LinearToGammaSpace(0);
            mat.SetColor("_EmissionColor", finalColor);
            mat.color = Color.white;




            //rend[rendererIndex].sharedMaterial = swordMaterialRef[materialIndex];
            // rendererIndex = 0;
            yield return new WaitForSeconds(wheelHealth.flashwait);
        }

        if (!flashing)
        {
            Material mat = rend.material;
            if (particle.activeSelf)
            {
                particle.SetActive(false);
            }



            //Color finalColor = originalColor * Mathf.LinearToGammaSpace(0);
            mat.SetColor("_EmissionColor", Color.black);
            mat.color = Color.white;
            StopCoroutine(FlashWheel());
        }


        //Material mat = rend[].material;

        yield return null;





    }

    public IEnumerator TestFlash()
    {
        wheelHealth.flashing = true;

        flashing = true;
        StartCoroutine(FlashWheel());
        yield return new WaitForSeconds(5);
        flashing = false;
        wheelHealth.flashing = false;

        BossWheelHealth.ballchainJustgone = false;


        yield return null;

    }
    public IEnumerator DamageFlash()
    {
        wheelHealth.flashing = true;
        flashing = true;
        StartCoroutine(FlashWheel());
        yield return new WaitForSeconds(.5f);
        flashing = false;
        wheelHealth.flashing = false;

        yield return null;
    }
    public IEnumerator DeathFlash()
    {
        flashing = true;
        StartCoroutine(FlashWheel());
        yield return new WaitForSeconds(1);
        flashing = false;
        if (!wheelsDieOnce)
        {
            wheelHealth.WheelDeath();
            wheelsDieOnce = true;
            rend.enabled = false;
        }
        StopAllCoroutines();
        StopCoroutine(DeathFlash());
        yield return null;
    }


}
