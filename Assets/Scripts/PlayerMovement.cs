using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {
        // Get player input
        if (movement.y == 0) movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x == 0) movement.y = Input.GetAxisRaw("Vertical");

        // Set animator values to player values
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate() {
        // Update player based on player input
        rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }

}
