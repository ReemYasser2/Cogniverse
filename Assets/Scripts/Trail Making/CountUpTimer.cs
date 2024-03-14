using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUpTimer : MonoBehaviour
{
    private string timerText;
    public static float elapsedTime;
    private bool isPlayPressed = false;
    public static bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlayPressed && !isPaused)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText = string.Format("{0:00}:{1:00}", minutes, seconds);
            Debug.Log(timerText);
        }
            
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        isPlayPressed = true;
        // Reset the timer to zero
        elapsedTime = 0f;
        isPaused = false;   
    }

    // Function to pause the timer
    public static void PauseTimer()
    {
        isPaused = true;
    }

    // Function to resume the timer
    public void ResumeTimer()
    {
        isPaused = false;
    }
}
