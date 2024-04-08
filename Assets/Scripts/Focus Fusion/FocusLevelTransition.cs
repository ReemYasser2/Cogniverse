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
            menuHandler.completeLevel1Canvas.SetActive(true);

            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);

            menuHandler.scorelvl1Text.text = $"Your Score: {ScoreCalculationFocus.score}";

            // statistics
            FocusTimer.OverallTime();
            ScoreCalculationFocus.scorePercentOne = (ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo);
            ScoreCalculationFocus.accuracy = ScoreCalculationFocus.AccuracyCalculation(ScoreCalculationFocus.correctCounter, (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo));
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;

            Debug.Log("FF: score: " + ScoreCalculationFocus.scorePercentOne);
            Debug.Log("FF: overall time: " + ScoreCalculationFocus.overallTime);
            Debug.Log("FF: accuracy: " + ScoreCalculationFocus.accuracy);
            Debug.Log("FF: RT GO: " + ScoreCalculationFocus.responseTimeGo);
            Debug.Log("FF: RT NO GO: " + ScoreCalculationFocus.responseTimeNoGo);
            
            ResetLevels();
            ScoreCalculationFocus.isLevel1 = false;
        }
        else if ((ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo) < 0.7 && ScoreCalculationFocus.isTimeOver) // retry lvl1
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            menuHandler.scorelvl1retryText.text = $"Your Score: {ScoreCalculationFocus.score}";

            // statistics
            FocusTimer.OverallTime();
            ScoreCalculationFocus.scorePercentOne = (ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo);
            ScoreCalculationFocus.accuracy = ScoreCalculationFocus.AccuracyCalculation(ScoreCalculationFocus.correctCounter, (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo));
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;

            Debug.Log("FF: score: " + ScoreCalculationFocus.scorePercentOne);
            Debug.Log("FF: overall time: " + ScoreCalculationFocus.overallTime);
            Debug.Log("FF: accuracy: " + ScoreCalculationFocus.accuracy);
            Debug.Log("FF: RT GO: " + ScoreCalculationFocus.responseTimeGo);
            Debug.Log("FF: RT NO GO: " + ScoreCalculationFocus.responseTimeNoGo);

            ResetLevels();
            ScoreCalculationFocus.isLevel1 = false;
        }
    }

    public void CheckLevel2()
    {
        if ((ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo) >= 0.7 && ScoreCalculationFocus.isTimeOver) // complete lvl2
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.completeLevel2Canvas.SetActive(true);
            menuHandler.scorelvl2Text.text = $"Your Score: {ScoreCalculationFocus.score}";

            // statistics
            FocusTimer.OverallTime();
            ScoreCalculationFocus.scorePercentTwo = (ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo);
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;
            ScoreCalculationFocus.accuracy = ScoreCalculationFocus.AccuracyCalculation(ScoreCalculationFocus.correctCounter, (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo));

            Debug.Log("FF: score: " + ScoreCalculationFocus.scorePercentTwo);
            Debug.Log("FF: overall time: " + ScoreCalculationFocus.overallTime);
            Debug.Log("FF: accuracy: " + ScoreCalculationFocus.accuracy);
            Debug.Log("FF: RT GO: " + ScoreCalculationFocus.responseTimeGo);
            Debug.Log("FF: RT NO GO: " + ScoreCalculationFocus.responseTimeNoGo);

            ResetLevels();
            ScoreCalculationFocus.isLevel2 = false;
        }
        else if ((ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo) < 0.7 && ScoreCalculationFocus.isTimeOver) // retry lvl2
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            menuHandler.scorelvl2retryText.text = $"Your Score: {ScoreCalculationFocus.score}";

            // statistics
            FocusTimer.OverallTime();
            ScoreCalculationFocus.scorePercentTwo = (ScoreCalculationFocus.score) / (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo);
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;
            ScoreCalculationFocus.accuracy = ScoreCalculationFocus.AccuracyCalculation(ScoreCalculationFocus.correctCounter, (ScoreCalculationFocus.totalTrialsGo + ScoreCalculationFocus.totalTrialsNoGo));

            Debug.Log("FF: score: " + ScoreCalculationFocus.scorePercentTwo);
            Debug.Log("FF: overall time: " + ScoreCalculationFocus.overallTime);
            Debug.Log("FF: accuracy: " + ScoreCalculationFocus.accuracy);
            Debug.Log("FF: RT GO: " + ScoreCalculationFocus.responseTimeGo);
            Debug.Log("FF: RT NO GO: " + ScoreCalculationFocus.responseTimeNoGo);

            ResetLevels();
            ScoreCalculationFocus.isLevel2 = false;
        }
    }

    public void ToHome()
    {
        GridSpawner.ResetText();
        ScoreCalculationFocus.isHomeClicked = true;
        ScoreCalculationFocus.reinforcementText = "";

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
        ScoreCalculationFocus.overallTime = 0;
        ResetResponseTimeTimer();
        ScoreCalculationFocus.remainingTime = 0;
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

    public void ResetGame()
    {
        GridSpawner.ResetText();
        ScoreCalculationFocus.isHomeClicked = true;
        ScoreCalculationFocus.reinforcementText = "";

        ScoreCalculationFocus.score = 0;
        ScoreCalculationFocus.isPlayPressed = false;
        ScoreCalculationFocus.isTimeOver = true;

        ScoreCalculationFocus.isLevel1 = false;
        ScoreCalculationFocus.isLevel2 = false;
        ScoreCalculationFocus.isGameOver = true;

        ScoreCalculationFocus.isPaused = false;
        ScoreCalculationFocus.overallTime = 0;
        ScoreCalculationFocus.accuracy = 0;
        ScoreCalculationFocus.correctCounter = 0;
        ScoreCalculationFocus.scorePercentOne = 0;
        ScoreCalculationFocus.scorePercentTwo = 0;

        ResetResponseTimeTimer();

        ScoreCalculationFocus.remainingTime = 0;
    }

    private void ResetLevels()
    {
        ResetResponseTimeTimer();
        ScoreCalculationFocus.isGameOver = true;
        ScoreCalculationFocus.score = 0;
        ScoreCalculationFocus.scorePercentOne = 0;
        ScoreCalculationFocus.scorePercentTwo = 0;
        ScoreCalculationFocus.overallTime = 0;
        ScoreCalculationFocus.accuracy = 0;
        ScoreCalculationFocus.correctCounter = 0;
    }
}
