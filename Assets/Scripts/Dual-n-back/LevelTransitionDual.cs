using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransitionDual : MonoBehaviour
{
    public DualMenuHandler dualMenuHandler;
    public float levelsAccuracy = ScoreCalculator.accuracy;
    int correctClicks = ScoreCalculator.correctCounter;

    public DatabaseManager databaseManager;

    private void Start()
    {
        databaseManager.GetStatisticsData(DatabaseGamesVariables.userID);
        Unlocklevels();

    }
    public void CheckLevel1()
    {
        databaseManager.GetStatisticsData(DatabaseGamesVariables.userID);
        if ((ScoreCalculator.score)/28f >= 0.7f)
        {
            // pass lvl 1
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel1Canvas();

            dualMenuHandler.level2Button.SetActive(true);
            dualMenuHandler.level2LockButton.SetActive(false);

            // statistics
            TimerDual.OverallTime();
            ScoreCalculator.scoreOnePercent = ScoreCalculator.score / 30f;
            levelsAccuracy = ScoreCalculator.AccuracyCalculation(ScoreCalculator.correctCounter, 30);
            ScoreCalculator.responseTimeGo = ScoreCalculator.responseTimeGo / ScoreCalculator.countGoTrials;
            ScoreCalculator.responseTimeNoGo = ScoreCalculator.responseTimeNoGo / ScoreCalculator.countNoGoTrials;

            databaseManager.CreateDualData(DatabaseGamesVariables.userID, ScoreCalculator.date, ScoreCalculator.time,
                1, ScoreCalculator.scoreOnePercent, levelsAccuracy, ScoreCalculator.overallTime, 
                ScoreCalculator.responseTimeGo, ScoreCalculator.responseTimeNoGo);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "islvlOnePassed", true);

            float highestScore = CheckHighest(ScoreCalculator.scoreOnePercent, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(levelsAccuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculator.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculator.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);
           
            updateStat(highestScore, ScoreCalculator.scoreOnePercent, highestAccuracy, levelsAccuracy,
                highestGoRT, ScoreCalculator.responseTimeGo, highestNoGoRT, ScoreCalculator.responseTimeNoGo);

            ResetLevels();
            ScoreCalculator.isLevel1 = false;
        }
        else if ((ScoreCalculator.score) / 28f < 0.7f)
        {
            // retry lvl1
            ScoreCalculator.reinforcementText = "";
            ShowLevelOneInstructions();

            // statistics
            TimerDual.OverallTime();
            ScoreCalculator.scoreOnePercent = ScoreCalculator.score / 30f;
            levelsAccuracy = ScoreCalculator.AccuracyCalculation(ScoreCalculator.correctCounter, 30);
            ScoreCalculator.responseTimeGo = ScoreCalculator.responseTimeGo / ScoreCalculator.countGoTrials;
            ScoreCalculator.responseTimeNoGo = ScoreCalculator.responseTimeNoGo / ScoreCalculator.countNoGoTrials;

            databaseManager.CreateDualData(DatabaseGamesVariables.userID, ScoreCalculator.date, ScoreCalculator.time,
                1, ScoreCalculator.scoreOnePercent, levelsAccuracy, ScoreCalculator.overallTime,
                ScoreCalculator.responseTimeGo, ScoreCalculator.responseTimeNoGo);

            float highestScore = CheckHighest(ScoreCalculator.scoreOnePercent, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(levelsAccuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculator.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculator.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculator.scoreOnePercent, highestAccuracy, levelsAccuracy,
                highestGoRT, ScoreCalculator.responseTimeGo, highestNoGoRT, ScoreCalculator.responseTimeNoGo);

            ResetLevels();
            ScoreCalculator.isLevel1 = false;

        }
    }

    public void CheckLevel2()
    {
        if ((ScoreCalculator.score) / 42f >= 0.7f)
        {
            // pass lvl2
            ScoreCalculator.reinforcementText = "";

            ShowCompleteLevel2Canvas();
            dualMenuHandler.level3Button.SetActive(true);
            dualMenuHandler.level3LockButton.SetActive(false);

            // statistics
            TimerDual.OverallTime();
            ScoreCalculator.scoreTwoPercent = ScoreCalculator.score / 45f;
            levelsAccuracy = ScoreCalculator.AccuracyCalculation(ScoreCalculator.correctCounter, 45);
            ScoreCalculator.responseTimeGo = ScoreCalculator.responseTimeGo / ScoreCalculator.countGoTrials;
            ScoreCalculator.responseTimeNoGo = ScoreCalculator.responseTimeNoGo / ScoreCalculator.countNoGoTrials;

            databaseManager.CreateDualData(DatabaseGamesVariables.userID, ScoreCalculator.date, ScoreCalculator.time,
                2, ScoreCalculator.scoreTwoPercent, levelsAccuracy, ScoreCalculator.overallTime,
                ScoreCalculator.responseTimeGo, ScoreCalculator.responseTimeNoGo);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "islvlTwoPassed", true);

            float highestScore = CheckHighest(ScoreCalculator.scoreTwoPercent, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(levelsAccuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculator.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculator.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculator.scoreTwoPercent, highestAccuracy, levelsAccuracy,
                highestGoRT, ScoreCalculator.responseTimeGo, highestNoGoRT, ScoreCalculator.responseTimeNoGo);

            ResetLevels();
            ScoreCalculator.isLevel2 = false;
        }
        else if ((ScoreCalculator.score) / 42f < 0.7f)
        {
            // retry lvl 2
            ScoreCalculator.reinforcementText = "";

            ShowLevelTwoInstructions();

            // statistics
            TimerDual.OverallTime();
            ScoreCalculator.scoreTwoPercent = ScoreCalculator.score / 45f;
            levelsAccuracy = ScoreCalculator.AccuracyCalculation(ScoreCalculator.correctCounter, 45);
            ScoreCalculator.responseTimeGo = ScoreCalculator.responseTimeGo / ScoreCalculator.countGoTrials;
            ScoreCalculator.responseTimeNoGo = ScoreCalculator.responseTimeNoGo / ScoreCalculator.countNoGoTrials;

            databaseManager.CreateDualData(DatabaseGamesVariables.userID, ScoreCalculator.date, ScoreCalculator.time,
                2, ScoreCalculator.scoreTwoPercent, levelsAccuracy, ScoreCalculator.overallTime,
                ScoreCalculator.responseTimeGo, ScoreCalculator.responseTimeNoGo);

            float highestScore = CheckHighest(ScoreCalculator.scoreTwoPercent, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(levelsAccuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculator.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculator.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculator.scoreTwoPercent, highestAccuracy, levelsAccuracy,
                highestGoRT, ScoreCalculator.responseTimeGo, highestNoGoRT, ScoreCalculator.responseTimeNoGo);

            ResetLevels();
            ScoreCalculator.isLevel2 = false;

        }
    }

    public void CheckLevel3()
    {
        if ((ScoreCalculator.score) / 42f >= 0.7f)
        {
            // pass lvl3
            ScoreCalculator.reinforcementText = "";

            ShowCompleteLevel3Canvas();

            // statistics
            TimerDual.OverallTime();
            levelsAccuracy = ScoreCalculator.AccuracyCalculation(ScoreCalculator.correctCounter, 45);
            ScoreCalculator.scoreThreePercent = ScoreCalculator.score / 45f;
            ScoreCalculator.responseTimeGo = ScoreCalculator.responseTimeGo / ScoreCalculator.countGoTrials;
            ScoreCalculator.responseTimeNoGo = ScoreCalculator.responseTimeNoGo / ScoreCalculator.countNoGoTrials;

            databaseManager.CreateDualData(DatabaseGamesVariables.userID, ScoreCalculator.date, ScoreCalculator.time,
                3, ScoreCalculator.scoreThreePercent, levelsAccuracy, ScoreCalculator.overallTime,
                ScoreCalculator.responseTimeGo, ScoreCalculator.responseTimeNoGo);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "islvlThreePassed", true);

            float highestScore = CheckHighest(ScoreCalculator.scoreThreePercent, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(levelsAccuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculator.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculator.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculator.scoreThreePercent, highestAccuracy, levelsAccuracy,
                highestGoRT, ScoreCalculator.responseTimeGo, highestNoGoRT, ScoreCalculator.responseTimeNoGo);

            ResetLevels();
            ScoreCalculator.isLevel3 = false;

        }
        else if ((ScoreCalculator.score) / 42f < 0.7f)
        {
            // retry lvl3
            ScoreCalculator.reinforcementText = "";

            ShowLevelThreeInstructions();

            // statistics
            TimerDual.OverallTime();
            levelsAccuracy = ScoreCalculator.AccuracyCalculation(ScoreCalculator.correctCounter, 45);
            ScoreCalculator.scoreThreePercent = ScoreCalculator.score / 45f;
            ScoreCalculator.responseTimeGo = ScoreCalculator.responseTimeGo / ScoreCalculator.countGoTrials;
            ScoreCalculator.responseTimeNoGo = ScoreCalculator.responseTimeNoGo / ScoreCalculator.countNoGoTrials;

            databaseManager.CreateDualData(DatabaseGamesVariables.userID, ScoreCalculator.date, ScoreCalculator.time,
                3, ScoreCalculator.scoreThreePercent, levelsAccuracy, ScoreCalculator.overallTime,
                ScoreCalculator.responseTimeGo, ScoreCalculator.responseTimeNoGo);

            float highestScore = CheckHighest(ScoreCalculator.scoreThreePercent, DatabaseGamesVariables.highestScoreDual);
            float highestAccuracy = CheckHighest(levelsAccuracy, DatabaseGamesVariables.highestAccuracyDual);
            float highestGoRT = CheckLeast(ScoreCalculator.responseTimeGo, DatabaseGamesVariables.highestGoRTDual);
            float highestNoGoRT = CheckLeast(ScoreCalculator.responseTimeNoGo, DatabaseGamesVariables.highestNoRTDual);

            updateStat(highestScore, ScoreCalculator.scoreThreePercent, highestAccuracy, levelsAccuracy,
                highestGoRT, ScoreCalculator.responseTimeGo, highestNoGoRT, ScoreCalculator.responseTimeNoGo);

            ResetLevels();
            ScoreCalculator.isLevel3 = false;

        }
    }

    private void ShowLevelOneInstructions() 
    { 
        dualMenuHandler.instructionsLevel1RetryCanvas.SetActive(true);
        dualMenuHandler.scorelvl1retryText.text = $"Your Score: {ScoreCalculator.score}";
    }
    private void ShowLevelTwoInstructions() 
    { 
        dualMenuHandler.instructionsLevel2RetryCanvas.SetActive(true);
        dualMenuHandler.scorelvl2retryText.text = $"Your Score: {ScoreCalculator.score}";
    }
    private void ShowLevelThreeInstructions() 
    { 
        dualMenuHandler.instructionsLevel3RetryCanvas.SetActive(true);
        dualMenuHandler.scorelvl3retryText.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void ShowCompleteLevel1Canvas()
    {
        dualMenuHandler.completeLevel1Canvas.SetActive(true);
        dualMenuHandler.scorelvl1Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void ShowCompleteLevel2Canvas()
    {
        dualMenuHandler.completeLevel2Canvas.SetActive(true);
        dualMenuHandler.scorelvl2Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void ShowCompleteLevel3Canvas()
    {
        dualMenuHandler.completeLevel3Canvas.SetActive(true);
        dualMenuHandler.scorelvl3Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    public void HomeButtonClicked()
    {
        ScoreCalculator.isHomeClicked = true;
        ScoreCalculator.reinforcementText = "";

        ScoreCalculator.isLevel1 = false;
        ScoreCalculator.isLevel2 = false;
        ScoreCalculator.isLevel3 = false;
        ScoreCalculator.isGameOver = true;

        ScoreCalculator.correctCounter = 0;
        ScoreCalculator.accuracy = 0;
        ScoreCalculator.score = 0;
        ScoreCalculator.trialsCount = 0;
        ScoreCalculator.maxTrials = 15;
        ScoreCalculator.elapsedTime = 0f;
        ScoreCalculator.isPlayPressed = false;
        ScoreCalculator.scoreOnePercent = 0;
        ScoreCalculator.scoreTwoPercent = 0;
        ScoreCalculator.scoreThreePercent = 0;
        ScoreCalculator.accuracy = 0;
        levelsAccuracy = 0;
        ScoreCalculator.correctCounter = 0;
        ScoreCalculator.overallTime = 0f;
        ResetResponseTimeTimer();
    }

    private void ResetResponseTimeTimer()
    {
        ScoreCalculator.countGoTrials = 0;
        ScoreCalculator.countNoGoTrials = 0;
        ScoreCalculator.responseTimeGo = 0;
        ScoreCalculator.responseTimeNoGo = 0;
        ScoreCalculator.isStopWatchStart = false;
        ScoreCalculator.elapsedTimeStopWatch = 0;
    }

    public void ResetGame()
    {
        ScoreCalculator.isHomeClicked = true;
        ScoreCalculator.reinforcementText = "";

        ScoreCalculator.isLevel1 = false;
        ScoreCalculator.isLevel2 = false;
        ScoreCalculator.isLevel3 = false;
        ScoreCalculator.isGameOver = true;

        ScoreCalculator.correctCounter = 0;
        ScoreCalculator.accuracy = 0;
        ScoreCalculator.score = 0;
        ScoreCalculator.trialsCount = 0;
        ScoreCalculator.maxTrials = 15;
        ScoreCalculator.elapsedTime = 0f;
        ScoreCalculator.isPlayPressed = false;
        ScoreCalculator.scoreOnePercent = 0;
        ScoreCalculator.scoreTwoPercent = 0;
        ScoreCalculator.scoreThreePercent = 0;
        ScoreCalculator.accuracy = 0;
        levelsAccuracy = 0;
        ScoreCalculator.correctCounter = 0;
        ScoreCalculator.overallTime = 0f;
        ResetResponseTimeTimer();
    }

    private void ResetLevels()
    {
        ResetResponseTimeTimer();
        ScoreCalculator.score = 0;
        ScoreCalculator.elapsedTime = 0f;
        ScoreCalculator.isPlayPressed = false;
        ScoreCalculator.accuracy = 0;
        levelsAccuracy = 0;
        ScoreCalculator.correctCounter = 0;
        ScoreCalculator.scoreOnePercent = 0f;
        ScoreCalculator.scoreTwoPercent = 0;
        ScoreCalculator.scoreThreePercent = 0;
        ScoreCalculator.overallTime = 0f;
        ScoreCalculator.isGameOver = true;
    }

    public void Unlocklevels()
    {
        if (DatabaseGamesVariables.islvlOnePasseddual)
        {
            dualMenuHandler.level2Button.SetActive(true);
            dualMenuHandler.level2LockButton.SetActive(false);
        }
        else if (DatabaseGamesVariables.islvlTwoPasseddual)
        {
            dualMenuHandler.level3Button.SetActive(true);
            dualMenuHandler.level3LockButton.SetActive(false);
        }
    }

    public void updateStat(float hScore, float lScore, float hAccuray, float lAccuracy, 
        float hGoRT, float lGoRT, float hNoGoRT, float lNoGoRT)
    {
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "highestScore", hScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "lastScore", lScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "highestAccuracy", hAccuray);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "lastAccuracy", lAccuracy);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "highestGoRT", hGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "lastGoRT", lGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "highestNoRT", hNoGoRT);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.dualname, "lastNoRT", lNoGoRT);
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

    public void GetDateTime()
    {
        DateTime currentDateTime = DateTime.Now;
        ScoreCalculator.date = currentDateTime.ToString("dd/MM/yyyy");
        ScoreCalculator.time = currentDateTime.ToString("HH:mm");
        Debug.Log("Date: " + ScoreCalculator.date);
        Debug.Log("Time: " + ScoreCalculator.time);
    }

}
