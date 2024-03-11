using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsHandler : MonoBehaviour
{
    public bool level_1 = true;
    public bool level1_menu = false;
    public bool level_2 = false;
    public bool level_3 = false;


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
        TrailLevel3.isGameOver = false;
        if (level==1)
        {
            level_1 = true;
            level1_menu = true;
            level_2 = false;
            level_3 = false;
            int trailIndex = Random.Range(0, levelOneTrails.Length);
            Debug.Log(levelOneTrails[trailIndex]); 
            levelOneTrails[trailIndex].SetActive(true);
            selectedTrail = trailIndex;
        }
        if (level==2)
        {
            level_2 = true;
            level_1 = false;
            level1_menu = false;
            level_3 = false;
            int trailIndex = Random.Range(0, levelTwoTrails.Length);
            levelTwoTrails[trailIndex].SetActive(true);
            levelOneTrails[0].SetActive(false);
            levelOneTrails[1].SetActive(false);
            selectedTrail = trailIndex;
        }
        if (level == 3)
        {
            level_3 = true;
            level_2 = false;
            level_1 = false;
            level1_menu = false;
            int trailIndex = Random.Range(0, levelThreeTrails.Length);
            trailIndex_copy = trailIndex;
            levelThreeTrails[trailIndex].SetActive(true);
            levelTwoTrails[0].SetActive(false);
            levelTwoTrails[1].SetActive(false);
            selectedTrail = trailIndex;
        }
        Debug.Log(selectedTrail);
    }
    public int GetTrailIndex()
    {
        return selectedTrail;
    }

    public void RestartGame()
    {
        level_1 = true;
        level1_menu = true;
        level_2 = false;
        level_3 = false;

        // reset score and number of mistakes
        trailLevel1.levelOneScore = 0;
        trailLevel1.mistakes = 0;
        trailLevel2.levelTwoScore = 0;
        trailLevel2.mistakes = 0;
        trailLevel3.levelThreeScore = 0;
        trailLevel3.mistakes = 0;

        // hide tial level three
        levelThreeTrails[trailIndex_copy].SetActive(false);

        // reset color of all buttons of level 1
        trailLevel1.ResetButtonColors(0);

        // reset color of all buttons of level 2


        // reset color of all buttons of level 3


    }
}
