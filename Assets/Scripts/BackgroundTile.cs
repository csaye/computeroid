using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{

    public Sprite tileNormal;
    public Sprite tileHighlight;

    private SpriteRenderer spriteRenderer;

    private bool isTile = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused && !ControlsMenu.isPaused && !FadeManager.fading && !LevelController.levelComplete && !OrderScreen.active) {
            CheckHighlight();
        } else {
            spriteRenderer.sprite = tileNormal;
        }
    }

    // Checks if the mouse is over the tile, and if so, highlights the tile
    void CheckHighlight() {
        
        // Reset parameter
        isTile = false;

        // For each hit overlapped with the mouse position
        foreach (RaycastHit2D rayHit in (Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(InputEx.mousePosition)))) {

            // If found collider, check for tile
            if (rayHit.collider != null) {

                // If at least one of the colliders has the position of the tile
                if (transform.position == rayHit.collider.gameObject.transform.position) {

                    // Because tile found, highlight tile
                    isTile = true;
                }
            }
        }

        // If a tile is found, highlight the tile
        if (isTile) {
            spriteRenderer.sprite = tileHighlight;

        // If a tile is not found, set it back to normal
        } else {
            spriteRenderer.sprite = tileNormal;
        }
        
    }

}
