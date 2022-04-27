using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public Slider slider;

    void ChargeValue()
    {
        PlayerController chargeScript = GetComponent<PlayerController>();
        slider.maxValue = chargeScript.maxCharge;
        slider.value = chargeScript.charge;
    }
}
// Brackys tutorial: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=607s