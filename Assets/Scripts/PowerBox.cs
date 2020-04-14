using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{

    private Charge chargeScript;

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
    }
}
