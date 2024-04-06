using UnityEngine;

public class LevelsTransition : MonoBehaviour
{
    public MazeMenuHandler menuHandler;
    public MazeSpawner mazeSpawner;
    public CountDownTimer CountDownTimer;

    private void Update()
    {
        if (ScoreCalculatorMaze.isLevel1)
        {
            //CountDownTimer.OverallTime(1);
            //.Log("overall time: "+ ScoreCalculatorMaze.overallTime);
            checkLevelOne();
            ScoreCalculatorMaze.isLevel1 = false;
        }
        else if (ScoreCalculatorMaze.isLevel2)
        {
            //CountDownTimer.OverallTime(2);
            //Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
            CheckLevelTwo();
            ScoreCalculatorMaze.isLevel2 = false;
        }
    }
    public void checkLevelOne()
    {
       if (ScoreCalculatorMaze.score <= 2 && HapticFeedback.checkpointCounter >= 9 || CountDownTimer.isTimeOver)
        {     // pass lvl1
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;
            menuHandler.completeLevel1Canvas.SetActive(true);
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
        else if (ScoreCalculatorMaze.score > 2 || HapticFeedback.checkpointCounter <= 9  || CountDownTimer.isTimeOver) 
        {
            // retry lvl1
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
    }

    public void CheckLevelTwo()
    {
        if (ScoreCalculatorMaze.score <= 4 && HapticFeedback.checkpointCounter >= 9 || CountDownTimer.isTimeOver) 
        {
            // pass lvl2
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;
            menuHandler.completeLevel2Canvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
        else if (ScoreCalculatorMaze.score > 4 || HapticFeedback.checkpointCounter <= 9 || CountDownTimer.isTimeOver) 
        {
            // retry lvl2
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
    }

    public void level1()
    {
        ScoreCalculatorMaze.isLevel1 = true;
        ScoreCalculatorMaze.isLevel2 = false;
        ScoreCalculatorMaze.isGameOver = false;
        ScoreCalculatorMaze.score = 0;
        HapticFeedback.checkpointCounter = 0;


    }

    public void level2() 
    {
        ScoreCalculatorMaze.isLevel2 = true;
        ScoreCalculatorMaze.isLevel1 = false;
        ScoreCalculatorMaze.isGameOver = false;
        ScoreCalculatorMaze.score = 0;
        HapticFeedback.checkpointCounter = 0;
    }

    public void HomeButtonClicked()
    {
        mazeSpawner.mazePrefabs[mazeSpawner.mazeIndex].SetActive(false);
        mazeSpawner.maze1Canvas.SetActive(false);
        mazeSpawner.maze2Canvas.SetActive(false);
        mazeSpawner.timerCanvas.SetActive(false);
        
        ScoreCalculatorMaze.score = 0;
        ScoreCalculatorMaze.isLevel2 = false;
        ScoreCalculatorMaze.isLevel1 = false;
        ScoreCalculatorMaze.isGameOver = true;

        if (ScoreCalculatorMaze.isLevel2)
        {
            mazeSpawner.level2.ShowHideMushrooms(false);
        }
    }
}
