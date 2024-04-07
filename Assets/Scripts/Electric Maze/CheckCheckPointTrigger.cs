using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCheckPointTrigger : MonoBehaviour
{
    public CountDownTimer CountDownTimer;
    public LevelsTransition LevelsTransition;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bat"))
        {
            Debug.Log("lvl passed!!");
            if (HapticFeedback.checkpointCounter >= 9)
            {
                if (ScoreCalculatorMaze.isLevel1)
                {
                    CountDownTimer.OverallTime(1);
                    Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                    LevelsTransition.checkLevelOne();
                }
                else if (ScoreCalculatorMaze.isLevel2)
                {
                    CountDownTimer.OverallTime(2);
                    Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                    LevelsTransition.CheckLevelTwo();
                }
            }
        }
    }
}
