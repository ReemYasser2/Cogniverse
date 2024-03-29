using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountDownTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    private float remainingTime;
    private bool isPlayPressed = false;
    public static bool isTimeOver = false;

    public Color criticalColor = Color.red;

    public LevelsTransition LevelsTransition;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, ScoreCalculatorMaze.isLevel1, ScoreCalculatorMaze.isLevel2, 5, 5);
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
                if (ScoreCalculatorMaze.isLevel1) 
                { 
                    LevelsTransition.checkLevelOne();
                    ScoreCalculatorMaze.isLevel1 = false;
                }
                else if (ScoreCalculatorMaze.isLevel2) 
                { 
                    LevelsTransition.CheckLevelTwo(); 
                    ScoreCalculatorMaze.isLevel2 = false;
                }

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
        remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, ScoreCalculatorMaze.isLevel1, ScoreCalculatorMaze.isLevel2, 10, 10);
    }
}
