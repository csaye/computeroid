using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    
    public Animator animator;

    // Whether a wire will disable others on the same x or y values from shorting
    public bool horizontalExclusion = false;
    public bool verticalExclusion = false;

    // Used by the wire pad to reset the wire
    public bool resetWire = false;

    // Storage of excluded wire shortage x and y values
    public static List<float> excludedX = new List<float>();
    public static List<float> excludedY = new List<float>();

    private GameObject player = null;

    private Color red = new Color(1, 0, 0, 1);
    private Color white = new Color(1, 1, 1, 1);

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private float maxInteractDistance = 1.5f;
    
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // If game not paused, check for shorting of wire
        if (!PauseMenu.isPaused && !FadeManager.fading && !LevelController.levelComplete && !OrderScreen.active) CheckShort();
        
        // If resetting not triggered, reset animation state
        if (!resetWire) animator.SetBool("Reset", false);

        // Resets the wire if being used by the wire pad
        if (resetWire) {
            resetWire = false;
            ResetWire();
        }
    }

    // Checks if wire is shorted out, and if so, sends signal to short wire
    void CheckShort() {

        // If player left clicks, is colored red
        if (playerSpriteRenderer.color == red) {

            // Raycast to mouse position
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(InputEx.mousePosition));
    
            // If wire hit by raycast, short out
            if (((GetComponent<BoxCollider2D>() != null && !GetComponent<BoxCollider2D>().isTrigger) || (GetComponent<PolygonCollider2D>() != null && !GetComponent<PolygonCollider2D>().isTrigger))
            && rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {

                // If wires free to short
                if (!horizontalExclusion && !verticalExclusion) {
                    
                    // Set cursor to hovering because over wire
                    CursorManager.hovering = true;

                    // If left mouse button pressed and player within range, short wire
                    if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {
                        
                        // Play level object sound
                        SoundManager.currentSound = "levelObject";
                        SoundManager.updateSound = true;

                        ShortWire();
                    }
                }

                // If horizontally excluded
                if (horizontalExclusion && !verticalExclusion && !excludedY.Contains(transform.position.y)) {
                    
                    // Set cursor to hovering because over wire
                    CursorManager.hovering = true;

                    // If left mouse button pressed and player within range, short wire and add Y value to no-short list
                    if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {
                        excludedY.Add(transform.position.y);

                        // Play level object sound
                        SoundManager.currentSound = "levelObject";
                        SoundManager.updateSound = true;

                        ShortWire();
                    }
                }

                // If vertically excluded
                if (verticalExclusion && !horizontalExclusion && !excludedX.Contains(transform.position.x)) {
                    
                    // Set cursor to hovering because over wire
                    CursorManager.hovering = true;
                    
                    // If left mouse button pressed and player within range, short wire and add X value to no-short list
                    if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {
                        excludedX.Add(transform.position.x);
                        
                        // Play level object sound
                        SoundManager.currentSound = "levelObject";
                        SoundManager.updateSound = true;
                        
                        ShortWire();
                    }
                }

                // If excluded horizontally and vertically
                if (verticalExclusion && horizontalExclusion && !excludedY.Contains(transform.position.y) && !excludedX.Contains(transform.position.x)) {
                    
                    // Set cursor to hovering because over wire
                    CursorManager.hovering = true;
                    
                    // If left mouse button pressed and player within range, short wire and add X and Y values to no-short list
                    if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {
                        excludedY.Add(transform.position.y);
                        excludedX.Add(transform.position.x);
                        
                        // Play level object sound
                        SoundManager.currentSound = "levelObject";
                        SoundManager.updateSound = true;

                        ShortWire();
                    }
                }

            }
        }
    }

    // Short the wire, using the player's red, doing the shorting animation, and losing hitbox
    void ShortWire() {
        playerSpriteRenderer.color = white;
        animator.SetBool("Shorted", true);
        if (GetComponent<BoxCollider2D>() != null) GetComponent<BoxCollider2D>().enabled = false;
        if (GetComponent<PolygonCollider2D>() != null) GetComponent<PolygonCollider2D>().enabled = false;
    }

    // Resets the wire back to its idle state (used for wire pads)
    void ResetWire() {
        animator.SetBool("Shorted", false);
        animator.SetBool("Reset", true);
    }
}
