using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMenuHandler : MonoBehaviour
{
    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject menuCanvas;

    public void MazeInstructionsHandler()
    {
        GeneralMenuHandler.InstructionsHandler(LevelsTransition.isLevel1, LevelsTransition.isLevel2, false, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel2MenuCanvas);
    }

    public void ShowMenuHandlerMaze()
    {
        GeneralMenuHandler.ShowMenuHandler(LevelsTransition.isLevel1, LevelsTransition.isLevel2, false, LevelsTransition.isGameOver, menuCanvas, instructionsLevel1Canvas, instructionsLevel2Canvas, instructionsLevel2Canvas, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel2MenuCanvas, 1, 2);
    }
}
