using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static float PlayerSpeed = 5f;
    private Rigidbody2D rb;
    public Animator animator;

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
}
