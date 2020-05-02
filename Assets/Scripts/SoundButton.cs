using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{

    public Sprite soundButtonOff;
    public Sprite soundButtonOn;

    public static bool soundOn = true;

    private SpriteRenderer spriteRenderer;

    private bool isButton = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (soundOn) spriteRenderer.sprite = soundButtonOn;
        if (!soundOn) spriteRenderer.sprite = soundButtonOff;
    }

    void Update()
    {
        if (!FadeManager.fading) CheckHighlight();
    }

    // Checks if the mouse is over the button, and if so, highlights the button
    void CheckHighlight() {
        
        // Reset parameter
        isButton = false;

        // For each hit overlapped with the mouse position
        foreach (RaycastHit2D rayHit in (Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition)))) {

            // If found collider, check for button
            if (rayHit.collider != null) {

                // If at least one of the colliders has the position of the button
                if (transform.position == rayHit.collider.gameObject.transform.position) {

                    // Because button found, update paramter
                    isButton = true;
                }
            }
        }

        // If button is found
        if (isButton) {

            // If mouse button down activate button function
            if (Input.GetMouseButtonDown(0)) ActivateButton();
        }
        
    }

    // Activate sound button
    void ActivateButton() {

        soundOn = !soundOn;
        if (soundOn) spriteRenderer.sprite = soundButtonOn;
        if (!soundOn) spriteRenderer.sprite = soundButtonOff;
    }
}
