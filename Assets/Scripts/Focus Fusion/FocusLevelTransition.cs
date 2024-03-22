using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusLevelTransition : MonoBehaviour
{
    public GameObject levelTwoInstructionsCanvas;
    public GameObject levelOneInstructionsCanvas;
    public GameObject gameOverCanvas;

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
        if (ScoreCalculationFocus.score >= 5 && FocusTimer.isTimeOver)
        {
            levelTwoInstructionsCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationFocus.score < 5 && FocusTimer.isTimeOver)
        {
            levelOneInstructionsCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }

    private void CheckLevel2()
    {
        if (ScoreCalculationFocus.score >= 5 && FocusTimer.isTimeOver)
        {
            gameOverCanvas.SetActive(true);
            GridSpawner.isGameOver = true;
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationFocus.score < 5 && FocusTimer.isTimeOver)
        {
            levelTwoInstructionsCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }
}
