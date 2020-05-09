using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static bool updateSound = false;

    public static float volume = 0.5f;

    public static string currentSound;

    public AudioClip buttonPress;
    public AudioClip levelObject;

    private AudioSource audioSource;

    void Start()
    {
        volume = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        audioSource = GetComponent<AudioSource>();
        UpdateSound();
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

        if (currentSound == "levelObject") {
            audioSource.clip = levelObject;
            audioSource.Play();
        }
    }
}
