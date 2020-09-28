using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SetTimer : MonoBehaviour
{
    public TextMeshProUGUI clock;
    public TextMeshProUGUI startTimer;
    public GameObject pauseButton;
    public float currentTime;
    public float count;
    public bool allowUpdate = false;
    public static bool isPaused;
    public static bool beep1;
    public static bool beep2;
    public static bool beep3;
    public static bool beepGo;
    public GameObject quitButton;
    public TextMeshProUGUI script;
    public GameObject nextButton;
    public GameObject lastButton;

    void Start()
    {
        isPaused = false;
        beep1 = false;
        beep2 = false;
        beep3 = false;
        beepGo = false;
        SetTime(SpeechLength.speechLength + 6);
        clock.enabled = false;
        pauseButton.SetActive(false);
        quitButton.SetActive(false);
    }

    // sets the time for the start of the instance
    public void SetTime(float time)
    {
        currentTime = time;
        count = time;
    }

    public void Update()
    {
        // Time does not count down if the app is paused
        if (isPaused == false)
        {
            // Counts down the time in seconds
            currentTime -= 1 * Time.deltaTime;
            TimeSpan timeValue = TimeSpan.FromSeconds(currentTime);
            float diff = count - currentTime;

            // shows the countdown till the start of the performance and when it finishes
            // countdown starts at 3 seconds
            if (diff > 0 && diff < 1)
            {
                startTimer.text = "3";

                // Plays the countdown sound once
                if ( beep3 == false)
                {
                    FindObjectOfType<AudioManager>().Play("countdown");
                    beep3 = true;
                }
            }
            // countdown changes to 2
            if (diff > 1 && diff < 2)
            {
                startTimer.text = "2";

                // Plays the countdown sound once
                if (beep2 == false)
                {
                    FindObjectOfType<AudioManager>().Play("countdown");
                    beep2 = true;
                }
            }
            // countdown changes to 1
            if (diff > 2 && diff < 3)
            {
                startTimer.text = "1";

                // Plays the countdown sound once
                if (beep1 == false)
                {
                    FindObjectOfType<AudioManager>().Play("countdown");
                    beep1 = true;
                }
            }

            // countdown changes to GO!
            if (diff > 3 && diff < 4)
            {
                startTimer.text = "GO!";

                // plays go sound once
                if (beepGo == false)
                {
                    FindObjectOfType<AudioManager>().Play("go");
                    beepGo = true;
                }
            }

            // starts the timer and disables the countdown
            if (diff > 5)
            {
                startTimer.enabled = false;
                pauseButton.SetActive(true);
                DisplayTimer();
            }

            // when countdown hits 15 seconds the timer changes to red
            if (currentTime <= 16 && currentTime > 0)
            {
                pauseButton.SetActive(false);
                clock.color = Color.red;
            }

            // Stops the application once the timer hits 0
            if (currentTime <= 0)
            {
                clock.enabled = false;
                pauseButton.SetActive(false);
                startTimer.enabled = true;
                startTimer.text = "FINISH!";
                quitButton.SetActive(true);
                script.enabled = false;
                nextButton.SetActive(false);
                lastButton.SetActive(false);

            }

            clock.text = timeValue.ToString(@"m\:ss");
        }
    }

    // checks to see if timer has been enabled
    public void DisplayTimer()
    {
        if (ShowTimer.toggleState == true)
        {
            clock.enabled = true;
        }
        return;
    }
}
