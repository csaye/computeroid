using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{

    public GameObject buttonResult;

    public Vector2 resultLocation;

    public Sprite buttonNormal;
    public Sprite buttonHighlight;

    private SpriteRenderer spriteRenderer;

    private GameObject player = null;

    private Charge chargeScript;

    private float maxInteractDistance = 1.5f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        chargeScript = GetComponent<Charge>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If not paused and button is charged
        if (!PauseMenu.isPaused && !FadeManager.fading && !LevelController.levelComplete) {

            // If not charged, default button to unpressed
            if (chargeScript.charged) {
                CheckHighlight();
            } else {
                spriteRenderer.sprite = buttonNormal;
            }
            
        } else {
            spriteRenderer.sprite = buttonNormal;
        }
    }

    // Checks if the mouse is over the button, and if so, highlights the button
    void CheckHighlight() {

        // Raycast to mouse position
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(InputEx.mousePosition));
        
        // If button hit by raycast, highlight button
        if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
            spriteRenderer.sprite = buttonHighlight;

            // If highlighted, mouse button down, and within player range, activate button function
            if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) ActivateButton();

        } else {
            spriteRenderer.sprite = buttonNormal;
        }
    }

    // Move the resultant object to the target location
    void ActivateButton() {

        // Move target object to to target position
        buttonResult.transform.localPosition = resultLocation;

        // Cancel velocity of target object
        if (buttonResult.GetComponent<Rigidbody2D>() != null) buttonResult.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
