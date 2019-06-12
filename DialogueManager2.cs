using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager2 : MonoBehaviour {

    public GameObject dialogue2;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;


    // Use this for initialization
    void Start () {
        dialogue2 = GameObject.FindGameObjectWithTag("PuzzleDialogue2");



    }

    public void OpenDialogue3()
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitToClose());
        TimeStop.unavailable = true;
        ItemInventory.unavailable = true;
        StartScreen.unavailable = true;
        WeaponInventory.unavailable = true;


        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //puzzle2Manager.DialogueBox();
    }
    public void CloseDialogue3()
    {
        GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayMenuSound();
        TimeStop.unavailable = false;
        ItemInventory.unavailable = false;
        StartScreen.unavailable = false;
        WeaponInventory.unavailable = false;

        dialogue2.SetActive(false);

        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpscontroller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public IEnumerator WaitToClose()
    {
        yield return new WaitForSecondsRealtime(10);
        CloseDialogue3();
    }

    public void MakeWait()
    {
        StartCoroutine(WaitToClose());
    }

    private void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            CloseDialogue3();
        }
    }


}
