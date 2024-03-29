using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTransitionWhack : MonoBehaviour
{
    public GameObject levelOneInstructionsRetryCanvas;
    public GameObject levelTwoInstructionsRetryCanvas;

    public GameObject levelOneCompleteCanvas;
    public GameObject levelTwoCompleteCanvas;

    public GameObject timerCanvas;

    public static bool isHomeButtonClicked;

    public TextMeshProUGUI scorelvl1Text;
    public TextMeshProUGUI scorelvl2Text;

    public GameObject level2Button;
    public GameObject level2LockButton;

    public void CheckLevel1()
    {
        if (ScoreCalculationWhack.score >= 10 && WhackTimer.isTimeOver) // pass lvl1
        {
            timerCanvas.SetActive(false);
            scorelvl1Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            levelOneCompleteCanvas.SetActive(true);
            level2Button.SetActive(true);
            level2LockButton.SetActive(false);
            ScoreCalculationWhack.score = 0;
        }
        else if (ScoreCalculationWhack.score < 10 && WhackTimer.isTimeOver) // retry lvl1
        {
            timerCanvas.SetActive(false);
            levelOneInstructionsRetryCanvas.SetActive(true);
            ScoreCalculationWhack.score = 0;
        }
    }

    public void CheckLevel2()
    {
        if (ScoreCalculationWhack.score >= 10 && WhackTimer.isTimeOver) // pass lvl2 
        {
            timerCanvas.SetActive(false);
            scorelvl2Text.text = $"Your Score: {ScoreCalculationWhack.score}";
            levelTwoCompleteCanvas.SetActive(true);
            Spawner.isGameOver = true;
            ScoreCalculationWhack.score = 0;
        }
        else if (ScoreCalculationWhack.score < 10 && WhackTimer.isTimeOver) // retry lvl3
        {
            timerCanvas.SetActive(false);
            levelTwoInstructionsRetryCanvas.SetActive(true);
            ScoreCalculationWhack.score = 0;
        }
    }

    public void HomeButton()
    {
        isHomeButtonClicked = true;

        ScoreCalculationWhack.score = 0;
        WhackTimer.isTimeOver = true;
        WhackTimer.isPlayPressed = false;

        Spawner.isLevel1 = false;
        Spawner.isLevel2 = false;
        Spawner.isGameOver = true;
    }
}

