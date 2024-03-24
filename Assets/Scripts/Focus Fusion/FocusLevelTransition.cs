using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusLevelTransition : MonoBehaviour
{
    public GameObject levelOneInstructionsRetryCanvas;
    public GameObject levelTwoInstructionsRetryCanvas;

    public GameObject levelOneCompleteCanvas;
    public GameObject levelTwoCompleteCanvas;

    public GameObject timerCanvas;

    // Update is called once per frame
    void Update()
    {
        if (GridSpawner.isLevel1)
        {
            CheckLevel1();
        }
        else if (GridSpawner.isLevel2)
        {
            CheckLevel2();
        }
    }

    private void CheckLevel1()
    {
        if (ScoreCalculationFocus.score >= 5 && FocusTimer.isTimeOver) // complete lvl1
        {
            timerCanvas.SetActive(false);
            levelOneCompleteCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationFocus.score < 5 && FocusTimer.isTimeOver) // retry lvl1
        {
            timerCanvas.SetActive(false);
            levelOneInstructionsRetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }

    private void CheckLevel2()
    {
        if (ScoreCalculationFocus.score >= 5 && FocusTimer.isTimeOver) // complete lvl2
        {
            timerCanvas.SetActive(false);
            levelTwoCompleteCanvas.SetActive(true);
            GridSpawner.isGameOver = true;
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationFocus.score < 5 && FocusTimer.isTimeOver) // retry lvl2
        {
            timerCanvas.SetActive(false);
            levelTwoInstructionsRetryCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }
}
