using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUpTimer : MonoBehaviour
{
    private string timerText;
    float elapsedTime;
    private bool isPlayPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlayPressed)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText = string.Format("{0:00}:{1:00}", minutes, seconds);
            Debug.Log(timerText);
        }
            
    }

    // This function is called when the game starts to start the timer
    public void StartGame()
    {
        isPlayPressed = true;
    }
}
