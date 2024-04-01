using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FocusLevelTransition : MonoBehaviour
{
    public FocusMenuHandler menuHandler;

    public void CheckLevel1()
    {
        if (ScoreCalculationFocus.score >= 5 && ScoreCalculationFocus.isTimeOver) // complete lvl1
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.scorelvl1Text.text = $"Your Score: {ScoreCalculationFocus.score}";
            menuHandler.completeLevel1Canvas.SetActive(true);
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
            ScoreCalculationFocus.score = 0;
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;
        }
        else if (ScoreCalculationFocus.score < 5 && ScoreCalculationFocus.isTimeOver) // retry lvl1
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }

    public void CheckLevel2()
    {
        if (ScoreCalculationFocus.score >= 5 && ScoreCalculationFocus.isTimeOver) // complete lvl2
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.scorelvl2Text.text = $"Your Score: {ScoreCalculationFocus.score}";
            menuHandler.completeLevel2Canvas.SetActive(true);
            ScoreCalculationFocus.isGameOver = true;
            ScoreCalculationFocus.score = 0;
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo / ScoreCalculationFocus.totalTrialsGo;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo / ScoreCalculationFocus.totalTrialsNoGo;
        }
        else if (ScoreCalculationFocus.score < 5 && ScoreCalculationFocus.isTimeOver) // retry lvl2
        {
            menuHandler.timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
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

        ScoreCalculationFocus.totalTrialsNoGo = 0;
        ScoreCalculationFocus.totalTrialsGo = 0;
        ScoreCalculationFocus.responseTimeGo = 0;
        ScoreCalculationFocus.responseTimeNoGo = 0;
        ScoreCalculationFocus.isStopWatchStart = false;
        ScoreCalculationFocus.isPaused = false;
        ScoreCalculationFocus.elapsedTimeStopWatch = 0;
    }
}
