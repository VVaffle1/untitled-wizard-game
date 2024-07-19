using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int playerHealth = 3;
    public SceneLoader sceneControl; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
           StartCoroutine(GameOverTime());
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            playerHealth--;
        }
    }

    IEnumerator GameOverTime()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<SceneLoader>().GameOver();
    }
}
