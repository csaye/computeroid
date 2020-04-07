using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{

    public Sprite tileNormal;
    public Sprite tileHighlight;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckHighlight();
    }

    // Checks if the mouse is over the tile, and if so, highlights the tile
    void CheckHighlight() {

        // Raycast to mouse position
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
        // If tile hit by raycast, highlight tile
        if (rayHit.collider != null && transform.position == rayHit.collider.gameObject.transform.position) {
            spriteRenderer.sprite = tileHighlight;
        } else {
            spriteRenderer.sprite = tileNormal;
        }
 
    }

}
