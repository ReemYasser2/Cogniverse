using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitionWhack : MonoBehaviour
{
    public GameObject levelTwoInstructionsCanvas;
    public GameObject levelOneInstructionsCanvas;
    public GameObject gameOverCanvas;
    public GameObject timerCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Spawner.isLevel1)
        {
            CheckLevel1();
        }
        else if (Spawner.isLevel2)
        {
            CheckLevel2();
        }
    }

    private void CheckLevel1()
    {
        if (ScoreCalculationWhack.score >= 10 && WhackTimer.isTimeOver)
        {
            timerCanvas.SetActive(false);
            levelTwoInstructionsCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationWhack.score < 10 && WhackTimer.isTimeOver)
        {
            timerCanvas.SetActive(false);
            levelOneInstructionsCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }

    private void CheckLevel2()
    {
        if (ScoreCalculationWhack.score >= 10 && WhackTimer.isTimeOver)
        {
            timerCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            Spawner.isGameOver = true;
            ScoreCalculationFocus.score = 0;
        }
        else if (ScoreCalculationWhack.score < 10 && WhackTimer.isTimeOver)
        {
            timerCanvas.SetActive(false);
            levelTwoInstructionsCanvas.SetActive(true);
            ScoreCalculationFocus.score = 0;
        }
    }
}

