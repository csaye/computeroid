using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject levelController;

    public Rigidbody2D rb;

    public Animator animator;

    // How quickly the player moves while walking normally
    public float walkSpeed = 2;

    // How quickly the player moves while sprinting
    public float sprintSpeed = 3;

    private LevelController levelControllerScript;

    Vector2 movement;

    void Start()
    {
        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {
        if (!levelControllerScript.levelComplete && !PauseMenu.isPaused) {
            UpdateMovement();
        } else {

            // If level complete or paused, stop all animation
            animator.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate() {
        
        // Update player based on player input
        if (!levelControllerScript.levelComplete && !PauseMenu.isPaused) {

            // If sprinting
            if (Input.GetKey("left shift") || Input.GetKey("right shift")) {

                // Sprint
                rb.MovePosition(rb.position + movement.normalized * sprintSpeed * Time.fixedDeltaTime);
            
            } else {

                // Walk
                rb.MovePosition(rb.position + movement.normalized * walkSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void UpdateMovement() {
        
        // Get player input
        if (movement.y == 0) movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x == 0) movement.y = Input.GetAxisRaw("Vertical");

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
