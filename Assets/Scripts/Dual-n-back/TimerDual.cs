using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDual : MonoBehaviour
{
    private string timerText;

    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculator.isPlayPressed && !ScoreCalculator.isPaused)
        {
            ScoreCalculator.elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(ScoreCalculator.elapsedTime / 60);
            int seconds = Mathf.FloorToInt(ScoreCalculator.elapsedTime % 60);
            timerText = string.Format("{0:00}:{1:00}", minutes, seconds);
            Debug.Log(timerText);
        }

    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        ScoreCalculator.isPlayPressed = true;
        // Reset the timer to zero
        ScoreCalculator.elapsedTime = 0f;
        ScoreCalculator.isPaused = false;
    }

    // Function to pause the timer
    public static void PauseTimer()
    {
        ScoreCalculator.isPaused = true;
    }

    // Function to resume the timer
    public void ResumeTimer()
    {
        ScoreCalculator.isPaused = false;
    }
}
