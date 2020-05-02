using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScreen : MonoBehaviour
{

    public float currentLevel;

    public GameObject background;

    public Sprite monitorFinalOff;

    private SpriteRenderer backgroundSpriteRenderer;

    void Start()
    {
        if (background != null) backgroundSpriteRenderer = background.GetComponent<SpriteRenderer>();
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

        // If the current level is one not previously completed, increment level value
        if (currentLevel >= LevelManager.level) LevelManager.level = currentLevel + 1;
        
        FadeManager.nextScene = "Credits";
        FadeManager.fading = true;
    }

    void MonitorOff() {

        // Turns the monitor off after the fade sequence
        backgroundSpriteRenderer.sprite = monitorFinalOff;
    }
}
