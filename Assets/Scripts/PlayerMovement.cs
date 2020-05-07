using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public Animator animator;

    // How quickly the player moves while walking normally
    public float walkSpeed = 2;

    // How quickly the player moves while sprinting
    public float sprintSpeed = 3;

    private bool fromX, fromY;

    Vector2 movement;

    void Start()
    {

    }

    void Update()
    {
        if (!LevelController.levelComplete && !PauseMenu.isPaused && !ControlsMenu.isPaused && !FadeManager.fading && !OrderScreen.active) {
            UpdateMovement();
        } else {

            // If level complete or paused, stop all animation
            animator.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate() {
        
        // Update player based on player input
        if (!LevelController.levelComplete && !PauseMenu.isPaused && !ControlsMenu.isPaused && !FadeManager.fading && !OrderScreen.active) {

            // If sprinting
            if (Input.GetKey("left shift") || Input.GetKey("right shift")) {

                // Sprint
                rb.MovePosition(rb.position + movement * sprintSpeed * Time.fixedDeltaTime);
            
            } else {

                // Walk
                rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void UpdateMovement() {
        
        // Get player input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize movement to prevent extra diagonal speed
        movement = movement.normalized;

        // Set animator values to player values if player moving
        if (movement != Vector2.zero)
        {

            // Reset animator parameters
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);

            // Reset from parameters if no longer moving in that direction
            if (movement.x == 0) fromX = false;
            if (movement.y == 0) fromY = false;

            // If moving in the x direction and was not moving from y before
            if (movement.x != 0 && !fromY) {
                fromX = true;
                animator.SetFloat("Horizontal", movement.x);

            // If moving in the y direction and was not moving from x before
            } else if (movement.y != 0 && !fromX) {
                fromY = true;
                animator.SetFloat("Vertical", movement.y);
            }
            
        }

        // Set the speed of the character in order to determine whether to move or not
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

}
