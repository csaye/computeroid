using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierEmitter : MonoBehaviour
{
    
    // The direction that the barrier emitter is facing
    public bool topDefault, bottomDefault, leftDefault, rightDefault;

    private SpriteRenderer spriteRenderer;

    private Charge chargeScript;

    private Vector2 center, size;

    private float centerX, centerY;

    private bool willContinue;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        chargeScript = GetComponent<Charge>();

        // Size set to just under full block in order to prevent laser-emitter interference
        size = new Vector2(0.499f, 0.499f);

        // Update the new center based on the current direction
        center = new Vector2(centerX, centerY);
    }

    void Update()
    {
        // If game not paused, update barriers
        if (!PauseMenu.isPaused) {

            // Set the start checking position for barriers to the position of the barrier emitter
            centerX = transform.position.x;
            centerY = transform.position.y;

            UpdateBarriers();
        }
    }

    // Check for and update the barriers based on the direction and charge of the barrier emitter
    void UpdateBarriers() {

        // Reset parameter
        willContinue = true;

        while (willContinue) {
        
            // Will not continue checking unless there is a barrier in the next tile
            willContinue = false;

            // If barrier emitter facing to the top
            if (topDefault) centerY++;

            // If barrier emitter facing to the bottom
            if (bottomDefault) centerY--;

            // If barrier emitter facing to the left
            if (leftDefault) centerX--;

            // If barrier emitter facing to the right
            if (rightDefault) centerX++;

            // Update new center to check accoringly
            center = new Vector2(centerX, centerY);

            // Double definition used to prevent jittery behavior
            if (chargeScript.charged) {

                // Check each collider in the current area for barrier and only continue if there is one
                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (collider.gameObject.tag == "Barrier") {

                        // Set the render status of the barrier to the activated status of the barrier emitter
                        collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;

                        // Update the collider of the gameObject based on the charge state
                        collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

                        // Because barrier found, continue checking cycle
                        willContinue = true;
                    }
                }

            } else {

                // Check each collider in the current area for barrier and only continue if there is one
                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (collider.gameObject.tag == "Barrier") {

                        // Set the render status of the barrier to the activated status of the barrier emitter
                        collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                        // Update the collider of the gameObject based on the charge state
                        collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

                        // Because barrier found, continue checking cycle
                        willContinue = true;
                    }
                }
            }

        }
    }
}
