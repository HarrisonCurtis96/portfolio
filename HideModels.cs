using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HideModels : MonoBehaviour
{
    // creates 8 gameobjects for the character models
    public GameObject male1;
    public GameObject male2;
    public GameObject male3;
    public GameObject male4;
    public GameObject woman1;
    public GameObject woman2;
    public GameObject woman3;
    public GameObject woman4;

    void Start()
    {
        // set all models to active (showing)
        male1.SetActive(true);
        male2.SetActive(true);
        male3.SetActive(true);
        male4.SetActive(true);
        woman1.SetActive(true);
        woman2.SetActive(true);
        woman3.SetActive(true);
        woman4.SetActive(true);
        HideModel(AudienceValueManager.audienceSize);
    }

    // hides model based on users input
    public void HideModel(int size)
    {
        if (size < 1)
        {
            male1.SetActive(false);
        }
        if (size < 2)
        {
            woman1.SetActive(false);
        }
        if (size < 3)
        {
            male2.SetActive(false);
        }
        if (size < 4)
        {
            woman2.SetActive(false);
        }
        if (size < 5)
        {
            male4.SetActive(false);
        }
        if (size < 6)
        {
            woman3.SetActive(false);
        }
        if (size < 7)
        {
            male3.SetActive(false);
        }
        if (size < 8)
        {
            woman4.SetActive(false);
        }
    }
}
