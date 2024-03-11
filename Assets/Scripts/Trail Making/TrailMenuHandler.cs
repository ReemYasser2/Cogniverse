using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMenuHandler : MonoBehaviour
{
    public LevelsHandler levelsHandler;

    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel3Canvas;
    public GameObject menuCanvas;


    public void MazeInstructionsHandler()
    {
        if (levelsHandler.level1_menu)
        {
            instructionsLevel1Canvas.SetActive(true);
        }
        else if (levelsHandler.level_2)
        {
            instructionsLevel2Canvas.SetActive(true);
        }
        else if (levelsHandler.level_3)
        {
            instructionsLevel3Canvas.SetActive(true);
        }
    }

    public void ShowMenuHandlerMaze()
    {
        if ((levelsHandler.level1_menu || levelsHandler.level_2 || levelsHandler.level_3) && !TrailLevel3.isGameOver)
        {
            if (menuCanvas.activeSelf == false)
            {
                menuCanvas.SetActive(true);
                CountUpTimer.PauseTimer();
            }
        }
    }
}
