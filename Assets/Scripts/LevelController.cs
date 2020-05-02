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
    }

    void Update()
    {
        if (levelComplete) Crash();
    }

    void Crash() {
        animator.SetBool("LevelComplete", true);
    }
}
