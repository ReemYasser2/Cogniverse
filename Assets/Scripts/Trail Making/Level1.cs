using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    public Button[] trail1Buttons = new Button[15];
    public Button[] trail2Buttons = new Button[20];
    public Button[] trail3Buttons = new Button[30];
    
    public int score = 0;
    private int buttonNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < trail1Buttons.Length; i++)
        {
            int buttonIndex = i; // Capture the current index to avoid closure issues
            trail1Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick(int buttonNo)
    {
        // Output this to the console when any button is clicked
        Debug.Log("Button clicked = " + (buttonNo + 1)); // Adjusted index for human-friendly numbering

        // Compare which button is pressed using a switch statement
        switch (buttonNo)
        {
            case 0:
                Debug.Log("Button 1 pressed!");
                score++;
                buttonNum = buttonNo;
                break;
            case 1:
                Debug.Log("Button 2 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                    Debug.Log("Score up");
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 2:
                Debug.Log("Button 3 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 3:
                Debug.Log("Button 4 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 4:
                Debug.Log("Button 5 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 5:
                Debug.Log("Button 6 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 6:
                Debug.Log("Button 7 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 7:
                Debug.Log("Button 8 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 8:
                Debug.Log("Button 9 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 9:
                Debug.Log("Button 10 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 10:
                Debug.Log("Button 11 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 11:
                Debug.Log("Button 12 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 12:
                Debug.Log("Button 13 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 13:
                Debug.Log("Button 14 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            case 14:
                Debug.Log("Button 15 pressed!");
                if (buttonNo - buttonNum == 1)
                {
                    score++;
                }
                else
                {
                    score--;
                }
                buttonNum = buttonNo;
                break;
            default:
                break;
        }
    }
}
