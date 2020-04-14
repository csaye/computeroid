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

    private Charge toChargeScript1;
    private Charge toChargeScript2;
    private Charge toChargeScript3;
    private Charge toChargeScript4;

    private SpriteRenderer spriteRenderer;

    private Color black = new Color(0, 0, 0, 1);
    private Color gray = new Color(0.4f, 0.4f, 0.4f, 1);

    void Start()
    {
        if (toCharge1 != null) toChargeScript1 = toCharge1.GetComponent<Charge>();
        if (toCharge2 != null) toChargeScript2 = toCharge2.GetComponent<Charge>();
        if (toCharge3 != null) toChargeScript3 = toCharge3.GetComponent<Charge>();
        if (toCharge4 != null) toChargeScript4 = toCharge4.GetComponent<Charge>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // If game not paused
        if (!PauseMenu.isPaused) {
            UpdateCharge();
            UpdateColor();
        }
    }

    // If object is charged, charge next object and vice versa
    void UpdateCharge() {

        if (toCharge1 != null) {

            // Set the next object to the charge state of the previous
            if (toCharge1.GetComponent<Renderer>().enabled) {
                toChargeScript1.charged = charged;
        
            // If the renderer of the next object is disabled, set the object to uncharged
            } else {
                toChargeScript1.charged = false;
            }
        }

        if (toCharge2 != null) {

            // Set the next object to the charge state of the previous
            if (toCharge2.GetComponent<Renderer>().enabled) {
                toChargeScript2.charged = charged;
        
            // If the renderer of the next object is disabled, set the object to uncharged
            } else {
                toChargeScript2.charged = false;
            }
        }

        if (toCharge3 != null) {

            // Set the next object to the charge state of the previous
            if (toCharge3.GetComponent<Renderer>().enabled) {
                toChargeScript3.charged = charged;
        
            // If the renderer of the next object is disabled, set the object to uncharged
            } else {
                toChargeScript3.charged = false;
            }
        }

        if (toCharge4 != null) {

            // Set the next object to the charge state of the previous
            if (toCharge4.GetComponent<Renderer>().enabled) {
                toChargeScript4.charged = charged;
        
            // If the renderer of the next object is disabled, set the object to uncharged
            } else {
                toChargeScript4.charged = false;
            }
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
