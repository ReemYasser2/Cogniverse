using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel1 : MonoBehaviour
{
   
    public LevelsHandler levelsHandler;

    public Button[] trail11Buttons = new Button[15];
    public Button[] trail12Buttons = new Button[15];
    public GameObject instructionsLevel2Canvas;
    int trailSelection;
    public int levelOneScore = 0;
    public int mistakes = 0;
    private int buttonNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();
        trailSelection = levelsHandler.GetTrailIndex();
        if (levelsHandler.level_1 == true && trailSelection == 0)
        {
            InitializeButtons();
        }
        else if (levelsHandler.level_1 == true && trailSelection == 1)
        {
            InitializeButtons2();
        }
    }

    // Update is called once per frame

    void TaskOnClick(int buttonNo)
    {
        // Output this to the console when any button is clicked
        Debug.Log("Button clicked = " + (buttonNo + 1)); // Adjusted index for human-friendly numbering

        // Check if the button is pressed in the correct order relative to the previous button
        if (buttonNo == buttonNum + 1)
        {
            levelOneScore++;
            Debug.Log("Score up");
            Debug.Log(levelOneScore);
            buttonNum = buttonNo;
        }
        else if (buttonNo == 0)
        {
            levelOneScore++;
            Debug.Log("Score up");
            Debug.Log(levelOneScore);
            buttonNum = buttonNo;
        }
        else
        {
            levelOneScore--;
            mistakes++;
            Debug.Log("Score --");
            Debug.Log(levelOneScore);

        }

        if (levelOneScore == 15 || levelOneScore + mistakes == 15)
        {
            
            levelsHandler.level_1 = false;
            levelsHandler.level_2 = true;
            levelsHandler.level_3 = false;
            instructionsLevel2Canvas.SetActive(true);
            Debug.Log("Level Passed");
        }
    }
    
    void InitializeButtons()
    {
            for (int i = 0; i < trail11Buttons.Length; i++)
            {
                int buttonIndex = i; // Capture the current index to avoid closure issues
                trail11Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
            }
            for (int i = 0; i < trail12Buttons.Length; i++)
            {
                int buttonIndex = i; // Capture the current index to avoid closure issues
                trail12Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
            }
        
    }
    void InitializeButtons2()
    {
        for (int i = 0; i < trail12Buttons.Length; i++)
        {
            int buttonIndex = i; // Capture the current index to avoid closure issues
            trail12Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
        }
    }

}


