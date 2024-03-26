using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusLevelTransition : MonoBehaviour
{
    public static bool isHomeClicked;

    public void ToHome()
    {
        isHomeClicked = true;

        ScoreCalculationFocus.score = 0;
        FocusTimer.isPlayPressed = false;
        FocusTimer.isTimeOver = true;

        GridSpawner.isLevel1 = false;
        GridSpawner.isLevel2 = false;
        GridSpawner.isGameOver = true;
    }
}
