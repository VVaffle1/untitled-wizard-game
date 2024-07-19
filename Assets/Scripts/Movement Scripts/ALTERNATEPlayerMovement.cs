using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALTERNATEPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator anim;

    private bool touchesGrass;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (touchesGrass == true)
        {
            moveSpeed = 2f;
        }
        else
        {
            moveSpeed = 4f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Grass")
        {
            touchesGrass = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Grass")
        {
            touchesGrass = false;
        }
    }
}
