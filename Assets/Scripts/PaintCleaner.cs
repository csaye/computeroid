using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCleaner : MonoBehaviour
{

    private GameObject player = null;

    private Color white = new Color(1, 1, 1, 1);

    private SpriteRenderer playerSpriteRenderer;

    private Charge chargeScript;

    private float maxInteractDistance = 1.5f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        chargeScript = GetComponent<Charge>();
    }

    void Update()
    {

        // If game not paused and paint cleaner charged
        if (!PauseMenu.isPaused && !FadeManager.fading && chargeScript.charged && !LevelController.levelComplete) CheckClean();
    }

    // Cleans the player of any paint they might have
    void CheckClean() {

        // If player is not colored white
        if (playerSpriteRenderer.color != white) {

            // Raycast to mouse position
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(InputEx.mousePosition));
    
            // If paint cleaner hit by raycast, change player color to white
            if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
                
                // Set cursor to hovering because over button
                CursorManager.hovering = true;

                // If left mouse button clicked and player within range, set player color to white
                if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) playerSpriteRenderer.color = white;
            }
        }

    }
}
