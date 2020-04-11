﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (currentLevel >= LevelManager.level) LevelManager.level++;
        SceneManager.LoadScene("Level Select");
    }
}
