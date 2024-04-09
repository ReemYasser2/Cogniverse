using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ScoreCalculator
{
    public static int score = 0;
    public static TextMeshProUGUI reinforcement;

    public static bool isLevel1 = false;
    public static bool isLevel2 = false;
    public static bool isLevel3 = false;
    public static bool isGameOver = true;
    public static bool isCalculated = false;
    public static bool isComparisonDone = false;
    public static bool isPlayPressed = false;
    public static bool isPaused = false;
    public static bool isHomeClicked = false;

    static int oldScore; 
    static int incrementCounter=0;
    public static int trialsCount = 0;
    public static int maxTrials = 15;
    public static int accuracy = 0;
    public static int correctCounter = 0;
    public static float scoreOnePercent = 0;
    public static float scoreTwoPercent = 0;
    public static float scoreThreePercent = 0;
    public static float overallTime;
    public static bool isStopWatchStart = false;
    public static bool isPausedStopWatch = false;
    public static float elapsedTimeStopWatch;
    public static float stopWatchtime;
    public static float responseTimeGo;
    public static float responseTimeNoGo;
    public static int countGoTrials = 0;
    public static int countNoGoTrials = 0;


    public static float elapsedTime;

    public static string reinforcementText;


    static List<string> positiveIncrease = new List<string>
            { " Good Job", "Keep it up", "You're on a roll", "Excellent work", "Amazing!!", "Awesome!!", "Well done!!"};
    static List<string> positiveDecrease = new List<string>
            { "Keep going", "Errors can teach", "Keep doing your best", "You've got this"};
    static List<string> negativeIncrease = new List<string>
            { " Average performance", "You can do better", "Ordinary move", "Below average"};
    static List<string> negativeDecrease = new List<string>
            { "You failed", "You missed it", "Not even close"};
    public static int CalculateScoreWhenPressed(Vector3 oldPos, Vector3 currentPos)
    {
        oldScore = score;
        if (!isCalculated)
        {
            isCalculated = true;
            if (oldPos == currentPos)
            {
                incrementCounter++;
                score++;
                correctCounter++;
                //Debug.Log("Increment score after pressing ");

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeGo = responseTimeGo + stopWatchtime;

            }
            else if (oldPos != currentPos && score != 0)
            {
                incrementCounter--;
                score--;
                //Debug.Log("Decrement score after pressing ");

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeGo = responseTimeGo + stopWatchtime;
            }
        }
        reinforcmentCondition();
        //Debug.Log(score);
        return score;
    }


    public static int CalculateColorScoreWhenPressed(Material oldColor, Material currentColor)
    {
        oldScore = score;

            if (oldColor == currentColor)
            {
                incrementCounter++;
                score++;
                correctCounter++;
               // Debug.Log("Increment score after pressing ");

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeGo = responseTimeGo + stopWatchtime;
            }
            else if (oldColor != currentColor && score != 0)
            {
                incrementCounter--;
                score--;
                //Debug.Log("Decrement score after pressing ");

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeGo = responseTimeGo + stopWatchtime;
            }
        
        reinforcmentCondition();
        //Debug.Log(score);
        return score;
    }

    public static  int CalculateScoreWithoutPressing(Vector3 oldPos, Vector3 currentPos)
    {
        oldScore = score;
        if (oldPos == currentPos && score != 0)
        {
            incrementCounter--;
            score--;
            //Debug.Log("Decrement score without pressing ");

            isStopWatchStart = false;
            elapsedTimeStopWatch = 0;
            responseTimeNoGo = responseTimeNoGo + stopWatchtime;
        }
        else if (oldPos != currentPos)
        {
            incrementCounter++;
            score++;
            correctCounter++;
           // Debug.Log("Increment Score without pressing ");

            countNoGoTrials++;
            countGoTrials--;
            isStopWatchStart = false;
            elapsedTimeStopWatch = 0;
            responseTimeNoGo = responseTimeNoGo + 0;

        }
        reinforcmentCondition();
        //Debug.Log(score);
        return score;
    }


    public static int CalculateColorScoreWithoutPressing(Material oldColor, Material currentColor)
    { 
        oldScore = score;
        if (oldColor == currentColor && score != 0)
        {
            incrementCounter--;
            score--;
            //Debug.Log("Decrement score without pressing ");

            isStopWatchStart = false;
            elapsedTimeStopWatch = 0;
            responseTimeNoGo = responseTimeNoGo + stopWatchtime;
        }
        else if (oldColor != currentColor)
        {
            incrementCounter++;
            score++;
            correctCounter++;
            //Debug.Log("Increment Score without pressing ");

            countNoGoTrials++;
            countGoTrials--;
            isStopWatchStart = false;
            elapsedTimeStopWatch = 0;
            responseTimeNoGo = responseTimeNoGo + 0;

        }
        reinforcmentCondition();
       // Debug.Log(score);
        return score;
    }


    public static int CalculateAudioScore(AudioClip oldAudio, AudioClip currentAudio)
    {
        // Logic to compare old and current audio clips goes here
        // You might need to modify this method based on your comparison criteria
        oldScore = score;

        if (!isComparisonDone)
        {
            isComparisonDone = true;

            if (oldAudio == currentAudio)
            {
                // Handle comparison when old and current clips are the same
                //Debug.Log("Audio clips are the same");
                // Adjust the score or perform actions accordingly
                incrementCounter++;
                score++;
                correctCounter++;

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeGo = responseTimeGo + stopWatchtime;
            }
            else
            {
                // Handle comparison when old and current clips are different
                //Debug.Log("Audio clips are different");
                // Adjust the score or perform actions accordingly
                incrementCounter--;
                score--;

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeGo = responseTimeGo + stopWatchtime;
            }
        }
        //Debug.Log(score);
        reinforcmentCondition();
        return score;
    }


    public static int CalculateAudioScoreWithoutPressing(AudioClip oldAudio, AudioClip currentAudio)
    {
        // Logic to compare old and current audio clips goes here
        // You might need to modify this method based on your comparison criteria
        oldScore = score;

        if (!isComparisonDone)
        {
            isComparisonDone = true;

            if (oldAudio == currentAudio)
            {
                // Handle comparison when old and current clips are the same
                //Debug.Log("Audio clips are the same");
                // Adjust the score or perform actions accordingly
                incrementCounter++;
                score++;
                correctCounter++;

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeNoGo = responseTimeNoGo + 0;
            }
            else
            {
                // Handle comparison when old and current clips are different
                //Debug.Log("Audio clips are different");
                // Adjust the score or perform actions accordingly
                incrementCounter--;
                score--;

                isStopWatchStart = false;
                elapsedTimeStopWatch = 0;
                responseTimeNoGo = responseTimeNoGo + stopWatchtime;
            }
        }
       // Debug.Log(score);
        reinforcmentCondition();
        return score;
    }




    public static int Increment(AudioClip oldAudio, AudioClip currentAudio)
    {
        oldScore = score;
        if (!isComparisonDone)
        {
            isComparisonDone = true;

            if (oldAudio != currentAudio)
            {
                // Audio clips arent the same and the button didnt get clicked
                //Debug.Log("Audio clips arent the same and the button didnt get clicked"); 
                incrementCounter++;
                correctCounter++;
                score++;
            }
            else if (oldAudio == currentAudio && score != 0)
            {
               // Debug.Log("Audio clips are the same and the button didnt get clicked");
                incrementCounter--;

                score--;
            }
        }
       // Debug.Log(score);
        reinforcmentCondition();
        return score;
    }
    public static void reinforcmentCondition()
    {
        if (score - oldScore == 1 && incrementCounter % 5 == 0 )
        {
            reinforcementText = "";
            reinforcementText = PositiveReinforcementIncrement();
        }
        else if (oldScore - score == 1)
        {
            reinforcementText = "";
            reinforcementText = PositiveReinforcementDecrement();
        }
    }
    public static string PositiveReinforcementIncrement()
    {
        int randomIndex = Random.Range(0, positiveIncrease.Count);
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
    public static float AccuracyCalculation(int correct, int total)
    {
        accuracy = correct / total;
        return accuracy;
    }
}