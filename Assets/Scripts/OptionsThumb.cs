using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsThumb : MonoBehaviour
{

    public bool soundSlider = false, musicSlider = false;

    private float xExtent = 1.8125f;
    private float xOffset;

    private bool isThumb = false, isSlider = false; 
    private bool activated = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (!FadeManager.fading) UpdateVolume();
        if (!FadeManager.fading && Input.GetMouseButtonDown(0)) CheckActivate();

        if (FadeManager.fading) activated = false;

        if (!FadeManager.fading && activated) ActivateThumb();
    }

    void UpdateVolume() {
        
        // The x-position of the slider converted into a 0 to 1 range
        float convertedX = (transform.localPosition.x + xExtent) / (2 * xExtent);

        if (musicSlider) MusicManager.volume = convertedX;
        // if (soundSlider) SoundManager.volume = convertedX;
    }

    // Checks if the mouse is clicked over the slider and held down and moves thumb accordingly
    void CheckActivate() {

        // Reset parameters
        isThumb = false;
        isSlider = false;

        // For each hit overlapped with the mouse position
        foreach (RaycastHit2D rayHit in (Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition)))) {

            // If found collider, check for thumb
            if (rayHit.collider != null) {

                // If at least one of the colliders is the thumb
                if (gameObject == rayHit.collider.gameObject) {

                    // Because thumb found, use thumb
                    isThumb = true;
                }
                
                // If at least one of the colliders is the parent of the thumb (the slider)
                if (gameObject.transform.parent.gameObject == rayHit.collider.gameObject) {

                    // Because slider found, use slider if thumb not found
                    isSlider = true;
                }
            }
        }

        // If thumb is found, activate thumb
        if (isThumb) {
            float thumbX = transform.position.x;
            float mouseX = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7.8f)).x;

            // Offset slider based on original mouse click
            xOffset = thumbX - mouseX;
            activated = true;

        // If slider found, move to mouse position and activate thumb
        } else if (isSlider) {
            xOffset = 0;
            activated = true;

        // If neither slider or thumb found, deactivate
        } else {
            activated = false;
        }

    }

    void ActivateThumb() {

        // While the mouse is still pressed down
        if (!Input.GetMouseButton(0)) activated = false;

        // Get the x position of the mouse
        float mouseX = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (Camera.main.transform.position.z * -1))).x;

        // Adjust for offset
        mouseX = mouseX + xOffset;

        // The x position of the mouse relative to the local x position of the thumb
        float mouseXLocal = mouseX + (transform.localPosition.x - transform.position.x);

        // If the position of the mouse is within the extent of the slider
        if (mouseXLocal > (xExtent * -1) && mouseXLocal < xExtent) {
            transform.localPosition = new Vector2(mouseXLocal, transform.localPosition.y);

        // If the mouse position is greater than the slider
        } else if (mouseXLocal >= xExtent){
            transform.localPosition = new Vector2(xExtent, transform.localPosition.y);

        // If the mouse position is less than the slider
        } else {
            transform.localPosition = new Vector2((xExtent * -1), transform.localPosition.y);
        }
    }
}
