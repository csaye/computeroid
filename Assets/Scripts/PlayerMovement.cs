using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject levelController;

    public Rigidbody2D rb;

    public Animator animator;

    public float movementSpeed;

    private LevelControllerTutorial levelControllerScript;

    Vector2 movement;

    void Start()
    {
        levelControllerScript = levelController.GetComponent<LevelControllerTutorial>();
    }

    void Update()
    {
        if (!levelControllerScript.levelComplete) {
            UpdateMovement();
        }
    }

    void FixedUpdate() {
        
        // Update player based on player input
        if (!levelControllerScript.levelComplete) {
            rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
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
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

}
