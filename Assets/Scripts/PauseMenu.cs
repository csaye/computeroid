using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject resumeButton, levelsButton, iButton, helpMenu;

    public static bool isPaused = false;
    public static bool helpMenuActive = false;
    public static bool iButtonPressed = false;
    
    // Pause the level initially in level 1 in order to introduce it to the player
    public static bool initiallyPaused = false;

    void Start()
    {

        // Update whether the pause menu has been triggered yet
        if (PlayerPrefs.GetFloat("InitiallyPaused", 0) == 0) {
            initiallyPaused = false;
        } else {
            initiallyPaused = true;
        }

        // Update whether the help menu has been triggered yet
        if (PlayerPrefs.GetFloat("IButtonPressed", 0) == 0) {
            iButtonPressed = false;
        } else {
            iButtonPressed = true;
        }
    }

    void Update()
    {

        // If level not completed, check for pause
        if (!LevelController.levelComplete && !FadeManager.fading) CheckPause();

        if (!initiallyPaused && SceneManager.GetActiveScene().name == ("Level 1")) InitialPause();

        if (LevelController.levelComplete) {
            isPaused = false;
            DeactivatePauseMenu();
        }

        if (!isPaused) DeactivatePauseMenu();
        if (isPaused && !LevelController.levelComplete) ActivatePauseMenu();
        if (!LevelController.levelComplete) UpdateHelpMenu();
    }

    // Pause the level initially in level 1 in order to introduce it to the player
    void InitialPause() {
        PlayerPrefs.SetFloat("InitiallyPaused", 1);
        initiallyPaused = true;
        isPaused = true;
    }

    void CheckPause() {
        if (Input.GetKeyDown("escape")) isPaused = !isPaused;
    }
    
    void DeactivatePauseMenu() {
        GetComponent<SpriteRenderer>().enabled = false;
        resumeButton.GetComponent<SpriteRenderer>().enabled = false;
        levelsButton.GetComponent<SpriteRenderer>().enabled = false;
        iButton.GetComponent<SpriteRenderer>().enabled = false;
        resumeButton.GetComponent<BoxCollider2D>().enabled = false;
        levelsButton.GetComponent<BoxCollider2D>().enabled = false;
        iButton.GetComponent<BoxCollider2D>().enabled = false;
    }

    void ActivatePauseMenu() {
        GetComponent<SpriteRenderer>().enabled = true;
        resumeButton.GetComponent<SpriteRenderer>().enabled = true;
        levelsButton.GetComponent<SpriteRenderer>().enabled = true;
        iButton.GetComponent<SpriteRenderer>().enabled = true;
        resumeButton.GetComponent<BoxCollider2D>().enabled = true;
        levelsButton.GetComponent<BoxCollider2D>().enabled = true;
        iButton.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void UpdateHelpMenu() {
        if (helpMenuActive && isPaused) {
            transform.position = new Vector2(-2.5f, 0);
            helpMenu.GetComponent<SpriteRenderer>().enabled = true;
        } else {
            transform.position = new Vector2(0, 0);
            helpMenu.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
