using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransitionDual : MonoBehaviour
{
    public GameObject instructionsLvl1RetryCanvas;
    public GameObject instructionsLvl2RetryCanvas;
    public GameObject instructionsLvl3RetryCanvas;
    public GameObject completeLevel1Canvas;
    public GameObject completeLevel2Canvas;
    public GameObject completeLevel3Canvas;

    public TextMeshProUGUI scorelvl1Text;
    public TextMeshProUGUI scorelvl2Text;
    public TextMeshProUGUI scorelvl3Text;

    public GameObject level2Button;
    public GameObject level2LockButton;
    public GameObject level3Button;
    public GameObject level3LockButton;

    public void CheckLevel1()
    {
        if (ScoreCalculator.score >= 5)
        {
            // pass lvl 1
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel1Canvas();
            ScoreCalculator.score = 0;
            level2Button.SetActive(true);
            level2LockButton.SetActive(false);
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
            level3Button.SetActive(true);
            level3LockButton.SetActive(false);
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

    private void ShowLevelOneInstructions() { instructionsLvl1RetryCanvas.SetActive(true); }
    private void ShowLevelTwoInstructions() { instructionsLvl2RetryCanvas.SetActive(true); }
    private void ShowLevelThreeInstructions() { instructionsLvl3RetryCanvas.SetActive(true); }

    private void ShowCompleteLevel1Canvas()
    {
        completeLevel1Canvas.SetActive(true);
        scorelvl1Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void ShowCompleteLevel2Canvas()
    {
        completeLevel2Canvas.SetActive(true);
        scorelvl2Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void ShowCompleteLevel3Canvas()
    {
        completeLevel3Canvas.SetActive(true);
        scorelvl3Text.text = $"Your Score: {ScoreCalculator.score}";
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
