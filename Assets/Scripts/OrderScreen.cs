using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderScreen : MonoBehaviour
{

    // Whether the order screen is currently active
    public static bool active;

    public bool volumeOverride = true;

    private AudioSource audioSource;

    void Awake()
    {
        active = true;

        // Fade out the music for the order sequence
        MusicManager.fadeMusic = true;

        audioSource = GetComponent<AudioSource>();
    }

    void Update() {

        // Update the volume of the typewriter sound
        UpdateVolume();
    }

    void UpdateVolume() {

        // If not overwritten by animator sequence, set volume of typewriter sounds to sound manager volume
        if (volumeOverride) {
            audioSource.volume = 0;
        } else {
            audioSource.volume = SoundManager.volume;
        }
    }

    void Deactivate()
    {
        active = false;

        // Activate music because order sequence is done
        MusicManager.updateMusic = true;
    }
}
