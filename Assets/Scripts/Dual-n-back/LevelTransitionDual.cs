using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransitionDual : MonoBehaviour
{
    public DualMenuHandler dualMenuHandler;

    public void CheckLevel1()
    {
        if (ScoreCalculator.score >= 5)
        {
            // pass lvl 1
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel1Canvas();
            ScoreCalculator.score = 0;
            dualMenuHandler.level2Button.SetActive(true);
            dualMenuHandler.level2LockButton.SetActive(false);
            ScoreCalculator.elapsedTime = 0f;
            ScoreCalculator.isPlayPressed = false;
        }
        else if (ScoreCalculator.score <= 5)
        {
            // retry lvl1
            ScoreCalculator.reinforcementText = "";
            ShowLevelOneInstructions();
            ScoreCalculator.score = 0;
            ScoreCalculator.elapsedTime = 0f;
            ScoreCalculator.isPlayPressed = false;
        }
    }

    public void CheckLevel2()
    {
        if (ScoreCalculator.score >= 10)
        {
            // pass lvl2
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel2Canvas();
            ScoreCalculator.score = 0;
            dualMenuHandler.level3Button.SetActive(true);
            dualMenuHandler.level3LockButton.SetActive(false);
            ScoreCalculator.elapsedTime = 0f;
            ScoreCalculator.isPlayPressed = false;
        }
        else if (ScoreCalculator.score <= 10)
        {
            // retry lvl 2
            ScoreCalculator.reinforcementText = "";
            ShowLevelTwoInstructions();
            ScoreCalculator.score = 0;
            ScoreCalculator.elapsedTime = 0f;
            ScoreCalculator.isPlayPressed = false;
        }
    }

    public void CheckLevel3()
    {
        if (ScoreCalculator.score >= 15)
        {
            // pass lvl3
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel3Canvas();
            ScoreCalculator.score = 0;
            ScoreCalculator.elapsedTime = 0f;
            ScoreCalculator.isPlayPressed = false;
            Debug.Log("game over test");
        }
        else if (ScoreCalculator.score <= 15)
        {
            // retry lvl3
            ScoreCalculator.reinforcementText = "";
            ShowLevelThreeInstructions();
            ScoreCalculator.score = 0;
            ScoreCalculator.elapsedTime = 0f;
            ScoreCalculator.isPlayPressed = false;;
        }
    }

    private void ShowLevelOneInstructions() { dualMenuHandler.instructionsLevel1RetryCanvas.SetActive(true); }
    private void ShowLevelTwoInstructions() { dualMenuHandler.instructionsLevel2RetryCanvas.SetActive(true); }
    private void ShowLevelThreeInstructions() { dualMenuHandler.instructionsLevel3RetryCanvas.SetActive(true); }

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

        ScoreCalculator.score = 0;
        ScoreCalculator.trialsCount = 0;
        ScoreCalculator.maxTrials = 5;
        ScoreCalculator.elapsedTime = 0f;
        ScoreCalculator.isPlayPressed = false;
    }
}
