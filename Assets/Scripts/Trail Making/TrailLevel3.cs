using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] trail31Buttons = new Button[30];
    public Button[] trail32Buttons = new Button[30];

    public int levelThreeScore = 0;
    public int mistakes = 0;
    private int buttonNum = 0;

    public LevelsHandler levelsHandler;

    public GameObject gameOverCanvas;

    public static bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();
        int trailSelection = levelsHandler.GetTrailIndex();
        if ( trailSelection == 0)
        {
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
        //Debug.Log("Button clicked = " + (buttonNo + 1)); // Adjusted index for human-friendly numbering

        // Check if the button is pressed in the correct order relative to the previous button
        if (buttonNo == buttonNum + 1)
        {
            levelThreeScore++;
            //Debug.Log("Score up");
            //Debug.Log(levelThreeScore);
            buttonNum = buttonNo;
        }
        else if (buttonNo == 0)
        {
            if (levelThreeScore <= 0) {
                levelThreeScore++;
                //Debug.Log("Score up");
                //Debug.Log(levelThreeScore);
                buttonNum = buttonNo;
            }
            else
            {
                levelThreeScore--;
                mistakes++;
                //Debug.Log("Score --");
            } 
        }
        else
        {
            levelThreeScore--;
            mistakes++;
            ///Debug.Log("Score --");
        }


        if (levelThreeScore == 30 || levelThreeScore + mistakes == 30)
        {
            Debug.Log("Heighest Score");
            gameOverCanvas.SetActive(true);
            isGameOver = true;
        }
    }
    void InitializeButtons()
    {
        {
            levelsHandler.level_3 = true;

                for (int i = 0; i < trail31Buttons.Length; i++)
                {
                    int buttonIndex = i; // Capture the current index to avoid closure issues
                    trail31Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
                }
            for (int i = 0; i < trail32Buttons.Length; i++)
            {
                int buttonIndex = i; // Capture the current index to avoid closure issues
                trail32Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
            }

        }
    }
    void InitializeButtons2()
    {
        for (int i = 0; i < trail32Buttons.Length; i++)
        {
            int buttonIndex = i; // Capture the current index to avoid closure issues
            trail32Buttons[i].onClick.AddListener(() => TaskOnClick(buttonIndex));
        }
    }
}
