using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    
    public Texture2D cursorNormal;
    public Texture2D cursorHover;
    public Texture2D cursorWait;

    static GameObject instance;

    public static bool hovering = false;

    private Vector2 cursorPosition;

    // Delay added so that hovering cursor does not flicker
    private float hoveringDelay;
    private float hoveringDelayDefault = 1;

    void Start()
    {

        // If the music manager instance is already created, do not create another one
        if (instance != null) {
            Destroy(gameObject);

        // If music manager instance not created, set instance to music manager
        } else {
            instance = gameObject;
            cursorPosition = new Vector2(0, 0);
            hoveringDelay = hoveringDelayDefault;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    void Update()
    {
        UpdateCursor();

        // Adds slight delay to turning off hover cursor so that cursor does not flicker
        if (hovering) {

            // If hovering, count down delay
            if (hoveringDelay > 0) hoveringDelay--;

        } else {
            
            // If not hovering, reset delay
            hoveringDelay = hoveringDelayDefault;
        }

        // If hovering delay expired, stop hovering
        if (hoveringDelay == 0) hovering = false;
    }

    // Updates the cursor based on the current state of the game
    void UpdateCursor() {
        if (hovering) {
            Cursor.SetCursor(cursorHover, cursorPosition, CursorMode.Auto);
        } else if (FadeManager.fading) {
            Cursor.SetCursor(cursorWait, cursorPosition, CursorMode.Auto);
        } else {
            Cursor.SetCursor(cursorNormal, cursorPosition, CursorMode.Auto);
        }
    }
}
