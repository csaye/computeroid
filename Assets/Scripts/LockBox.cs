using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBox : MonoBehaviour
{

    public Animator animator;

    private GameObject player = null;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private BoxCollider2D boxCollider;

    private Color yellow = new Color(1, 1, 0, 1);
    private Color white = new Color(1, 1, 1, 1);

    private float maxInteractDistance = 1.5f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // If not paused and button is charged
        if (!PauseMenu.isPaused && !FadeManager.fading && !LevelController.levelComplete) CheckUnlock();
    }

    void CheckUnlock() {
        
        // If the player clicks, is colored yellow, and within range of the lockbox
        if (Input.GetMouseButtonDown(0) && playerSpriteRenderer.color == yellow && Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {

            // Raycast to mouse position
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(InputEx.mousePosition));
            
            // If lock box hit by raycast, unlock lock
            if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
                Unlock();
            }
        }
    }

    // Unlocks the lock, removing the yellow color from the player and opening the lock
    void Unlock() {
        animator.SetBool("Unlocked", true);
        playerSpriteRenderer.color = white;
        boxCollider.enabled = false;
    }
}
