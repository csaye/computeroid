using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerTutorial : MonoBehaviour
{

    public GameObject crashScreen;

    public bool levelComplete = false;

    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {
        if (levelComplete) Crash();
    }

    void Crash() {
        animator.SetBool("LevelComplete", true);
    }
}
