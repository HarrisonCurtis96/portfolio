using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimer : MonoBehaviour
{
    public Toggle toggle;
    public static bool toggleState;

    public void Start()
    {
        toggle.GetComponent<Toggle>();
        toggleState = toggle.isOn;
    }

    // updates the toggle value
    public void toggleUpdate(bool value)
    {
        toggle.isOn = value;
        toggleState = toggle.isOn;
    }
}

