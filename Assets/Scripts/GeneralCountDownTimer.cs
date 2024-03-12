using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class GeneralCountDownTimer : MonoBehaviour
{
    private static Color criticalColor = Color.red;
    //private static float remainingTime;

    // function for initialization
    public static float TimerInitialization(TMP_Text timerText, bool isLevel1, bool isLevel2, float setLevel1Time, float setLevel2Time)
    {
        timerText.color = Color.white;
        float remainingTime = 0;
        if (isLevel1)
        {
            remainingTime = setLevel1Time;
        }
        else if (isLevel2)
        {
            remainingTime = setLevel2Time;
        }

        return remainingTime;
    }

    public static void TimerUpdate(TMP_Text timerText, ref bool isTimeOver, ref float gameRemainingTime)
    {
        if (gameRemainingTime > 0)
        {
            gameRemainingTime -= Time.deltaTime;

            if (gameRemainingTime <= 5)
            {
                timerText.color = criticalColor;
            }
        }
        else if (gameRemainingTime <= 0)
        {
            gameRemainingTime = 0;
            // Game over
            isTimeOver = true;
        }
        int minutes = Mathf.FloorToInt(gameRemainingTime / 60);
        int seconds = Mathf.FloorToInt(gameRemainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
