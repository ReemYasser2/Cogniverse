using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrailLevel1 : MonoBehaviour
{
   
    public LevelsHandler levelsHandler;

    public Button[] trail11Buttons = new Button[15];
    public Button[] trail12Buttons = new Button[15];
    public Button[] mistakesIndicator = new Button[3];
    public GameObject completeLevel1Canvas;
    public GameObject trail11;
    public GameObject trail12;
    int trailSelection;
    public int levelOneScore = 0;
    public int mistakes = 0;
    private int buttonNum = 0;
    public TextMeshProUGUI scorelvl1Text;
    public GameObject instructionsLevel1RetryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();
        trailSelection = levelsHandler.GetTrailIndex();

        if (levelsHandler.level_1 == true && trailSelection==0)
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

        ///Debug.Log("Button clicked = " + (buttonNo + 1)); // Adjusted index for human-friendly numbering

        Button clickedButton;
        if (trail11.activeSelf)
        {
            clickedButton = trail11Buttons[buttonNo];
        }
        else
        {
            clickedButton = trail12Buttons[buttonNo];
        }

        // Check if the button is pressed in the correct order relative to the previous button
        if (buttonNo == buttonNum + 1)
        {
            ResetButtonColors(buttonNo);
            ColorCorrectorDoubleClick(buttonNo);

            clickedButton.GetComponent<Image>().color = Color.green;
            levelOneScore++;
            //Debug.Log("Score up");
            //Debug.Log(levelOneScore);
            buttonNum = buttonNo;
            ReinforcementManagement.PositiveReinforcementIncrement();

        }
        else if (buttonNo == 0)
        { 
            if (levelOneScore <= 0)
            {
                clickedButton.GetComponent<Image>().color = Color.green;
                levelOneScore++;
                //Debug.Log("Score up");
                //Debug.Log(levelOneScore);
                buttonNum = buttonNo;

                ReinforcementManagement.PositiveReinforcementIncrement();

            }
            else {
                levelOneScore--;
                mistakes++;
                if (mistakes == 1 )
                {
                    mistakesIndicator[0].GetComponent<Image>().color = Color.red;
                }
                else if (mistakes == 2 )
                {
                     mistakesIndicator[1].GetComponent<Image>().color = Color.red;
                }
                else if (mistakes == 3 )
                {
                    
                    mistakesIndicator[2].GetComponent<Image>().color = Color.red;
                }
                else
                {
                    for (int i = 0; i < mistakesIndicator.Length; i++)
                    {
                        mistakesIndicator[i].GetComponent<Image>().color = Color.green;
                    }
                }
                clickedButton.GetComponent<Image>().color = Color.red;
                ReinforcementManagement.PositiveReinforcementDecrement();
                //Debug.Log(levelOneScore);
                } 
        }
        else
        {

            clickedButton.GetComponent<Image>().color = Color.red;
            ReinforcementManagement.PositiveReinforcementDecrement();

            levelOneScore--;
            mistakes++;
            if (mistakes == 1)
            {
                mistakesIndicator[0].GetComponent<Image>().color = Color.red;
            }
            else if (mistakes == 2)
            {
                 mistakesIndicator[1].GetComponent<Image>().color = Color.red;
            }
            else if (mistakes == 3)
            {
                
                mistakesIndicator[2].GetComponent<Image>().color = Color.red;
            }
            else
            {
                for (int i = 0; i < mistakesIndicator.Length; i++)
                {
                    mistakesIndicator[i].GetComponent<Image>().color = Color.green;
                }
            }
            //Debug.Log("Score --");
            //Debug.Log(levelOneScore);

        }
        StartCoroutine(ResetTextAfterDelay());

        if ((levelOneScore == 15 || levelOneScore + mistakes == 15) && (CountUpTimer.elapsedTime < 30f ) && mistakes < 3)
        {
            ResetButtonColors(0);
            levelsHandler.level_1 = false;
            levelsHandler.level_2 = true;
            levelsHandler.level_3 = false;
            // timer end
            CountUpTimer.elapsedTime = 0f;
            CountUpTimer.isPlayPressed = false;
            completeLevel1Canvas.SetActive(true);
            scorelvl1Text.text = $"Your Score: {levelOneScore}";
            Debug.Log("Level Passed");
            for (int i = 0; i < mistakesIndicator.Length; i++)
            {
                mistakesIndicator[i].GetComponent<Image>().color = Color.green;
            }
        }
        else if (mistakes >= 3 || CountUpTimer.elapsedTime > 30f)  // didn't pass the level, replay
        {
            instructionsLevel1RetryCanvas.SetActive(true);
            CountUpTimer.elapsedTime = 0f;
            CountUpTimer.isPlayPressed = false;
            for (int i = 0; i < mistakesIndicator.Length; i++)
            {
                mistakesIndicator[i].GetComponent<Image>().color = Color.green;
            }
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


    public void ResetButtonColors(int startIndex)
    {
        Color normalColor = new Color(0.98f, 0.98f, 0.7f);
        for (int i = startIndex; i < trail11Buttons.Length; i++)
        {
            trail11Buttons[i].GetComponent<Image>().color = normalColor; 
        }
        for (int i = startIndex; i < trail12Buttons.Length; i++)
        {
            trail12Buttons[i].GetComponent<Image>().color = normalColor; 
        }
    }


    public void ColorCorrectorDoubleClick(int endIndex)
    {
        for (int i = 0; i < endIndex; i++)
        {
            trail11Buttons[i].GetComponent<Image>().color = Color.green;
        }
        for (int i = 0; i < endIndex; i++)
        {
            trail12Buttons[i].GetComponent<Image>().color = Color.green;
        }
    }

    IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);

        // After waiting for the specified duration, reset the text to nothing
        ReinforcementManagement.reinforcementText = "";
    }
}


