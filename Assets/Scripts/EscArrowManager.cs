using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscArrowManager : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        // If the esc button has not already been triggered for a scene transition
        if (!EscButton.pressed) {
            CheckArrow();
        } else {
            spriteRenderer.enabled = false;
        }
    }

    void CheckArrow() {

        // If in any scene where esc goes to main menu
        if (SceneManager.GetActiveScene().name == "Options" || SceneManager.GetActiveScene().name == "Level Select" || SceneManager.GetActiveScene().name == "Credits") {

            // Set active
            spriteRenderer.enabled = true;
        } else {

            // If not in correct scenes, set inactive
            spriteRenderer.enabled = false;
        }
    }
}
