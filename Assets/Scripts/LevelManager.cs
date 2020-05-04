using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float level;
    public static float currentLevel;

    public static bool tutorialComplete = false;

    public bool levelSelected = false;

    void Start()
    {
        // Saves the current level unlocked
        PlayerPrefs.SetFloat("LevelUnlocked", level);

        // Saves the current level
        PlayerPrefs.SetFloat("CurrentLevel", currentLevel);

        if (tutorialComplete) PlayerPrefs.SetInt("TutorialComplete", 1);
    }

    void Update()
    {

    }
}
