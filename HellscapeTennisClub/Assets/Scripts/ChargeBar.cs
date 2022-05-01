using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public Slider slider;
    public PlayerController chargeScript;

    void Start()
    {
        slider.maxValue = chargeScript.maxCharge;
    }

    void Update()
    {
        slider.value = chargeScript.charge;
    }
}
// Brackys tutorial: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=607s