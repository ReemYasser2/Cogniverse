using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel2 : MonoBehaviour
{
    public Button[] trail21Buttons = new Button[20];
    public Button[] trail22Buttons = new Button[20];
    public int levelTwoScore = 0;
    public int mistakes = 0;
    private int buttonNum = 0;
    public GameObject instructionsLevel3Canvas;
    public LevelsHandler levelsHandler;
    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();
        int trailSelection = levelsHandler.GetTrailIndex();

        if (trailSelection == 0) {
            InitializeButtons();
        }
        else if ( trailSelection == 1)
        {
            InitializeButtons2();
        }


    }
    void TaskOnClick(int buttonNo)
    {
        // Output this to the console when any button is clicked

        // Check if the button is pressed in the correct order relative to the previous button
        if (buttonNo == buttonNum + 1)
        {
            levelTwoScore++;
            Debug.Log("Score up");
            Debug.Log(levelTwoScore);
            buttonNum = buttonNo;
        }
        else if (buttonNo == 0)
        {
            levelTwoScore++;
            Debug.Log("Score up");
            Debug.Log(levelTwoScore);
            buttonNum = buttonNo;
        }
        else
        {
            levelTwoScore--;
            Debug.Log("Score --");
            Debug.Log(levelTwoScore);
        }
        

        if (levelTwoScore == 20 || levelTwoScore+mistakes == 20)
        {
            levelsHandler.level_1 = false;
            levelsHandler.level_2 = false;
            levelsHandler.level_3 = true;
            instructionsLevel3Canvas.SetActive(true);
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
            for (int i = 0; i < trail22Buttons.Length; i++)
            {
                int buttonIndex = i; // Capture the current index to avoid closure issues
                trail22Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
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