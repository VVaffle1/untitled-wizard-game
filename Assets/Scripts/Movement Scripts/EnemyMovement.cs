using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public static float speed = 1.5f;
    private GameObject playerPosition;
    [SerializeField] private AudioClip damageSoundClip;
    public GameObject Explosion;
    public GameObject floatingPoints;
    public ScreenShake cameraShake;

    public bool IsAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive == false) { return; }
        EnemyMove();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fireball" && other.gameObject.GetComponent<Spell>().HasHit == false && IsAlive == true)
        {
            other.gameObject.GetComponent<Spell>().HasHit = true;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        IsAlive = false;
        Instantiate(Explosion, transform.position, Quaternion.identity);
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        FindObjectOfType<ScoreKeeper>().ScoreIncrease();
        AudioSource.PlayClipAtPoint(damageSoundClip, new Vector2(-0.18f, 1.2f), 1f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.08f);
        Instantiate(floatingPoints, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.transform.position, speed * Time.deltaTime);
    }
}
