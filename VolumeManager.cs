using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TextMeshProUGUI volumeValue;
    public static float volume;

    // find text box element
    public void Start()
    {
        volumeValue.GetComponent<TextMeshProUGUI>();
    }

    // Updates the percentage shown for the volume
    public void TextUpdate(float value)
    {
        volumeValue.text = (value + "%").ToString();
        volume = value;
        SetVolume(value);
    }

    // stores volume value
    public void rememberVolume()
    {
        volumeValue.text = (volume + "%").ToString();    
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume - 80);
    }
}
