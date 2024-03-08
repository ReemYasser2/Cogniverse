using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsHandler : MonoBehaviour
{
    public bool level_1= true;
    public bool level_2= false;
    public bool level_3= false;


    public int selectedTrail;

    public GameObject[] levelOneTrails = new GameObject[2];
    public GameObject[] levelTwoTrails = new GameObject[2];
    public GameObject[] levelThreeTrails = new GameObject[2];
    public Transform spawnPosition;
    public void TrailSelection(int level)
    {
        if (level==1)
        {
            int trailIndex = Random.Range(0, levelOneTrails.Length);
            Debug.Log(levelOneTrails[trailIndex]); 
            levelOneTrails[trailIndex].SetActive(true);
            selectedTrail = trailIndex;
        }
        if (level==2)
        {
            level_2= true;  
            int trailIndex = Random.Range(0, levelTwoTrails.Length);
            levelTwoTrails[trailIndex].SetActive(true);
            levelOneTrails[0].SetActive(false);
            levelOneTrails[1].SetActive(false);
            selectedTrail = trailIndex;
        }
        if (level == 3)
        {
            level_3= true;
            int trailIndex = Random.Range(0, levelThreeTrails.Length);
            levelThreeTrails[trailIndex].SetActive(true);
            levelTwoTrails[0].SetActive(false);
            levelTwoTrails[1].SetActive(false);
            selectedTrail = trailIndex;
        }
    }
    public int GetTrailIndex()
    {
        return selectedTrail;
    }
    
}
