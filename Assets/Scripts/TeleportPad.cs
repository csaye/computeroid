using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{

    public Sprite teleportPadNormal, teleportPadHighlight;

    private GameObject player = null;

    private SpriteRenderer spriteRenderer, playerSpriteRenderer;

    private Color purple = new Color(0.5f, 0, 1, 1);
    private Color white = new Color(1, 1, 1, 1);

    private Vector2 center, size;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        center = new Vector2(transform.position.x, transform.position.y);

        // Size set to just under full block in order to prevent interference
        size = new Vector2(0.499f, 0.499f);

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused && !FadeManager.fading && !LevelController.levelComplete) {
            CheckTeleport();
        }

        CheckHighlight();
    }

    void CheckTeleport() {

        // If left mouse button pressed
        if (Input.GetMouseButtonDown(0)) {
            
            // If player is colored purple
            if (playerSpriteRenderer.color == purple) {

                // Raycast to mouse position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(InputEx.mousePosition));

                // If hit collider in the position of the teleport pad, teleport
                if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
                    
                    // If teleport pad not obstructed, teleport
                    if (!Obstructed()) Teleport();
                }
            }
        }
    }

    void Teleport() {
        playerSpriteRenderer.color = white;
        player.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    // Checks whether the teleport pad is currently obstructed
    bool Obstructed() {

        // Checks each collider in the region of the teleport pad for an obstructing object
        foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {

            // If hit object has box collider
            if (collider.GetComponent<BoxCollider2D>() != null) {

                // If object found, set parameter
                if (!collider.GetComponent<BoxCollider2D>().isTrigger) return true;
            }

            // If hit object has polygon collider
            if (collider.GetComponent<PolygonCollider2D>() != null) {

                // If object found, set parameter
                if (!collider.GetComponent<PolygonCollider2D>().isTrigger) return true;
            }

        }

        // If no obstruction found in any collider within the region of the teleport pad, return false
        return false;
    }

    // If the player is colored purple, highlight the teleport pad
    void CheckHighlight() {

        // If player is colored purple
        if (playerSpriteRenderer.color == purple) {

            // Set the sprite to highlight
            spriteRenderer.sprite = teleportPadHighlight;

        // If player is not colored purple
        } else {

            // Set the sprite to normal
            spriteRenderer.sprite = teleportPadNormal;
        }
    }
}
