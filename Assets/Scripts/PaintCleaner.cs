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
        if (!PauseMenu.isPaused && chargeScript.charged) CheckClean();
    }

    // Cleans the player of any paint they might have
    void CheckClean() {

        // If player left clicks, is not colored white, and within interaction distance, change player to white
        if (Input.GetMouseButtonDown(0)) {
            if (playerSpriteRenderer.color != white && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {

                // Raycast to mouse position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
                // If paint cleaner hit by raycast, change player color to white
                if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
                    
                    // Set player color to white
                    playerSpriteRenderer.color = white;
                }
            }

        }
    }
}
