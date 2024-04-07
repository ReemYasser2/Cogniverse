using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchDual : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculator.isStopWatchStart && !ScoreCalculator.isPausedStopWatch)
        {
            ScoreCalculator.elapsedTimeStopWatch += Time.deltaTime;
            ScoreCalculator.stopWatchtime = Mathf.Round(ScoreCalculator.elapsedTimeStopWatch * 1000f) / 1000f;
            // Debug.Log(ScoreCalculationFocus.stopWatchtime);
        }
    }

    // Function to pause the timer
    public static void PauseTimer()
    {
        ScoreCalculator.isPausedStopWatch = true;
    }

    // Function to resume the timer
    public void ResumeTimer()
    {
        ScoreCalculator.isPausedStopWatch = false;
    }
}
