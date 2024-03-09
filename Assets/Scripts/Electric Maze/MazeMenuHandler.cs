using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMenuHandler : MonoBehaviour
{
    
    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject menuCanvas;

    public void MazeInstructionsHandler()
    {
        if (LevelsTransition.isLevel1)
        {
            instructionsLevel1Canvas.SetActive(true);
        }
        else if (LevelsTransition.isLevel2)
        {
            instructionsLevel2Canvas.SetActive(true);
        }
    }

    public void ShowMenuHandlerMaze()
    {
        if ((LevelsTransition.isLevel1 || LevelsTransition.isLevel2) && !LevelsTransition.isGameOver)
        {
            if (menuCanvas.activeSelf == false)
            {
                menuCanvas.SetActive(true);
                PauseGame.Pause();
            }
        }
    }
}
