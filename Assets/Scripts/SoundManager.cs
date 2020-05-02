using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    static GameObject instance;

    public static bool updateSound = false;

    public static float volume = 0.5f;

    public static string currentSound;

    // public AudioClip x;

    private AudioSource audioSource;

    void Start()
    {

        // If the sound manager instance is already created, do not create another one
        if (instance != null) {
            Destroy(gameObject);

        // If sound manager instance not created, set instance to sound manager
        } else {
            instance = gameObject;
            audioSource = GetComponent<AudioSource>();
            UpdateSound();
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (updateSound) {
            updateSound = false;
            UpdateSound();
        }

        UpdateVolume();
    }

    void UpdateVolume() {
        audioSource.volume = volume;
    }

    void UpdateSound() {

        // if (currentSound == "x") {
        //     audioSource.clip = x;
        //     audioSource.Play();
        // }
    }
}
