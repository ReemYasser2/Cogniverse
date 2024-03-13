using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMenuHandler : MonoBehaviour
{
    public LevelsHandler levelsHandler;

    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel3Canvas;
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject instructionsLevel3MenuCanvas;
    public GameObject menuCanvas;

    public void TrailInstructionsHandler()
    {
        GeneralMenuHandler.InstructionsHandler(levelsHandler.level1_menu, levelsHandler.level_2, levelsHandler.level_3, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas);
    }

    public void ShowMenuHandlerTrail()
    {
        GeneralMenuHandler.ShowMenuHandler(levelsHandler.level1_menu, levelsHandler.level_2, levelsHandler.level_3, TrailLevel3.isGameOver, menuCanvas, instructionsLevel1Canvas, instructionsLevel2Canvas, instructionsLevel3Canvas, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas, 2, 3);
    }
}
