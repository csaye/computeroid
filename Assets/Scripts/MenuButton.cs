﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{

    public bool startButton, optionsButton;
    public bool resumeButton;
    public bool levelsButton;
    public bool iButton;
    public bool optionsFullscreen, optionsReset, optionsYesReset, optionsNoReset;
    public bool exitButton, noExit, yesExit;
    public bool okButton;

    public string destinationScene;

    public Sprite buttonNormal;
    public Sprite buttonHighlight;
    
    private SpriteRenderer spriteRenderer;

    private bool isButton = false;

    private float popupDelay, popupDelayDefault = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // If button is not hidden
        if (GetComponent<Renderer>().enabled) {

            // If not fading to a new scene or ok button with order screen inactive
            if (!FadeManager.fading && ((okButton && OrderScreen.active) || (!okButton && !OrderScreen.active))) {
                
                // Special case for menu buttons blocked by popups
                if (((exitButton || startButton || optionsButton) && OptionsPopupExit.isPaused) || (optionsReset && OptionsPopupReset.isPaused)) {
                    
                    spriteRenderer.sprite = buttonNormal;
                    popupDelay = popupDelayDefault;

                } else {

                    // Wait for popup delay to expire before pressing button
                    if (popupDelay <= 0) CheckHighlight();
                    if (popupDelay > 0) popupDelay--;
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

            // Set cursor to hovering because over button
            CursorManager.hovering = true;

            // Set sprite to highlighted button
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
            PauseMenu.iButtonPressed = true;
            PlayerPrefs.SetFloat("IButtonPressed", 1);
            PauseMenu.helpMenuActive = !PauseMenu.helpMenuActive;

        } else if (optionsFullscreen) {
            
            // Toggle fullscreen
            Screen.fullScreen = !Screen.fullScreen;

        } else if (optionsReset) {

            // Trigger options reset screen
            OptionsPopupReset.isPaused = true;

        } else if (exitButton) {

            // Confirm game exit
            OptionsPopupExit.isPaused = true;

        } else if (yesExit) {

            // Quit application
            Application.Quit();

        } else if (noExit) {

            // Quit confirm game exit screen
            OptionsPopupExit.isPaused = false;

            spriteRenderer.sprite = buttonNormal;

        } else if (optionsYesReset) {

            // Reset all player data
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
            PlayerPrefs.DeleteKey("InitiallyPaused");
            PauseMenu.initiallyPaused = false;
            PlayerPrefs.DeleteKey("IButtonPressed");
            PauseMenu.iButtonPressed = false;
            PlayerPrefs.DeleteKey("EscPressed");
            EscButton.pressed = false;
            
            PauseMenu.helpMenuActive = false;
            
            PlayerPrefs.Save();
            OptionsPopupReset.isPaused = false;

        } else if (optionsNoReset) {

            // Quit confirm reset all screen
            OptionsPopupReset.isPaused = false;

            spriteRenderer.sprite = buttonNormal;

        } else if (okButton) {

            OrderScreen.active = false;

        } else {

            FadeManager.nextScene = destinationScene;
            FadeManager.fading = true;
        }
    }
}
