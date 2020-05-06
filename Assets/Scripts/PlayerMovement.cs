﻿using System.Collections;
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

    Vector2 movement;

    void Start()
    {

    }

    void Update()
    {
        if (!LevelController.levelComplete && !PauseMenu.isPaused && !ControlsMenu.isPaused && !FadeManager.fading) {
            UpdateMovement();
        } else {

            // If level complete or paused, stop all animation
            animator.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate() {
        
        // Update player based on player input
        if (!LevelController.levelComplete && !PauseMenu.isPaused && !ControlsMenu.isPaused && !FadeManager.fading) {

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

        // Set animator values to player values
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

        // Set the speed of the character in order to determine whether to move or not
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

}
