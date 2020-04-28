using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{

    public GameObject levelController;
    public GameObject resumeButton;

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
        
        if (levelControllerScript.levelComplete) {
            isPaused = false;
            DeactivateControlsMenu();
        }

        if (!isPaused) DeactivateControlsMenu();
        if (isPaused && !levelControllerScript.levelComplete) ActivateControlsMenu();
    }

    void CheckPause() {
        if (Input.GetKeyDown("escape")) isPaused = !isPaused;
    }
    
    void DeactivateControlsMenu() {
        GetComponent<SpriteRenderer>().enabled = false;
        resumeButton.GetComponent<SpriteRenderer>().enabled = false;
        resumeButton.GetComponent<BoxCollider2D>().enabled = false;
    }

    void ActivateControlsMenu() {
        GetComponent<SpriteRenderer>().enabled = true;
        resumeButton.GetComponent<SpriteRenderer>().enabled = true;
        resumeButton.GetComponent<BoxCollider2D>().enabled = true;
    }
}
