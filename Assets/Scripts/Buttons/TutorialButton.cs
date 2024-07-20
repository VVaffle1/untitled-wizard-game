using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{

    public GameObject tutorialScreen;
    public bool isClicked = false; 

    void Start()
    {
        tutorialScreen.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void StartTutorial()
    {
        if(isClicked == false)
        {
            tutorialScreen.GetComponent<SpriteRenderer>().enabled = true;
            isClicked = true;
        }
        else
        {
            tutorialScreen.GetComponent<SpriteRenderer>().enabled = false;
            isClicked = false;
        }
    }
    

}
