using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        CheckMainMenu();
    }

    // Checks if the player presses escape, and if so, takes them to the main menu
    void CheckMainMenu() {
        if (Input.GetKeyDown("escape")) SceneManager.LoadScene("Main Menu");
    }
}
