using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{

    private GameObject player = null;

    private SpriteRenderer playerSpriteRenderer;

    private Color purple = new Color(0.5f, 0, 1, 1);
    private Color white = new Color(1, 1, 1, 1);

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused) {
            CheckTeleport();
        }
    }

    void CheckTeleport() {

        // If left mouse button pressed
        if (Input.GetMouseButtonDown(0)) {
            
            // If player is colored purple
            if (playerSpriteRenderer.color == purple) {

                // Raycast to mouse position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

                // If hit collider in the position of the teleport pad, teleport
                if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) Teleport();
            }
        }
    }

    void Teleport() {
        playerSpriteRenderer.color = white;
        player.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
