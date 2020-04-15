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

    void Start()
    {
        renderFrames = 0;
        
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

            // Size set to just under full block in order to prevent laser-emitter interference
            size = new Vector2(0.499f, 0.499f);

            EmitLaser();
        }

        if (renderFrames > 0) renderFrames--;
        if (renderFrames < 0) renderFrames = 0;
    }

    void EmitLaser() {

        // Reset all values to default at beginning of laser emission
        willContinue = true;
        isFirstLaser = true;
        isSecondLaser = true;

        // Continues to instantiate laser while not obstructed
        while (willContinue) {

            // If laser traveling to the bottom right
            if (bottomRight) {

                // If first or second laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser || isSecondLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser1Prefab, center, Quaternion.identity);
                    Destroy(laser, renderFrames/30.0f);
                    currentX++;
                    currentY--;
                    center = new Vector2(currentX, currentY);
                }

                // If the collider hits something, continuation will be based off of whether it is a reflective object
                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger && !isFirstLaser) {
                        willContinue = checkReflect();
                    }
                }
                
            }

            // If laser traveling to the bottom left
            if (bottomLeft) {

                // If first or second laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser || isSecondLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser2Prefab, center, Quaternion.identity);
                    Destroy(laser, renderFrames/30.0f);
                    currentX--;
                    currentY--;
                    center = new Vector2(currentX, currentY);
                }

                // If the collider hits something, continuation will be based off of whether it is a reflective object
                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger && !isFirstLaser) {
                        willContinue = checkReflect();
                    }
                }

            }

            // If laser traveling to the top left
            if (topLeft) {

                // If first or second laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser || isSecondLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser3Prefab, center, Quaternion.identity);
                    Destroy(laser, renderFrames/30.0f);
                    currentX--;
                    currentY++;
                    center = new Vector2(currentX, currentY);
                }

                // If the collider hits something, continuation will be based off of whether it is a reflective object
                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger && !isFirstLaser) {
                        willContinue = checkReflect();
                    }
                }

            }

            // If laser traveling to the top right
            if (topRight) {

                // If first or second laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser || isSecondLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser4Prefab, center, Quaternion.identity);
                    Destroy(laser, renderFrames/30.0f);
                    currentX++;
                    currentY++;
                    center = new Vector2(currentX, currentY);
                }

                // If the collider hits something, continuation will be based off of whether it is a reflective object
                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger && !isFirstLaser) {
                        willContinue = checkReflect();
                    }
                }

            }

            // If second time passing through while loop, disable second laser
            if (!isFirstLaser) isSecondLaser = false;

            // If first time passing through while loop, disable first laser
            if (isFirstLaser) isFirstLaser = false;

        }
    }

    // If the hit object is one which can be reflected off of, reflect; otherwise, end laser
    bool checkReflect() {

        if (laser == null) return false;

        // check objects in collider for player colored blue or mirror block
        foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
            if ((collider.gameObject == player && playerSpriteRenderer.color == blue) || collider.gameObject.tag == ("MirrorBox")) {
                    
                // Because of reflection, laser status must be reset for colliders to be corrected
                isFirstLaser = true;
                isSecondLaser = true;

                // If reflecting, checks for orientation, updates orientation, moves 1 unit in correct orientation, and laser continues to travel

                // If reflecting coming from the bottom right direction
                if (bottomRight) {
                    
                    // If the difference in the x orientation is greater, laser will reflect to the bottom left
                    if (Mathf.Abs(laser.transform.position.x - collider.gameObject.transform.position.x) > Mathf.Abs(laser.transform.position.y - collider.gameObject.transform.position.y)) {
                        currentX--;
                        center = new Vector2(currentX, currentY);
                        bottomLeft = true;

                    // If the difference in the y orientation is greater, laser will reflect to the top right
                    } else {
                        currentY++;
                        center = new Vector2(currentX, currentY);
                        topRight = true;
                    }

                    bottomRight = false;
                    return true;
                }

                // If reflecting coming from the bottom left direction
                if (bottomLeft) {

                    // If the difference in the x orientation is greater, laser will reflect to the bottom right
                    if (Mathf.Abs(laser.transform.position.x - collider.gameObject.transform.position.x) > Mathf.Abs(laser.transform.position.y - collider.gameObject.transform.position.y)) {
                        currentX++;
                        center = new Vector2(currentX, currentY);
                        bottomRight = true;

                    // If the difference in the y orientation is greater, laser will reflect to the top left
                    } else {
                        currentY++;
                        center = new Vector2(currentX, currentY);
                        topLeft = true;
                    }

                    bottomLeft = false;
                    return true;
                }

                // If reflecting coming from the top left direction
                if (topLeft) {

                    // If the difference in the x orientation is greater, laser will reflect to the top right
                    if (Mathf.Abs(laser.transform.position.x - collider.gameObject.transform.position.x) > Mathf.Abs(laser.transform.position.y - collider.gameObject.transform.position.y)) {
                        currentX++;
                        center = new Vector2(currentX, currentY);
                        topRight = true;

                    // If the difference in the y orientation is greater, laser will reflect to the bottom left
                    } else {
                        currentY--;
                        center = new Vector2(currentX, currentY);
                        bottomLeft = true;
                    }

                    topLeft = false;
                    return true;
                }

                // If reflecting coming from the top right direction
                if (topRight) {

                    // If the difference in the x orientation is greater, laser will reflect to the top left
                    if (Mathf.Abs(laser.transform.position.x - collider.gameObject.transform.position.x) > Mathf.Abs(laser.transform.position.y - collider.gameObject.transform.position.y)) {
                        currentX--;
                        center = new Vector2(currentX, currentY);
                        topLeft = true;

                    // If the difference in the y orientation is greater, laser will reflect to the bottom right
                    } else {
                        currentY--;
                        center = new Vector2(currentX, currentY);
                        bottomRight = true;
                    }

                    topRight = false;
                    return true;
                }

            }

        }

        // If the collider is not the player colored blue or the mirror block, end laser
        return false;
    }
}
