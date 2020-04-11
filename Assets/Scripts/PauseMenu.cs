using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject levelController;
    public GameObject resumeButton, levelsButton;

    public static bool isPaused = false;

    private LevelController levelControllerScript;

    void Start()
    {
        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {

        // If level not completed, check for pause
        if (!levelControllerScript.levelComplete) CheckPause();
        
        if (!isPaused || levelControllerScript.levelComplete) DeactivatePauseMenu();
        if (isPaused) ActivatePauseMenu();
    }

    void CheckPause() {
        if (Input.GetKeyDown("escape")) isPaused = !isPaused;
    }
    
    void DeactivatePauseMenu() {
        GetComponent<SpriteRenderer>().enabled = false;
        resumeButton.GetComponent<SpriteRenderer>().enabled = false;
        levelsButton.GetComponent<SpriteRenderer>().enabled = false;
        resumeButton.GetComponent<BoxCollider2D>().enabled = false;
        levelsButton.GetComponent<BoxCollider2D>().enabled = false;
    }

    void ActivatePauseMenu() {
        GetComponent<SpriteRenderer>().enabled = true;
        resumeButton.GetComponent<SpriteRenderer>().enabled = true;
        levelsButton.GetComponent<SpriteRenderer>().enabled = true;
        resumeButton.GetComponent<BoxCollider2D>().enabled = true;
        levelsButton.GetComponent<BoxCollider2D>().enabled = true;
    }
}
