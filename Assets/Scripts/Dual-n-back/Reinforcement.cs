using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reinforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText; 



    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculator.isGameOver)
        {
            reinforcmentText.text = "";
        }
        else if (ScoreCalculator.isStartLevel1)
        {
            reinforcmentText.text = "";
        }
        else if (ScoreCalculator.isStartLevel2)
        {
            reinforcmentText.text = "";
        }
        else if (ScoreCalculator.isStartLevel3)
        {
            reinforcmentText.text = "";
        }
        else
        {
            //reinforcmentText.text = ScoreCalculator.reinforcementText;
            DynamicTextManager.CreateText(new Vector3 (0.2f, 0f, -7.2f), ScoreCalculator.reinforcementText, DynamicTextManager.defaultData);
        }
    }
}
