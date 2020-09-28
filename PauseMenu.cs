using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider volumeSlider;
    public TextMeshProUGUI script;

    public void PauseGame()
    {
        volumeSlider.value = VolumeManager.volume;

        if (SetTimer.isPaused == false)
        {
            SetTimer.isPaused = true;
            pauseMenu.SetActive(true);
            script.enabled = false;
            return;
        }

        if (SetTimer.isPaused == true)
        {
            SetTimer.isPaused = false;
            pauseMenu.SetActive(false);
            script.enabled = true;
            return;
        }
    }

    // return to game button, restars the timer and hides the menu
    public void ReturnToGame()
    {
        SetTimer.isPaused = false;
        pauseMenu.SetActive(false);
        script.enabled = true;
        return;
    }

    // quits the performance and returns to the main menu
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        SceneManager.LoadScene(0);
    }
}
