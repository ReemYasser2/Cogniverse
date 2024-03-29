using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhackTimer : MonoBehaviour
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
        if (ScoreCalculationWhack.isPlayPressed)
        {
            // GeneralCountDownTimer.TimerUpdate(timerText, ref isTimeOver, ref remainingTime);

            if (ScoreCalculationWhack.remainingTime > 0)
            {
                ScoreCalculationWhack.remainingTime -= Time.deltaTime;

                if (ScoreCalculationWhack.remainingTime <= 5)
                {
                    timerText.color = criticalColor;
                }
            }
            else if (ScoreCalculationWhack.remainingTime <= 0)
            {
                ScoreCalculationWhack.reinforcementText = "";

                ScoreCalculationWhack.remainingTime = 0;
                // Timer is over
                ScoreCalculationWhack.isTimeOver = true;
            }
            int minutes = Mathf.FloorToInt(ScoreCalculationWhack.remainingTime / 60);
            int seconds = Mathf.FloorToInt(ScoreCalculationWhack.remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        ScoreCalculationWhack.isPlayPressed = true;
        ScoreCalculationWhack.isTimeOver = false;
        timerText.color = Color.white;
        if (ScoreCalculationWhack.isLevel1) { ScoreCalculationWhack.remainingTime = 300; }
        else if (ScoreCalculationWhack.isLevel2) {  ScoreCalculationWhack.remainingTime = 300; }
     
        //remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, isLevel1, isLevel2, 5, 10);
    }
}
