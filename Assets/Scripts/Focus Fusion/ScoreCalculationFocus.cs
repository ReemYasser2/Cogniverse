using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreCalculationFocus 
{
    public static int score = 0;

    public static string reinforcementText;
    public static int incrementCounter = 0;
    public static float remainingTime;
    public static float elapsedTimeStopWatch;
    public static float stopWatchtime;
    public static float responseTimeGo;
    public static float responseTimeNoGo;

    public static bool isPlayPressed = false;
    public static bool isTimeOver = false;
    public static bool isLevel1;
    public static bool isLevel2;
    public static bool isGameOver;
    public static bool isHomeClicked;
    public static bool isStopWatchStart = false;
    public static bool isPaused = false;

    public static int totalTrialsNoGo;
    public static int totalTrialsGo;
    
    

    static List<string> positiveIncrease = new List<string>
            { " Good Job", "Keep it up", "You're on a roll", "Excellent work", "Amazing!!", "Awesome!!", "Well done!!"};
    static List<string> positiveDecrease = new List<string>
            { "Keep going", "Errors can teach", "Keep doing your best", "You've got this"};
    static List<string> negativeIncrease = new List<string>
            { " Average performance", "You can do better", "Ordinary move", "Below average"};
    static List<string> negativeDecrease = new List<string>
            { "You failed", "You missed it", "Not even close"};


    public static void Increment()
    {
        incrementCounter++;

        score++;
        Debug.Log(score);
        if (incrementCounter % 5 == 0)
        {
            reinforcementText = PositiveReinforcementIncrement();
        }

    }
    public static void Decrement()
    {
        score--;
        reinforcementText = PositiveReinforcementDecrement();
        Debug.Log(score);


    }

    public static int getScore()
    {
        return score;
    }

    public static string PositiveReinforcementIncrement()
    {
        int randomIndex = Random.Range(0, positiveIncrease.Count);
        Debug.Log(positiveIncrease[randomIndex]);
        return positiveIncrease[randomIndex];

    }
    public static string PositiveReinforcementDecrement()
    {
        int randomIndex = Random.Range(0, positiveDecrease.Count);
        return positiveDecrease[randomIndex];
    }
    public static string NegativeReinforcementIncrement()
    {
        int randomIndex = Random.Range(0, negativeIncrease.Count);
        return negativeIncrease[randomIndex];
    }
    public static string NegativeReinforcementDecrement()
    {
        int randomIndex = Random.Range(0, negativeDecrease.Count);
        return negativeDecrease[randomIndex];
    }

}
