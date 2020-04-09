using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public GameObject levelSelector;

    private LevelSelector levelSelectorScript;

    void Start()
    {
        levelSelectorScript = levelSelector.GetComponent<LevelSelector>();
    }

    void Update()
    {
        
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
}
