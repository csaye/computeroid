using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderScreen : MonoBehaviour
{

    // Whether the order screen is currently active
    public static bool active;

    void Awake()
    {
        active = true;

        // Fade out the music for the order sequence
        MusicManager.fadeMusic = true;
    }

    void Deactivate()
    {
        active = false;

        // Activate music because order sequence is done
        MusicManager.updateMusic = true;
    }
}
