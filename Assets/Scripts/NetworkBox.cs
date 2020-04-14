using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkBox : MonoBehaviour
{

    public GameObject levelController;

    private Charge chargeScript;
    private LevelController levelControllerScript;

    void Start()
    {
        chargeScript = GetComponent<Charge>();

        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {
        CheckCrash();
    }
    
    void CheckCrash() {
        if (!chargeScript.charged) levelControllerScript.levelComplete = true;
    }
}
