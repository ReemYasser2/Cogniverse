using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using Unity.XR.Oculus;
using UnityEditor.Rendering;

public class GridSpawner : MonoBehaviour
{
    public GameObject[] gridsPrefabs;
    public Transform spawnPosition; 
    public Transform[] levelTwoSpawnPos;
    GameObject newObject;
    private bool isClicked = false;
    [SerializeField] private InputActionReference leftActionReference;
    [SerializeField] private InputActionReference rightActionReference;
        public GameObject menuCanvas;

    public FocusReinforcement FocusReinforcement;

    public FocusLevelTransition levelTransition;

    // Start is called before the first frame update
    void Start()
    {
        leftActionReference.action.performed += OnClickCustom;
        rightActionReference.action.performed += OnClickCustom;

    }

    private void OnClickCustom(InputAction.CallbackContext obj)
    {
        if(menuCanvas.activeSelf == false) {
        isClicked = true;
        ScoreCalculationFocus.isStopWatchStart = false;
        ScoreCalculationFocus.elapsedTimeStopWatch = 0;
        if (newObject && newObject.layer != 9)
        {
            ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo + ScoreCalculationFocus.stopWatchtime;
        }

        if (newObject && !ScoreCalculationFocus.isHomeClicked)
        {
            if (obj.action.name == "PrimaryRight")
            {
                if (newObject.layer == 10)
                {
                    ScoreCalculationFocus.Increment();

                    FocusReinforcement.increaseAudio(ScoreCalculationFocus.randomIndexPositiveInc);
                    
                    StartCoroutine(ResetTextAfterDelay());

                }
                else if ( newObject.layer == 9 || newObject.layer == 8)
                {
                    ScoreCalculationFocus.Decrement();
                    //
                    FocusReinforcement.decreaseAudio(ScoreCalculationFocus.randomIndexPositiveDec);
                    StartCoroutine(ResetTextAfterDelay());

                }

            }
            else if (obj.action.name == "PrimaryLeft")
            {
                if (newObject.layer == 8)
                {
                    ScoreCalculationFocus.Increment();
                    
                    FocusReinforcement.increaseAudio(ScoreCalculationFocus.randomIndexPositiveInc);
                   
                    StartCoroutine(ResetTextAfterDelay());

                }
                else if ( newObject.layer == 9 || newObject.layer == 10)
                {
                    ScoreCalculationFocus.Decrement();
                    //
                    FocusReinforcement.decreaseAudio(ScoreCalculationFocus.randomIndexPositiveDec);
                    StartCoroutine(ResetTextAfterDelay());

                }

            }

        }
    
        }
    }

