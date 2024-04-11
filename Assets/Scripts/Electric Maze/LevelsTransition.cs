using System;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelsTransition : MonoBehaviour
{
    public MazeMenuHandler menuHandler;
    public MazeSpawner mazeSpawner;
    public CountDownTimer CountDownTimer;
    public HapticFeedback hapticFeedback;
    public DatabaseManager databaseManager; 

    private void Start()
    {
        databaseManager.GetStatisticsMazeData(DatabaseGamesVariables.userID);
        Unlocklevels();

    }

    public void checkLevelOne()
    {
        databaseManager.GetStatisticsMazeData(DatabaseGamesVariables.userID);
        if (ScoreCalculatorMaze.score <= 2 && HapticFeedback.checkpointCounter >= 9)// || CountDownTimer.isTimeOver)
        {     // pass lvl1
            menuHandler.completeLevel1Canvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);

            // statistics
            CountDownTimer.OverallTime(1);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            databaseManager.CreateMazeData(DatabaseGamesVariables.userID, ScoreCalculatorMaze.date, ScoreCalculatorMaze.time,
                1, ScoreCalculatorMaze.overallTime, ScoreCalculatorMaze.numberOfHits);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.mazename, "islvlOnePassed", true);

            ResetLevels();
            ScoreCalculatorMaze.isLevel1 = false;
           
        }
        else if (ScoreCalculatorMaze.score >= 2 || HapticFeedback.checkpointCounter < 8)//  || CountDownTimer.isTimeOver) 
        {
            // retry lvl1
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            // statistics
            CountDownTimer.OverallTime(1);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            databaseManager.CreateMazeData(DatabaseGamesVariables.userID, ScoreCalculatorMaze.date, ScoreCalculatorMaze.time,
                1, ScoreCalculatorMaze.overallTime, ScoreCalculatorMaze.numberOfHits);

            ResetLevels();
            ScoreCalculatorMaze.isLevel1 = false;
           
        }
        databaseManager.GetStatisticsMazeData(DatabaseGamesVariables.userID);
    }

    public void CheckLevelTwo()
    {
        databaseManager.GetStatisticsMazeData(DatabaseGamesVariables.userID);
        if (ScoreCalculatorMaze.score <= 4 && HapticFeedback.checkpointCounter >= 9)// || CountDownTimer.isTimeOver) 
        {
            // pass lvl2
            menuHandler.completeLevel2Canvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            // statistics
            CountDownTimer.OverallTime(2);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            databaseManager.CreateMazeData(DatabaseGamesVariables.userID, ScoreCalculatorMaze.date, ScoreCalculatorMaze.time,
                2, ScoreCalculatorMaze.overallTime, ScoreCalculatorMaze.numberOfHits);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.mazename, "islvlTwoPassed", true);

            ResetLevels();
            ScoreCalculatorMaze.isLevel2 = false;
           
        }
        else if (ScoreCalculatorMaze.score >= 4 || HapticFeedback.checkpointCounter < 8)// || CountDownTimer.isTimeOver) 
        {
            // retry lvl2
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            // statistics
            CountDownTimer.OverallTime(2);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            databaseManager.CreateMazeData(DatabaseGamesVariables.userID, ScoreCalculatorMaze.date, ScoreCalculatorMaze.time,
                2, ScoreCalculatorMaze.overallTime, ScoreCalculatorMaze.numberOfHits);

            ResetLevels();
            ScoreCalculatorMaze.isLevel2 = false;
        }
        databaseManager.GetStatisticsMazeData(DatabaseGamesVariables.userID);
    }

    public void level1()
    {
        ScoreCalculatorMaze.isLevel1 = true;
        ScoreCalculatorMaze.isLevel2 = false;
        ScoreCalculatorMaze.isGameOver = false;
        ScoreCalculatorMaze.score = 0;
        HapticFeedback.checkpointCounter = 0;
        ScoreCalculatorMaze.numberOfHits = 0;
        ScoreCalculatorMaze.overallTime = 0;

        hapticFeedback.livesCount.text = string.Format("{0}", 2);

    }

    public void level2() 
    {
        ScoreCalculatorMaze.isLevel2 = true;
        ScoreCalculatorMaze.isLevel1 = false;
        ScoreCalculatorMaze.isGameOver = false;
        ScoreCalculatorMaze.score = 0;
        HapticFeedback.checkpointCounter = 0;
        ScoreCalculatorMaze.numberOfHits = 0;
        ScoreCalculatorMaze.overallTime = 0;
        hapticFeedback.livesCount.text = string.Format("{0}", 4);
    }

    public void HomeButtonClicked()
    {
        ScoreCalculatorMaze.reinforcementText = "";
        mazeSpawner.mazePrefabs[mazeSpawner.mazeIndex].SetActive(false);
        mazeSpawner.maze1Canvas.SetActive(false);
        mazeSpawner.maze2Canvas.SetActive(false);
        mazeSpawner.timerCanvas.SetActive(false);
        
        ScoreCalculatorMaze.score = 0;
        HapticFeedback.checkpointCounter = 0;
        ScoreCalculatorMaze.numberOfHits = 0;
        ScoreCalculatorMaze.overallTime = 0;
        ScoreCalculatorMaze.isLevel2 = false;
        ScoreCalculatorMaze.isLevel1 = false;
        ScoreCalculatorMaze.isGameOver = true;

        if (ScoreCalculatorMaze.isLevel2)
        {
            mazeSpawner.level2.ShowHideMushrooms(false);
        }
    }

    private void ResetLevels()
    {
        ScoreCalculatorMaze.isGameOver = true;
        CountDownTimer.isTimeOver = true;
        ScoreCalculatorMaze.numberOfHits = 0;
        ScoreCalculatorMaze.overallTime = 0;
    }
    public void GetDateTime()
    {
        DateTime currentDateTime = DateTime.Now;
        ScoreCalculatorMaze.date = currentDateTime.ToString("dd/MM/yyyy");
        ScoreCalculatorMaze.time = currentDateTime.ToString("HH:mm");
    }

    public void Unlocklevels()
    {
        if (DatabaseGamesVariables.islvlOnePassedMaze)
        {
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
        }
        else { return; }
    }
}
