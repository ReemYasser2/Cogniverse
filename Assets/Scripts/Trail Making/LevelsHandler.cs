using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsHandler : MonoBehaviour
{
    public bool level_1= true;
    public bool level_2= false;
    public bool level_3= false;


    public int selectedTrail = 0;

    public GameObject[] levelOneTrails = new GameObject[2];
    public GameObject[] levelTwoTrails = new GameObject[2];
    public GameObject[] levelThreeTrails = new GameObject[2];


    // Start is called before the first frame update
    public void TrailSelection()
    {
        if (level_1)
        {
            int trailIndex = Random.Range(0, levelOneTrails.Length);
            Debug.Log(levelOneTrails[trailIndex]); // NULL????!!!!
            levelOneTrails[trailIndex].SetActive(true);
            selectedTrail = trailIndex;
        }
        if (level_2)
        {
            int trailIndex = Random.Range(0, levelTwoTrails.Length);
            levelTwoTrails[trailIndex].SetActive(true);
            levelOneTrails[trailIndex].SetActive(false); ;
        }
        if (level_3)
        {
            int trailIndex = Random.Range(0, levelThreeTrails.Length);
            levelThreeTrails[trailIndex].SetActive(true);
            levelTwoTrails[trailIndex].SetActive(false);
        }
    }
    
}
