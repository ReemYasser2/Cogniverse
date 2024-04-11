using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FocusLevelTransition : MonoBehaviour
{
    public FocusMenuHandler menuHandler;
    public DatabaseManager databaseManager;

    private void Start()
    {
        databaseManager.GetStatisticsFFData(DatabaseGamesVariables.userID);
        Unlocklvl();
    }

    public void CheckLevel1()
    {
        databaseManager.GetStatisticsFFData(DatabaseGamesVariables.userID);
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

            databaseManager.CreateFocusData(DatabaseGamesVariables.userID, ScoreCalculationFocus.date, ScoreCalculationFocus.time,
                1, ScoreCalculationFocus.scorePercentOne, ScoreCalculationFocus.accuracy, ScoreCalculationFocus.overallTime,
                ScoreCalculationFocus.responseTimeGo, ScoreCalculationFocus.responseTimeNoGo);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "islvlOnePassed", true);

            float highestScore = CheckHighest(ScoreCalculationFocus.scorePercentOne, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(ScoreCalculationFocus.accuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculationFocus.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculationFocus.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculationFocus.scorePercentOne, highestAccuracy, ScoreCalculationFocus.accuracy,
                highestGoRT, ScoreCalculationFocus.responseTimeGo, highestNoGoRT, ScoreCalculationFocus.responseTimeNoGo);

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

            databaseManager.CreateFocusData(DatabaseGamesVariables.userID, ScoreCalculationFocus.date, ScoreCalculationFocus.time,
                1, ScoreCalculationFocus.scorePercentOne, ScoreCalculationFocus.accuracy, ScoreCalculationFocus.overallTime,
                ScoreCalculationFocus.responseTimeGo, ScoreCalculationFocus.responseTimeNoGo);

            float highestScore = CheckHighest(ScoreCalculationFocus.scorePercentOne, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(ScoreCalculationFocus.accuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculationFocus.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculationFocus.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculationFocus.scorePercentOne, highestAccuracy, ScoreCalculationFocus.accuracy,
                highestGoRT, ScoreCalculationFocus.responseTimeGo, highestNoGoRT, ScoreCalculationFocus.responseTimeNoGo);

            ResetLevels();
            ScoreCalculationFocus.isLevel1 = false;
        }
        databaseManager.GetStatisticsFFData(DatabaseGamesVariables.userID);
    }

    public void CheckLevel2()
    {
        databaseManager.GetStatisticsFFData(DatabaseGamesVariables.userID);
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

            databaseManager.CreateFocusData(DatabaseGamesVariables.userID, ScoreCalculationFocus.date, ScoreCalculationFocus.time,
                2, ScoreCalculationFocus.scorePercentTwo, ScoreCalculationFocus.accuracy, ScoreCalculationFocus.overallTime,
                ScoreCalculationFocus.responseTimeGo, ScoreCalculationFocus.responseTimeNoGo);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "islvlTwoPassed", true);

            float highestScore = CheckHighest(ScoreCalculationFocus.scorePercentTwo, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(ScoreCalculationFocus.accuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculationFocus.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculationFocus.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculationFocus.scorePercentTwo, highestAccuracy, ScoreCalculationFocus.accuracy,
                highestGoRT, ScoreCalculationFocus.responseTimeGo, highestNoGoRT, ScoreCalculationFocus.responseTimeNoGo);

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

            databaseManager.CreateFocusData(DatabaseGamesVariables.userID, ScoreCalculationFocus.date, ScoreCalculationFocus.time,
                2, ScoreCalculationFocus.scorePercentTwo, ScoreCalculationFocus.accuracy, ScoreCalculationFocus.overallTime,
                ScoreCalculationFocus.responseTimeGo, ScoreCalculationFocus.responseTimeNoGo);

            float highestScore = CheckHighest(ScoreCalculationFocus.scorePercentTwo, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(ScoreCalculationFocus.accuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculationFocus.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculationFocus.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculationFocus.scorePercentTwo, highestAccuracy, ScoreCalculationFocus.accuracy,
                highestGoRT, ScoreCalculationFocus.responseTimeGo, highestNoGoRT, ScoreCalculationFocus.responseTimeNoGo);

            ResetLevels();
            ScoreCalculationFocus.isLevel2 = false;
        }
        databaseManager.GetStatisticsFFData(DatabaseGamesVariables.userID);
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
    public void updateStat(float hScore, float lScore, float hAccuray, float lAccuracy,
        float hGoRT, float lGoRT, float hNoGoRT, float lNoGoRT)
    {
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "highestScore", hScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "lastScore", lScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "highestAccuracy", hAccuray);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "lastAccuracy", lAccuracy);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "highestGoRT", hGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "lastGoRT", lGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "highestNoRT", hNoGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.focusname, "lastNoRT", lNoGoRT);
    }

    public float CheckHighest(float current, float last)
    {
        if (current >= last)
        {
            return current;
        }
        else if (current < last)
        {
            return last;
        }
        else { return 0; }
    }

    public float CheckLeast(float current, float last)
    {
        if (current <= last)
        {
            return current;
        }
        else if (current > last)
        {
            return last;
        }
        else { return 0; }
    }

    private void Unlocklvl()
    {
        if (DatabaseGamesVariables.islvlOnePassedFF)
        {
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
        }
        else { return; }
    }

    public void GetDateTime()
    {
        DateTime currentDateTime = DateTime.Now;
        ScoreCalculationFocus.date = currentDateTime.ToString("dd/MM/yyyy");
        ScoreCalculationFocus.time = currentDateTime.ToString("HH:mm");
    }
}
