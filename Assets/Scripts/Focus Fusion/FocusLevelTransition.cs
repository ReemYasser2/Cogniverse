using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FocusLevelTransition : MonoBehaviour
{
    public FocusMenuHandler menuHandler;

    public void CheckLevel1()
    {
        if ((ScoreCalculationFocus.score)/ (ScoreCalculationFocus.totalTrialsGo+ ScoreCalculationFocus.totalTrialsNoGo) >= 0.7 && ScoreCalculationFocus.isTimeOver) // complete lvl1
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.scorelvl1Text.text = $"Your Score: {ScoreCalculationFocus.score}";
            menuHandler.completeLevel1Canvas.SetActive(true);
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
            ScoreCalculationFocus.scorePercentOne = (ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo);
            Debug.Log("score %: " + ScoreCalculationFocus.scorePercentOne);
            ScoreCalculationFocus.score = 0;
            ScoreCalculationFocus.scorePercentOne = 0;
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;

            ScoreCalculationFocus.accuracy = ScoreCalculationFocus.AccuracyCalculation(ScoreCalculationFocus.correctCounter, (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo));

            Debug.Log("Response time Go:" + ScoreCalculationFocus.responseTimeGo);
            Debug.Log("Response time No Go:" + ScoreCalculationFocus.responseTimeNoGo);
            Debug.Log("Conter go: " + ScoreCalculationFocus.totalTrialsGo);
            Debug.Log("Conter no go: " + ScoreCalculationFocus.totalTrialsNoGo);

            ResetResponseTimeTimer();
        }
        else if ((ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo) < 0.7 && ScoreCalculationFocus.isTimeOver) // retry lvl1
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
            ScoreCalculationFocus.accuracy = 0;
            ScoreCalculationFocus.correctCounter = 0;
            ResetResponseTimeTimer();
        }
    }

    public void CheckLevel2()
    {
        if ((ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo) >= 0.7 && ScoreCalculationFocus.isTimeOver) // complete lvl2
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.scorelvl2Text.text = $"Your Score: {ScoreCalculationFocus.score}";
            menuHandler.completeLevel2Canvas.SetActive(true);
            ScoreCalculationFocus.isGameOver = true;
            ScoreCalculationFocus.scorePercentTwo = (ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo);
            Debug.Log("score %: "+ScoreCalculationFocus.score);
            ScoreCalculationFocus.score = 0;
            ScoreCalculationFocus.scorePercentTwo = 0;
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;

            ScoreCalculationFocus.accuracy = ScoreCalculationFocus.AccuracyCalculation(ScoreCalculationFocus.correctCounter, (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo));

            Debug.Log("Response time Go:" + ScoreCalculationFocus.responseTimeGo);
            Debug.Log("Response time No Go:" + ScoreCalculationFocus.responseTimeNoGo);
            Debug.Log("Conter go: " + ScoreCalculationFocus.totalTrialsGo);
            Debug.Log("Conter no go: " + ScoreCalculationFocus.totalTrialsNoGo);

            ResetResponseTimeTimer();
        }
        else if ((ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo) < 0.7 && ScoreCalculationFocus.isTimeOver) // retry lvl2
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
            ScoreCalculationFocus.accuracy = 0;
            ScoreCalculationFocus.correctCounter = 0;
            ResetResponseTimeTimer();
        }
    }

    public void ToHome()
    {
        ScoreCalculationFocus.isHomeClicked = true;

        ScoreCalculationFocus.score = 0;
        ScoreCalculationFocus.isPlayPressed = false;
        ScoreCalculationFocus.isTimeOver = true;

        ScoreCalculationFocus.isLevel1 = false;
        ScoreCalculationFocus.isLevel2 = false;
        ScoreCalculationFocus.isGameOver = true;

        ScoreCalculationFocus.isPaused = false;

        ScoreCalculationFocus.accuracy = 0;
        ScoreCalculationFocus.correctCounter = 0;
        ScoreCalculationFocus.scorePercentOne = 0;
        ScoreCalculationFocus.scorePercentTwo = 0;
        ResetResponseTimeTimer();
    }

    private void ResetResponseTimeTimer()
    {
        ScoreCalculationFocus.totalTrialsNoGo = 0;
        ScoreCalculationFocus.totalTrialsGo = 0;
        ScoreCalculationFocus.responseTimeGo = 0;
        ScoreCalculationFocus.responseTimeNoGo = 0;
        ScoreCalculationFocus.isStopWatchStart = false;
        ScoreCalculationFocus.elapsedTimeStopWatch = 0;
    }
}
