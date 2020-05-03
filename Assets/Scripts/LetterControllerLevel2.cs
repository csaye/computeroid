using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterControllerLevel2 : MonoBehaviour
{

    public Animator animator;

    public Vector2 targetPoint;

    private float maxInteractDistance = 0.2f;

    void Start()
    {

    }

    void Update()
    {
        CheckCrash();
    }

    void CheckCrash() {
        if (Vector2.Distance(transform.position, targetPoint) < maxInteractDistance) LevelController.levelComplete = true;
    }
}
