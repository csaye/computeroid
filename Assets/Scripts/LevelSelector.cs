﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    public Animator animator;

    public GameObject levelManager;

    public float currentPos = 1;

    private LevelManager levelManagerScript;

    private SpriteRenderer spriteRenderer;

    private Color black = new Color(0, 0, 0, 1);
    private Color gray = new Color (0.5f, 0.5f, 0.5f, 1);

    // Level selector positioning in scene
    private float row1 = -1.93762f, row2 = 0.0623729f, row3 = 2.062382f;
    private float col1 = -5.25012f, col2 = -1.750118f, col3 = 1.749884f, col4 = 5.249887f;

    void Start()
    {
        levelManagerScript = levelManager.GetComponent<LevelManager>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set level selector position to the last level played
        if (LevelManager.currentLevel == 1) currentPos = 1;
        if (LevelManager.currentLevel == 2) currentPos = 2;
        if (LevelManager.currentLevel == 3) currentPos = 3;
        if (LevelManager.currentLevel == 4) currentPos = 4;
        if (LevelManager.currentLevel == 5) currentPos = 5;
        if (LevelManager.currentLevel == 6) currentPos = 6;
        if (LevelManager.currentLevel == 7) currentPos = 7;
        if (LevelManager.currentLevel == 8) currentPos = 8;
        if (LevelManager.currentLevel == 9) currentPos = 9;
        if (LevelManager.currentLevel == 10) currentPos = 10;
        if (LevelManager.currentLevel == 11) currentPos = 11;
        if (LevelManager.currentLevel == 12) currentPos = 12;
    }

    void Update()
    {
        if (!levelManagerScript.levelSelected) {
            UpdatePosition();
            UpdateColor();
        }
    }

    // Updates the position of the level selector based on player input and levels unlocked
    void UpdatePosition() {
        if (currentPos == 1) {
            transform.position = new Vector2(col1, row1);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 1;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 2) {
                currentPos++;
                return;
            }
        }
        if (currentPos == 2) {
            transform.position = new Vector2(col2, row1);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 2;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 3) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 3) {
            transform.position = new Vector2(col3, row1);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 3;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 4) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 4) {
            transform.position = new Vector2(col4, row1);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 4;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && LevelManager.level >= 5) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 5) {
            transform.position = new Vector2(col4, row2);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 5;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && LevelManager.level >= 6) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) currentPos--;
        }
        if (currentPos == 6) {
            transform.position = new Vector2(col3, row2);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 6;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && LevelManager.level >= 7) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) currentPos--;
        }
        if (currentPos == 7) {
            transform.position = new Vector2(col2, row2);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 7;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && LevelManager.level >= 8) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) currentPos--;
        }
        if (currentPos == 8) {
            transform.position = new Vector2(col1, row2);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 8;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && LevelManager.level >= 9) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) currentPos--;
        }
        if (currentPos == 9) {
            transform.position = new Vector2(col1, row3);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 9;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 10) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) currentPos--;
        }
        if (currentPos == 10) {
            transform.position = new Vector2(col2, row3);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 10;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 11) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 11) {
            transform.position = new Vector2(col3, row3);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 11;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 12) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 12) {
            transform.position = new Vector2(col4, row3);
            if (Input.GetKeyDown("return") || overFolder(currentPos)) {
                LevelManager.currentLevel = 12;
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
    }

    // Updates the color of the level selector based on whether the selected level is completed or not
    void UpdateColor() {
        
        // If the current level selected is one not completed, set selector color to gray
        if (currentPos == LevelManager.level) {
            spriteRenderer.color = gray;
        
        // If the current level has already been completed, set selector color to black
        } else {
            spriteRenderer.color = black;
        }
    }

    bool overFolder(float currentFolder) {
        
        // If left mouse button pressed
        if (Input.GetMouseButtonDown(0)) {

            // For each hit overlapped with the mouse position
            foreach (RaycastHit2D rayHit in (Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition)))) {

                // If found collider, check for folder
                if (rayHit.collider != null) {

                    // If hit collider belongs to a folder
                    if (rayHit.collider.gameObject.GetComponent<FolderSelect>() != null) {

                        // If folder number is same as one overlapped by level selector, return true
                        if (rayHit.collider.gameObject.GetComponent<FolderSelect>().folderNumber == currentFolder) {
                            return true;
                        }
                    }
                }
            }
        }
        
        // If mouse position and folder do not meet requirements, return false
        return false;
    }
}
