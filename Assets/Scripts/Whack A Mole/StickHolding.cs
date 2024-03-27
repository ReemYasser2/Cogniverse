using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickHolding : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public GameObject messageCanvas;
    public float holdThreshold = 0.1f;

    public GameObject instructionsLevel1selectlvlCanvas;
    public GameObject instructionsLevel2selectlvlCanvas;

    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject menuCanvas;

    private bool paused = false;

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

            if ((LevelsTransition.isLevel1 || LevelsTransition.isLevel2) && !LevelsTransition.isGameOver)
            {

                // Check if the timer is paused
                if (Mathf.Approximately(Time.timeScale, 0f))
                {
                    Debug.Log("Timer is paused");
                    PauseGame.Pause();
                }
                else
                {
                    Debug.Log("Timer is running");
                }
            }
        }
        else
        {

            ShowHoldMessage();
            if ((LevelsTransition.isLevel1 || LevelsTransition.isLevel2) && !LevelsTransition.isGameOver)
            {
                // Check if the timer is paused
                if (Mathf.Approximately(Time.timeScale, 0f))
                {
                    Debug.Log("Timer is paused");
                }
                else
                {
                    Debug.Log("Timer is running");
                    PauseGame.Pause();
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