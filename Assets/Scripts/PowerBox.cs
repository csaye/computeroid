using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{

    private Charge chargeScript;

    // The maximum amount of charge power an object can have
    private float maxCharge = 4;

    void Start()
    {
        chargeScript = GetComponent<Charge>();
    }

    void Update()
    {
        ActivateCharge();
    }

    void ActivateCharge() {
        chargeScript.charged = true;
        chargeScript.chargePower = maxCharge;
    }
}
