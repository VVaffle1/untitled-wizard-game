using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{

    public GameObject spell;
    public float spellSpeed = 4.0f;
    [SerializeField] private AudioClip fireClip;

    const int LeftMouseButton = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            OnMouseClick();
            AudioSource.PlayClipAtPoint(fireClip, transform.position, 1f);
        }
    }
    void OnMouseClick()
    {
        Vector2 playerMousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerSpellDirection = playerMousePosition - playerPosition;
        playerSpellDirection.Normalize();
        Quaternion spellRotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerSpellDirection.y, playerSpellDirection.x) * Mathf.Rad2Deg+180);
        GameObject spellProjectile = (GameObject)Instantiate(spell, playerPosition + playerSpellDirection, spellRotation);
        spellProjectile.GetComponent<Rigidbody2D>().velocity = playerSpellDirection * spellSpeed;
    }
}