using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderSelect : MonoBehaviour
{

    public GameObject levelSelector;

    // The number of the folder
    public float folderNumber;

    private LevelSelector levelSelectorScript;

    private bool isFolder = false;

    void Start()
    {
        levelSelectorScript = levelSelector.GetComponent<LevelSelector>();
    }

    void Update()
    {

        // If not fading or level already selected, check for folder
        if (!FadeManager.fading && !LevelManager.levelSelected) CheckFolder();
    }

    // Checks if the mouse is over the folder
    void CheckFolder() {
        
        // Reset parameter
        isFolder = false;

        // For each hit overlapped with the mouse position
        foreach (RaycastHit2D rayHit in (Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(InputEx.mousePosition)))) {

            // If found collider, check for folder
            if (rayHit.collider != null) {

                // If at least one of the colliders has the position of the folder
                if (transform.position == rayHit.collider.gameObject.transform.position) {

                    // Because folder found, set parameter
                    isFolder = true;
                }
            }
        }

        // If a foler is found, check and move the selector
        if (isFolder) {

            // Set cursor to hovering if folder unlocked
            if (folderNumber <= LevelManager.level) CursorManager.hovering = true;

            // If left mouse button pressed while over folder
            if (Input.GetMouseButtonDown(0)) MoveSelector();
        }
        
    }

    // If the selected folder is unlocked, move the level selector
    void MoveSelector() {

        // If folder unlocked, set level selector position to folder position
        if (folderNumber <= LevelManager.level) {
            
            // Play button press sound
            SoundManager.currentSound = "buttonPress";
            SoundManager.updateSound = true;

            levelSelectorScript.currentPos = folderNumber;
        }
    }
}
