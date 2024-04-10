using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class ScoreCalculatorMaze : MonoBehaviour
{
    public static int score = 0;
    public static TextMeshProUGUI reinforcement;
    public static string reinforcementText;

    public static bool isLevel1;
    public static bool isLevel2;
    public static bool isGameOver;
    public static bool isHomeButtonClicked;

    public static float overallTime;
    public static int numberOfHits;
   


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
        score++;
        
        //Debug.Log(score);
        if (DatabaseGamesVariables.ispositiveGroup) { reinforcementText = PositiveReinforcementDecrement(); }
        else if (DatabaseGamesVariables.isnegativeGroup) { reinforcementText = NegativeReinforcementDecrement(); }
        else if (DatabaseGamesVariables.iscontrolGroup) { return; }
        else { return; }

        // Debug.Log(reinforcementText);

    }
    public static void Decrement()
    {
        score--;
       // Debug.Log(reinforcementText);
        if (DatabaseGamesVariables.ispositiveGroup) { reinforcementText = PositiveReinforcementIncrement(); }
        else if (DatabaseGamesVariables.isnegativeGroup) { reinforcementText = NegativeReinforcementIncrement(); }
        else if (DatabaseGamesVariables.iscontrolGroup) { return; }
        else { return; }
        //Debug.Log("test -");
    }

    public static int getScore()
    {
        return score;
    }

    public static string PositiveReinforcementIncrement()
    {
        int randomIndex = Random.Range(0, positiveIncrease.Count);   
        //Debug.Log(positiveIncrease[randomIndex]);
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

    IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);

        // After waiting for the specified duration, reset the text to nothing
     reinforcementText = "";
    }
}
