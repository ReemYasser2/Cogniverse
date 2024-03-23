using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhackReiforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        reinforcmentText.text = ScoreCalculationWhack.reinforcementText;

    }
}
