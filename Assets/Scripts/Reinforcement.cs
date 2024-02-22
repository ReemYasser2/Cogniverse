using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reinforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnManager.isGameOver)
        {
            reinforcmentText.text = "";
            Debug.Log("game over");
        }
        else if (SpawnManager.isStartLevel1)
        {
            reinforcmentText.text = "";
            Debug.Log("level 1");
        }
        else if (SpawnManager.isStartLevel2)
        {
            reinforcmentText.text = "";
            Debug.Log("level 2");
        }
        else if (SpawnManager.isStartLevel3)
        {
            reinforcmentText.text = "";
            Debug.Log("level 3");
        }
        else
        {
            reinforcmentText.text = ScoreCalculator.reinforcementText;
        }
    }
}
