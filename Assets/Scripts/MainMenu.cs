using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private bool fullResolution;

    void Start()
    {
        PlayerPrefs.SetInt("Screenmanager Resolution Width", 1024);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 576);

        fullResolution = Screen.fullScreen;
    }

    void Update()
    {
        UpdateResolution();
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
}
