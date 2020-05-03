using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{

    public GameObject levelController;

    public Sprite powerButtonNormal;
    public Sprite powerButtonHighlight;

    private SpriteRenderer spriteRenderer;

    private GameObject player = null;

    private LevelController levelControllerScript;

    private float maxInteractDistance = 1.5f;

    private bool isButton = false;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();

        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {
        // If game not paused, check highlight
        if (!PauseMenu.isPaused && !FadeManager.fading) {
            CheckHighlight();
        } else {
            spriteRenderer.sprite = powerButtonNormal;
        }
    }

    // Checks if the mouse is over the button, and if so, highlights the button
    void CheckHighlight() {
        
        // Reset parameter
        isButton = false;

        // For each hit overlapped with the mouse position
        foreach (RaycastHit2D rayHit in (Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(InputEx.mousePosition)))) {

            // If found collider, check for button
            if (rayHit.collider != null) {

                // If at least one of the colliders has the position of the button
                if (transform.position == rayHit.collider.gameObject.transform.position) {

                    // Because button found, highlight button
                    isButton = true;
                }
            }
        }

        // If a button is found, highlight the button
        if (isButton) {
            spriteRenderer.sprite = powerButtonHighlight;

            // If highlighted, mouse button down, and within player range, activate button function
            if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) ActivateButton();

        // If a button is not found, set it back to normal
        } else {
            spriteRenderer.sprite = powerButtonNormal;
        }
        
    }

    void ActivateButton() {

        // Activate end game sequence
        MusicManager.stopMusic = true;
        levelControllerScript.levelComplete = true;
    }
}
