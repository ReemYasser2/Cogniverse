using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel1 : MonoBehaviour
{
   
    public LevelsHandler levelsHandler;

    public Button[] trail11Buttons = new Button[15];
    public Button[] trail12Buttons = new Button[15];


    public int score = 0;
    private int buttonNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();
        InitializeButtons();


    }

    // Update is called once per frame

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

        if (score == 15)
        {
            levelsHandler.level_1 = false;
            levelsHandler.level_2 = true;
            levelsHandler.level_3 = false;
            Debug.Log("Level Passed");
        }
    }
    void InitializeButtons()
    {
        //levelsHandler.TrailSelection();
        Debug.Log(" INITIAL");
        if (levelsHandler.level_1 == true && levelsHandler.selectedTrail == 0)
        {
            Debug.Log(" F");
            for (int i = 0; i < trail11Buttons.Length; i++)
            {
                int buttonIndex = i; // Capture the current index to avoid closure issues
                trail11Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
            }
        }
        else if (levelsHandler.level_1 == true && levelsHandler.selectedTrail == 1)
        {
            Debug.Log(" S");
            for (int i = 0; i < trail12Buttons.Length; i++)
            {
                int buttonIndex = i; // Capture the current index to avoid closure issues
                trail12Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
            }
        }
    }

}


