using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ReinforcementManagement
{
    public static TextMeshProUGUI reinforcement;
    public static string reinforcementText;
    public static int incrementCounter = 0;
    public static float elapsedTime;
    public static float overallTime;

    public static bool isPlayPressed = false;
    public static bool isPaused = false;
    public static bool level_1 = false;
    public static bool level1_menu = false;
    public static bool level_2 = false;
    public static bool level_3 = false;
    public static bool isGameOver = true;

    public static int numberOfMistakeslvl1;
    public static int numberOfMistakeslvl2;
    public static int numberOfMistakeslvl3;

    public static int randomIndexPositiveInc;
    public static int randomIndexPositiveDec;

    public static string date;
    public static string time;

    static List<string> positiveIncrease = new List<string>
            { " Good Job", "Keep it up", "You're on a roll", "Excellent work", "Amazing!!", "Awesome!!", "Well done!!"};
    static List<string> positiveDecrease = new List<string>
            { "Keep going", "Errors can teach", "Keep doing your best", "You've got this"};
    static List<string> negativeIncrease = new List<string>
            { " Average performance", "You can do better", "Ordinary move", "Below average"};
    static List<string> negativeDecrease = new List<string>
            { "You failed", "You missed it", "Not even close"};

    public static void PositiveReinforcementIncrement()
    {
        if (DatabaseGamesVariables.ispositiveGroup)
        {
            incrementCounter++;
            int randomIndex = Random.Range(0, positiveIncrease.Count);
            randomIndexPositiveInc = randomIndex;
            if (incrementCounter % 5 == 0)
            {
                reinforcementText = positiveIncrease[randomIndex];
            }
        }
        else if (DatabaseGamesVariables.isnegativeGroup)
        {
            incrementCounter++;
            int randomIndex = Random.Range(0, negativeIncrease.Count);
            randomIndexPositiveInc = randomIndex;
            if (incrementCounter % 5 == 0)
            {
                reinforcementText = negativeIncrease[randomIndex];
            }
            //return negativeIncrease[randomIndex];
        }
        else if (DatabaseGamesVariables.iscontrolGroup) { return; }
        else { return; }

    }
    public static string PositiveReinforcementDecrement()
    {
        if (DatabaseGamesVariables.ispositiveGroup)
        {
            int randomIndex = Random.Range(0, positiveDecrease.Count);
            reinforcementText = positiveDecrease[randomIndex];
            randomIndexPositiveDec = randomIndex;
            return positiveDecrease[randomIndex];
        }
        else if (DatabaseGamesVariables.isnegativeGroup)
        {
            int randomIndex = Random.Range(0, negativeDecrease.Count);
            reinforcementText = negativeDecrease[randomIndex];
            randomIndexPositiveDec = randomIndex;
            return negativeDecrease[randomIndex];
        }
        else if (DatabaseGamesVariables.iscontrolGroup) { return null; }
        else { return null; }
    }
    public static string NegativeReinforcementIncrement()
    {
        incrementCounter++;
        int randomIndex = Random.Range(0, negativeIncrease.Count); 
        reinforcementText = negativeIncrease[randomIndex];
        
        return negativeIncrease[randomIndex];
    }
    public static string NegativeReinforcementDecrement()
    {
        int randomIndex = Random.Range(0, negativeDecrease.Count); 
        reinforcementText = negativeDecrease[randomIndex];
        return negativeDecrease[randomIndex];
    }
}
