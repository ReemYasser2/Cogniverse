using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MazeReinforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText;


    // Update is called once per frame
    void Update()
    {

       //s reinforcmentText.text = ScoreCalculatorMaze.reinforcementText;
        DynamicTextData data = DynamicTextManager.defaultData;
        data.lifetime = 0.1f;
        DynamicTextManager.CreateText(new Vector3(11f, 3f, 3f), ScoreCalculatorMaze.reinforcementText, data);
    }
}
