using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel2 : MonoBehaviour
{
    public Button[] trail21Buttons = new Button[20];
    public Button[] trail22Buttons = new Button[20];
    public int score = 15;
    private int buttonNum = 0;

    public LevelsHandler levelsHandler;
    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();
        int trailSelection = levelsHandler.GetTrailIndex();

        if (levelsHandler.level_2 == true && trailSelection == 0) {
            InitializeButtons();
        }
        else if (levelsHandler.level_2 == true && trailSelection == 1)
        {
            InitializeButtons2();
        }


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

        if (score == 35)
        {
            levelsHandler.level_1 = false;
            levelsHandler.level_2 = false;
            levelsHandler.level_3 = true;
            Debug.Log("Level Passed");
        }
    }
    void InitializeButtons()
    {
            levelsHandler.level_2 = true;
  
                for (int i = 0; i < trail21Buttons.Length; i++)
                {
                    int buttonIndex = i; // Capture the current index to avoid closure issues
                    trail21Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
                }

    }
    void InitializeButtons2()
    {
        for (int i = 0; i < trail22Buttons.Length; i++)
        {
            int buttonIndex = i; // Capture the current index to avoid closure issues
            trail22Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
        }
    }
}