using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PowerUpSpawn", 7, 15);

    }

    // Update is called once per frame


    public void PowerUpSpawn()
    {
        float screenX = Random.Range(-4f, 4f);
        float screenY = Random.Range(-4f, 4f);
        Vector2 randomPosition = new Vector2(screenX, screenY);

        Instantiate(powerUp, randomPosition, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("TempPlayer"))
        {
            PowerUpEffect();
 
            Vector3 timeOutCorner = transform.position + new Vector3(0f, 100f, 0f);
            transform.position = timeOutCorner;
        }
    }
    public void PowerUpEffect()
    {
        int power = Random.Range(0, 2);
        if (power == 0)
        {
            StartCoroutine(PlayerSpeedBoost());
        }
        if (power == 1)
        {
            StartCoroutine(EnemySlowDown());
        }
    }

    IEnumerator PlayerSpeedBoost()
    {
        PlayerMovement.PlayerSpeed = 4f;
       
        yield return new WaitForSeconds(5);
        
        PlayerMovement.PlayerSpeed = 2f;
        Destroy(gameObject);

    }

    IEnumerator EnemySlowDown()
    {
        EnemyMovement.speed = .75f;
        yield return new WaitForSeconds(10);
        EnemyMovement.speed = 1.5f;
        Destroy(gameObject);

    }
}







