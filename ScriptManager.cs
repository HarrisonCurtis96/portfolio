using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public TextMeshProUGUI inputBox;
    public static string script = "";

    // Pulls text from the text box and remembers the text
    public void StoreScript()
    {
        script = inputBox.GetComponent<TextMeshProUGUI>().text;
        inputBox.GetComponent<TextMeshProUGUI>().text = script;

    }
}
