using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float PlayerSpeed = 5f;
    private Rigidbody2D rb;
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
    }


    private void MovementX()
    {
        float moveInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveInput * (PlayerSpeed), rb.velocity.y);
        
    }
    private void MovementY()
    {
        float moveInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveInput * (PlayerSpeed));
    }
}
