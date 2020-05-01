using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    private bool fullResolution;

    void Start()
    {
        MusicManager.updateMusic = true;

        fullResolution = Screen.fullScreen;

        if (fullResolution) Screen.SetResolution(1024, 576, true);
        if (!fullResolution) Screen.SetResolution(1024, 576, false);
    }

    void Update()
    {
        UpdateResolution();
        CheckMainMenu();
    }

    // Checks if the player presses escape, and if so, takes them to the main menu
    void CheckMainMenu() {
        if (Input.GetKeyDown("escape")) SceneManager.LoadScene("Main Menu");
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
