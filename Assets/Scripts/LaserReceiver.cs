using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    
    // The direction that the input port is facing
    public bool bottomRightDefault, bottomLeftDefault, topLeftDefault, topRightDefault;

    private Charge chargeScript;

    private Vector2 center, size;

    // All receivers wait a few frames to turn off to prevent jittery behavior
    private float waitFrames = 3;

    void Start()
    {
        chargeScript = GetComponent<Charge>();

        size = new Vector2(0.499f, 0.499f);

        // Update center based on the direction the receiver is facing
        if (bottomRightDefault) center = new Vector2(transform.position.x + 1, transform.position.y - 1);
        if (bottomLeftDefault) center = new Vector2(transform.position.x - 1, transform.position.y - 1);
        if (topLeftDefault) center = new Vector2(transform.position.x - 1, transform.position.y + 1);
        if (topRightDefault) center = new Vector2(transform.position.x + 1, transform.position.y + 1);
    }

    
    void Update()
    {
        CheckCharged();
    }

    void CheckCharged() {

        // If the input port is facing to the bottom right
        if (bottomRightDefault) {

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                if (collider.gameObject.tag == ("Laser3")) {
                    waitFrames = 3;
                    chargeScript.charged = true;
                    return;
                }
            }

            // If wait frame over, turn off receiver
            if (waitFrames <= 0) {
                chargeScript.charged = false;
                return;
            }
        }

        // If the input port is facing to the bottom left
        if (bottomLeftDefault) {

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                if (collider.gameObject.tag == ("Laser4")) {
                    waitFrames = 3;
                    chargeScript.charged = true;
                    return;
                }
            }

            // If wait frame over, turn off receiver
            if (waitFrames <= 0) {
                chargeScript.charged = false;
                return;
            }
        }

        // If the input port is facing to the top left
        if (topLeftDefault) {

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                if (collider.gameObject.tag == ("Laser1")) {
                    waitFrames = 3;
                    chargeScript.charged = true;
                    return;
                }
            }

            // If wait frame over, turn off receiver
            if (waitFrames <= 0) {
                chargeScript.charged = false;
                return;
            }
        }

        // If the input port is facing to the top right
        if (topRightDefault) {

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                if (collider.gameObject.tag == ("Laser2")) {
                    waitFrames = 3;
                    chargeScript.charged = true;
                    return;
                }
            }

            // If wait frame over, turn off receiver
            if (waitFrames <= 0) {
                chargeScript.charged = false;
                return;
            }
        }

        if (waitFrames > 0) waitFrames--;
        if (waitFrames < 0) waitFrames = 0;

    }
}
