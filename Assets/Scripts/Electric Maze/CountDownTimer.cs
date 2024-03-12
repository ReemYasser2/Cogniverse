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
    // public GameObject gameOverCanvas;
    private Color criticalColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        timerText.color = Color.white;
        if (LevelsTransition.isLevel1)
        {
            remainingTime = 7;
        }
        else if (LevelsTransition.isLevel2)
        {
            remainingTime = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayPressed)
        {
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
                // Game over
                isTimeOver = true;
               // gameOverCanvas.SetActive(true);
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
        timerText.color = Color.white;
        // Reset the timer to its initial value
        if (LevelsTransition.isLevel1)
        {
            remainingTime = 7;
        }
        else if (LevelsTransition.isLevel2)
        {
            remainingTime = 10;
        }
    }
}
