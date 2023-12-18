using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculation : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public int CalculateScore(Vector3 oldPos, Vector3 currentPos)
    {
        if (oldPos == currentPos)
        {
            score++;
            Debug.Log(score);
        }
        else if( oldPos!=currentPos && score !=0)
        {
            score--;
            Debug.Log(score);
        }
        Debug.Log(score);
        return score;
    }
}
