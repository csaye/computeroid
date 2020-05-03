using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public static bool fromMainMenu = true;

    void Start()
    {

        fromMainMenu = true;

        // Loads the current level unlocked
        LevelManager.level = PlayerPrefs.GetFloat("LevelUnlocked", 0);

        // Loads the current level
        LevelManager.currentLevel = PlayerPrefs.GetFloat("CurrentLevel", 0);

        // Loads whether the tutorial has been completed
        if (PlayerPrefs.GetInt("TutorialComplete", 0) == 1) LevelManager.tutorialComplete = true;
    }

    void Update()
    {
        if (!FadeManager.fading) CheckQuit();
        DevCommands();
    }

    void CheckQuit() {
        if (Input.GetKeyDown("escape")) Application.Quit();
    }

    void DevCommands() {

        // RESET
        if (Input.GetKeyDown("p")) {
            PlayerPrefs.DeleteAll();
            SoundManager.volume = 0.5f;
            MusicManager.volume = 0.5f;
            PlayerPrefs.Save();
        }

        // DEBUG
        if (Input.GetKeyDown("g")) {
            Debug.Log("mouse position: " + Input.mousePosition);
            Debug.Log("fixed mouse position: " + InputEx.mousePosition);
        }
    }
}
