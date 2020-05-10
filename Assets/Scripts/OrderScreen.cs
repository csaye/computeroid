using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderScreen : MonoBehaviour
{

    // Whether the order screen is currently active
    public static bool active;

    public GameObject okButton;

    public bool volumeOverride = true;

    private AudioSource audioSource;

    private Animator animator;

    void Awake()
    {
        active = true;

        // Fade out the music for the order sequence
        MusicManager.fadeMusic = true;

        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
    }

    void Update() {

        // Update the volume of the typewriter sound
        UpdateVolume();

        // Update the alpha of the ok button to match the order screen
        UpdateOkAlpha();
    }

    void UpdateVolume() {

        // If not overwritten by animator sequence, set volume of typewriter sounds to sound manager volume
        if (volumeOverride) {
            audioSource.volume = 0;
        } else {
            audioSource.volume = SoundManager.volume;
        }

        // If ok button has been activated, fade out
        if (!active) animator.SetBool("FadeOut", true);
    }

    void UpdateOkAlpha() {

        // Set the alpha of the ok button to the alpha of the order screen
        okButton.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
    }

    void ActivateOk() {

        // Activate ok button
        okButton.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Deactivate() {

        // Activate music because order sequence is done
        MusicManager.updateMusic = true;
    }
}
