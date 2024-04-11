using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUpTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    // Update is called once per frame
    void Update()
    {
        if (ReinforcementManagement.isPlayPressed && !ReinforcementManagement.isPaused)
        {
            ReinforcementManagement.elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(ReinforcementManagement.elapsedTime / 60);
            int seconds = Mathf.FloorToInt(ReinforcementManagement.elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            //Debug.Log(timerText);
        }
            
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        ReinforcementManagement.isPlayPressed = true;
        // Reset the timer to zero
        ReinforcementManagement.elapsedTime = 0f;
        ReinforcementManagement.isPaused = false;
        GetDateTime();
    }

    // Function to pause the timer
    public static void PauseTimer()
    {
        ReinforcementManagement.isPaused = true;
    }

    // Function to resume the timer
    public void ResumeTimer()
    {
        ReinforcementManagement.isPaused = false;
    }

    public static void OverallTime()
    {
        ReinforcementManagement.overallTime = Mathf.Round(ReinforcementManagement.elapsedTime * 100f) / 100f;
    }

    public void GetDateTime()
    {
        DateTime currentDateTime = DateTime.Now;
        ScoreCalculator.date = currentDateTime.ToString("dd/MM/yyyy");
        ScoreCalculator.time = currentDateTime.ToString("HH:mm");
        Debug.Log("Date: " + ScoreCalculator.date);
        Debug.Log("Time: " + ScoreCalculator.time);
    }
}
