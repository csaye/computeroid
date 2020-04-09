using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashScreen : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void GoLevelSelect() {
        LevelManager.level++;
        SceneManager.LoadScene("Level Select");
    }
}
