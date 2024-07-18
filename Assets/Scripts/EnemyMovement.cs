using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1.5f;
    private GameObject playerPosition;
    [SerializeField] private AudioClip damageSoundClip;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        EnemyMove();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Fireball")
        {
            FindObjectOfType<ScoreKeeper>().ScoreIncrease();
            AudioSource.PlayClipAtPoint(damageSoundClip,new Vector2(-0.18f, 1.2f),1f); 
            Destroy(gameObject);
        }


    }
    void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.transform.position, speed * Time.deltaTime);
    }

}
