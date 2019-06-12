using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickaxeControl : MonoBehaviour {
  //  private Animator anim;
    //private  Animation animation;
    public Material[] weaponmats;
    public Renderer weaponrend;

    //public Renderer[] weaponrends;
    private int weaponrendIndex;
    public int rcount;

    public GameObject weapon;
    public int count;
    public GameObject[] weaponparts;

    private int materialIndex;
    private int weaponpartIndex;

    //public static bool swingingWeapon;

    public SwitchWeapons weaponswitchScript;
    public PopupManager popupscript;

    // Use this for initialization
    void Start () {
       // weaponswitchScript = GameObject.FindGameObjectWithTag("WeaponContainer").GetComponent<SwitchWeapons>();
        //anim = gameObject.GetComponent<Animator>();
        if (GameObject.FindGameObjectWithTag("PopupManager"))
        {
            if (!popupscript)
            {
                popupscript = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
            }
        }

    }


    public void SwingPickaxe()
    {
        if (!popupscript)
        {
            popupscript = GameObject.FindGameObjectWithTag("PopupManager").GetComponent<PopupManager>();
        }
        if (!PopupManager.firstusedPickaxe)
        {
            StartCoroutine(popupscript.firstpickaxe());
            PopupManager.firstusedPickaxe = true;
        }
        if (SwitchWeapons.pickaxeActive)
        {
           // anim.SetTrigger("PickAttack1");
            StartCoroutine(Attacking());
        }
    }
    private IEnumerator Attacking()
    {
        WeaponControl.swingingWeapon = true;
        yield return new WaitForSeconds(.5f);
        if (Input.GetAxisRaw("Attack1") > 0)
        {
             WeaponControl.swingingWeapon = true;
            yield return new WaitForSeconds(.5f);
            StartCoroutine(Attacking());
        }
        WeaponControl.swingingWeapon = false;
        StopCoroutine(Attacking());
    }

    // Update is called once per frame
    void Update () {
        
    }
}
