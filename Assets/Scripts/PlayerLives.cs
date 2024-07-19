using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int playerHealth = 3;
    public SceneLoader sceneControl;

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
            if (playerHealth <= 0) { return; }
            Vector3 difference = (transform.position - other.transform.position).normalized;

            StartCoroutine(Knockback(difference));
        }
    }

    IEnumerator GameOverTime()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<SceneLoader>().GameOver();
    }

    IEnumerator Knockback(Vector3 direction)
    {
        float timer = 0f;

        while (timer < knockbackDuration)
        {
            Debug.Log("worked");
            transform.position += direction * knockbackSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
