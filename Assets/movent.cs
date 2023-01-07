using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movent : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundLayers;

    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        rb.velocity = movement * speed;

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (IsGrounded())
        {
            isJumping = false;
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayers);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
