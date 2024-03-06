using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel2 : MonoBehaviour
{
    public Button[] trail2Buttons = new Button[20];

    public int score = 15;
    private int buttonNum = 0;

    public LevelsHandler levelsHandler;
    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();

        for (int i = 0; i < trail2Buttons.Length; i++)
        {
            int buttonIndex = i; // Capture the current index to avoid closure issues
            trail2Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
        }
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
                { score++;  Debug.Log("Score up"); }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 2:
                Debug.Log("Button 3 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 3:
                Debug.Log("Button 4 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 4:
                Debug.Log("Button 5 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 5:
                Debug.Log("Button 6 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                {  score--; }
                buttonNum = buttonNo;
                break;
            case 6:
                Debug.Log("Button 7 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++;  }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 7:
                Debug.Log("Button 8 pressed!");
                if (buttonNo - buttonNum == 1)
                {  score++; }
                else
                {  score--; }
                buttonNum = buttonNo;
                break;
            case 8:
                Debug.Log("Button 9 pressed!");
                if (buttonNo - buttonNum == 1)
                {  score++; }
                else
                {  score--; }
                buttonNum = buttonNo;
                break;
            case 9:
                Debug.Log("Button 10 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 10:
                Debug.Log("Button 11 pressed!");
                if (buttonNo - buttonNum == 1)
                {  score++;  }
                else
                {  score--; }
                buttonNum = buttonNo;
                break;
            case 11:
                Debug.Log("Button 12 pressed!");
                if (buttonNo - buttonNum == 1)
                {   score++;  }
                else
                {  score--; }
                buttonNum = buttonNo;
                break;
            case 12:
                Debug.Log("Button 13 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 13:
                Debug.Log("Button 14 pressed!");
                if (buttonNo - buttonNum == 1)
                {score++; }
                else
                {  score--;  }
                buttonNum = buttonNo;
                break;
            case 14:
                Debug.Log("Button 15 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++;  }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 15:
                Debug.Log("Button 16 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 16:
                Debug.Log("Button 17 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 17:
                Debug.Log("Button 18 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 18:
                Debug.Log("Button 19 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            case 19:
                Debug.Log("Button 20 pressed!");
                if (buttonNo - buttonNum == 1)
                { score++; }
                else
                { score--; }
                buttonNum = buttonNo;
                break;
            default:
                break;
        }
        if (score == 35)
        {
            levelsHandler.level_2 = false;
            levelsHandler.level_3 = true;
        }
    }
}
