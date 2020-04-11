﻿using System.Collections;
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

    private float maxInteractDistance = 1.5f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused) CheckHighlight();
    }

    // Checks if the mouse is over the button, and if so, highlights the button
    void CheckHighlight() {

        // Raycast to mouse position
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        
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
        buttonResult.transform.localPosition = resultLocation;
    }
}
