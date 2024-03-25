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
    public Button[] mistakesIndicator_3 = new Button[3];

    public GameObject trail31;
    public GameObject trail32;
    public int levelThreeScore = 0;
    public int mistakes = 0;
    private int buttonNum = 0;

    public LevelsHandler levelsHandler;

    public GameObject completeLevel3Canvas;

    public static bool isGameOver;
    public TextMeshProUGUI scorelvl3Text;
    public GameObject instructionsLevel3RetryCanvas;

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
            if (buttonNo == 1 && buttonNum == 0)
            {
                if (levelThreeScore <= 0 && mistakes == 0)
                {
                    levelThreeScore--;
                    mistakes++;
                    clickedButton.GetComponent<Image>().color = Color.red;
                    ReinforcementManagement.PositiveReinforcementDecrement();
                    MistakesIndicator();
                    buttonNum = buttonNo;
                }
                else
                {
                    ResetButtonColors(buttonNo);
                    ColorCorrectorDoubleClick(buttonNo);

                    clickedButton.GetComponent<Image>().color = Color.green;
                    ReinforcementManagement.PositiveReinforcementIncrement();
                    levelThreeScore++;
                    buttonNum = buttonNo;
                }
            }
            else
            {
                ResetButtonColors(buttonNo);
                ColorCorrectorDoubleClick(buttonNo);

                clickedButton.GetComponent<Image>().color = Color.green;
                ReinforcementManagement.PositiveReinforcementIncrement();
                levelThreeScore++;
                buttonNum = buttonNo;
            }
            
        }
        else if (buttonNo == 0)
        {
            if (levelThreeScore <= 0) {
                ResetButtonColors(buttonNo);
                ColorCorrectorDoubleClick(buttonNo);

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
                MistakesIndicator();
                //Debug.Log("Score --");
            } 
        }
        else
        {
            clickedButton.GetComponent<Image>().color = Color.red;
            ReinforcementManagement.PositiveReinforcementDecrement();

            levelThreeScore--;
            mistakes++;
            MistakesIndicator();
            //Debug.Log("Score --");
        }
        StartCoroutine(ResetTextAfterDelay());


        if ((levelThreeScore == 30 || levelThreeScore + mistakes == 30) && (CountUpTimer.elapsedTime < 120f) && mistakes < 3)
        {
            Debug.Log("Heighest Score");
            // timer end
            CountUpTimer.elapsedTime = 0f;
            CountUpTimer.isPlayPressed = false;
            completeLevel3Canvas.SetActive(true);
            scorelvl3Text.text = $"Your Score: {levelThreeScore}";
            isGameOver = true;
            ResetIndicator();
        } 
        else if(mistakes >= 3 || CountUpTimer.elapsedTime > 120f) // didn't pass the level, replay
        {
            instructionsLevel3RetryCanvas.SetActive(true); 
            CountUpTimer.elapsedTime = 0f;
            CountUpTimer.isPlayPressed = false;
            ResetIndicator();
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
    void MistakesIndicator()
    {
        if (mistakes == 1)
        {
            mistakesIndicator_3[0].GetComponent<Image>().color = Color.red;
        }
        else if (mistakes == 2)
        {
            mistakesIndicator_3[1].GetComponent<Image>().color = Color.red;
        }
        else if (mistakes == 3)
        {
            mistakesIndicator_3[2].GetComponent<Image>().color = Color.red;
        }
        else
        {
            for (int i = 0; i < mistakesIndicator_3.Length; i++)
            {
                mistakesIndicator_3[i].GetComponent<Image>().color = Color.green;
            }
        }
    }
    void ResetIndicator()
    {
        for (int i = 0; i < mistakesIndicator_3.Length; i++)
        {
            mistakesIndicator_3[i].GetComponent<Image>().color = Color.green;
        }
    }
}
