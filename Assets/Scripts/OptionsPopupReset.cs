using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPopupReset : MonoBehaviour
{
    
    public GameObject yesButton, noButton;

    public static bool isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isPaused) ActivatePopup();
        if (!isPaused) DeactivatePopup();
    }

    void ActivatePopup() {
        GetComponent<SpriteRenderer>().enabled = true;
        yesButton.GetComponent<SpriteRenderer>().enabled = true;
        noButton.GetComponent<SpriteRenderer>().enabled = true;
        yesButton.GetComponent<BoxCollider2D>().enabled = true;
        noButton.GetComponent<BoxCollider2D>().enabled = true;
    }

    void DeactivatePopup() {
        GetComponent<SpriteRenderer>().enabled = false;
        yesButton.GetComponent<SpriteRenderer>().enabled = false;
        noButton.GetComponent<SpriteRenderer>().enabled = false;
        yesButton.GetComponent<BoxCollider2D>().enabled = false;
        noButton.GetComponent<BoxCollider2D>().enabled = false;
    }
}
