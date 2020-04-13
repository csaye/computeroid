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

    private SpriteRenderer playerSpriteRenderer;

    private Color blue = new Color(0, 0, 1, 1);

    private bool willContinue = true, isFirstLaser = true;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused) {

            bottomRight = bottomRightDefault;
            bottomLeft = bottomLeftDefault;
            topLeft = topLeftDefault;
            topRight = topRightDefault;
            
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

            center = new Vector2(currentX, currentY);
            size = new Vector2(0.495f, 0.495f);

            EmitLaser();
        }
    }

    void EmitLaser() {

        willContinue = true;
        isFirstLaser = true;

        while (willContinue) {

            // If laser traveling to the bottom right
            if (bottomRight) {

                // If first laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser1Prefab, center, Quaternion.identity);
                    Destroy(laser, 1.0f/30.0f);
                    currentX++;
                    currentY--;
                    center = new Vector2(currentX, currentY);
                }

                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger && !isFirstLaser) {
                        willContinue = checkReflect();
                    }
                }

            }

            if (bottomLeft) {

                // If first laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser2Prefab, center, Quaternion.identity);
                    Destroy(laser, 1.0f/30.0f);
                    currentX--;
                    currentY--;
                    center = new Vector2(currentX, currentY);
                }

                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger) {
                        willContinue = checkReflect();
                    }
                }

            }

            if (topLeft) {

                // If first laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser3Prefab, center, Quaternion.identity);
                    Destroy(laser, 1.0f/30.0f);
                    currentX--;
                    currentY++;
                    center = new Vector2(currentX, currentY);
                }

                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger) {
                        willContinue = checkReflect();
                    }
                }

            }

            if (topRight) {

                // If first laser, do not instantiate no matter what if there is a collider
                if (isFirstLaser) {
                    foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                        if (!collider.isTrigger) {
                            willContinue = false;
                        }
                    }
                }

                // If there are no objects with a box collider within the area, instantiate the laser
                if (willContinue && !isFirstLaser) {
                    laser = Instantiate(laser4Prefab, center, Quaternion.identity);
                    Destroy(laser, 1.0f/30.0f);
                    currentX++;
                    currentY++;
                    center = new Vector2(currentX, currentY);
                }

                foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (!collider.isTrigger) {
                        willContinue = checkReflect();
                    }
                }

            }

            isFirstLaser = false;

        }
    }

    bool checkReflect() {

        if (laser == null) return false;

        // check objects in collider for player colored blue or mirror block
        foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
            if ((collider.gameObject == player && playerSpriteRenderer.color == blue) || collider.gameObject.tag == ("MirrorBox")) {
                    
                isFirstLaser = true;

                // If reflecting, checks for orientation, updates orientation, moves 1 unit in correct orientation, and laser continues to travel

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

                if (bottomLeft) {

                    // If the difference in the x orientation is greater, laser will reflect to the bottom right
                    if (Mathf.Abs(laser.transform.position.x - collider.gameObject.transform.position.x) > Mathf.Abs(laser.transform.position.y - collider.gameObject.transform.position.y)) {
                        currentX--;
                        center = new Vector2(currentX, currentY);
                        bottomRight = true;

                    // If the difference in the y orientation is greater, laser will reflect to the top left
                    } else {
                        currentY--;
                        center = new Vector2(currentX, currentY);
                        topLeft = true;
                    }

                    bottomLeft = false;
                    return true;
                }

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
