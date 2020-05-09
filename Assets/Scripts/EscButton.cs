using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscButton : MonoBehaviour
{

    // Whether the esc button has been pressed to trigger a scene transition yet
    public static bool pressed;

    public Sprite escButtonNormal;
    public Sprite escButtonHighlight;

    public bool toMainMenu, toPauseMenu, toControlsMenu, quitGame;

    public GameObject levelManager;

    private SpriteRenderer spriteRenderer;

    private bool isButton = false;

    private LevelManager levelManagerScript;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Loads whether the esc button has been triggered
        if (PlayerPrefs.GetInt("EscPressed", 0) == 0) {
            pressed = false;
        } else {
            pressed = true;
        }

        if (levelManager != null) levelManagerScript = levelManager.GetComponent<LevelManager>();
    }

    void Update()
    {
        // If game not paused, check highlight
        if (!PauseMenu.isPaused && !FadeManager.fading && !ControlsMenu.isPaused && !OptionsPopupExit.isPaused && !OptionsPopupReset.isPaused && !LevelController.levelComplete && !OrderScreen.active) {
            if (levelManager != null) {
                
                // Only if level select button
                if (!LevelManager.levelSelected) {
                    CheckHighlight();
                } else {
                    spriteRenderer.sprite = escButtonNormal;
                }

            } else {
                CheckHighlight();
            }
            
        } else {
            spriteRenderer.sprite = escButtonNormal;
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

            // Set cursor to hovering because over button
            CursorManager.hovering = true;

            // Set sprite to highlighted button
            spriteRenderer.sprite = escButtonHighlight;

            // If highlighted and mouse button down, activate button function
            if (Input.GetMouseButtonDown(0)) {
                
                // Play button press sound
                SoundManager.currentSound = "buttonPress";
                SoundManager.updateSound = true;

                ActivateButton();
            }

        // If a button is not found, set it back to normal
        } else {
            spriteRenderer.sprite = escButtonNormal;
        }
        
    }

    // Activate esc button function
    void ActivateButton() {

        if (toMainMenu) {

            // If scene transition button not pressed yet, set to pressed
            if (!pressed) {
                PlayerPrefs.SetInt("EscPressed", 1);
                pressed = true;
            }

            FadeManager.nextScene = "Main Menu";
            FadeManager.fading = true;
        }
        
        if (toPauseMenu) PauseMenu.isPaused = true;
        if (toControlsMenu) ControlsMenu.isPaused = true;
        if (quitGame) Application.Quit();
    }
}
