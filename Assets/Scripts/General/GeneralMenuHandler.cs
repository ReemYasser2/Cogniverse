using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMenuHandler : MonoBehaviour
{
    public static void InstructionsHandler(bool level1, bool level2, bool level3, GameObject instructionsLevel1Canvas, GameObject instructionsLevel2Canvas, GameObject instructionsLevel3Canvas)
    {
        if (level1)
        {
            instructionsLevel1Canvas.SetActive(true);
        }
        else if (level2)
        {
            instructionsLevel2Canvas.SetActive(true);
        }
        else if (level3)
        {
            instructionsLevel3Canvas.SetActive(true);
        }
    }

    public static void MenuHelperFuncrion(GameObject menuCanvas, int timer)
    {
        menuCanvas.SetActive(true);
        if (timer == 1)
        {
            PauseGame.Pause();
        }
        else if (timer == 2)
        {
            CountUpTimer.PauseTimer();
        }
    }

    public static void ShowMenuHandler(bool level1, bool level2, bool level3, bool gameOver, GameObject menuCanvas, GameObject instructionsLevel1Canvas, GameObject instructionsLevel2Canvas, GameObject instructionsLevel3Canvas, GameObject instructionsLevel1MenuCanvas, GameObject instructionsLevel2MenuCanvas, GameObject instructionsLevel3MenuCanvas, int timer, int levels)
    {
        if (levels == 2)
        {
            if (menuCanvas.activeSelf == false && instructionsLevel1Canvas.activeSelf == false && instructionsLevel2Canvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false)
            {
                 if ((level1 || level2) && !gameOver)
                 {
                    MenuHelperFuncrion(menuCanvas, timer);
                 }
            }
               
        }
        else if (levels == 3)
        {
            if (menuCanvas.activeSelf == false && instructionsLevel1Canvas.activeSelf == false && instructionsLevel2Canvas.activeSelf == false && instructionsLevel3Canvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false && instructionsLevel3MenuCanvas.activeSelf == false)
            {
                if ((level1 || level2 || level3) && !gameOver)
                {
                    MenuHelperFuncrion(menuCanvas, timer);
                }
            }
        }
        
    }
}
