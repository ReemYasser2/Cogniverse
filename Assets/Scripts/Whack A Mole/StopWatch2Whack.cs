using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch2Whack : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculationWhack.isStopWatch2Start && !ScoreCalculationWhack.isPaused2)
        {
            ScoreCalculationWhack.elapsedTimeStopWatch2 += Time.deltaTime;
            ScoreCalculationWhack.stopWatchtime2 = Mathf.Round(ScoreCalculationWhack.elapsedTimeStopWatch2 * 1000f) / 1000f;
            //Debug.Log(ScoreCalculationWhack.stopWatchtime2);
        }
    }

    // Function to pause the timer
    public static void PauseTimer()
    {
        ScoreCalculationWhack.isPaused2 = true;
    }

    // Function to resume the timer
    public static void ResumeTimer()
    {
        ScoreCalculationWhack.isPaused2 = false;
    }
}
