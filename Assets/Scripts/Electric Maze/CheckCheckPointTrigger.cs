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
            //Debug.Log("lvl passed!!");
            if (HapticFeedback.checkpointCounter >= 8)
            {
                if (ScoreCalculatorMaze.isLevel1)
                {
                    LevelsTransition.checkLevelOne();
                }
                else if (ScoreCalculatorMaze.isLevel2)
                {
                    LevelsTransition.CheckLevelTwo();
                }
            }
        }
    }
}
