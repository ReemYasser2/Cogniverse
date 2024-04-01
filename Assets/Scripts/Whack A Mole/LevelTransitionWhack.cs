using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransitionWhack : MonoBehaviour
{
    public WhackMenuHandler WhackMenuHandler;


    public void CheckLevel1()
    {
        if (((ScoreCalculationWhack.score)/ScoreCalculationWhack.spawnsCounter) >= 0.7 && ScoreCalculationWhack.isTimeOver) // pass lvl1
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.scorelvl1Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            ScoreCalculationWhack.scoreOnePercent = ScoreCalculationWhack.score / ScoreCalculationWhack.spawnsCounter;
            WhackMenuHandler.completeLevel1Canvas.SetActive(true);
            WhackMenuHandler.level2Button.SetActive(true);
            WhackMenuHandler.level2LockButton.SetActive(false);
            ScoreCalculationWhack.score = 0;
            ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo / ScoreCalculationWhack.spawnsCounter;
            
            Debug.Log("Response time:" + ScoreCalculationWhack.responseTimeGo);
            Debug.Log("Conter: " + ScoreCalculationWhack.spawnsCounter);
            ResetResponseTimeTimer();

        }
        else if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) < 0.7 && ScoreCalculationWhack.isTimeOver) // retry lvl1
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            ScoreCalculationWhack.score = 0;
            ResetResponseTimeTimer();
        }
    }

    public void CheckLevel2()
    {
        if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) >= 0.7 && ScoreCalculationWhack.isTimeOver) // pass lvl2 
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.scorelvl2Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            ScoreCalculationWhack.scoreTwoPercent = ScoreCalculationWhack.score / ScoreCalculationWhack.spawnsCounter;
            WhackMenuHandler.completeLevel2Canvas.SetActive(true);
            ScoreCalculationWhack.isGameOver = true;
            ScoreCalculationWhack.score = 0;
            ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo / ScoreCalculationWhack.spawnerGoCounter;
            ScoreCalculationWhack.responseTimeNoGo = ScoreCalculationWhack.responseTimeNoGo / ScoreCalculationWhack.spawnerNoGoCounter;
            
            Debug.Log("Response time Go:" + ScoreCalculationWhack.responseTimeGo);
            Debug.Log("Response time No Go:" + ScoreCalculationWhack.responseTimeNoGo);
            Debug.Log("Conter go: " + ScoreCalculationWhack.spawnerGoCounter);
            Debug.Log("Conter no go: " + ScoreCalculationWhack.spawnerNoGoCounter);
            ResetResponseTimeTimer();
        }
        else if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) < 0.7 && ScoreCalculationWhack.isTimeOver) // retry lvl3
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            ScoreCalculationWhack.score = 0;
            ResetResponseTimeTimer();
        }
    }

    public void HomeButton()
    {
        ScoreCalculationWhack.isHomeButtonClicked = true;

        ScoreCalculationWhack.score = 0;
        ScoreCalculationWhack.isTimeOver = true;
        ScoreCalculationWhack.isPlayPressed = false;

        ScoreCalculationWhack.isLevel1 = false;
        ScoreCalculationWhack.isLevel2 = false;
        ScoreCalculationWhack.isGameOver = true;

        ScoreCalculationWhack.isPaused1 = false;
        ScoreCalculationWhack.isPaused2 = false;
        ScoreCalculationWhack.isStopWatch1Start = false;
        ScoreCalculationWhack.isStopWatch2Start = false;
        ScoreCalculationWhack.isFirstObjectCollide = false;
        ScoreCalculationWhack.isSecondObjectCollide = false;
        ResetResponseTimeTimer();

    }

    private void ResetResponseTimeTimer()
    {
        ScoreCalculationWhack.elapsedTimeStopWatch1 = 0;
        ScoreCalculationWhack.elapsedTimeStopWatch2 = 0;
        ScoreCalculationWhack.responseTimeGo = 0;
        ScoreCalculationWhack.responseTimeNoGo = 0;
        ScoreCalculationWhack.stopWatchtime1 = 0;
        ScoreCalculationWhack.stopWatchtime2 = 0;
        ScoreCalculationWhack.spawnerGoCounter = 0;
        ScoreCalculationWhack.spawnerNoGoCounter = 0;
    }
}

