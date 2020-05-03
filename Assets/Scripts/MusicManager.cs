using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    static GameObject instance;

    public static bool updateMusic = false, stopMusic = false;

    public static float volume = 0.5f;

    public AudioClip theme, early, middle, later;

    private AudioSource audioSource;

    void Start()
    {
        
        // If the music manager instance is already created, do not create another one
        if (instance != null) {
            Destroy(gameObject);

        // If music manager instance not created, set instance to music manager
        } else {
            volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
            instance = gameObject;
            audioSource = GetComponent<AudioSource>();
            UpdateMusic();
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (updateMusic) {
            updateMusic = false;
            UpdateMusic();
        }

        if (stopMusic) {
            stopMusic = false;
            StopMusic();
        }

        UpdateVolume();
    }

    void StopMusic() {
        audioSource.Stop();
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
            audioSource.clip = middle;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Level 10") {
            audioSource.clip = middle;
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
