using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{

    // The direction that the laser is currently traveling in
    public bool bottomRightDefault, bottomLeftDefault, topLeftDefault, topRightDefault;
    private bool bottomRight, bottomLeft, topLeft, topRight;

    public GameObject laser1Prefab, laser2Prefab, laser3Prefab, laser4Prefab;

    private float currentX, currentY;

    private Vector2 center, size;

    private GameObject player;

    // The most recent laser instantiated
    private GameObject laser;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private Color blue = new Color(0, 0, 1, 1);

    private Charge chargeScript;

    // Whether the laser will continue and whether the current laser is the first or second
    private bool willContinue = true, isFirstLaser = true, isSecondLaser = true;

    private float renderFramesDefault = 2, renderFrames;

    // A higher frame count means smoother laser transitions but more flickering
    private float frameCount = 30.0f;

    void Start()
    {
        renderFrames = 0;
        
        // Size set to just under full block in order to prevent laser-emitter interference
            size = new Vector2(0.499f, 0.499f);

        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        chargeScript = GetComponent<Charge>();
    }

    // Each iteration of update begins at the emitter and re-forms the laser path
    void Update()
    {
        if (!PauseMenu.isPaused && chargeScript.charged && renderFrames <= 0) {

            renderFrames = renderFramesDefault;

            // In beginning of laser emission, output direction set to default
            bottomRight = bottomRightDefault;
            bottomLeft = bottomLeftDefault;
            topLeft = topLeftDefault;
            topRight = topRightDefault;
            
            // Depending on current orientation, update instantiation position accordingly
            if (bottomRight) {
                currentX = transform.position.x + 1;
                currentY = transform.position.y - 1;
            }
            if (bottomLeft) {
                currentX = transform.position.x - 1;
                currentY = transform.position.y - 1;
            }
            if (topLeft) {
                currentX = transform.position.x - 1;
                currentY = transform.position.y + 1;
            }
            if (topRight) {
                currentX = transform.position.x + 1;
                currentY = transform.position.y + 1;
            }

            // Set new laser center to updated position
            center = new Vector2(currentX, currentY);

            PrepEmit();
        }

        if (renderFrames > 0) renderFrames--;
        if (renderFrames < 0) renderFrames = 0;
    }

    void PrepEmit() {

        // Reset all values to default at beginning of laser emission
        willContinue = true;
        isFirstLaser = true;
        isSecondLaser = true;

        // Continues to instantiate laser while not obstructed
        while (willContinue) {

            if (bottomRight) EmitLaser(laser1Prefab, 1, -1);
            if (bottomLeft) EmitLaser(laser2Prefab, -1, -1);
            if (topLeft) EmitLaser(laser3Prefab, -1, 1);
            if (topRight) EmitLaser(laser4Prefab, 1, 1);

            // If second time passing through while loop, disable second laser
            if (!isFirstLaser) isSecondLaser = false;

            // If first time passing through while loop, disable first laser
            if (isFirstLaser) isFirstLaser = false;

        }
    }

    void EmitLaser(GameObject prefab, float xChange, float yChange) {

        // If first or second laser, do not instantiate no matter what if there is a collider
        if (willContinue && (isFirstLaser || isSecondLaser)) {
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                if (!collider.isTrigger) {
                    willContinue = false;
                }
            }
        }

        // If there are no objects with a box collider within the area, instantiate the laser
        if (willContinue && !isFirstLaser) {
            laser = Instantiate(prefab, center, Quaternion.identity);
            Destroy(laser, renderFrames/frameCount);
            currentX = currentX + xChange;
            currentY = currentY + yChange;
            center = new Vector2(currentX, currentY);
        }

        // If the collider hits something, continuation will be based off of whether it is a reflective object
        if (willContinue && !isFirstLaser) {
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                if (!collider.isTrigger) willContinue = prepReflect();
            }
        }
    }

    // If the hit object is one which can be reflected off of, reflect; otherwise, end laser
    bool prepReflect() {

        if (laser == null) return false;

        // check objects in collider for player colored blue or mirror block
        foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
            if ((collider.gameObject == player && playerSpriteRenderer.color == blue) || collider.gameObject.tag == ("MirrorBox")) {
                    
                // Because of reflection, laser status must be reset for colliders to be corrected
                isFirstLaser = true;
                isSecondLaser = true;

                // If reflecting, checks for orientation, updates orientation, moves 1 unit in correct orientation, and laser continues to travel

                if (bottomRight) return reflectLaser(collider, "bottomRight", "bottomLeft", "topRight", -1, 1);
                if (bottomLeft) return reflectLaser(collider, "bottomLeft", "bottomRight", "topLeft", 1, 1);
                if (topLeft) return reflectLaser(collider, "topLeft", "topRight", "bottomLeft", 1, -1);
                if (topRight) return reflectLaser(collider, "topRight", "topLeft", "bottomRight", -1, -1);
            }

        }

        // If the collider is not the player colored blue or the mirror block, end laser
        return false;
    }

    bool reflectLaser(Collider2D collider, string initialDirection, string xDirection, string yDirection, float xChange, float yChange) {

        // If the difference in the x orientation is greater, laser will reflect to the x direction
        if (Mathf.Abs(laser.transform.position.x - collider.gameObject.transform.position.x) > Mathf.Abs(laser.transform.position.y - collider.gameObject.transform.position.y)) {
            currentX = currentX + xChange;
            center = new Vector2(currentX, currentY);
            
            if (xDirection == "bottomRight") bottomRight = true;
            if (xDirection == "bottomLeft") bottomLeft = true;
            if (xDirection == "topLeft") topLeft = true;
            if (xDirection == "topRight") topRight = true;

        // If the difference in the y orientation is greater, laser will reflect to the y direction
        } else {
            currentY = currentY + yChange;
            center = new Vector2(currentX, currentY);
            
            if (yDirection == "bottomRight") bottomRight = true;
            if (yDirection == "bottomLeft") bottomLeft = true;
            if (yDirection == "topLeft") topLeft = true;
            if (yDirection == "topRight") topRight = true;
        }

        if (initialDirection == "bottomRight") bottomRight = false;
        if (initialDirection == "bottomLeft") bottomLeft = false;
        if (initialDirection == "topLeft") topLeft = false;
        if (initialDirection == "topRight") topRight = false;

        return true;
    }
}
