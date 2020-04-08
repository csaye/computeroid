using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{

    public GameObject levelController;
    
    public Animator animator;

    public bool vital = false;

    private GameObject player = null;

    private Color red = new Color(1, 0, 0, 1);
    private Color white = new Color(1, 1, 1, 1);

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private LevelController levelControllerScript;

    private bool shorted = false;

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
        CheckShort();
    }

    // Checks if wire is shorted out, and if so, sends signal to short wire
    void CheckShort() {

        // If player left clicks, is colored red, within interaction distance, short out wire
        if (Input.GetMouseButtonDown(0)) {
            if (playerSpriteRenderer.color == red && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {
                
                // Raycast to mouse position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
                // If wire hit by raycast, short out
                if (!shorted && rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
                    shorted = true;
                    ShortWire();
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
