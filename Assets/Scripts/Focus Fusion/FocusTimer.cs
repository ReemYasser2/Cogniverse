using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FocusTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    public static float remainingTime;
    public static bool isPlayPressed = false;
    public static bool isTimeOver = false;

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
        if (isPlayPressed)
        {
            // GeneralCountDownTimer.TimerUpdate(timerText, ref isTimeOver, ref remainingTime);

            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                if (remainingTime <= 5)
                {
                    timerText.color = criticalColor;
                }
            }
            else if (remainingTime <= 0)
            {
                remainingTime = 0;
                // Timer is over
                isTimeOver = true;
                ScoreCalculationFocus.reinforcementText = "";
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        FocusLevelTransition.isHomeClicked = false;
        isPlayPressed = true;
        isTimeOver = false;
        timerText.color = Color.white;
        if (GridSpawner.isLevel1) { remainingTime = 5; }
        else if (GridSpawner.isLevel2) { remainingTime = 10; }
        //remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, isLevel1, isLevel2, 5, 10);
    }


}
