using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ReinforcementManagement
{
    public static TextMeshProUGUI reinforcement;
    public static string reinforcementText;

    static List<string> positiveIncrease = new List<string>
            { " Good Job", "Keep it up", "You're on a roll", "Excellent work", "Amazing!!", "Awesome!!", "Well done!!"};
    static List<string> positiveDecrease = new List<string>
            { "Keep going", "Errors can teach", "Keep doing your best", "You've got this"};
    static List<string> negativeIncrease = new List<string>
            { " Average performance", "You can do better", "Ordinary move", "Below average"};
    static List<string> negativeDecrease = new List<string>
            { "You failed", "You missed it", "Not even close"};

    public static string PositiveReinforcementIncrement()
    {
        int randomIndex = Random.Range(0, positiveIncrease.Count);
        reinforcementText = positiveIncrease[randomIndex];
        return positiveIncrease[randomIndex];
    }
    public static string PositiveReinforcementDecrement()
    {
        int randomIndex = Random.Range(0, positiveDecrease.Count);
        reinforcementText = positiveDecrease[randomIndex];

        return positiveDecrease[randomIndex];
    }
    public static string NegativeReinforcementIncrement()
    {
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
