using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{

    public bool bottomRight, bottomLeft, topLeft, topRight;
    public GameObject laser1Prefab, laser2Prefab, laser3Prefab, laser4Prefab;

    void Start()
    {

    }

    void Update()
    {
        if (!PauseMenu.isPaused) EmitLaser();
    }

    void EmitLaser() {
        if (bottomRight) {
            
        }
        if (bottomLeft) {

        }
        if (topLeft) {

        }
        if (topRight) {

        }
    }
}
