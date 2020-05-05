﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    // Whether the current level is completed or not — reset in level select
    public static bool levelComplete = false;

    public Animator animator;

    void Start()
    {
        LevelManager.levelSelected = false;

        MusicManager.updateMusic = true;
        MainMenu.fromMainMenu = false;
    }

    void Update()
    {
        if (levelComplete) Crash();
    }

    void Crash() {
        animator.SetBool("LevelComplete", true);
    }
}
