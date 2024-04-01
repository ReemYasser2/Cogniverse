using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FocusTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    

    public Color criticalColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        // remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, isLevel1, isLevel2, 5, 10);
        timerText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculationFocus.isPlayPressed)
        {
            // GeneralCountDownTimer.TimerUpdate(timerText, ref isTimeOver, ref remainingTime);

            if (ScoreCalculationFocus.remainingTime > 0)
            {
                ScoreCalculationFocus.remainingTime -= Time.deltaTime;

                if (ScoreCalculationFocus.remainingTime <= 5)
                {
                    timerText.color = criticalColor;
                }
            }
            else if (ScoreCalculationFocus.remainingTime <= 0)
            {
                OverallTime();
                Debug.Log("overall time: " + ScoreCalculationFocus.overallTime);
                ScoreCalculationFocus.remainingTime = 0;
                // Timer is over
                ScoreCalculationFocus.isTimeOver = true;
                ScoreCalculationFocus.reinforcementText = "";
            }
            int minutes = Mathf.FloorToInt(ScoreCalculationFocus.remainingTime / 60);
            int seconds = Mathf.FloorToInt(ScoreCalculationFocus.remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        ScoreCalculationFocus.isHomeClicked = false;
        ScoreCalculationFocus.isPlayPressed = true;
        ScoreCalculationFocus.isTimeOver = false;
        timerText.color = Color.white;
        if (ScoreCalculationFocus.isLevel1) { ScoreCalculationFocus.remainingTime = 180; }
        else if (ScoreCalculationFocus.isLevel2) { ScoreCalculationFocus.remainingTime = 180; }
        //remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, isLevel1, isLevel2, 5, 10);
    }

    private void OverallTime()
    {
        ScoreCalculationFocus.overallTime = 180 - ScoreCalculationFocus.remainingTime;
    }
}
