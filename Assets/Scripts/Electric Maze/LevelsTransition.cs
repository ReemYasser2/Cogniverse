using UnityEngine;
using UnityEngine.Rendering;

public class LevelsTransition : MonoBehaviour
{
    public MazeMenuHandler menuHandler;
    public MazeSpawner mazeSpawner;
    public CountDownTimer CountDownTimer;
    public HapticFeedback hapticFeedback;


    public void checkLevelOne()
    {
       if (ScoreCalculatorMaze.score <= 2 && HapticFeedback.checkpointCounter >= 9)// || CountDownTimer.isTimeOver)
        {     // pass lvl1
            menuHandler.completeLevel1Canvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);

            // statistics
            CountDownTimer.OverallTime(1);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            Debug.Log("MAZE: overall time: " + ScoreCalculatorMaze.overallTime);
            Debug.Log("MAZE: # of hits: " + ScoreCalculatorMaze.numberOfHits);

            ResetLevels();
            ScoreCalculatorMaze.isLevel1 = false;
           
        }
        else if (ScoreCalculatorMaze.score >= 2 || HapticFeedback.checkpointCounter < 9)//  || CountDownTimer.isTimeOver) 
        {
            // retry lvl1
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            // statistics
            CountDownTimer.OverallTime(1);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            Debug.Log("MAZE: overall time: " + ScoreCalculatorMaze.overallTime);
            Debug.Log("MAZE: # of hits: " + ScoreCalculatorMaze.numberOfHits);

            ResetLevels();
            ScoreCalculatorMaze.isLevel1 = false;
           
        }
    }

    public void CheckLevelTwo()
    {
        if (ScoreCalculatorMaze.score <= 4 && HapticFeedback.checkpointCounter >= 9)// || CountDownTimer.isTimeOver) 
        {
            // pass lvl2
            menuHandler.completeLevel2Canvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            // statistics
            CountDownTimer.OverallTime(2);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            Debug.Log("MAZE: overall time: " + ScoreCalculatorMaze.overallTime);
            Debug.Log("MAZE: # of hits: " + ScoreCalculatorMaze.numberOfHits);

            ResetLevels();
            ScoreCalculatorMaze.isLevel2 = false;
           
        }
        else if (ScoreCalculatorMaze.score >= 4 || HapticFeedback.checkpointCounter < 9)// || CountDownTimer.isTimeOver) 
        {
            // retry lvl2
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            mazeSpawner.ShowHideMaze(false);

            // statistics
            CountDownTimer.OverallTime(2);
            ScoreCalculatorMaze.numberOfHits = ScoreCalculatorMaze.score;

            Debug.Log("MAZE: overall time: " + ScoreCalculatorMaze.overallTime);
            Debug.Log("MAZE: # of hits: " + ScoreCalculatorMaze.numberOfHits);

            ResetLevels();
            ScoreCalculatorMaze.isLevel2 = false;
        }
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
}
