using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScreen : MonoBehaviour
{

    public float currentLevel;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void GoLevelSelect() {
        
        // If the current level is one not previously completed, increment level value
        if (currentLevel >= LevelManager.level) LevelManager.level = currentLevel + 1;
        
        FadeManager.nextScene = "Level Select";
        FadeManager.fading = true;
    }

    void GoCredits() {

        // Signify all level completion (in credits)
        LevelManager.level = 13;
        
        FadeManager.nextScene = "Credits";
        FadeManager.fading = true;
    }

}
