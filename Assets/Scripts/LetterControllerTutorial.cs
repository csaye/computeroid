using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterControllerTutorial : MonoBehaviour
{

    public Animator animator;

    public static float corruptLevel;

    private float startY;

    private bool corrupt = false;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        CheckCorrupt();
        CheckCrash();
    }

    void CheckCorrupt() {
        if (!corrupt && Mathf.Abs(transform.position.y - startY) > 0.5f) {
            corrupt = true;
            corruptLevel++;
            animator.SetFloat("CorruptLevel", corruptLevel);
        }
    }

    void CheckCrash() {
        if (corruptLevel > 2) LevelController.levelComplete = true;
    }
}
