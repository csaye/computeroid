using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{

    private bool lastFrameFullScreen = false;

    void Start()
    {
        
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
