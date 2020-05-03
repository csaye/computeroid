using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
static public class InputEx
{
    
    // Whether the class has already been initialized
    static private bool initialized = false;

    static private float gameWidth = 1024, gameHeight = 576;

    // The aspect ratio of the game screen as width over height
    static private float gameAspect = gameWidth / gameHeight;

    // The aspect ratio of the screen; found later
    static private float screenAspect;

    // The width and height of the screen
    static private float screenWidth, screenHeight;

    // The fixed mouse position, adjusted for the fullscreen bug
    static private Vector3 fixedMousePosition = new Vector3(0, 0, 0);

    // A fixed mouse position for the fullscreen distortion bug
    // Use InputEx.mousePosition instead of Input.mousePosition
    static public Vector3 mousePosition {

        // Set the mouse position to the fixed mouse position and update the fixed mouse position
        get {

            // Update and return the fixed mouse position
            UpdateMousePosition();
            return fixedMousePosition;
        }
    }

    // Initialize the class
    static private void Initialize() {
        
        // Because class running, no need to initialize again
        initialized = true;

        // The current resolution of the screen
        Resolution resolution = Screen.currentResolution;

        // All of the current supported resolutions; used to find the fullscreen resolution
        Resolution[] resolutions = Screen.resolutions;

        // Set width and height to initial resolution values
        screenWidth = Screen.currentResolution.width;
        screenHeight = Screen.currentResolution.height;

        // Cycle through all supported resolutions, saving largest (fullscreen)
        foreach (Resolution res in resolutions) {

            // If new supported resolution is greater than previous, update values
            if (screenWidth < res.width) screenWidth = res.width;
            if (screenHeight < res.height) screenHeight = res.height;
        }

        // Now with fullscreen resolution, set aspect ratio of screen to width over height
        screenAspect = screenWidth / screenHeight;
    }

    static private void UpdateMousePosition() {

        // If class not initialized yet, initialize class
        if (!initialized) Initialize();
        
        // If game is not in fullscreen or has game aspect use normal mouse position as fixed mouse position
        fixedMousePosition = Input.mousePosition;
        if (!Screen.fullScreen || gameAspect == screenAspect) return;

        // If game is in fullscreen, fix distorted mouse positioning based on screen resolution

        // If screen is wider than aspect ratio of game, fix distorted mouse x position coordinate
        if (gameAspect < screenAspect) {

            // Begin with the mouse position
            float fixedX = Input.mousePosition.x;

            // The width of the game screen as resolution
            float gameScreenWidthResolution = screenHeight * gameAspect;

            // The horizontal stretch of the screen as a result of the screen width over the game screen width
            float horizontalStretch = screenWidth / gameScreenWidthResolution;

            // Stretch screen x position to game screen size
            fixedX = fixedX * horizontalStretch;

            // The width of the game screen in coordinates
            float gameScreenWidth = (gameWidth * gameScreenWidthResolution) / screenWidth;

            // The total offset of the horizontal screen resolution and the game screen resolution
            float fullOffset = gameWidth - gameScreenWidth;

            // The distance between the left/right of the screen and the left/right of the game screen
            float halfOffset = fullOffset / 2.0f;

            // The distance that the x position must be offset
            float offsetFactor = halfOffset * horizontalStretch;

            // Add offset back to x position
            fixedX = fixedX - offsetFactor;

            // Fix coordinate by stretching incorrect mouse x position and then adding back offset
            fixedMousePosition.x = fixedX;
        }

        // If screen is taller than aspect ratio of game, fix distorted mouse y position coordinate
        if (gameAspect > screenAspect) {

            // Begin with the mouse position
            float fixedY = Input.mousePosition.y;

            // The height of the game screen as resolution
            float gameScreenHeightResolution = screenWidth / gameAspect;

            // The vertical stretch of the screen as a result of the screen height over the game screen height
            float verticalStretch = screenHeight / gameScreenHeightResolution;

            // Stretch screen y position to game screen size
            fixedY = fixedY * verticalStretch;

            // The height of the game screen in coordinates
            float gameScreenHeight = (gameHeight * gameScreenHeightResolution) / screenHeight;

            // The total offset of the vertical screen resolution and the game screen resolution
            float fullOffset = gameHeight - gameScreenHeight;

            // The distance between the top/bottom of the screen and the top/bottom of the game screen
            float halfOffset = fullOffset / 2.0f;

            // The distance that the y position must be offset
            float offsetFactor = halfOffset * verticalStretch;

            // Add offset back to y position
            fixedY = fixedY - offsetFactor;

            // Fix coordinate by stretching incorrect mouse y position and then adding back offset
            fixedMousePosition.y = fixedY;
        }

    }

}