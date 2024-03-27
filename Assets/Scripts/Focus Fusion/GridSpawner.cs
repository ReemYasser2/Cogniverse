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

    public static bool isLevel1;
    public static bool isLevel2;
    public static bool isGameOver;

    public FocusLevelTransition levelTransition;

    // Start is called before the first frame update
    void Start()
    {
        leftActionReference.action.performed += OnClickCustom;
        rightActionReference.action.performed += OnClickCustom;

    }

    private void OnClickCustom( InputAction.CallbackContext obj)
    {
        isClicked = true;
        if (newObject && !FocusLevelTransition.isHomeClicked)
        {
            if (obj.action.name == "PrimaryRight")
            {
                if (newObject.layer == 10)
                {
                    ScoreCalculationFocus.Increment();
                    StartCoroutine(ResetTextAfterDelay());

                }
                else if (newObject.layer != 10 || newObject.layer == 9)
                {
                    ScoreCalculationFocus.Decrement();
                    StartCoroutine(ResetTextAfterDelay());

                }

            }
            else if (obj.action.name == "PrimaryLeft")
            {
                if (newObject.layer == 8)
                {
                    ScoreCalculationFocus.Increment();
                    StartCoroutine(ResetTextAfterDelay());

                }
                else if (newObject.layer != 8 || newObject.layer == 9)
                {
                    ScoreCalculationFocus.Decrement();
                    StartCoroutine(ResetTextAfterDelay());

                }

            }

        }
        //GetUserResponse();
    }

    IEnumerator RandomSpawner(int level)
    {
        if (level == 1)
        {
            
            //FocusTimer.remainingTime = 15;

            while (!FocusTimer.isTimeOver && !FocusLevelTransition.isHomeClicked)
            {
                isClicked = false;
                if (newObject != null)
                {
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(0.25f);
                int randomIndex = Random.Range(0, gridsPrefabs.Length);

                newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
                if (!FocusLevelTransition.isHomeClicked)
                {
                    HandleNoClickOnLayerNine();
                }
                

                if (newObject != null)
                {
                    Destroy(newObject);
                }

                yield return new WaitForSeconds(0.85f);

            }
            yield return new WaitForSeconds(0.5f);
            isLevel1 = false;
            if (!FocusLevelTransition.isHomeClicked) { levelTransition.CheckLevel1(); }
        }
        else if (level == 2)
        {
            
            //FocusTimer.remainingTime = 6;

            Debug.Log("Level 2 starts");
            while (!FocusTimer.isTimeOver && !FocusLevelTransition.isHomeClicked)
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

                newObject = Instantiate(gridsPrefabs[randomIndex], levelTwoSpawnPos[randomPosIndex].position, Quaternion.identity);
                yield return new WaitForSeconds(1.25f);
                if (!FocusLevelTransition.isHomeClicked)
                {
                    HandleNoClickOnLayerNine();
                }

                if (newObject != null)
                {
                    newObject.SetActive(false);
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(1);

            }
            yield return new WaitForSeconds(0.5f);
            isLevel2 = false;
            if (!FocusLevelTransition.isHomeClicked) { levelTransition.CheckLevel2(); }
        }
    }
    IEnumerator WhenClicked()
    {
        isClicked = false;
        if (newObject != null)
        {
            Destroy(newObject);
            Debug.Log("Object destroyed");
        }
        
        yield return  new WaitForSeconds(1f);
        
    }

    private void HandleNoClickOnLayerNine()
    {
        if (newObject && newObject.layer == 9 && !isClicked)
        {
            ScoreCalculationFocus.Increment(); // Increment score if no click and layer is 9
        } 
        else if (!isClicked) 
        {
            ScoreCalculationFocus.Decrement();
        }

        StartCoroutine(ResetTextAfterDelay());

    }

    public void StartSpawning(int level)
    {
        StartCoroutine(RandomSpawner(level));
    }
    public void GetUserResponse()
    {
        if (!FocusTimer.isTimeOver) {
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
        isLevel1 = true;
        isLevel2 = false;
        isGameOver = false;
        FocusLevelTransition.isHomeClicked = false;
    }

    public void level2()
    {
        isLevel1 = false;
        isLevel2 = true;
        isGameOver = false;
        FocusLevelTransition.isHomeClicked = false;
    }
}
