using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : MonoBehaviour
{
    
    private GameObject player = null;

    private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D rigidBody;

    private Color green = new Color(0, 1, 0, 1);

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        if (GetComponent<Rigidbody2D>() != null) rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused && !FadeManager.fading && !LevelController.levelComplete && !OrderScreen.active) UpdatePushable();
    }

    void UpdatePushable() {
        
        // If player is green, set block to pushable
        if (playerSpriteRenderer.color == green) {
            rigidBody.isKinematic = false;
        
        // Otherwise, set block to unpushable
        } else {
            rigidBody.isKinematic = true;
        }
    }
}
