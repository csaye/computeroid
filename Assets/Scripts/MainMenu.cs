using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public static bool fromMainMenu = true;

    private bool fullResolution;

    void Start()
    {
        fromMainMenu = true;

        PlayerPrefs.SetInt("Screenmanager Resolution Width", 1024);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 576);

        fullResolution = Screen.fullScreen;

        if (fullResolution) Screen.SetResolution(1024, 576, true);
        if (!fullResolution) Screen.SetResolution(1024, 576, false);
    }

    void Update()
    {
        UpdateResolution();
        CheckQuit();
    }

    void OnApplicationQuit() {

        PlayerPrefs.SetInt("Screenmanager Resolution Width", 1024);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 576);
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

    void CheckQuit() {
        if (Input.GetKeyDown("escape")) Application.Quit();
    }
}
