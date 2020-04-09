using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    public Animator animator;

    public GameObject levelManager;

    public float currentPos = 1;

    private LevelManager levelManagerScript;

    // Level selector positioning in scene
    private float row1 = -1.93762f, row2 = 0.0623729f, row3 = 2.062382f;
    private float col1 = -5.25012f, col2 = -1.750118f, col3 = 1.749884f, col4 = 5.249887f;

    void Start()
    {
        levelManagerScript = levelManager.GetComponent<LevelManager>();
    }

    void Update()
    {
        if (!levelManagerScript.levelSelected) UpdatePosition();
    }

    // Updates the position of the level selector based on player input and levels unlocked
    void UpdatePosition() {
        if (currentPos == 1) {
            transform.position = new Vector2(col1, row1);
            if (Input.GetKeyDown("return")) {
                levelManagerScript.levelSelected = true;
                animator.SetBool("LevelSelected", true);
            }
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 2) {
                currentPos++;
                return;
            }
        }
        if (currentPos == 2) {
            transform.position = new Vector2(col2, row1);
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 3) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 3) {
            transform.position = new Vector2(col3, row1);
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 4) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 4) {
            transform.position = new Vector2(col4, row1);
            if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && LevelManager.level >= 5) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 5) {
            transform.position = new Vector2(col4, row2);
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && LevelManager.level >= 6) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) currentPos--;
        }
        if (currentPos == 6) {
            transform.position = new Vector2(col3, row2);
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && LevelManager.level >= 7) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) currentPos--;
        }
        if (currentPos == 7) {
            transform.position = new Vector2(col2, row2);
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("left")) && LevelManager.level >= 8) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) currentPos--;
        }
        if (currentPos == 8) {
            transform.position = new Vector2(col1, row2);
            if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && LevelManager.level >= 9) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) currentPos--;
        }
        if (currentPos == 9) {
            transform.position = new Vector2(col1, row3);
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 10) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) currentPos--;
        }
        if (currentPos == 10) {
            transform.position = new Vector2(col2, row3);
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 11) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 11) {
            transform.position = new Vector2(col3, row3);
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right")) && LevelManager.level >= 12) {
                currentPos++;
                return;
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
        if (currentPos == 12) {
            transform.position = new Vector2(col4, row3);
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) currentPos--;
        }
    }
}
