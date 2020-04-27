using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePad : MonoBehaviour
{

    // The wire prefab associated with the wire pad
    public GameObject wirePrefab;

    private GameObject player = null;

    private SpriteRenderer playerSpriteRenderer;

    private Color orange = new Color(1, 0.5f, 0, 1);
    private Color white = new Color(1, 1, 1, 1);

    private Vector2 center, size;

    private Wire wireScript;

    private float maxInteractDistance = 1.5f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        center = new Vector2(transform.position.x, transform.position.y);

        // Size set to just under full block in order to prevent interference
        size = new Vector2(0.499f, 0.499f);

        if (wirePrefab.GetComponent<Wire>() != null) wireScript = wirePrefab.GetComponent<Wire>();
    }

    void Update()
    {

        // If game not paused, check for wire placement
        if (!PauseMenu.isPaused) {
            CheckWire();
        }
    }

    // Places the wire if there is no obstruction in place
    void CheckWire() {

        // If left mouse button pressed
        if (Input.GetMouseButtonDown(0)) {

            // If player is colored orange and within range of the wire pad
            if (playerSpriteRenderer.color == orange && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {
                
                // Raycast to mouse position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

                // If hit collider in the position of the wire pad
                if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {

                    // If a wire is not already in the location of the wire pad, place a wire
                    if (!Obstructed()) PlaceWire();
                }
            }
        }
    }

    // Places the corresponding wire based on public settings
    void PlaceWire() {

        // Reset player color to white
        playerSpriteRenderer.color = white;

        if (wirePrefab.GetComponent<Wire>() != null) wireScript.resetWire = true;

        if (wirePrefab.GetComponent<BoxCollider2D>() != null) wirePrefab.GetComponent<BoxCollider2D>().enabled = true;
        if (wirePrefab.GetComponent<PolygonCollider2D>() != null) wirePrefab.GetComponent<PolygonCollider2D>().enabled = true;
        if (wirePrefab.GetComponent<CircleCollider2D>() != null) wirePrefab.GetComponent<CircleCollider2D>().enabled = true;
        wirePrefab.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Checks whether the wire pad is currently obstructed
    bool Obstructed() {

        // Checks each collider in the region of the wire pad for an obstructing object
        foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {

            // If hit object has box collider
            if (collider.GetComponent<BoxCollider2D>() != null) {

                // If object found, set parameter
                if (!collider.GetComponent<BoxCollider2D>().isTrigger) return true;
            }

            // If hit object has polygon collider
            if (collider.GetComponent<PolygonCollider2D>() != null) {

                // If object found, set parameter
                if (!collider.GetComponent<PolygonCollider2D>().isTrigger) return true;
            }

            // If hit object has circle collider
            if (collider.GetComponent<CircleCollider2D>() != null) {

                // If object found, set parameter
                if (!collider.GetComponent<CircleCollider2D>().isTrigger) return true;
            }

        }

        // If no obstruction found in any collider within the region of the wire pad, return false
        return false;
    }

}
