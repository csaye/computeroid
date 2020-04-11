using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    
    public bool startButton;
    public bool resumeButton;
    public bool levelsButton;

    public string destinationScene;

    public Sprite buttonNormal;
    public Sprite buttonHighlight;
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckHighlight();
    }

    // Checks if the mouse is over the button, and if so, highlights the button
    void CheckHighlight() {

        // Raycast to mouse position
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
        // If button hit by raycast, highlight button
        if (GetComponent<Renderer>().enabled && rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
            spriteRenderer.sprite = buttonHighlight;

            // If highlighted and mouse button down, activate scene switching
            if (Input.GetMouseButtonDown(0)) SwitchScene();

        } else {
            spriteRenderer.sprite = buttonNormal;
        }
    }

    void SwitchScene() {
        if (startButton) {
            // Take player to tutorial if they have not completed it yet
            if (LevelManager.tutorialComplete) {
                SceneManager.LoadScene(destinationScene);
            } else {
                LevelManager.tutorialComplete = true;
                SceneManager.LoadScene("Tutorial");
            }
        } else if (resumeButton) {
            PauseMenu.isPaused = false;
        } else if (levelsButton) {
            PauseMenu.isPaused = false;
            SceneManager.LoadScene(destinationScene);
        } else {
            SceneManager.LoadScene(destinationScene);
        }
    }
}
