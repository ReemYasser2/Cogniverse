using UnityEngine;

public class LevelsTransition : MonoBehaviour
{
    public MazeMenuHandler menuHandler;
    public MazeSpawner mazeSpawner;
    public CountDownTimer CountDownTimer;


    public void checkLevelOne()
    {
       if (ScoreCalculatorMaze.score <= 2 && HapticFeedback.checkpointCounter >= 9)// || CountDownTimer.isTimeOver)
        {     // pass lvl1
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;
            menuHandler.completeLevel1Canvas.SetActive(true);
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
        else if (ScoreCalculatorMaze.score >= 2 || HapticFeedback.checkpointCounter < 9)//  || CountDownTimer.isTimeOver) 
        {
            // retry lvl1
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
    }

    public void CheckLevelTwo()
    {
        if (ScoreCalculatorMaze.score <= 4 && HapticFeedback.checkpointCounter >= 9)// || CountDownTimer.isTimeOver) 
        {
            // pass lvl2
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;
            menuHandler.completeLevel2Canvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
        else if (ScoreCalculatorMaze.score >= 4 || HapticFeedback.checkpointCounter < 9)// || CountDownTimer.isTimeOver) 
        {
            // retry lvl2
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
    }
    
    public void checkLevelOneWithoutTimer()
    {
       if (ScoreCalculatorMaze.score <= 2 && HapticFeedback.checkpointCounter >= 9)
        {     // pass lvl1
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;
            menuHandler.completeLevel1Canvas.SetActive(true);
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
        else if (ScoreCalculatorMaze.score >= 2 || HapticFeedback.checkpointCounter < 9) 
        {
    
            // retry lvl1
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
    }

    public void CheckLevelTwoWithoutTimer()
    {
        if (ScoreCalculatorMaze.score <= 4 && HapticFeedback.checkpointCounter >= 9) 
        {
            // pass lvl2
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;
            menuHandler.completeLevel2Canvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);
            ScoreCalculatorMaze.isGameOver = true;
        }
        else if (ScoreCalculatorMaze.score >= 4 || HapticFeedback.checkpointCounter <9) 
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
