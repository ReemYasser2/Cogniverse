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

            reinforcmentText.text = ScoreCalculator.reinforcementText;

    }
}
