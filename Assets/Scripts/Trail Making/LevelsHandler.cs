using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsHandler : MonoBehaviour
{
    public bool level_1= true;
    public bool level_2= false;
    public bool level_3= false;

    public GameObject[] trails; 
    


    // Start is called before the first frame update
    public void TrailSelection()
    {
        if (level_1)
        {
            int trailIndex = Random.Range(0, 1);
            trails[trailIndex].SetActive(true);
        }
        if (level_2)
        {
            int trailIndex = Random.Range(2, 3);
            trails[trailIndex].SetActive(true);
        }
        if (level_3)
        {
            int trailIndex = Random.Range(4, 5);
            trails[trailIndex].SetActive(true);
        }
    }
    
}
