using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyManager : MonoBehaviour
{

    static GameObject instance;

    void Awake()
    {
        // If dont destroy manager is already created, do not create another
        if (instance != null) {
            Destroy(gameObject);

        // If dont destroy manager is not created, create and save to instance
        } else {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }

}
