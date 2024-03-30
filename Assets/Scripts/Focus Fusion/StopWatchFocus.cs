using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchFocus : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculationFocus.isStopWatchStart)
        {
            ScoreCalculationFocus.elapsedTimeStopWatch += Time.deltaTime;
            ScoreCalculationFocus.stopWatchtime = Mathf.FloorToInt(ScoreCalculationFocus.elapsedTimeStopWatch);
            Debug.Log(ScoreCalculationFocus.stopWatchtime);
        }
    }
}
