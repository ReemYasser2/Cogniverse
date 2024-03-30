using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsHandler : MonoBehaviour
{
    public int selectedTrail;

    public GameObject[] levelOneTrails = new GameObject[2];
    public GameObject[] levelTwoTrails = new GameObject[2];
    public GameObject[] levelThreeTrails = new GameObject[2];
    public Transform spawnPosition;

    public TrailLevel1 trailLevel1;
    public TrailLevel2 trailLevel2;
    public TrailLevel3 trailLevel3;

    public int trailIndex_copy;
    public void TrailSelection(int level)
    {
        ReinforcementManagement.isGameOver = false;
        if (level==1)
        {
            ReinforcementManagement.level_1 = true;
            ReinforcementManagement.level1_menu = true;
            ReinforcementManagement.level_2 = false;
            ReinforcementManagement.level_3 = false;
            int trailIndex = Random.Range(0, levelOneTrails.Length);
            Debug.Log(levelOneTrails[trailIndex]); 
            levelOneTrails[trailIndex].SetActive(true);
            selectedTrail = trailIndex;
            trailLevel1.scorePercent = (trailLevel1.levelOneScore)/15;
        }
        if (level==2)
        {
            ReinforcementManagement.level_2 = true;
            ReinforcementManagement.level_1 = false;
            ReinforcementManagement.level1_menu = false;
            ReinforcementManagement.level_3 = false;
            int trailIndex = Random.Range(0, levelTwoTrails.Length);
            levelTwoTrails[trailIndex].SetActive(true);
            levelOneTrails[0].SetActive(false);
            levelOneTrails[1].SetActive(false);
            selectedTrail = trailIndex;
            trailLevel2.scorePercent = (trailLevel2.levelTwoScore) / 20;
        }
        if (level == 3)
        {
            ReinforcementManagement.level_3 = true;
            ReinforcementManagement.level_2 = false;
            ReinforcementManagement.level_1 = false;
            ReinforcementManagement.level1_menu = false;
            int trailIndex = Random.Range(0, levelThreeTrails.Length);
            trailIndex_copy = trailIndex;
            levelThreeTrails[trailIndex].SetActive(true);
            levelTwoTrails[0].SetActive(false);
            levelTwoTrails[1].SetActive(false);
            selectedTrail = trailIndex;
            trailLevel3.scorePercent = (trailLevel3.levelThreeScore) / 30;
        }
        Debug.Log(selectedTrail);
    }
    public int GetTrailIndex()
    {
        return selectedTrail;
    }

    public void ReplayLevel1()
    {
        ReinforcementManagement.level_1 = true;
        ReinforcementManagement.level1_menu = true;
        ReinforcementManagement.level_2 = false;
        ReinforcementManagement.level_3 = false;

        // reset score and number of mistakes
        trailLevel1.levelOneScore = 0;
        trailLevel1.mistakes = 0;
        trailLevel1.scorePercent = 0;

        // hide trails 
        levelOneTrails[0].SetActive(false);
        levelOneTrails[1].SetActive(false);

        // reset color of all buttons 
        trailLevel1.ResetButtonColors(0);

        TrailSelection(1);
    }
    
    public void ReplayLevel2()
    {
        ReinforcementManagement.level_1 = false;
        ReinforcementManagement.level1_menu = false;
        ReinforcementManagement.level_2 = true;
        ReinforcementManagement.level_3 = false;

        // reset score and number of mistakes
        trailLevel2.levelTwoScore = 0;
        trailLevel2.mistakes = 0;
        trailLevel2.scorePercent = 0;

        // hide trails
        levelTwoTrails[0].SetActive(false);
        levelTwoTrails[1].SetActive(false);

        // reset color of all buttons
        trailLevel2.ResetButtonColors(0);

        TrailSelection(2);
    }
    
    public void ReplayLevel3()
    {
        ReinforcementManagement.level_1 = false;
        ReinforcementManagement.level1_menu = false;
        ReinforcementManagement.level_2 = false;
        ReinforcementManagement.level_3 = true;

        // reset score and number of mistakes
        trailLevel3.levelThreeScore = 0;
        trailLevel3.mistakes = 0;
        trailLevel3.scorePercent = 0;

        // hide trails
        levelThreeTrails[0].SetActive(false);
        levelThreeTrails[1].SetActive(false);

        // reset color of all buttons 
        trailLevel3.ResetButtonColors(0);

        TrailSelection(3);
    }

    public void HomeButton()
    {
        trailLevel1.levelOneScore = 0;
        trailLevel1.mistakes = 0;
        trailLevel1.scorePercent = 0;

        trailLevel2.levelTwoScore = 0;
        trailLevel2.mistakes = 0;
        trailLevel2.scorePercent = 0;

        trailLevel3.levelThreeScore = 0;
        trailLevel3.mistakes = 0;
        trailLevel3.scorePercent = 0;

        levelOneTrails[0].SetActive(false);
        levelOneTrails[1].SetActive(false);
        levelTwoTrails[0].SetActive(false);
        levelTwoTrails[1].SetActive(false);
        levelThreeTrails[0].SetActive(false);
        levelThreeTrails[1].SetActive(false);

        trailLevel1.ResetButtonColors(0);
        trailLevel2.ResetButtonColors(0);
        trailLevel3.ResetButtonColors(0);

        ReinforcementManagement.elapsedTime = 0f;
        ReinforcementManagement.isPlayPressed = false;
    }
}
