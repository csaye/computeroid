using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterControllerLevel2 : MonoBehaviour
{

    public GameObject levelController;

    public Animator animator;

    public Vector2 targetPoint;

    private LevelController levelControllerScript;

    private float maxInteractDistance = 0.2f;

    void Start()
    {
        levelControllerScript = levelController.GetComponent<LevelController>();
    }

    void Update()
    {
        CheckCrash();
    }

    void CheckCrash() {
        if (Vector2.Distance(transform.position, targetPoint) < maxInteractDistance) levelControllerScript.levelComplete = true;
    }
}
