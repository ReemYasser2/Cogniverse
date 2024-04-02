using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel2 : MonoBehaviour
{
    public Button[] trail21Buttons = new Button[20];
    public Button[] trail22Buttons = new Button[20];
    public Button[] mistakesIndicator_2 = new Button[3];
    public int levelTwoScore = 0;
    public GameObject trail21;
    public GameObject trail22;
    public int mistakes = 0;
    private int buttonNum = 0;
    public LevelsHandler levelsHandler;
    public TrailMenuHandler menuHandler;
    public float scorePercent = 0;
    public float levelTwoAccuracy = 0;
    public int correctCounter = 0;
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

        Button clickedButton;
        if (trail21.activeSelf)
        {
            clickedButton = trail21Buttons[buttonNo];
        }
        else
        {
            clickedButton = trail22Buttons[buttonNo];
        }

        // Check if the button is pressed in the correct order relative to the previous button
        if (buttonNo == buttonNum + 1)
        {
            if (buttonNo == 1 && buttonNum == 0)
            {
                if (levelTwoScore <= 0 && mistakes == 0)
                {
                    levelTwoScore--;
                    mistakes++;
                    clickedButton.GetComponent<Image>().color = Color.red;
                    ReinforcementManagement.PositiveReinforcementDecrement();
                    MistakesIndicator();
                    buttonNum = buttonNo;
                    //scorePercent = levelTwoScore / 20;
                }
                else if (levelTwoScore < -1 && mistakes > 0)
                {
                    levelTwoScore--;
                    mistakes++;
                    MistakesIndicator();
                    clickedButton.GetComponent<Image>().color = Color.red;
                    ReinforcementManagement.PositiveReinforcementDecrement();
                    buttonNum = buttonNo;
                }
                else
                {
                    ResetButtonColors(buttonNo);
                    ColorCorrectorDoubleClick(buttonNo);

                    clickedButton.GetComponent<Image>().color = Color.green;
                    ReinforcementManagement.PositiveReinforcementIncrement();
                    levelTwoScore++;
                    correctCounter++;
                    buttonNum = buttonNo;
                    //scorePercent = levelTwoScore / 20;
                }
            }
            else
            {
                ResetButtonColors(buttonNo);
                ColorCorrectorDoubleClick(buttonNo);

                clickedButton.GetComponent<Image>().color = Color.green;
                ReinforcementManagement.PositiveReinforcementIncrement();
                levelTwoScore++;
                correctCounter++;
                buttonNum = buttonNo;
                //scorePercent = levelTwoScore / 20;
            }
                
        }
        else if (buttonNo == 0)
        { if (levelTwoScore <= 0)
            {
                ResetButtonColors(buttonNo);
                ColorCorrectorDoubleClick(buttonNo);

                clickedButton.GetComponent<Image>().color = Color.green;
                ReinforcementManagement.PositiveReinforcementIncrement();
                levelTwoScore++;
                correctCounter++;
                buttonNum = buttonNo;
                //scorePercent = levelTwoScore / 20;
            }
            else
            {
                levelTwoScore--;
                mistakes++;
                clickedButton.GetComponent<Image>().color = Color.red;
                ReinforcementManagement.PositiveReinforcementDecrement();
                MistakesIndicator();
                //Debug.Log("Score --");
                //Debug.Log(levelTwoScore);
                //scorePercent = levelTwoScore / 20;
            }
         }
        else
        {
            clickedButton.GetComponent<Image>().color = Color.red;
            ReinforcementManagement.PositiveReinforcementDecrement();

            levelTwoScore--;
            mistakes++;
            MistakesIndicator();
            //scorePercent = levelTwoScore / 20;
        }
        scorePercent = levelTwoScore / 20;
        StartCoroutine(ResetTextAfterDelay());

        if ((levelTwoScore == 20 || levelTwoScore+mistakes == 20) && (ReinforcementManagement.elapsedTime < 60f) && mistakes < 3) // pass lvl 2
        {
            CountUpTimer.OverallTime();
            Debug.Log("overall time: " + ReinforcementManagement.overallTime);
            ReinforcementManagement.numberOfMistakeslvl2 = mistakes;
            ResetButtonColors(0);

            ReinforcementManagement.level_1 = false;
            ReinforcementManagement.level_2 = false;
            ReinforcementManagement.level_3 = true;
            // timer end
            ReinforcementManagement.elapsedTime = 0f;
            ReinforcementManagement.isPlayPressed = false;
            menuHandler.completeLevel2Canvas.SetActive(true);
            menuHandler.level3Button.SetActive(true);
            menuHandler.level3LockButton.SetActive(false);
            levelTwoAccuracy = CalculateAccuracy(correctCounter, 20);
            menuHandler.scorelvl2Text.text = $"Your Score: {levelTwoScore}";
            Debug.Log("Level Passed");
            ResetIndicator();
        }
        else if (mistakes >= 3 || ReinforcementManagement.elapsedTime > 60f) // didn't pass the level, replay 
        {
            menuHandler.instructionsLevel2RetryCanvas.SetActive(true);
            menuHandler.scorelvl2retryText.text = $"Your Score: {levelTwoScore}";
            ReinforcementManagement.elapsedTime = 0f;
            ReinforcementManagement.isPlayPressed = false;
            levelTwoAccuracy = 0;
            correctCounter = 0; 
            ResetIndicator();
        }
    }
    void InitializeButtons()
    {
        ReinforcementManagement.level_2 = true;
  
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

    public void ResetButtonColors(int startIndex)
    {
        Color normalColor = new Color(0.98f, 0.98f, 0.7f);
        for (int i = startIndex; i < trail21Buttons.Length; i++)
        {
            trail21Buttons[i].GetComponent<Image>().color = normalColor;
        }
        for (int i = startIndex; i < trail22Buttons.Length; i++)
        {
            trail22Buttons[i].GetComponent<Image>().color = normalColor;
        }
    }
    public void ColorCorrectorDoubleClick(int endIndex)
    {
        for (int i = 0; i < endIndex; i++)
        {
            trail21Buttons[i].GetComponent<Image>().color = Color.green;
        }
        for (int i = 0; i < endIndex; i++)
        {
            trail22Buttons[i].GetComponent<Image>().color = Color.green;
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
                mistakesIndicator_2[0].GetComponent<Image>().color = Color.red;
            }
            else if (mistakes == 2)
            {
                mistakesIndicator_2[1].GetComponent<Image>().color = Color.red;
            }
            else if (mistakes == 3)
            {
                mistakesIndicator_2[2].GetComponent<Image>().color = Color.red;
            }
            else
            {
                for (int i = 0; i < mistakesIndicator_2.Length; i++)
                {
                    mistakesIndicator_2[i].GetComponent<Image>().color = Color.green;
                }
            }
    }
    void ResetIndicator()
    {
        for (int i = 0; i < mistakesIndicator_2.Length; i++)
            {
                mistakesIndicator_2[i].GetComponent<Image>().color = Color.green;
            }
    }
    float CalculateAccuracy(int correct, int total)
    {
        float acc = correct / total;
        return acc;
    }
}