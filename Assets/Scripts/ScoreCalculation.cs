using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreCalculator
{
    public static int score = 0;
    public static bool isCalculated = false;
    public static bool isComparisonDone = false;
    public static int CalculateScoreWhenPressed(Vector3 oldPos, Vector3 currentPos)
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
    public static  int CalculateScoreWithoutPressing(Vector3 oldPos, Vector3 currentPos)
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

    public static int CalculateAudioScore(AudioClip oldAudio, AudioClip currentAudio)
    {
        // Logic to compare old and current audio clips goes here
        // You might need to modify this method based on your comparison criteria
        if (!isComparisonDone)
        {
            isComparisonDone = true;

            if (oldAudio == currentAudio)
            {
                // Handle comparison when old and current clips are the same
                Debug.Log("Audio clips are the same");
                // Adjust the score or perform actions accordingly
                score++;
            }
            else
            {
                // Handle comparison when old and current clips are different
                Debug.Log("Audio clips are different");
                // Adjust the score or perform actions accordingly
                score--;
            }

        }
        Debug.Log(score);

        return score;
    }
    public static int Increment(AudioClip oldAudio, AudioClip currentAudio)
    {

        if (!isComparisonDone)
        {
            isComparisonDone = true;

            if (oldAudio != currentAudio)
            {
                // Audio clips arent the same and the button didnt get clicked
                Debug.Log("Audio clips arent the same and the button didnt get clicked");
                score++;
            }
            else if (oldAudio == currentAudio && score != 0)
            {
                Debug.Log("Audio clips are the same and the button didnt get clicked");
                score--;
            }
        }
        Debug.Log(score);

        return score;
    }


}