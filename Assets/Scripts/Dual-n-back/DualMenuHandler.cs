using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualMenuHandler : MonoBehaviour
{
    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel3Canvas;
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject instructionsLevel3MenuCanvas;
    public GameObject menuCanvas;


    public void InstructionsHandler()
    {
        GeneralMenuHandler.InstructionsHandler(ScoreCalculator.isLevel1, ScoreCalculator.isLevel2, ScoreCalculator.isLevel3, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas);
        /*
        if (ScoreCalculator.isLevel1)
        {
            instructionsLevel1Canvas.SetActive(true);
        }
        else if (ScoreCalculator.isLevel2)
        {
            instructionsLevel2Canvas.SetActive(true);
        }
        else if(ScoreCalculator.isLevel3)
        {
            instructionsLevel3Canvas.SetActive(true);
        }
        */
    }

    public void ShowMenuHandler()
    {
        //GeneralMenuHandler.ShowMenuHandler(ScoreCalculator.isGameStart, ScoreCalculator.isLevel2, ScoreCalculator.isLevel3, ScoreCalculator.isGameOver, menuCanvas, instructionsLevel1Canvas, instructionsLevel2Canvas, instructionsLevel3Canvas, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas, 1, 3);

        if (ScoreCalculator.isGameStart && !ScoreCalculator.isGameOver)
        {
            if (menuCanvas.activeSelf == false)
            {
                menuCanvas.SetActive(true);
                PauseGame.Pause();
            }
        }
    }
}
