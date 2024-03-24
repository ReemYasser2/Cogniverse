using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] trail31Buttons = new Button[30];
    public Button[] trail32Buttons = new Button[30];
    public GameObject trail31;
    public GameObject trail32;
    public int levelThreeScore = 0;
    public int mistakes = 0;
    private int buttonNum = 0;

    public LevelsHandler levelsHandler;

    public GameObject completeLevel3Canvas;

    public static bool isGameOver;
    public TextMeshProUGUI scorelvl3Text;

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

        Button clickedButton;
        if (trail31.activeSelf)
        {
            clickedButton = trail31Buttons[buttonNo];
        }
        else
        {
            clickedButton = trail32Buttons[buttonNo];
        }

        // Check if the button is pressed in the correct order relative to the previous button
        if (buttonNo == buttonNum + 1)
        {
            ResetButtonColors(buttonNo);
            ColorCorrectorDoubleClick(buttonNo);

            clickedButton.GetComponent<Image>().color = Color.green;
            ReinforcementManagement.PositiveReinforcementIncrement();
            levelThreeScore++;
            //Debug.Log("Score up");
            //Debug.Log(levelThreeScore);
            buttonNum = buttonNo;
        }
        else if (buttonNo == 0)
        {
            if (levelThreeScore <= 0) {
                clickedButton.GetComponent<Image>().color = Color.green;
                ReinforcementManagement.PositiveReinforcementIncrement();
                levelThreeScore++;
                //Debug.Log("Score up");
                //Debug.Log(levelThreeScore);
                buttonNum = buttonNo;
            }
            else
            {
                levelThreeScore--;
                mistakes++;
                clickedButton.GetComponent<Image>().color = Color.red;
                ReinforcementManagement.PositiveReinforcementDecrement();
                //Debug.Log("Score --");
            } 
        }
        else
        {
            clickedButton.GetComponent<Image>().color = Color.red;
            ReinforcementManagement.PositiveReinforcementDecrement();

            levelThreeScore--;
            mistakes++;
            //Debug.Log("Score --");
        }
        StartCoroutine(ResetTextAfterDelay());


        if (levelThreeScore == 30 || levelThreeScore + mistakes == 30)
        {
            Debug.Log("Heighest Score");
            // timer end
            CountUpTimer.elapsedTime = 0f;
            CountUpTimer.isPlayPressed = false;
            completeLevel3Canvas.SetActive(true);
            scorelvl3Text.text = $"Your Score: {levelThreeScore}";
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

    public void ResetButtonColors(int startIndex)
    {
        Color normalColor = new Color(0.98f, 0.98f, 0.7f);
        for (int i = startIndex; i < trail31Buttons.Length; i++)
        {
            trail31Buttons[i].GetComponent<Image>().color = normalColor;
        }
        for (int i = startIndex; i < trail32Buttons.Length; i++)
        {
            trail32Buttons[i].GetComponent<Image>().color = normalColor;
        }
    }


    public void ColorCorrectorDoubleClick(int endIndex)
    {
        for (int i = 0; i < endIndex; i++)
        {
            trail31Buttons[i].GetComponent<Image>().color = Color.green;
        }
        for (int i = 0; i < endIndex; i++)
        {
            trail32Buttons[i].GetComponent<Image>().color = Color.green;
        }
    }

    IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);

        // After waiting for the specified duration, reset the text to nothing
        ReinforcementManagement.reinforcementText = "";
    }
}
