using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPrompt : MonoBehaviour
{
    // gameobject for the canvas which holds the text element to update
    public TextMeshProUGUI scriptBox;
    public GameObject scriptBoxObject;

    // used to store lines for the pages
    public string[] strings; 
    public string[][] splitArrays;

    // the page number the user is currently on
    public int pageNumber = 0;

    // next and last page buttons to move between the pages of the users script
    public GameObject nextButton;
    public GameObject lastButton;

    public void Start()
    {
        scriptBox.enabled = true;

        // call function to split the script into pages
        MakePages(ScriptManager.script);

        // set the first page
        string text = "";
        if (splitArrays.Length != 0)
        {
            for (int x = 0; x < splitArrays[0].Count(); x++)
            {
                text = text + splitArrays[0][x] + Environment.NewLine;
            }
        }

        scriptBox.GetComponent<TextMeshProUGUI>().text = text;

        lastButton.SetActive(false);
        if (splitArrays.ToList().Count == 0)
        {
            nextButton.SetActive(true);
        }
    }


    // Seperates the users script into pages   
    public IEnumerable<string> MakePages(string userText)
    {
        var lines = new List<string>();
        int length = 30;

        // trim white space
        userText = userText.Trim();

        while (userText.Length > 0)
        {
            if (userText.Length <= length)
            {
                lines.Add(userText);
                break;
            }

            //
            var lastSpaceIndex = userText.Substring(0, length).LastIndexOf(' ');
            lines.Add(userText.Substring(0, lastSpaceIndex >= 0 ? lastSpaceIndex : length).Trim());
            userText = userText.Substring(lastSpaceIndex >= 0 ? lastSpaceIndex + 1 : length);
        }

        // push to array
        strings = lines.ToArray();

        //split the array of strings into pages of maximum 4 lines
        int i = 0;
        var query = from s in strings
                    let num = i++
                    group s by num / 5 into g
                    select g.ToArray();
        splitArrays = query.ToArray();

        return strings;
    }

    // loads the next script page
    public void NextPage()
    {
        // does not run if user is on the last page
        if (pageNumber != (splitArrays.ToList().Count - 1))
        {
            pageNumber++;
            string text = BuildText(pageNumber);
            scriptBox.GetComponent<TextMeshProUGUI>().text = text;
        }
        else
        {
            Debug.Log("No more pages");
        }

        CheckForHideButtons();

        return;
    }

    // loads the previous script page
    public void LastPage()
    {
        // does not run if user is on the first page
        if (pageNumber != 0)
        {
            pageNumber--;
            string text = BuildText(pageNumber);
            scriptBox.GetComponent<TextMeshProUGUI>().text = text;
        }
        else
        {
            Debug.Log("Currently on first page, cant move back");
        }

        CheckForHideButtons();

        return;
    }


    // builds the pages
    public string BuildText(int page)
    {
        string scriptText = "";
        int lines = splitArrays[page].ToList().Count;

        // loop through the lines on for each page, each one on a new line
        for (int x = 0; x < lines; x++)
        {
            scriptText = scriptText + splitArrays[page][x] + Environment.NewLine;
        }

        return scriptText;
    }

    // Checks to see if the 
    public void CheckForHideButtons()
    {
        // hide last page button if user is on the first page
        if (pageNumber == 0)
        {
            lastButton.SetActive(false);
        }
        else
        {
            lastButton.SetActive(true);
        }

        // hide next page button if the user is on the last page
        if (pageNumber == (splitArrays.ToList().Count - 1))
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }
}
