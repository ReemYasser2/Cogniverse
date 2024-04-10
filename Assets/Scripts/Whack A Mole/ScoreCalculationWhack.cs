using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreCalculationWhack
{
    public static int score = 0;
    public static int correctCounter = 0;
    public static float spawnsCounter = 0;
    public static float accuracy = 0;
    public static float scoreOnePercent = 0;
    public static float scoreTwoPercent = 0;
    public static float spawnerNoGoCounter = 0;
    public static float spawnerGoCounter = 0;
    public static int incrementCounter = 0;

    public static string reinforcementText;
    public static string tag1;
    public static string tag2;

    public static bool isLevel1;
    public static bool isLevel2;
    public static bool isGameOver;
    public static bool isPlayPressed = false;
    public static bool isTimeOver = false;
    public static bool isHomeButtonClicked;
    public static bool isStopWatch1Start = false;
    public static bool isStopWatch2Start = false;
    public static bool isFirstObjectCollide = false;
    public static bool isSecondObjectCollide = false;
    public static bool isPaused1 = false;
    public static bool isPaused2 = false;

    public static float remainingTime;
    public static float elapsedTimeStopWatch1;
    public static float elapsedTimeStopWatch2;
    public static float responseTimeGo;
    public static float responseTimeNoGo;
    public static float stopWatchtime1;
    public static float stopWatchtime2;
    public static float overallTime;

    public static int randomIndexPositiveInc;
    public static int randomIndexPositiveDec;

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
        correctCounter++;
        if (incrementCounter % 5 == 0)
        {
            if (DatabaseGamesVariables.ispositiveGroup) { reinforcementText = PositiveReinforcementIncrement(); }
            else if (DatabaseGamesVariables.isnegativeGroup) { reinforcementText = NegativeReinforcementIncrement(); }
            else if (DatabaseGamesVariables.iscontrolGroup) { return; }
            else { return; }
        }
        Debug.Log(score);

    }
    public static void Decrement()
    {
        score--;
        if (DatabaseGamesVariables.ispositiveGroup) { reinforcementText = PositiveReinforcementDecrement(); }
        else if (DatabaseGamesVariables.isnegativeGroup) { reinforcementText = NegativeReinforcementDecrement(); }
        else if (DatabaseGamesVariables.iscontrolGroup) { return; }
        else { return; }
        //Debug.Log(score);

    }

    public static int getScore()
    {
        return score;
    }

    public static string PositiveReinforcementIncrement()
    {
        int randomIndex = Random.Range(0, positiveIncrease.Count);
        randomIndexPositiveInc = randomIndex;
        return positiveIncrease[randomIndex];

    }
    public static string PositiveReinforcementDecrement()
    {
        int randomIndex = Random.Range(0, positiveDecrease.Count);
        randomIndexPositiveDec = randomIndex;
        return positiveDecrease[randomIndex];
    }
    public static string NegativeReinforcementIncrement()
    {
        int randomIndex = Random.Range(0, negativeIncrease.Count);
        randomIndexPositiveInc = randomIndex;
        return negativeIncrease[randomIndex];
    }
    public static string NegativeReinforcementDecrement()
    {
        int randomIndex = Random.Range(0, negativeDecrease.Count);
        randomIndexPositiveDec = randomIndex;
        return negativeDecrease[randomIndex];
    }
    public static float AccuracyCalculation(int correct, float total)
    {
        accuracy = correct / total;
        return accuracy;
    }
}
