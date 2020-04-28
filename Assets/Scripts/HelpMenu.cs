using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{

    public Sprite helpMenu1, helpMenu2, helpMenu3, helpMenu4, helpMenu5, helpMenu6;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GetComponent<Renderer>().enabled) UpdateHelpMenu();
    }

    // Updates the help menu based on which paints have been discovered so far
    void UpdateHelpMenu() {

        if (LevelManager.level >= 11) {
            spriteRenderer.sprite = helpMenu6;

        } else if (LevelManager.level >= 9) {
            spriteRenderer.sprite = helpMenu5;

        } else if (LevelManager.level >= 7) {
            spriteRenderer.sprite = helpMenu4;

        } else if (LevelManager.level >= 5) {
            spriteRenderer.sprite = helpMenu3;

        } else if (LevelManager.level >= 4) {
            spriteRenderer.sprite = helpMenu2;

        } else {
            spriteRenderer.sprite = helpMenu1;
        }
    }
}
