using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{

    public GameObject levelController;
    
    public Animator animator;

    // Whether shorting the wire will crash the level
    public bool vital = false;

    // Whether a wire will disable others on the same x or y values from shorting
    public bool horizontalExclusion = false;
    public bool verticalExclusion = false;

    // Storage of excluded wire shortage x and y values
    public static List<float> excludedX = new List<float>();
    public static List<float> excludedY = new List<float>();

    private GameObject player = null;

    private Color red = new Color(1, 0, 0, 1);
    private Color white = new Color(1, 1, 1, 1);

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private LevelController levelControllerScript;

    // private bool shorted = false;

    private float maxInteractDistance = 1;
    
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused) CheckShort();
    }

    // Checks if wire is shorted out, and if so, sends signal to short wire
    void CheckShort() {

        // If player left clicks, is colored red, within interaction distance, short out wire
        if (Input.GetMouseButtonDown(0)) {
            if (playerSpriteRenderer.color == red && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {

                // Raycast to mouse position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
                // If wire hit by raycast, short out
                if (!GetComponent<BoxCollider2D>().isTrigger && rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {

                    // If wires free to short, short wire
                    if (!horizontalExclusion && !verticalExclusion) {
                        ShortWire();
                    }

                    // If horizontally excluded, add Y value to no-short list
                    if (horizontalExclusion && !verticalExclusion && !excludedY.Contains(transform.position.y)) {
                        excludedY.Add(transform.position.y);
                        ShortWire();
                    }

                    // If vertically excluded, add X value to no-short list
                    if (verticalExclusion && !horizontalExclusion && !excludedX.Contains(transform.position.x)) {
                        excludedX.Add(transform.position.x);
                        ShortWire();
                    }

                    // If excluded horizontally and vertically, add X and Y values to no-short list
                    if (verticalExclusion && horizontalExclusion && !excludedY.Contains(transform.position.y) && !excludedX.Contains(transform.position.x)) {
                        excludedY.Add(transform.position.y);
                        excludedX.Add(transform.position.x);
                        ShortWire();
                    }
                }
            }
        }
    }

    // Short the wire, using the player's red, doing the shorting animation, and losing hitbox
    void ShortWire() {
        playerSpriteRenderer.color = white;
        animator.SetBool("Shorted", true);
        GetComponent<BoxCollider2D>().isTrigger = true;

        // If the wire is vital, end the level
        if (vital) levelControllerScript.levelComplete = true;
    }
}
