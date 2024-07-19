using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static float PlayerSpeed = 4f;
    private Rigidbody2D rb;
    public Animator animator;
    private bool isTouchingGrass;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementX();
        MovementY();
        animator.SetFloat("Speed", PlayerSpeed);

        if (isTouchingGrass == true)
        {
            PlayerSpeed = 2f;
        }
        else 
        {
            PlayerSpeed = 4f;
        }
    }


    private void MovementX()
    {
        float moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", moveInput);
      

        rb.velocity = new Vector2(moveInput * (PlayerSpeed), rb.velocity.y);
        
    }
    private void MovementY()
    {
        float moveInput = Input.GetAxis("Vertical");
        animator.SetFloat("Vertical", moveInput);

        rb.velocity = new Vector2(rb.velocity.x, moveInput * (PlayerSpeed));
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Grass")
        {
            isTouchingGrass = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Grass")
        {
            isTouchingGrass = false;
        }
    }

}
