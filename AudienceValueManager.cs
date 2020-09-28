using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudienceValueManager : MonoBehaviour
{
    public TextMeshProUGUI audienceValue;
    public static int audienceSize;

    public void Start()
    {
        audienceValue.GetComponent<TextMeshProUGUI>();
    }

    //updates the audience size 
    public void TextUpdate(float value)
    {
        audienceValue.text = value.ToString();
        audienceSize = int.Parse(audienceValue.text);
    }
}
