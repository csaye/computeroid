using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    
    // The color of the paint bucket
    public Color paintColor;

    public Sprite paintLevel0, paintLevel1, paintLevel2, paintLevel3, paintLevel4, paintLevel5, paintLevelInfinite;

    // Whether the bucket contains an infinite amount of paint
    public bool infinite;

    // How much paint is in the paint bucket
    public float paintLevel;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private GameObject player = null;

    private Color white = new Color(1, 1, 1, 1);

    private float maxInteractDistance = 1.5f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        if (infinite) paintLevel = 1;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        if (paintLevel > 0) spriteRenderer.color = paintColor;
    }

    void Update()
    {
        UpdatePaintLevel();
        if (!PauseMenu.isPaused && !FadeManager.fading) CheckClick();
    }

    // Check if paint bucket is clicked and player is clean, and if so, transfer color to player
    void CheckClick() {
        if (Input.GetMouseButtonDown(0) && playerSpriteRenderer.color == white) {

            // Check if player is close enough to the paint bucket
            if (Vector2.Distance(transform.position, player.transform.position) < maxInteractDistance) {
            
                // Raycast to mouse position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
                // If bucket hit by raycast, transfer paint
                if (rayHit.collider != null && paintLevel > 0 && playerSpriteRenderer.color != paintColor && transform.position == rayHit.collider.gameObject.transform.position) {
                    if (!infinite) paintLevel--;
                    playerSpriteRenderer.color = paintColor;
                }
            }
        }
    }

    // Updates the paint level based on how much paint is left in the bucket
    void UpdatePaintLevel() {
        
        // If the paint level is not infinite, update accordingly
        if (!infinite) {
            if (paintLevel == 0) spriteRenderer.sprite = paintLevel0;
            if (paintLevel == 1) spriteRenderer.sprite = paintLevel1;
            if (paintLevel == 2) spriteRenderer.sprite = paintLevel2;
            if (paintLevel == 3) spriteRenderer.sprite = paintLevel3;
            if (paintLevel == 4) spriteRenderer.sprite = paintLevel4;
            if (paintLevel == 5) spriteRenderer.sprite = paintLevel5;

        // If paint level is infinite, set to infinite paint sprite
        } else {
            spriteRenderer.sprite = paintLevelInfinite;
        }
    }

}
