using System.Collections;
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

    // The higher the center speed, the quicker the paper goes to the middle of the screen
    private float centerSpeed = 0.03125f;

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
        SceneManager.LoadScene("Level " + levelSelectorScript.currentPos);
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
            if (centerFactor > 0) centerFactor = centerFactor - centerSpeed;
            transform.position = new Vector2(centerFactor * startX, centerFactor * startY);
            if (centerFactor <= centerSpeed) transform.position = new Vector2(0, 0);
        }
    }
}
