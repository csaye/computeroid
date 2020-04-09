using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    
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
        if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
            spriteRenderer.sprite = buttonHighlight;

            // If highlighted and mouse button down, activate scene switching
            if (Input.GetMouseButtonDown(0)) SwitchScene();

        } else {
            spriteRenderer.sprite = buttonNormal;
        }
    }

    void SwitchScene() {
        SceneManager.LoadScene(destinationScene);
    }
}
