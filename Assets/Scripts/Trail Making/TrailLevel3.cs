using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] trail31Buttons = new Button[30];
    public Button[] trail32Buttons = new Button[30];

    public int score = 35;
    private int buttonNum = 0;

    public LevelsHandler levelsHandler;
    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();

        InitializeButtons();
    }
    void TaskOnClick(int buttonNo)
    {
        // Output this to the console when any button is clicked
        Debug.Log("Button clicked = " + (buttonNo + 1)); // Adjusted index for human-friendly numbering

        // Check if the button is pressed in the correct order relative to the previous button
        if (buttonNo == buttonNum + 1)
        {
            score++;
            Debug.Log("Score up");
        }
        else if (buttonNo == 0)
        {
            score++;
            Debug.Log("Score up");
        }
        else
        {
            score--;
            Debug.Log("Score --");
        }

        buttonNum = buttonNo;

        if (score == 65)
        {
            Debug.Log("Heighest Score");
        }
    }
    void InitializeButtons()
    {
        {
            if (levelsHandler.level_3 == true && levelsHandler.selectedTrail == 0)
            {
                for (int i = 0; i < trail31Buttons.Length; i++)
                {
                    int buttonIndex = i; // Capture the current index to avoid closure issues
                    trail31Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
                }
            }
            else if (levelsHandler.level_3 == true && levelsHandler.selectedTrail == 1)
            {
                for (int i = 0; i < trail32Buttons.Length; i++)
                {
                    int buttonIndex = i; // Capture the current index to avoid closure issues
                    trail32Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
                }
            }
        }
    }
}
