using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickHolding : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public GameObject messageCanvas;
    public float holdThreshold = 0.1f;

    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject menuCanvas;

    private bool paused = false;
   
    // Start is called before the first frame update
    void Start()
    {

    }

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
                if (menuCanvas.activeSelf == false && instructionsLevel1Canvas.activeSelf == false && instructionsLevel2Canvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false)
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
                    //PauseGame.Pause();
                    /*
                    if (paused)
                    {
                        Debug.Log("shatoor");
                        Time.timeScale = 0;
                        paused = true;
                    }
                    */
                }
            }
        }
        else
        {
            
            ShowHoldMessage();
            if ((LevelsTransition.isLevel1 || LevelsTransition.isLevel2) && !LevelsTransition.isGameOver)
            {
                if (menuCanvas.activeSelf == false && instructionsLevel1Canvas.activeSelf == false && instructionsLevel2Canvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false)
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
                    //PauseGame.Pause();
                    /*
                    if (!paused)
                    {
                        Debug.Log("wa7sh");
                        Time.timeScale = 1;
                        paused = false;
                    }
                    */
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
