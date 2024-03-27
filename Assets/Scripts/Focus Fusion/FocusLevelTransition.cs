using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FocusLevelTransition : MonoBehaviour
{
    public GameObject levelOneInstructionsRetryCanvas;
    public GameObject levelTwoInstructionsRetryCanvas;

    public GameObject levelOneCompleteCanvas;
    public GameObject levelTwoCompleteCanvas;

    public GameObject timerCanvas;

    public static bool isHomeClicked;

    public GameObject level2Button;
    public GameObject level2LockButton;

    public TextMeshProUGUI scorelvl1Text;
    public TextMeshProUGUI scorelvl2Text;

    public void CheckLevel1()
    {
        if (ScoreCalculationFocus.score >= 5 && FocusTimer.isTimeOver) // complete lvl1
        {
            timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            scorelvl1Text.text = $"Your Score: {ScoreCalculationFocus.score}";
            levelOneCompleteCanvas.SetActive(true);
            level2Button.SetActive(true);
            level2LockButton.SetActive(false);
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationFocus.score < 5 && FocusTimer.isTimeOver) // retry lvl1
        {
            timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            levelOneInstructionsRetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }

    public void CheckLevel2()
    {
        if (ScoreCalculationFocus.score >= 5 && FocusTimer.isTimeOver) // complete lvl2
        {
            timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            scorelvl2Text.text = $"Your Score: {ScoreCalculationFocus.score}";
            levelTwoCompleteCanvas.SetActive(true);
            GridSpawner.isGameOver = true;
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationFocus.score < 5 && FocusTimer.isTimeOver) // retry lvl2
        {
            timerCanvas.SetActive(false);
            GridSpawner.ResetText();
            levelTwoInstructionsRetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }

    public void ToHome()
    {
        isHomeClicked = true;

        ScoreCalculationFocus.score = 0;
        FocusTimer.isPlayPressed = false;
        FocusTimer.isTimeOver = true;

        GridSpawner.isLevel1 = false;
        GridSpawner.isLevel2 = false;
        GridSpawner.isGameOver = true;
    }
}
