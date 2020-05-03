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
    }

    void CheckQuit() {
        if (Input.GetKeyDown("escape")) Application.Quit();
    }

}
