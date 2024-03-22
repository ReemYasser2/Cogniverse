using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMenuHandler : MonoBehaviour
{
    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject menuCanvas;

    public GridSpawner gridSpawner;

    public void InstructionsHandler()
    {
        GeneralMenuHandler.InstructionsHandler(GridSpawner.isLevel1, GridSpawner.isLevel2, false, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel2MenuCanvas);
    }

    public void ShowMenuHandler()
    {
        //GeneralMenuHandler.ShowMenuHandler(GridSpawner.isLevel1, GridSpawner.isLevel2, false, GridSpawner.isGameOver, menuCanvas, instructionsLevel1Canvas, instructionsLevel2Canvas, instructionsLevel2Canvas, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel2MenuCanvas, 1, 2);

        if (menuCanvas.activeSelf == false && instructionsLevel1Canvas.activeSelf == false && instructionsLevel2Canvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false)
        {
            if ((GridSpawner.isLevel1 || GridSpawner.isLevel2) && !GridSpawner.isGameOver)
            {
                GeneralMenuHandler.MenuHelperFuncrion(menuCanvas, 1);
                gridSpawner.ShowHideGrid(false);
            }
        }
    }
}
