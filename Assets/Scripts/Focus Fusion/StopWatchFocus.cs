using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchFocus : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculationFocus.isStopWatchStart && !ScoreCalculationFocus.isPaused)
        {
            ScoreCalculationFocus.elapsedTimeStopWatch += Time.deltaTime;
            ScoreCalculationFocus.stopWatchtime = Mathf.Round(ScoreCalculationFocus.elapsedTimeStopWatch * 1000f) / 1000f;
           // Debug.Log(ScoreCalculationFocus.stopWatchtime);
        }
    }

    // Function to pause the timer
    public static void PauseTimer()
    {
        ScoreCalculationFocus.isPaused = true;
    }

    // Function to resume the timer
    public void ResumeTimer()
    {
        ScoreCalculationFocus.isPaused = false;
    }
}