    IEnumerator RandomSpawner(int level)
    {
        if (level == 1)
        {
            levelTransition.GetDateTime();   
            //FocusTimer.remainingTime = 15;

            while (!ScoreCalculationFocus.isTimeOver && !ScoreCalculationFocus.isHomeClicked)
            {
                isClicked = false;
                if (newObject != null)
                {
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(0.25f);
                int randomIndex = Random.Range(0, gridsPrefabs.Length);
                
                if (ScoreCalculationFocus.isStopWatchStart) 
                { 
                    ScoreCalculationFocus.isStopWatchStart = false;
                    ScoreCalculationFocus.elapsedTimeStopWatch = 0;
                    ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo + ScoreCalculationFocus.stopWatchtime;
                }

                newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity);
                ScoreCalculationFocus.totalTrialsGo++;
                ScoreCalculationFocus.isStopWatchStart = true; 

                yield return new WaitForSeconds(1f);
                if (!ScoreCalculationFocus.isHomeClicked)
                {
                    HandleNoClickOnLayerNine();
                }

                yield return new WaitForSeconds(0.1f);

                if (newObject != null)
                {
                    Destroy(newObject);
                }

                yield return new WaitForSeconds(0.85f);

            }
            yield return new WaitForSeconds(0.5f);
            ScoreCalculationFocus.isLevel1 = false;
            if (!ScoreCalculationFocus.isHomeClicked) { levelTransition.CheckLevel1(); }
        }
        else if (level == 2)
        {
            levelTransition.GetDateTime();
            //FocusTimer.remainingTime = 6;

            //Debug.Log("Level 2 starts");
            while (!ScoreCalculationFocus.isTimeOver && !ScoreCalculationFocus.isHomeClicked)
            {

                isClicked = false;
                if (newObject != null)
                {
                    newObject.SetActive(false);
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(0.25f);
                int randomIndex = Random.Range(0, gridsPrefabs.Length);
                int randomPosIndex = Random.Range(0, levelTwoSpawnPos.Length);

                if (ScoreCalculationFocus.isStopWatchStart)
                {
                    ScoreCalculationFocus.isStopWatchStart = false;
                    ScoreCalculationFocus.elapsedTimeStopWatch = 0;
                    ScoreCalculationFocus.responseTimeGo = ScoreCalculationFocus.responseTimeGo + ScoreCalculationFocus.stopWatchtime;
                }
                newObject = Instantiate(gridsPrefabs[randomIndex], levelTwoSpawnPos[randomPosIndex].position, Quaternion.identity);
                ScoreCalculationFocus.totalTrialsGo++;
                ScoreCalculationFocus.isStopWatchStart = true;

                yield return new WaitForSeconds(1.25f);
                if (!ScoreCalculationFocus.isHomeClicked)
                {
                    HandleNoClickOnLayerNine();
                }
                yield return new WaitForSeconds(0.1f);

                if (newObject != null)
                {
                    newObject.SetActive(false);
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(1);

            }
            yield return new WaitForSeconds(0.5f);
            ScoreCalculationFocus.isLevel2 = false;
            if (!ScoreCalculationFocus.isHomeClicked) { levelTransition.CheckLevel2(); }
        }
    }
    IEnumerator WhenClicked()
    {
        isClicked = false;
        if (newObject != null)
        {
            Destroy(newObject);
            //Debug.Log("Object destroyed");
        }
        
        yield return  new WaitForSeconds(1f);
        
    }

    private void HandleNoClickOnLayerNine()
    {
        if (newObject && newObject.layer == 9)
        {
            ScoreCalculationFocus.totalTrialsGo--;
            ScoreCalculationFocus.totalTrialsNoGo++;
        }
        if (newObject && newObject.layer == 9 && isClicked)
        {
            ScoreCalculationFocus.isStopWatchStart = false;
            ScoreCalculationFocus.elapsedTimeStopWatch = 0;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo + ScoreCalculationFocus.stopWatchtime;
        }

        if (newObject && newObject.layer == 9 && !isClicked)
        {
            ScoreCalculationFocus.Increment(); // Increment score if no click and layer is 9

            FocusReinforcement.increaseAudio(ScoreCalculationFocus.randomIndexPositiveInc);
           
            ScoreCalculationFocus.isStopWatchStart = false;
            ScoreCalculationFocus.elapsedTimeStopWatch = 0;
            ScoreCalculationFocus.responseTimeNoGo = ScoreCalculationFocus.responseTimeNoGo + 0;
        } 
        else if (newObject &&  !isClicked) 
        {
            ScoreCalculationFocus.Decrement();
            FocusReinforcement.decreaseAudio(ScoreCalculationFocus.randomIndexPositiveDec);
        }

        StartCoroutine(ResetTextAfterDelay());

    }

    public void StartSpawning(int level)
    {
        StartCoroutine(RandomSpawner(level));
    }
    public void GetUserResponse()
    {
        if (!ScoreCalculationFocus.isTimeOver) {
            StartCoroutine(WhenClicked());      
        }
    }
    IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);

        // After waiting for the specified duration, reset the text to nothing
        ScoreCalculationFocus.reinforcementText = "";
    }

    public static void ResetText() { ScoreCalculationFocus.reinforcementText = "";  }
    public void ShowHideGrid(bool isVisible)
    {
        if (newObject != null)
        {
            newObject.SetActive(isVisible);
        }
    }

    public void level1()
    {
        ScoreCalculationFocus.isLevel1 = true;
        ScoreCalculationFocus.isLevel2 = false;
        ScoreCalculationFocus.isGameOver = false;
        ScoreCalculationFocus.isHomeClicked = false;
    }

    public void level2()
    {
        ScoreCalculationFocus.isLevel1 = false;
        ScoreCalculationFocus.isLevel2 = true;
        ScoreCalculationFocus.isGameOver = false;
        ScoreCalculationFocus.isHomeClicked = false;
    }
}
