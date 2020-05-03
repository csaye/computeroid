using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{

    public GameObject xButton;

    public static bool isPaused = false;

    void Start()
    {
        isPaused = true;
    }

    void Update()
    {
        // If level not completed, check for pause
        if (!LevelController.levelComplete) CheckPause();
        
        if (LevelController.levelComplete) {
            isPaused = false;
            DeactivateControlsMenu();
        }

        if (!isPaused) DeactivateControlsMenu();
        if (isPaused && !LevelController.levelComplete) ActivateControlsMenu();
    }

    void CheckPause() {
        if (Input.GetKeyDown("escape")) isPaused = !isPaused;
    }
    
    void DeactivateControlsMenu() {
        GetComponent<SpriteRenderer>().enabled = false;
        xButton.GetComponent<SpriteRenderer>().enabled = false;
        xButton.GetComponent<BoxCollider2D>().enabled = false;
    }

    void ActivateControlsMenu() {
        GetComponent<SpriteRenderer>().enabled = true;
        xButton.GetComponent<SpriteRenderer>().enabled = true;
        xButton.GetComponent<BoxCollider2D>().enabled = true;
    }
}
