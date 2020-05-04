using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{

    public bool startButton;
    public bool resumeButton;
    public bool levelsButton;
    public bool iButton;
    public bool optionsX, optionsReset, optionsCheckExit, optionsXExit, optionsCheckReset, optionsXReset;

    public string destinationScene;

    public Sprite buttonNormal;
    public Sprite buttonHighlight;
    
    private SpriteRenderer spriteRenderer;

    private bool isButton = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // If button is not hidden
        if (GetComponent<Renderer>().enabled) {

            // If not fading to a new scene or options popup active, check highlight
            if (!FadeManager.fading) {
                
                // Special case for options menu buttons blocked by popups
                if ((optionsX || optionsReset) && (OptionsPopupExit.isPaused || OptionsPopupReset.isPaused)) {
                    spriteRenderer.sprite = buttonNormal;
                } else {
                    CheckHighlight();
                }

            } else {
                spriteRenderer.sprite = buttonNormal;
            }
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
            spriteRenderer.sprite = buttonHighlight;

            // If highlighted and mouse button down activate button function
            if (Input.GetMouseButtonDown(0)) {
                
                // Play button press sound
                SoundManager.currentSound = "buttonPress";
                SoundManager.updateSound = true;
                
                ActivateButton();
            }

        // If a button is not found, set it back to normal
        } else {
            spriteRenderer.sprite = buttonNormal;
        }
        
    }

    void ActivateButton() {

        if (startButton) {

            // Take player to tutorial if they have not completed it yet
            if (LevelManager.tutorialComplete) {

                FadeManager.nextScene = destinationScene;
                FadeManager.fading = true;

            } else {
                LevelManager.tutorialComplete = true;

                FadeManager.nextScene = "Tutorial";
                FadeManager.fading = true;
            }

        } else if (resumeButton) {
            PauseMenu.isPaused = false;
            ControlsMenu.isPaused = false;
            spriteRenderer.enabled = false;
            spriteRenderer.sprite = buttonNormal;

        } else if (levelsButton) {
            PauseMenu.isPaused = false;

            FadeManager.nextScene = destinationScene;
            FadeManager.fading = true;

        } else if (iButton) {
            PauseMenu.helpMenuActive = !PauseMenu.helpMenuActive;

        } else if (optionsX) {
            OptionsPopupExit.isPaused = true;

        } else if (optionsReset) {
            OptionsPopupReset.isPaused = true;

        } else if (optionsCheckExit) {
            Application.Quit();

        } else if (optionsXExit) {
            OptionsPopupExit.isPaused = false;

        } else if (optionsCheckReset) {

            PlayerPrefs.DeleteKey("LevelUnlocked");
            LevelManager.level = 0;
            PlayerPrefs.DeleteKey("CurrentLevel");
            LevelManager.currentLevel = 0;
            PlayerPrefs.DeleteKey("TutorialComplete");
            LevelManager.tutorialComplete = false;
            PlayerPrefs.DeleteKey("MusicVolume");
            MusicManager.volume = 0.5f;
            PlayerPrefs.DeleteKey("SoundVolume");
            SoundManager.volume = 0.5f;
            
            PlayerPrefs.Save();
            OptionsPopupReset.isPaused = false;

        } else if (optionsXReset) {
            OptionsPopupReset.isPaused = false;

        } else {

            FadeManager.nextScene = destinationScene;
            FadeManager.fading = true;
        }
    }
}
