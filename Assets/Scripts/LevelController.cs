using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    // Whether the current level is completed or not — reset in level select
    public static bool levelComplete = false;

    // Whether the level has a order screen — if so, skip music
    public bool hasOrderScreen;

    public Animator animator;

    void Start()
    {
        LevelManager.levelSelected = false;

        if (!hasOrderScreen) MusicManager.updateMusic = true;
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
