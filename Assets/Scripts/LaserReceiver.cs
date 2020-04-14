using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    
    // The direction that the input port is facing
    public bool bottomRightDefault, bottomLeftDefault, topLeftDefault, topRightDefault;

    private Charge chargeScript;

    private Vector2 center, size;

    void Start()
    {
        chargeScript = GetComponent<Charge>();

        size = new Vector2(0.499f, 0.499f);
    }

    
    void Update()
    {
        CheckCharged();
    }

    void CheckCharged() {

        // If the input port is facing to the bottom right
        if (bottomRightDefault) {
            center = new Vector2(transform.position.x + 1, transform.position.y - 1);

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (collider.gameObject.tag == ("Laser3")) {
                        chargeScript.charged = true;
                        return;
                }
            }
            chargeScript.charged = false;
            return;
        }

        // If the input port is facing to the bottom left
        if (bottomLeftDefault) {
            center = new Vector2(transform.position.x - 1, transform.position.y - 1);

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (collider.gameObject.tag == ("Laser4")) {
                        chargeScript.charged = true;
                        return;
                }
            }
            chargeScript.charged = false;
            return;
        }

        // If the input port is facing to the top left
        if (topLeftDefault) {
            center = new Vector2(transform.position.x - 1, transform.position.y + 1);

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (collider.gameObject.tag == ("Laser1")) {
                        chargeScript.charged = true;
                        return;
                }
            }
            chargeScript.charged = false;
            return;
        }

        // If the input port is facing to the top right
        if (topRightDefault) {
            center = new Vector2(transform.position.x + 1, transform.position.y + 1);

            // If the correct laser is in the correct space, set the receiver to charged
            foreach (Collider2D collider in (Physics2D.OverlapBoxAll(center, size, 0))) {
                    if (collider.gameObject.tag == ("Laser2")) {
                        chargeScript.charged = true;
                        return;
                }
            }
            chargeScript.charged = false;
            return;
        }

    }
}
