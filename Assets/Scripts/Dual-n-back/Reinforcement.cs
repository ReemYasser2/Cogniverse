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
        //reinforcmentText.text = ScoreCalculator.reinforcementText;
        DynamicTextManager.CreateText(new Vector3 (0.2f, 0f, -7.2f), ScoreCalculator.reinforcementText, DynamicTextManager.defaultData);
    }
}
