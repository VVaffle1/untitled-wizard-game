using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{

    public GameObject tutorialScreen;

    void Start()
    {
        tutorialScreen.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void StartTutorial()
    {
        tutorialScreen.GetComponent<SpriteRenderer>().enabled = true;
    }

}
