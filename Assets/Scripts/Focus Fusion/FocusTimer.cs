using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FocusTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    public float remainingTime;
    private bool isPlayPressed = false;
    public static bool isTimeOver = false;
    public GameObject gameOverCanvas;

    public Color criticalColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        timerText.color = Color.white;
        /*
        if (level1)
        {
            remainingTime = 5;
        }
        else if (level2)
        {
            remainingTime = 10;
        }
        */
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
                // Timer is over
                isTimeOver = true;
                gameOverCanvas.SetActive(true);
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
        /*
        // Reset the timer to its initial value
        if (level1)
        {
            remainingTime = 5;
        }
        else if (level2)
        {
            remainingTime = 10;
        }
        */
    }
}
