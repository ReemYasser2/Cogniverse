using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float remainingTime;
    private bool isPlayPressed = false;
    public GameObject gameOverCanvas;

    // Update is called once per frame
    void Update()
    {
        if (isPlayPressed)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                // Game over
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
    }
}
