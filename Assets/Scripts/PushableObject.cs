using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    void Start()
    {
        if (GetComponent<Rigidbody2D>() != null) rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // If game paused or level complete
        if (PauseMenu.isPaused || ControlsMenu.isPaused || LevelController.levelComplete) MakeStatic();
    }


    // Cancel velocity if paused
    void MakeStatic() {
        rigidBody.velocity = new Vector2(0, 0);
    }
}
