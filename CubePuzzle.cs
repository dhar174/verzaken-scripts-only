using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzle : MonoBehaviour {

    public GameObject greenCube;
    public GameObject yellowCube;
    public GameObject redCube;

    public OpenPuzzleDoor openPuzzDoor;

    public static int count;

    public bool hasWon;


    // Use this for initialization
    void Start () {
        openPuzzDoor = GameObject.FindGameObjectWithTag("PuzzleDoor").GetComponent<OpenPuzzleDoor>();
        count = 0;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("GreenPlat"))
        {
            if (other.CompareTag("GreenCube"))
            {
                GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

                count += 1;
            }
           
        }
        if (this.gameObject.CompareTag("RedPlat"))
        {
            if (other.CompareTag("RedCube"))
            {
                GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

                count += 1;
            }
            
        }
        if (this.gameObject.CompareTag("YellowPlat"))
        {
            if (other.CompareTag("YellowCube"))
            {
                GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

                count += 1;
            }
        }
    }

    public void Update()
    {
       if(count==3)
       {
            //GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();

            Debug.Log("PuzzDoor Opened");
            if (!hasWon)
            {
                openPuzzDoor.OpenThePuzzDoor();
                GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>().PlayPuzzleSuccess();
                hasWon = true;
            }

        }


    }
}
