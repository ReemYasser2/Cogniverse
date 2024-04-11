using Firebase.Database;
using System;
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
    public GameObject trail11;
    public GameObject trail12;
    int trailSelection;
    public int levelOneScore = 0;
    public int mistakes = 0;
    private int buttonNum = 0;

    public TrailMenuHandler menuHandler;
    public float scorePercent = 0;

    public float levelOneAccuracy = 0f;
    public float correctCounter = 0;

    public TrailReinforcement TrailReinforcement;
    public DatabaseManager databaseManager;
    // Start is called before the first frame update
    void Start()
    {
        databaseManager.GetStatisticsDataTrail(DatabaseGamesVariables.userID);
        Unlocklevel2();

        levelsHandler = GetComponent<LevelsHandler>();
        levelsHandler = gameObject.AddComponent<LevelsHandler>();
        trailSelection = levelsHandler.GetTrailIndex();

        if (trailSelection == 0)
        {
            InitializeButtons();
        }
        else if (trailSelection == 1)
        {
            InitializeButtons2();
        }


    }

    // Update is called once per frame


    void TaskOnClick(int buttonNo)
    {
        databaseManager.GetStatisticsDataTrail(DatabaseGamesVariables.userID);

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
            if (buttonNo == 1 && buttonNum == 0)
            {
                if (levelOneScore <= 0 && mistakes == 0)
                {

                    levelOneScore--;
                    mistakes++;
                    MistakesIndicator();
                    clickedButton.GetComponent<Image>().color = Color.red;
                    ReinforcementManagement.PositiveReinforcementDecrement();
                    TrailReinforcement.decreaseAudio(ReinforcementManagement.randomIndexPositiveDec);
                    buttonNum = buttonNo;
                }
                else if (levelOneScore < -1 && mistakes > 0)
                {
                    levelOneScore--;
                    mistakes++;
                    MistakesIndicator();
                    clickedButton.GetComponent<Image>().color = Color.red;
                    ReinforcementManagement.PositiveReinforcementDecrement();
                    TrailReinforcement.decreaseAudio(ReinforcementManagement.randomIndexPositiveDec);
                    buttonNum = buttonNo;
                    // scorePercent = levelOneScore / 15;  
                }
                else
                {
                    ResetButtonColors(buttonNo);
                    ColorCorrectorDoubleClick(buttonNo);

                    clickedButton.GetComponent<Image>().color = Color.green;
                    levelOneScore++;
                    correctCounter++;
                    buttonNum = buttonNo;
                    ReinforcementManagement.PositiveReinforcementIncrement();
                    TrailReinforcement.increaseAudio(ReinforcementManagement.randomIndexPositiveInc);
                    // scorePercent = levelOneScore / 15;
                }

            }
            else
            {
                ResetButtonColors(buttonNo);
                ColorCorrectorDoubleClick(buttonNo);

                clickedButton.GetComponent<Image>().color = Color.green;
                levelOneScore++;
                correctCounter++;
                buttonNum = buttonNo;
                ReinforcementManagement.PositiveReinforcementIncrement();
                TrailReinforcement.increaseAudio(ReinforcementManagement.randomIndexPositiveInc);
                //scorePercent = levelOneScore / 15;
            }


        }
        else if (buttonNo == 0)
        {
            if (levelOneScore <= 0)
            {
                ResetButtonColors(buttonNo);
                ColorCorrectorDoubleClick(buttonNo);

                clickedButton.GetComponent<Image>().color = Color.green;
                levelOneScore++;
                correctCounter++;
                buttonNum = buttonNo;

                ReinforcementManagement.PositiveReinforcementIncrement();
                TrailReinforcement.increaseAudio(ReinforcementManagement.randomIndexPositiveInc);
                //scorePercent = levelOneScore / 15;

            }
            else
            {
                levelOneScore--;
                mistakes++;
                MistakesIndicator();
                clickedButton.GetComponent<Image>().color = Color.red;
                ReinforcementManagement.PositiveReinforcementDecrement();
                TrailReinforcement.decreaseAudio(ReinforcementManagement.randomIndexPositiveDec);
                //Debug.Log(levelOneScore);
                //  scorePercent = levelOneScore / 15;
            }
        }
        else
        {

            clickedButton.GetComponent<Image>().color = Color.red;
            ReinforcementManagement.PositiveReinforcementDecrement();
            TrailReinforcement.decreaseAudio(ReinforcementManagement.randomIndexPositiveDec);
            levelOneScore--;
            mistakes++;
            MistakesIndicator();
            //scorePercent = levelOneScore / 15;

        }
        scorePercent = levelOneScore / 15;
        StartCoroutine(ResetTextAfterDelay());

        if ((levelOneScore == 15 || levelOneScore + mistakes == 15) && (ReinforcementManagement.elapsedTime < 30f) && mistakes < 3) // pass lvl1
        {
            menuHandler.completeLevel1Canvas.SetActive(true);
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
            menuHandler.scorelvl1Text.text = $"Your Score: {levelOneScore}";

            // statistics
            CountUpTimer.OverallTime();
            ReinforcementManagement.numberOfMistakeslvl1 = mistakes;
            levelOneAccuracy = CalculateAccuracy(correctCounter, 15);
            scorePercent = levelOneScore / 15;
            // score!

            databaseManager.CreateTrailData(DatabaseGamesVariables.userID, ReinforcementManagement.date, ReinforcementManagement.time,
                1, scorePercent, levelOneAccuracy, ReinforcementManagement.overallTime, ReinforcementManagement.numberOfMistakeslvl1);

            databaseManager.UpdatelvlStatus(DatabaseGamesVariables.userID, DatabaseGamesVariables.trailname, "islvlOnePassed", true);

            float highestScore = LevelsHandler.CheckHighest(scorePercent, DatabaseGamesVariables.highestScoreTrail);
            float highestAccuracy = LevelsHandler.CheckHighest(levelOneAccuracy, DatabaseGamesVariables.highestAccuracyTrail);
            
            updateStat(highestScore, scorePercent, highestAccuracy, levelOneAccuracy);

            ResetLevelone();
            ReinforcementManagement.level1_menu = false;
            ReinforcementManagement.level_1 = false;
        }
        else if (mistakes >= 3 || ReinforcementManagement.elapsedTime > 30f)  // didn't pass the level, replay
        {
            menuHandler.instructionsLevel1RetryCanvas.SetActive(true);
            menuHandler.scorelvl1retryText.text = $"Your Score: {levelOneScore}";

            // statistics
            CountUpTimer.OverallTime();
            ReinforcementManagement.numberOfMistakeslvl1 = mistakes;
            levelOneAccuracy = CalculateAccuracy(correctCounter, 15);
            scorePercent = levelOneScore / 15;

            databaseManager.CreateTrailData(DatabaseGamesVariables.userID, ReinforcementManagement.date, ReinforcementManagement.time,
                1, scorePercent, levelOneAccuracy, ReinforcementManagement.overallTime, ReinforcementManagement.numberOfMistakeslvl1);

            float highestScore = LevelsHandler.CheckHighest(scorePercent, DatabaseGamesVariables.highestScoreTrail);
            float highestAccuracy = LevelsHandler.CheckHighest(levelOneAccuracy, DatabaseGamesVariables.highestAccuracyTrail);

            updateStat(highestScore, scorePercent, highestAccuracy, levelOneAccuracy);


            ResetLevelone();
            ReinforcementManagement.level1_menu = false;
            ReinforcementManagement.level_1 = false;
        }
        databaseManager.GetStatisticsDataTrail(DatabaseGamesVariables.userID);
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
    void MistakesIndicator()
    {
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
    }
    public void ResetIndicator()
    {
        for (int i = 0; i < mistakesIndicator.Length; i++)
        {
            mistakesIndicator[i].GetComponent<Image>().color = Color.green;
        }
    }
    float CalculateAccuracy(float correct, float total)
    {
        float acc = correct / total;
        return acc;
    }

    private void ResetLevelone()
    {
        ReinforcementManagement.elapsedTime = 0f;
        ReinforcementManagement.isPlayPressed = false;
        levelOneAccuracy = 0;
        correctCounter = 0;
        scorePercent = 0;
        ResetIndicator();
        LevelsHandler.ResetAllBooleans();
        ResetButtonColors(0);
        ReinforcementManagement.overallTime = 0f;
        ReinforcementManagement.numberOfMistakeslvl1 = 0;
        levelOneAccuracy = 0f;
    }

    private void Unlocklevel2()
    {
        if (DatabaseGamesVariables.islvlOnePassedtrail)
        {
            menuHandler.level2Button.SetActive(true);
            menuHandler.level2LockButton.SetActive(false);
        }
    }

    public void updateStat(float hScore, float lScore, float hAccuray, float lAccuracy)
    {
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.trailname, "highestScore", hScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.trailname, "lastScore", lScore);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.trailname, "highestAccuracy", hAccuray);
        databaseManager.UpdateStatistics(DatabaseGamesVariables.userID, DatabaseGamesVariables.trailname, "lastAccuracy", lAccuracy);
    }
}


