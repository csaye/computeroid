﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public GameObject paper;
    public GameObject levelSelector;

    private LevelSelector levelSelectorScript;

    private bool center = false;

    private float startX, startY;
    private float centerFactor;

    void Start()
    {
        levelSelectorScript = levelSelector.GetComponent<LevelSelector>();
    }

    void Update()
    {
        if (!center) UpdatePosition();
        if (center) SlideToCenter();
    }

    // Loads the corresponding level for the level selected by the selector
    void LoadLevelScene() {
        if (levelSelectorScript.currentPos == 1) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 2) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 3) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 4) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 5) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 6) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 7) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 8) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 9) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 10) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 11) SceneManager.LoadScene("Level 1");
        if (levelSelectorScript.currentPos == 12) SceneManager.LoadScene("Level 1");
    }

    void UpdatePosition() {
        transform.position = paper.transform.position;
    }

    void Center() {

        center = true;
        startX = transform.position.x;
        startY = transform.position.y;

        centerFactor = 1;
    }

    // Slides the loading screen to the center as it expands to fill the screen
    void SlideToCenter() {
        if (centerFactor >= 0) {
            if (centerFactor > 0) centerFactor = centerFactor - 0.025f;
            transform.position = new Vector2(centerFactor * startX, centerFactor * startY);
            if (centerFactor <= 0.025) transform.position = new Vector2(0, 0);
        }
    }
}
