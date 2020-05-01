using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public bool levelComplete = false;

    public Animator animator;

    private bool fullResolution;

    void Start()
    {
        MusicManager.updateMusic = true;
        MainMenu.fromMainMenu = false;

        fullResolution = Screen.fullScreen;

        if (fullResolution) Screen.SetResolution(1024, 576, true);
        if (!fullResolution) Screen.SetResolution(1024, 576, false);
    }

    void Update()
    {
        UpdateResolution();
        if (levelComplete) Crash();
    }

    void Crash() {
        animator.SetBool("LevelComplete", true);
    }

    void UpdateResolution() {
        
        if (!Screen.fullScreen && fullResolution) {
            fullResolution = false;
            Screen.SetResolution(1024, 576, false);
        }

        if (Screen.fullScreen) {
            fullResolution = true;
        }
    }
}
