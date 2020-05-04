using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    void Start()
    {
        LevelController.levelComplete = false;
        MusicManager.updateMusic = true;

        // Saves the current level unlocked
        PlayerPrefs.SetFloat("LevelUnlocked", LevelManager.level);

        // Saves the current level
        PlayerPrefs.SetFloat("CurrentLevel", LevelManager.currentLevel);
    }

    void Update()
    {
        if (!FadeManager.fading) CheckMainMenu();
    }

    // Checks if the player presses escape, and if so, takes them to the main menu
    void CheckMainMenu() {
        if (Input.GetKeyDown("escape")) {
            FadeManager.nextScene = "Main Menu";
            FadeManager.fading = true;
        }
    }

}
