using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculatorMaze : MonoBehaviour
{
    public static int score = 0;

    public static void Increment()
    { 
        score++;
        Debug.Log(score);
    }
    public static void Decrement()
    {
        score--;
        Debug.Log("test -");
    }

    public static int getScore()
    {
        return score;
    }
}
