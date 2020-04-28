using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscButton : MonoBehaviour
{

    public Sprite escButtonNormal;
    public Sprite escButtonHighlight;

    public bool toMainMenu, toPauseMenu, toControlsMenu, quitGame;

    private SpriteRenderer spriteRenderer;

    private bool isButton = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If game not paused, check highlight
        if (!PauseMenu.isPaused) {
            CheckHighlight();
        } else {
            spriteRenderer.sprite = escButtonNormal;
        }
    }

    // Checks if the mouse is over the button, and if so, highlights the button
    void CheckHighlight() {
        
        // Reset parameter
        isButton = false;

        // For each hit overlapped with the mouse position
        foreach (RaycastHit2D rayHit in (Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition)))) {

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
            spriteRenderer.sprite = escButtonHighlight;

            // If highlighted and mouse button down activate button function
            if (Input.GetMouseButtonDown(0)) ActivateButton();

        // If a button is not found, set it back to normal
        } else {
            spriteRenderer.sprite = escButtonNormal;
        }
        
    }

    // Activate esc button function
    void ActivateButton() {

        if (toMainMenu) SceneManager.LoadScene("Main Menu");
        if (toPauseMenu) PauseMenu.isPaused = true;
        if (toControlsMenu) ControlsMenu.isPaused = true;
        if (quitGame) Application.Quit();
    }
}
