using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    public int sceneSelection;

    public Animator transition;

    public float transitionTime = 1f;

    // user scene selection
    public void SetScene(int scene)
    {
        sceneSelection = scene;
    }

    // Changes scene to what the user selected
    public void PlayGame()
    {
        Debug.Log("playgame");
        LoadScene();
    }

    // Closes the application
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LoadScene() 
    {
        StartCoroutine(LoadLevel(sceneSelection + 1));
    }

    IEnumerator LoadLevel(int levelindez)
    {
        // play animation
        transition.SetTrigger("start");

        // wait for animation to finish
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelindez);
    }
}
