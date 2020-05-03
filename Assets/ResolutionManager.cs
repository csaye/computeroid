using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{

    static GameObject instance;

    private bool lastFrameFullScreen = false;

    void Start()
    {
        
        // If the resolution manager instance is already created, do not create another one
        if (instance != null) {
            Destroy(gameObject);

        // If resolution manager instance not created, set instance to resolution manager
        } else {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        UpdateResolution();
    }

    void UpdateResolution() {

        // If on the frame exiting out of fullscreen, set window back to normal
        if (!Screen.fullScreen && Screen.fullScreen != lastFrameFullScreen) {
            Screen.SetResolution(1024, 576, false);
        }

        lastFrameFullScreen = Screen.fullScreen;
    }
}
