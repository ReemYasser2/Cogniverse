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

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, LevelsTransition.isLevel1, LevelsTransition.isLevel2, 30, 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayPressed)
        {
            GeneralCountDownTimer.TimerUpdate(timerText, ref isTimeOver, ref remainingTime);
        }
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        isPlayPressed = true;
        isTimeOver = false;
        remainingTime = GeneralCountDownTimer.TimerInitialization(timerText, LevelsTransition.isLevel1, LevelsTransition.isLevel2, 30, 60);
    }
}
