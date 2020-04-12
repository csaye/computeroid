using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    
    // The object to be charged
    public GameObject toCharge;

    // Whether the object is charged
    public bool charged;

    private Charge toChargeScript;

    void Start()
    {
        toChargeScript = toCharge.GetComponent<Charge>();
    }

    void Update()
    {
        UpdateCharge();
    }

    // If object is charged, charge next object and vice versa
    void UpdateCharge() {
        toChargeScript.charged = charged;
    }
}
