using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculation : MonoBehaviour
{
    int score = 0;
    public bool isCalculated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public int CalculateScoreWhenPressed(Vector3 oldPos, Vector3 currentPos)
    {
        Debug.Log(score);
        if (!isCalculated)
        { 
            isCalculated = true;
            if (oldPos == currentPos)
            {
                score++;
                    Debug.Log("Increment score after pressing ");
                    Debug.Log(score);
            }
            else if (oldPos != currentPos && score != 0)
            {
                score--;
                    Debug.Log("Decrement score after pressing ");
                    Debug.Log(score);
            }
        }
        return score;
    }
    public int CalculateScoreWithoutPressing(Vector3 oldPos, Vector3 currentPos)
    {
        Debug.Log(score);
        if (oldPos == currentPos && score != 0)
        {
            score--;
            Debug.Log("Decrement score without pressing ");
            Debug.Log(score);
        }
        else if (oldPos != currentPos)
        {
            score++;
            Debug.Log("Increment Score without pressing ");
            Debug.Log(score);
        }
        return score;
    }
}
