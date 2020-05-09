using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFilterManager : MonoBehaviour
{

    public GameObject arrow;

    void Start()
    {

    }

    void Update()
    {
        UpdateFilter();
        UpdateArrow();
    }

    void UpdateFilter() {

        // If pause menu or controls menu or popups active, show filter, otherwise do not
        if (PauseMenu.isPaused || ControlsMenu.isPaused || OptionsPopupExit.isPaused || OptionsPopupReset.isPaused) {
            GetComponent<SpriteRenderer>().enabled = true;
        } else {
            GetComponent<SpriteRenderer>().enabled = false;
            arrow.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Updates the arrow pointing to the help menu button
    void UpdateArrow() {
        
        // If button not pressed and filter triggered
        if (!PauseMenu.iButtonPressed && GetComponent<SpriteRenderer>().enabled) {
            
            // If help menu, controls menu, and popups not active
            if (!PauseMenu.helpMenuActive && !ControlsMenu.isPaused && !OptionsPopupExit.isPaused && !OptionsPopupReset.isPaused) {
                arrow.GetComponent<SpriteRenderer>().enabled = true;
            } else {
                arrow.GetComponent<SpriteRenderer>().enabled = false;
            }

        } else {
            arrow.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
