using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScreen : MonoBehaviour
{

    public bool volumeOverride = true, lastFrameOverride = true;

    public float currentLevel;

    private AudioSource audioSource;

    // Controllers of the sound fades
    private bool fadeIn, fadeOut;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Update the volume of the crash sound
        UpdateVolume();

        // Fades in crash sound
        if (fadeIn) {
            fadeIn = false;
            StartCoroutine(FadeIn());
        }

        // Fades out crash sound
        if (fadeOut) {
            fadeOut = false;
            StartCoroutine(FadeOut());
        }
    }

    void UpdateVolume() {

        // If volume override status changes
        if (volumeOverride != lastFrameOverride) {
            
            // If not overwritten by animator sequence, set volume of crash sounds to sound manager volume
            if (volumeOverride) {
                fadeOut = true;
            } else {
                fadeIn = true;
            }
        }

        lastFrameOverride = volumeOverride;
    }

    IEnumerator FadeIn() {

        // Fade in the crash sound over the course of a second
        for (int i = 0; i <= 100; i++) {
            audioSource.volume = (i / 100.0f) * SoundManager.volume;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeOut() {

        // Fade out the crash sound over the course of a second
        for (int i = 100; i >= 0; i--) {
            audioSource.volume = (i / 100.0f) * SoundManager.volume;
            yield return new WaitForSeconds(0.01f);
        }
    }

    void GoLevelSelect() {
        
        // If the current level is one not previously completed, increment level value
        if (currentLevel >= LevelManager.level) LevelManager.level = currentLevel + 1;
        
        FadeManager.nextScene = "Level Select";
        FadeManager.fading = true;
    }

    void GoCredits() {

        // Signify all level completion (in credits)
        LevelManager.level = 13;
        
        FadeManager.nextScene = "Credits";
        FadeManager.fading = true;
    }

}
