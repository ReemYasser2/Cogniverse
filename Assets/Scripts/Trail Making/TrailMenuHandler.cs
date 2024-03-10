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
        if (levelsHandler.level_1)
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
        if ((levelsHandler.level_1 || levelsHandler.level_2 || levelsHandler.level_3) && !TrailLevel3.isGameOver)
        {
            Debug.Log(levelsHandler.level_1);
            Debug.Log(levelsHandler.level_2);
            Debug.Log(levelsHandler.level_3);
            if (menuCanvas.activeSelf == false)
            {
                menuCanvas.SetActive(true);
                PauseGame.Pause();
            }
        }
    }
}
