using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (!FadeManager.fading && !OptionsPopupExit.isPaused && !OptionsPopupReset.isPaused) CheckMainMenu();
    }

    // Checks if the player presses escape, and if so, takes them to the main menu
    void CheckMainMenu() {
        if (Input.GetKeyDown("escape")) {

            FadeManager.nextScene = "Main Menu";
            FadeManager.fading = true;
        }
    }

}
