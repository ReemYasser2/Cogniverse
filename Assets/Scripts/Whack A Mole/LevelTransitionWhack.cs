using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransitionWhack : MonoBehaviour
{
    public WhackMenuHandler WhackMenuHandler;


    public void CheckLevel1()
    {
<<<<<<< Updated upstream
        if (ScoreCalculationWhack.score >= 10 && ScoreCalculationWhack.isTimeOver) // pass lvl1
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.scorelvl1Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            WhackMenuHandler.completeLevel1Canvas.SetActive(true);
            WhackMenuHandler.level2Button.SetActive(true);
            WhackMenuHandler.level2LockButton.SetActive(false);
=======
        if (((ScoreCalculationWhack.score)/ScoreCalculationWhack.spawnsCounter) >= 0.7 && WhackTimer.isTimeOver) // pass lvl1
        {
            timerCanvas.SetActive(false);
            scorelvl1Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            ScoreCalculationWhack.scoreOnePercent = ScoreCalculationWhack.score / ScoreCalculationWhack.spawnsCounter;
            levelOneCompleteCanvas.SetActive(true);
            level2Button.SetActive(true);
            level2LockButton.SetActive(false);
>>>>>>> Stashed changes
            ScoreCalculationWhack.score = 0;

        }
<<<<<<< Updated upstream
        else if (ScoreCalculationWhack.score < 10 && ScoreCalculationWhack.isTimeOver) // retry lvl1
=======
        else if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) < 0.7 && WhackTimer.isTimeOver) // retry lvl1
>>>>>>> Stashed changes
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            ScoreCalculationWhack.score = 0;
        }
    }

    public void CheckLevel2()
    {
<<<<<<< Updated upstream
        if (ScoreCalculationWhack.score >= 10 && ScoreCalculationWhack.isTimeOver) // pass lvl2 
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.scorelvl2Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            WhackMenuHandler.completeLevel2Canvas.SetActive(true);
            ScoreCalculationWhack.isGameOver = true;
            ScoreCalculationWhack.score = 0;
        }
        else if (ScoreCalculationWhack.score < 10 && ScoreCalculationWhack.isTimeOver) // retry lvl3
=======
        if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) >= 0.7 && WhackTimer.isTimeOver) // pass lvl2 
        {
            timerCanvas.SetActive(false);
            scorelvl2Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            ScoreCalculationWhack.scoreTwoPercent = ScoreCalculationWhack.score / ScoreCalculationWhack.spawnsCounter;
            levelTwoCompleteCanvas.SetActive(true);
            Spawner.isGameOver = true;
            ScoreCalculationWhack.score = 0;
        }
        else if (((ScoreCalculationWhack.score) / ScoreCalculationWhack.spawnsCounter) < 0.7 && WhackTimer.isTimeOver) // retry lvl3
>>>>>>> Stashed changes
        {
            WhackMenuHandler.timerCanvas.SetActive(false);
            WhackMenuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            ScoreCalculationWhack.score = 0;
        }
    }

    public void HomeButton()
    {
        ScoreCalculationWhack.isHomeButtonClicked = true;

        ScoreCalculationWhack.score = 0;
        ScoreCalculationWhack.isTimeOver = true;
        ScoreCalculationWhack.isPlayPressed = false;

        ScoreCalculationWhack.isLevel1 = false;
        ScoreCalculationWhack.isLevel2 = false;
        ScoreCalculationWhack.isGameOver = true;
    }
}

