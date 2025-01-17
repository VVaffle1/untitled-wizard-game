using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int playerHealth = 3;
    public SceneLoader sceneControl;
    public AudioSource hurtClip;

    public float knockbackDuration = 0.2f;
    public float knockbackSpeed = 10f;


    void Update()
    {
        
        if (playerHealth <= 0)
        {
        StartCoroutine(GameOverTime());

        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            playerHealth--;
            Vector3 difference = (transform.position - other.transform.position).normalized;

            StartCoroutine(Knockback(difference));
            StartCoroutine(FlashRed());
            
        }
    }

    IEnumerator GameOverTime()
    {
        
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<SceneLoader>().GameOver();
    }

    IEnumerator Knockback(Vector3 direction)
    {
        float timer = 0f;
        hurtClip.Play();
        while (timer < knockbackDuration)
        {
            Debug.Log("worked");
            transform.position += direction * knockbackSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FlashRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
