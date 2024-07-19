using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Main Scene");

        GameObject[] scoreText = GameObject.FindGameObjectsWithTag("Score");
        foreach (GameObject obj in scoreText)
        {
            Destroy(obj);
        }
    }
}