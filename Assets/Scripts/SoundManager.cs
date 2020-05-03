using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    static GameObject instance;

    public static bool updateSound = false;

    public static float volume = 0.5f;

    public static string currentSound;

    public AudioClip buttonPress;

    private AudioSource audioSource;

    void Start()
    {

        // If the sound manager instance is already created, do not create another one
        if (instance != null) {
            Destroy(gameObject);

        // If sound manager instance not created, set instance to sound manager
        } else {
            volume = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
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
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    void UpdateSound() {

        if (currentSound == "buttonPress") {
            audioSource.clip = buttonPress;
            audioSource.Play();
        }
    }
}
