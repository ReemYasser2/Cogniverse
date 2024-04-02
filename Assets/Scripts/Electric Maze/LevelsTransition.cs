using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LevelsTransition : MonoBehaviour
{
    //int score1;
    public GameObject levelTwoInstructionsCanvas;
    public GameObject levelOneInstructionsCanvas;
    public GameObject gameOverCanvas;

    public static bool isLevel1;
    public static bool isLevel2;
    public static bool isGameOver;

    public MazeSpawner mazeSpawner;

    //public CountDownTimer time;
    // Start is called before the first frame update
    void Start()
    {
        //time = GetComponent<CountDownTimer>();
        //time = gameObject.AddComponent<CountDownTimer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevel1)
        {
            checkLevelOne();
        }
        else if (isLevel2)
        {
            CheckLevelTwo();
        }
    }

    private void checkLevelOne()
    {
        if (ScoreCalculatorMaze.score <= 2 && CountDownTimer.isTimeOver && HapticFeedback.checkpointCounter>=13)
        {
            levelTwoInstructionsCanvas.SetActive(true);
            mazeSpawner.HideMaze();
        }
        else if (ScoreCalculatorMaze.score > 2 && CountDownTimer.isTimeOver)
        {
            levelOneInstructionsCanvas.SetActive(true);
            mazeSpawner.HideMaze();
        }
    }

    private void CheckLevelTwo()
    {
        if (ScoreCalculatorMaze.score <= 4 && CountDownTimer.isTimeOver )
        {
            gameOverCanvas.SetActive(true);
            mazeSpawner.HideMaze();
            isGameOver = true;
        }
        else if (ScoreCalculatorMaze.score > 4 && CountDownTimer.isTimeOver && HapticFeedback.checkpointCounter >= 13)
        {
            levelTwoInstructionsCanvas.SetActive(true);
            mazeSpawner.HideMaze();
        }
    }

    public static void level1()
    {
        isLevel1 = true;
        isLevel2 = false;
        ScoreCalculatorMaze.score = 0;
        HapticFeedback.checkpointCounter = 0;


    }

    public void level2() 
    { 
        isLevel2 = true;
        isLevel1 = false;
        ScoreCalculatorMaze.score = 0;
        HapticFeedback.checkpointCounter = 0;
    }

}
