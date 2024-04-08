using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountDownTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    private float remainingTime;
    private bool isPlayPressed = false;
    public static bool isTimeOver = true;

    public Color criticalColor = Color.red;

    public LevelsTransition LevelsTransition;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, ScoreCalculatorMaze.isLevel1, ScoreCalculatorMaze.isLevel2, 30, 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayPressed && !isTimeOver)
        {
            // GeneralCountDownTimer.TimerUpdate(timerText, ref isTimeOver, ref remainingTime);

            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                /*if (ScoreCalculatorMaze.isLevel1)
                {
                    //CountDownTimer.OverallTime(1);
                    //.Log("overall time: "+ ScoreCalculatorMaze.overallTime);
                    LevelsTransition.checkLevelOneWithoutTimer();
                    ScoreCalculatorMaze.isLevel1 = false;
                    isTimeOver = true;
                }
                else if (ScoreCalculatorMaze.isLevel2)
                {
                    //CountDownTimer.OverallTime(2);
                    //Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                    LevelsTransition.CheckLevelTwoWithoutTimer();
                    ScoreCalculatorMaze.isLevel2 = false;
                    isTimeOver = true;
                }*/

                if (remainingTime <= 5)
                {
                    timerText.color = criticalColor;
                }
            }
            else if (remainingTime <= 0)
            {
                // Timer is over
                isTimeOver = true;
                ScoreCalculatorMaze.reinforcementText = "";
                if (ScoreCalculatorMaze.isLevel1)
                {
                    //CountDownTimer.OverallTime(1);
                    //.Log("overall time: "+ ScoreCalculatorMaze.overallTime);
                    LevelsTransition.checkLevelOne();
                    ScoreCalculatorMaze.isLevel1 = false;
                }
                else if (ScoreCalculatorMaze.isLevel2)
                {
                    //CountDownTimer.OverallTime(2);
                    //Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                    LevelsTransition.CheckLevelTwo();
                    ScoreCalculatorMaze.isLevel2 = false;
                }
                remainingTime = 0;
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        isPlayPressed = true;
        isTimeOver = false;
        remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, ScoreCalculatorMaze.isLevel1, ScoreCalculatorMaze.isLevel2, 30, 60);
    }

    public  void OverallTime(int level)
    {
        if (level == 1) { ScoreCalculatorMaze.overallTime = 30 - remainingTime; }
        else if (level == 2) { ScoreCalculatorMaze.overallTime = 60 - remainingTime; }
    }
}
