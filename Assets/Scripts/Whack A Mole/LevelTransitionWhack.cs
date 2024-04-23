using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransitionWhack : MonoBehaviour
{
    public WhackMenuHandler WhackMenuHandler;
    public DatabaseManager databaseManager;

    private void Start()
    {
        databaseManager.GetStatisticsWhackData(DatabaseGamesVariables.userID);
        Unlocklevels();

    }

    public void CheckLevel1()
    {
        databaseManager.GetStatisticsWhackData(DatabaseGamesVariables.userID);
        if (((ScoreCalculationWhack.score)/ScoreCalculationWhack.spawnsCounter) >= 0.7 && ScoreCalculationWhack.isTimeOver) // pass lvl1
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.completeLevel1Canvas.SetActive(true);
            WhackMenuHandler.level2Button.SetActive(true);
            WhackMenuHandler.level2LockButton.SetActive(false);
            WhackMenuHandler.scorelvl1Text.text = $"Your Score: {ScoreCalculationWhack.score}";

            // statistics
            WhackTimer.OverallTime();
            ScoreCalculationWhack.scoreOnePercent = ScoreCalculationWhack.score / ScoreCalculationWhack.spawnsCounter;
            ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo / ScoreCalculationWhack.spawnsCounter;
            ScoreCalculationWhack.accuracy = ScoreCalculationWhack.AccuracyCalculation(ScoreCalculationWhack.correctCounter, ScoreCalculationWhack.spawnsCounter);

            databaseManager.CreateWhackData(DatabaseGamesVariables.userID, ScoreCalculationWhack.date, ScoreCalculationWhack.time,
                1, ScoreCalculationWhack.scoreOnePercent, ScoreCalculationWhack.accuracy, ScoreCalculationWhack.overallTime,
                ScoreCalculationWhack.responseTimeGo, 0);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "islvlOnePassed", true);

            float highestScore = CheckHighest(ScoreCalculationWhack.scoreOnePercent, DatabaseGamesVariables.highestScoreWhack);
            float highestAccuracy = CheckHighest(ScoreCalculationWhack.accuracy, DatabaseGamesVariables.highestAccuracyWhack);
            float highestGoRT = CheckLeast(ScoreCalculationWhack.responseTimeGo, DatabaseGamesVariables.highestGoRTWhack);

            updateStat(highestScore, ScoreCalculationWhack.scoreOnePercent, highestAccuracy, ScoreCalculationWhack.accuracy,
                highestGoRT, ScoreCalculationWhack.responseTimeGo, 0, 0);

            ScoreCalculationWhack.isLevel1 = false;

            ResetResponseTimeTimer();
            ScoreCalculationWhack.score = 0;
            ScoreCalculationWhack.accuracy = 0;
            ScoreCalculationWhack.scoreOnePercent = 0;
            ScoreCalculationWhack.correctCounter = 0;
            ScoreCalculationWhack.isGameOver = true;

        }
        else if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) < 0.7 && ScoreCalculationWhack.isTimeOver) // retry lvl1
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            WhackMenuHandler.scorelvl1retryText.text = $"Your Score: {ScoreCalculationWhack.score}";

            // statistics
            WhackTimer.OverallTime();
            ScoreCalculationWhack.scoreOnePercent = ScoreCalculationWhack.score / ScoreCalculationWhack.spawnsCounter;
            ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo / ScoreCalculationWhack.spawnsCounter;
            ScoreCalculationWhack.accuracy = ScoreCalculationWhack.AccuracyCalculation(ScoreCalculationWhack.correctCounter, ScoreCalculationWhack.spawnsCounter);

            databaseManager.CreateWhackData(DatabaseGamesVariables.userID, ScoreCalculationWhack.date, ScoreCalculationWhack.time,
                1, ScoreCalculationWhack.scoreOnePercent, ScoreCalculationWhack.accuracy, ScoreCalculationWhack.overallTime,
                ScoreCalculationWhack.responseTimeGo, 0);

            float highestScore = CheckHighest(ScoreCalculationWhack.scoreOnePercent, DatabaseGamesVariables.highestScoreWhack);
            float highestAccuracy = CheckHighest(ScoreCalculationWhack.accuracy, DatabaseGamesVariables.highestAccuracyWhack);
            float highestGoRT = CheckLeast(ScoreCalculationWhack.responseTimeGo, DatabaseGamesVariables.highestGoRTWhack);

            updateStat(highestScore, ScoreCalculationWhack.scoreOnePercent, highestAccuracy, ScoreCalculationWhack.accuracy,
                highestGoRT, ScoreCalculationWhack.responseTimeGo, 0, 0);

            ScoreCalculationWhack.isLevel1 = false;

            ResetResponseTimeTimer();
            ScoreCalculationWhack.score = 0;
            ScoreCalculationWhack.accuracy = 0;
            ScoreCalculationWhack.scoreOnePercent = 0;
            ScoreCalculationWhack.correctCounter = 0;
            ScoreCalculationWhack.isGameOver = true;
        }
        databaseManager.GetStatisticsWhackData(DatabaseGamesVariables.userID);
    }

    public void CheckLevel2()
    {
        databaseManager.GetStatisticsWhackData(DatabaseGamesVariables.userID);
        if (((ScoreCalculationWhack.score) /( ScoreCalculationWhack.spawnsCounter/2)) >= 0.7 && ScoreCalculationWhack.isTimeOver) // pass lvl2 
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.scorelvl2Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            WhackMenuHandler.completeLevel2Canvas.SetActive(true);

            // statistics
            WhackTimer.OverallTime();
            ScoreCalculationWhack.scoreTwoPercent = ScoreCalculationWhack.score / (ScoreCalculationWhack.spawnsCounter / 2);
            ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo / ScoreCalculationWhack.spawnerGoCounter;
            ScoreCalculationWhack.responseTimeNoGo = ScoreCalculationWhack.responseTimeNoGo / ScoreCalculationWhack.spawnerNoGoCounter;
            ScoreCalculationWhack.accuracy = ScoreCalculationWhack.AccuracyCalculation(ScoreCalculationWhack.correctCounter, ScoreCalculationWhack.spawnsCounter/2);

            databaseManager.CreateWhackData(DatabaseGamesVariables.userID, ScoreCalculationWhack.date, ScoreCalculationWhack.time,
                2, ScoreCalculationWhack.scoreTwoPercent, ScoreCalculationWhack.accuracy, ScoreCalculationWhack.overallTime,
                ScoreCalculationWhack.responseTimeGo, ScoreCalculationWhack.responseTimeNoGo);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "islvlTwoPassed", true);

            float highestScore = CheckHighest(ScoreCalculationWhack.scoreTwoPercent, DatabaseGamesVariables.highestScoreWhack);
            float highestAccuracy = CheckHighest(ScoreCalculationWhack.accuracy, DatabaseGamesVariables.highestAccuracyWhack);
            float highestGoRT = CheckLeast(ScoreCalculationWhack.responseTimeGo, DatabaseGamesVariables.highestGoRTWhack);
            float highestNoGoRT = CheckLeast(ScoreCalculationWhack.responseTimeNoGo, DatabaseGamesVariables.highestNoRTWhack);

            updateStat(highestScore, ScoreCalculationWhack.scoreTwoPercent, highestAccuracy, ScoreCalculationWhack.accuracy,
                highestGoRT, ScoreCalculationWhack.responseTimeGo, highestNoGoRT, ScoreCalculationWhack.responseTimeNoGo);

            ScoreCalculationWhack.isLevel2 = false;

            ResetResponseTimeTimer();
            ScoreCalculationWhack.isGameOver = true;
            ScoreCalculationWhack.score = 0;
            ScoreCalculationWhack.accuracy = 0;
            ScoreCalculationWhack.scoreTwoPercent = 0;
            ScoreCalculationWhack.correctCounter = 0;

        }
        else if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) < 0.7 && ScoreCalculationWhack.isTimeOver) // retry lvl3
        {
            Debug.Log("score lvl2: " + ScoreCalculationWhack.score);
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            WhackMenuHandler.scorelvl2retryText.text = $"Your Score: {ScoreCalculationWhack.score}";

            // statistics
            WhackTimer.OverallTime();
            ScoreCalculationWhack.scoreTwoPercent = ScoreCalculationWhack.score / ScoreCalculationWhack.spawnsCounter;
            ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo / ScoreCalculationWhack.spawnerGoCounter;
            ScoreCalculationWhack.responseTimeNoGo = ScoreCalculationWhack.responseTimeNoGo / ScoreCalculationWhack.spawnerNoGoCounter;
            ScoreCalculationWhack.accuracy = ScoreCalculationWhack.AccuracyCalculation(ScoreCalculationWhack.correctCounter, ScoreCalculationWhack.spawnsCounter);

            databaseManager.CreateWhackData(DatabaseGamesVariables.userID, ScoreCalculationWhack.date, ScoreCalculationWhack.time,
                2, ScoreCalculationWhack.scoreTwoPercent, ScoreCalculationWhack.accuracy, ScoreCalculationWhack.overallTime,
                ScoreCalculationWhack.responseTimeGo, ScoreCalculationWhack.responseTimeNoGo);

            float highestScore = CheckHighest(ScoreCalculationWhack.scoreTwoPercent, DatabaseGamesVariables.highestScoreWhack);
            float highestAccuracy = CheckHighest(ScoreCalculationWhack.accuracy, DatabaseGamesVariables.highestAccuracyWhack);
            float highestGoRT = CheckLeast(ScoreCalculationWhack.responseTimeGo, DatabaseGamesVariables.highestGoRTWhack);
            float highestNoGoRT = CheckLeast(ScoreCalculationWhack.responseTimeNoGo, DatabaseGamesVariables.highestNoRTWhack);

            updateStat(highestScore, ScoreCalculationWhack.scoreTwoPercent, highestAccuracy, ScoreCalculationWhack.accuracy,
                highestGoRT, ScoreCalculationWhack.responseTimeGo, highestNoGoRT, ScoreCalculationWhack.responseTimeNoGo);

            ScoreCalculationWhack.isLevel2 = false;

            ResetResponseTimeTimer();
            ScoreCalculationWhack.isGameOver = true;
            ScoreCalculationWhack.score = 0;
            ScoreCalculationWhack.accuracy = 0;
            ScoreCalculationWhack.scoreTwoPercent = 0;
            ScoreCalculationWhack.correctCounter = 0;
        }
        databaseManager.GetStatisticsWhackData(DatabaseGamesVariables.userID);
    }

    public void HomeButton()
    {
        ScoreCalculationWhack.reinforcementText = "";
        ScoreCalculationWhack.isHomeButtonClicked = true;

        ScoreCalculationWhack.score = 0;
        ScoreCalculationWhack.accuracy = 0;
        ScoreCalculationWhack.correctCounter = 0;
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
        ScoreCalculationWhack.scoreTwoPercent = 0;
        ScoreCalculationWhack.scoreOnePercent = 0;
        ScoreCalculationWhack.overallTime = 0;
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

    public void Unlocklevels()
    {
        if (DatabaseGamesVariables.islvlOnePassedWhack)
        {
            WhackMenuHandler.level2Button.SetActive(true);
            WhackMenuHandler.level2LockButton.SetActive(false);
        }
        else { return; }
    }

    public void updateStat(float hScore, float lScore, float hAccuray, float lAccuracy,
        float hGoRT, float lGoRT, float hNoGoRT, float lNoGoRT)
    {
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "highestScore", hScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "lastScore", lScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "highestAccuracy", hAccuray);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "lastAccuracy", lAccuracy);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "highestGoRT", hGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "lastGoRT", lGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "highestNoRT", hNoGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.whackname, "lastNoRT", lNoGoRT);
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
        if (current <= last && current > 0)
        {
            return current;
        }
        else if (current > last)
        {
            return last;
        }
        else { return 0; }
    }

    public void GetDateTime()
    {
        DateTime currentDateTime = DateTime.Now;
        ScoreCalculationWhack.date = currentDateTime.ToString("dd/MM/yyyy");
        ScoreCalculationWhack.time = currentDateTime.ToString("HH:mm");
    }
}

