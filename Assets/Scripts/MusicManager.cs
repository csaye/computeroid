using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public static bool updateMusic = false, stopMusic = false, fadeMusic = false;

    public static float volume = 0.5f;

    public AudioClip theme, early, middle, later;

    private AudioSource audioSource;

    // The volume should be controlled by the fade while music is fading
    private bool fadeOverride;

    void Start()
    {
        volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        audioSource = GetComponent<AudioSource>();
        UpdateMusic();
    }

    void Update()
    {
        if (updateMusic) {
            updateMusic = false;
            fadeOverride = false;
            UpdateMusic();
        }

        if (stopMusic) {
            stopMusic = false;
            StopMusic();
        }

        if (fadeMusic) {
            fadeMusic = false;
            fadeOverride = true;
            StartCoroutine(FadeMusic());
        }

        if (!fadeOverride) UpdateVolume();
    }

    void StopMusic() {
        audioSource.Stop();
    }

    IEnumerator FadeMusic() {

        // Fade out music over a second
        for (int i = 100; i >= 0; i--) {
            audioSource.volume = volume * (i/100.0f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    void UpdateVolume() {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    void UpdateMusic() {

        if (SceneManager.GetActiveScene().name == "Main Menu") {
            audioSource.clip = theme;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level Select") {
            audioSource.clip = theme;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Credits") {
            audioSource.clip = theme;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Tutorial") {
            audioSource.clip = early;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 1") {
            audioSource.clip = early;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 2") {
            audioSource.clip = early;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 3") {
            audioSource.clip = early;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 4") {
            audioSource.clip = early;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 5") {
            audioSource.clip = middle;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 6") {
            audioSource.clip = middle;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 7") {
            audioSource.clip = middle;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 8") {
            audioSource.clip = middle;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 9") {
            audioSource.clip = later;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 10") {
            audioSource.clip = later;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 11") {
            audioSource.clip = later;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 12") {
            audioSource.clip = later;
            audioSource.Play();
        }
    }
}
