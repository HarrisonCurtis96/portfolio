using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechLength : MonoBehaviour
{
    public TextMeshProUGUI time;
    public static float speechLength = 30;

    public void Start()
    {
        time.GetComponent<TextMeshProUGUI>();
    }

    // Updates the text above the time slider, increments in 15 seconds
    public void TextUpdate(float value)
    {
        value *= 15;
        TimeSpan timeValue = TimeSpan.FromSeconds(value);
        time.text = timeValue.ToString(@"m\:ss");
        speechLength = value;
    }
}
