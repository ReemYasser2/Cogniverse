using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickHolding : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public GameObject messageCanvas;
    public float holdThreshold = 0.1f;

    private bool paused = false;
    public WhackMenuHandler whackMenuHandler;

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the hand and the stick's socket
        float distanceToSocketLeftHand = Vector3.Distance(transform.position, leftHand.position);
        float distanceToSocketRightHand = Vector3.Distance(transform.position, rightHand.position);

        // Check if the hand is close enough to the socket
        if (distanceToSocketLeftHand < holdThreshold || distanceToSocketRightHand < holdThreshold)
        {
            HideHoldMessage();
            if ((ScoreCalculationWhack.isLevel1 || ScoreCalculationWhack.isLevel2) && !ScoreCalculationWhack.isGameOver)
            {
                if (!whackMenuHandler.menuCanvas.activeSelf)
                {

                    // Check if the timer is paused
                    if (Mathf.Approximately(Time.timeScale, 0f))
                    {
                        Debug.Log("Timer is paused");
                        PauseGame.Pause();
                        StopWatch1Whack.PauseTimer();
                        StopWatch2Whack.PauseTimer();
                    }
                    else
                    {
                        //Debug.Log("Timer is running");
                    }
                }
            }
        }
        else
        {

            ShowHoldMessage();
           if ((ScoreCalculationWhack.isLevel1 || ScoreCalculationWhack.isLevel2) && !ScoreCalculationWhack.isGameOver)
            {
                if (!whackMenuHandler.menuCanvas.activeSelf)
                {
                    // Check if the timer is paused
                    if (Mathf.Approximately(Time.timeScale, 0f))
                    {
                        Debug.Log("Timer is paused");
                    }
                    else
                    {
                        //Debug.Log("Timer is running");
                        PauseGame.Pause();
                        StopWatch1Whack.ResumeTimer();
                        StopWatch2Whack.ResumeTimer();
                    }
                }
            }
        }
    }

    private void ShowHoldMessage()
    {
        messageCanvas.SetActive(true);
    }

    private void HideHoldMessage()
    {
        messageCanvas.SetActive(false);
    }
}