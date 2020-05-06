using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public static bool fromMainMenu = true;

    void Start()
    {

        fromMainMenu = true;

        // Reset the level complete status
        LevelController.levelComplete = false;

        // Loads the current level unlocked
        LevelManager.level = PlayerPrefs.GetFloat("LevelUnlocked", 0);

        // Loads the current level
        LevelManager.currentLevel = PlayerPrefs.GetFloat("CurrentLevel", 0);

        // Loads whether the tutorial has been completed
        if (PlayerPrefs.GetInt("TutorialComplete", 0) == 0) {
            LevelManager.tutorialComplete = false;
        } else {
            LevelManager.tutorialComplete = true;
        }
    }

    void Update()
    {
        if (!FadeManager.fading) CheckQuit();
    }

    void CheckQuit() {
        if (Input.GetKeyDown("escape")) {
            
            // Trigger exit confirm menu
            OptionsPopupExit.isPaused = !OptionsPopupExit.isPaused;
        }
    }

}
