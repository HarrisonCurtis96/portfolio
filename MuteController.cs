using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MuteController : MonoBehaviour
{
    public Toggle toggle;
    public static bool toggleMute;

    public void Start()
    {
        toggle.GetComponent<Toggle>();
        toggleMute = toggle.isOn;
    }

    // updates the value of the toggle
    public void toggleUpdate(bool value)
    {
        toggle.isOn = value;
        toggleMute = toggle.isOn;
    }
}
