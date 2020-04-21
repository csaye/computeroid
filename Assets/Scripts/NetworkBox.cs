﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkBox : MonoBehaviour
{

    public GameObject levelController;

    private Charge chargeScript;
    private LevelController levelControllerScript;

    private float startDelayFrames = 60;

    void Start()
    {
        chargeScript = GetComponent<Charge>();

        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused) {
            if (startDelayFrames <= 0) CheckCrash();
            if (startDelayFrames > 0) startDelayFrames--;
            if (startDelayFrames < 0) startDelayFrames = 0;
        }
    }
    
    void CheckCrash() {

        // If not charged, crash the level
        if (!chargeScript.charged) levelControllerScript.levelComplete = true;
    }
}
