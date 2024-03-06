using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInstructionsHandler : MonoBehaviour
{
    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel3Canvas;


    public void InstructionsHandler()
    {
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

    }
}
