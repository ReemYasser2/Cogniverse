using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch1Whack : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculationWhack.isStopWatch1Start && !ScoreCalculationWhack.isPaused1)
        {
            ScoreCalculationWhack.elapsedTimeStopWatch1 += Time.deltaTime;
            ScoreCalculationWhack.stopWatchtime1 = Mathf.Round(ScoreCalculationWhack.elapsedTimeStopWatch1 * 1000f) / 1000f;
            //Debug.Log(ScoreCalculationWhack.stopWatchtime1);
        }
    }

    // Function to pause the timer
    public static void PauseTimer()
    {
        ScoreCalculationWhack.isPaused1 = true;
    }

    // Function to resume the timer
    public static void ResumeTimer()
    {
        ScoreCalculationWhack.isPaused1 = false;
    }
}
