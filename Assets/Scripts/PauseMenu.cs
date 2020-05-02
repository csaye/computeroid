using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject levelController;
    public GameObject resumeButton, levelsButton, iButton, helpMenu;

    public static bool isPaused = false;
    public static bool helpMenuActive = false;

    private LevelController levelControllerScript;

    void Start()
    {
        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {

        // If level not completed, check for pause
        if (!levelControllerScript.levelComplete && !FadeManager.fading) CheckPause();
        
        if (levelControllerScript.levelComplete) {
            isPaused = false;
            DeactivatePauseMenu();
        }

        if (!isPaused) DeactivatePauseMenu();
        if (isPaused && !levelControllerScript.levelComplete) ActivatePauseMenu();
        if (!levelControllerScript.levelComplete) UpdateHelpMenu();
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
