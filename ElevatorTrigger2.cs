using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger2 : MonoBehaviour {
    public Animator anim;
    // Use this for initialization
    void Start () {
        anim = gameObject.transform.parent.root.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!anim.isActiveAndEnabled)
            {
                anim.enabled = true;
            }
            anim.SetBool("PlayerOn",true);
            //StartCoroutine(unparent());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!anim.isActiveAndEnabled)
            {
                anim.enabled = true;
            }
            anim.SetBool("PlayerOn", true);
            //StartCoroutine(unparent());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("PlayerOn", false);
           // other.gameObject.transform.parent = null;
            //GameObject.Find("[VRTK]").GetComponent<keepWeapon>().ReDDOL();


        }
    }
    public IEnumerator unparent()
    {
        yield return new WaitForSecondsRealtime(30);
        GameObject.FindGameObjectWithTag("Player").transform.parent=null;
        GameObject.FindGameObjectWithTag("Player").GetComponent<keepWeapon>().ReDDOL();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
