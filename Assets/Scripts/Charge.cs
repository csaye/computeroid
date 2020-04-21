using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    
    // The objects to be charged (every charge object can charge up to four others)
    public GameObject toCharge1;
    public GameObject toCharge2;
    public GameObject toCharge3;
    public GameObject toCharge4;

    // Whether the object is charged
    public bool charged;

    // The level of charge the object currently has
    public float chargePower;

    private Charge toChargeScript1;
    private Charge toChargeScript2;
    private Charge toChargeScript3;
    private Charge toChargeScript4;

    private SpriteRenderer spriteRenderer;

    private Color black = new Color(0, 0, 0, 1);
    private Color gray = new Color(0.4f, 0.4f, 0.4f, 1);

    // The maximum amount of charge power an object can have
    private float maxCharge = 4;

    void Start()
    {
        if (toCharge1 != null) toChargeScript1 = toCharge1.GetComponent<Charge>();
        if (toCharge2 != null) toChargeScript2 = toCharge2.GetComponent<Charge>();
        if (toCharge3 != null) toChargeScript3 = toCharge3.GetComponent<Charge>();
        if (toCharge4 != null) toChargeScript4 = toCharge4.GetComponent<Charge>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (charged) chargePower = maxCharge;
    }

    void Update()
    {

        // If game not paused
        if (!PauseMenu.isPaused) {
            UpdateChargePower();
            UpdateCharge();
            UpdateColor();
        }
    }

    // If object is charged, charge next object and vice versa
    void UpdateChargePower() {

        if (toCharge1 != null) {

            if (toCharge1.GetComponent<BoxCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge1.GetComponent<SpriteRenderer>().enabled && toCharge1.GetComponent<BoxCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript1.chargePower = maxCharge;
                    } else {
                        toChargeScript1.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript1.chargePower > 0) toChargeScript1.chargePower--;
                    if (toChargeScript1.chargePower < 0) toChargeScript1.chargePower = 0;
                }

            }

            if (toCharge1.GetComponent<PolygonCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge1.GetComponent<SpriteRenderer>().enabled && toCharge1.GetComponent<PolygonCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript1.chargePower = maxCharge;
                    } else {
                        toChargeScript1.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript1.chargePower > 0) toChargeScript1.chargePower--;
                    if (toChargeScript1.chargePower < 0) toChargeScript1.chargePower = 0;
                }

            }
        }

        if (toCharge2 != null) {

            if (toCharge2.GetComponent<BoxCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge2.GetComponent<SpriteRenderer>().enabled && toCharge2.GetComponent<BoxCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript2.chargePower = maxCharge;
                    } else {
                        toChargeScript2.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript2.chargePower > 0) toChargeScript2.chargePower--;
                    if (toChargeScript2.chargePower < 0) toChargeScript2.chargePower = 0;
                }

            }

            if (toCharge2.GetComponent<PolygonCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge2.GetComponent<SpriteRenderer>().enabled && toCharge2.GetComponent<PolygonCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript2.chargePower = maxCharge;
                    } else {
                        toChargeScript2.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript2.chargePower > 0) toChargeScript2.chargePower--;
                    if (toChargeScript2.chargePower < 0) toChargeScript2.chargePower = 0;
                }

            }
        }

        if (toCharge3 != null) {

            if (toCharge3.GetComponent<BoxCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge3.GetComponent<SpriteRenderer>().enabled && toCharge3.GetComponent<BoxCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript3.chargePower = maxCharge;
                    } else {
                        toChargeScript3.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript3.chargePower > 0) toChargeScript3.chargePower--;
                    if (toChargeScript3.chargePower < 0) toChargeScript3.chargePower = 0;
                }

            }

            if (toCharge3.GetComponent<PolygonCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge3.GetComponent<SpriteRenderer>().enabled && toCharge3.GetComponent<PolygonCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript3.chargePower = maxCharge;
                    } else {
                        toChargeScript3.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript3.chargePower > 0) toChargeScript3.chargePower--;
                    if (toChargeScript3.chargePower < 0) toChargeScript3.chargePower = 0;
                }

            }
        }

        if (toCharge4 != null) {

            if (toCharge4.GetComponent<BoxCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge4.GetComponent<SpriteRenderer>().enabled && toCharge4.GetComponent<BoxCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript4.chargePower = maxCharge;
                    } else {
                        toChargeScript4.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript4.chargePower > 0) toChargeScript4.chargePower--;
                    if (toChargeScript4.chargePower < 0) toChargeScript4.chargePower = 0;
                }

            }

            if (toCharge4.GetComponent<PolygonCollider2D>() != null) {

                // Set the next object to the charge state of the previous
                if (toCharge4.GetComponent<SpriteRenderer>().enabled && toCharge4.GetComponent<PolygonCollider2D>().enabled) {
                    if (charged) {
                        toChargeScript4.chargePower = maxCharge;
                    } else {
                        toChargeScript4.chargePower--;
                    }
            
                // If the renderer of the next object is disabled, set the object to uncharged
                } else {
                    if (toChargeScript4.chargePower > 0) toChargeScript4.chargePower--;
                    if (toChargeScript4.chargePower < 0) toChargeScript4.chargePower = 0;
                }

            }
        }

    }

    void UpdateCharge() {
        if (chargePower > 0) {
            charged = true;
        } else {
            charged = false;
        }
    }

    // Update the color of the object based on its charge
    void UpdateColor() {

        // If the object is charged, set color to black; otherwise, set to gray
        if (charged) {
            spriteRenderer.color = black;
        } else {
            spriteRenderer.color = gray;
        }
    }

}
