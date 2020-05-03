using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPopupReset : MonoBehaviour
{
    
    public GameObject checkButton, xButton;

    public static bool isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isPaused) ActivatePopup();
        if (!isPaused || OptionsPopupExit.isPaused) DeactivatePopup();
    }

    void ActivatePopup() {
        GetComponent<SpriteRenderer>().enabled = true;
        checkButton.GetComponent<SpriteRenderer>().enabled = true;
        xButton.GetComponent<SpriteRenderer>().enabled = true;
        checkButton.GetComponent<BoxCollider2D>().enabled = true;
        xButton.GetComponent<BoxCollider2D>().enabled = true;
    }

    void DeactivatePopup() {
        GetComponent<SpriteRenderer>().enabled = false;
        checkButton.GetComponent<SpriteRenderer>().enabled = false;
        xButton.GetComponent<SpriteRenderer>().enabled = false;
        checkButton.GetComponent<BoxCollider2D>().enabled = false;
        xButton.GetComponent<BoxCollider2D>().enabled = false;
    }
}
