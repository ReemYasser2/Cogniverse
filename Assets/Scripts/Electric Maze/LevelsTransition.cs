using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LevelsTransition : MonoBehaviour
{
    int score1;
    public GameObject levelTwoInstructions; 
    public CountDownTimer time;
    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<CountDownTimer>();
        time = gameObject.AddComponent<CountDownTimer>(); 


    }

    // Update is called once per frame
    void Update()
    {
        checkLevelOne();
    }
    public void checkLevelOne()
    {
        
    }
}
