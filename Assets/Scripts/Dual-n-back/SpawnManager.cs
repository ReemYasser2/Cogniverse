using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject instructionsLvl1RetryCanvas;
    public GameObject instructionsLvl2RetryCanvas;
    public GameObject instructionsLvl3RetryCanvas;
    public GameObject completeLevel1Canvas;
    public GameObject completeLevel2Canvas;
    public GameObject completeLevel3Canvas;
    public Transform[] spawnPositions;
    public Material[] materials;
    public Vector3 currentPosition;
    private Vector3 oldPosition;
    public float intervalBetweenSpawns;
    public bool isAPressed = false;

    public TextMeshProUGUI scorelvl1Text;
    public TextMeshProUGUI scorelvl2Text;
    public TextMeshProUGUI scorelvl3Text;

    public int score1;
    public int score2;
    public int score3;
    private int score2Only;
    private int score3Only;
    
    public GameObject colourButton;
    public static bool isHomeClicked = false;
    public GameObject level2Button;
    public GameObject level2LockButton;
    public GameObject level3Button;
    public GameObject level3LockButton;
    IEnumerator SpawnObjectsRandomly(int level)
    {
        if (level == 1)
        {
            AudioSpawnSharedVariables.trialsCount = 0;
            AudioSpawnSharedVariables.maxTrials = 5;
            ScoreCalculator.score = 0;
            while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials && !isHomeClicked)
            {
                //ScoreCalculator.isGameStart = true;
                ScoreCalculator.isGameOver = false;
                //ScoreCalculator.isStartLevel1 = false;
                //ScoreCalculator.isStartLevel2 = false;
                //ScoreCalculator.isStartLevel3 = false;
                colourButton.SetActive(false);
                intervalBetweenSpawns = 2.0f;
                yield return new WaitForSeconds(intervalBetweenSpawns);
                ScoreCalculator.reinforcementText = "";

                // Randomly selecting one of the positions
                int randomIndex = Random.Range(0, spawnPositions.Length);
                Vector3 spawnPos = spawnPositions[randomIndex].position;

                // Instantiate the cube at the chosen position
                GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);// Get or add a Renderer component
                ScoreCalculator.isCalculated = false;
                SetCurrentPosition(newObject);

                isAPressed = false;
                // cube visibility time before destroying it
                yield return new WaitForSeconds(0.76f);

                if (!isAPressed && AudioSpawnSharedVariables.trialsCount != 0)
                {
                    ScoreCalculator.CalculateScoreWithoutPressing(oldPosition, currentPosition);
                }

                yield return new WaitForSeconds(1.0f);
                Destroy(newObject);
                SetOldPosition(spawnPos);
                AudioSpawnSharedVariables.trialsCount++;
            }
            yield return new WaitForSeconds(0.7f);
            score1 = ScoreCalculator.score;
            CheckLevel1();
            ScoreCalculator.isLevel1 = false;
            
        }
        else if (level == 2)
        {
            AudioSpawnSharedVariables.trialsCount = 0;
            AudioSpawnSharedVariables.maxTrials = 5;
            ScoreCalculator.score = 0;
            while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials && !isHomeClicked)
            {
                //ScoreCalculator.isGameStart = true;
                ScoreCalculator.isGameOver = false;
                //ScoreCalculator.isStartLevel1 = false;
                //ScoreCalculator.isStartLevel2 = true;
                //ScoreCalculator.isStartLevel3 = false;
                colourButton.SetActive(true);
                intervalBetweenSpawns = 2.0f;
                yield return new WaitForSeconds(intervalBetweenSpawns);
                ScoreCalculator.reinforcementText = "";

                // Randomly selecting one of the positions
                int randomIndex = Random.Range(0, spawnPositions.Length);
                Vector3 spawnPos = spawnPositions[randomIndex].position;

                // Instantiate the cube at the chosen position
                GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);// Get or add a Renderer component
                // Randomly select a material from the materials array
                int randomMaterialIndex = Random.Range(0, materials.Length);
                Material randomMaterial = materials[randomMaterialIndex];

                // Apply the material to the child object
                Renderer childRenderer = newObject.transform.GetChild(0).GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    childRenderer.material = randomMaterial;
                }
                ScoreCalculator.isCalculated = false;
                SetCurrentPosition(newObject);

                isAPressed = false;
                // cube visibility time before destroying it
                yield return new WaitForSeconds(0.76f);

                if (!isAPressed && AudioSpawnSharedVariables.trialsCount != 0)
                {
                    ScoreCalculator.CalculateScoreWithoutPressing(oldPosition, currentPosition);
                }

                yield return new WaitForSeconds(1.0f);
                Destroy(newObject);
                SetOldPosition(spawnPos);
                AudioSpawnSharedVariables.trialsCount++;
            }
            yield return new WaitForSeconds(0.7f);
            score2 = ScoreCalculator.score;
            ScoreCalculator.isLevel2 = false; 
            CheckLevel2();
        }
        else if (level == 3)
        {
            AudioSpawnSharedVariables.trialsCount = 0;
            AudioSpawnSharedVariables.maxTrials = 5;
            ScoreCalculator.score = 0;
            while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials && !isHomeClicked)
            {
                //ScoreCalculator.isGameStart = true;
                ScoreCalculator.isGameOver = false;
               //ScoreCalculator.isStartLevel1 = false;
                //ScoreCalculator.isStartLevel2 = false;
                //ScoreCalculator.isStartLevel3 = true;
                colourButton.SetActive(true);
                intervalBetweenSpawns = 0.5f;
                yield return new WaitForSeconds(intervalBetweenSpawns);
                ScoreCalculator.reinforcementText = "";

                
                // Randomly selecting one of the positions
                int randomIndex = Random.Range(0, spawnPositions.Length);
                Vector3 spawnPos = spawnPositions[randomIndex].position;

                // Instantiate the cube at the chosen position
                GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);// Get or add a Renderer component
                // Randomly select a material from the materials array
                int randomMaterialIndex = Random.Range(0, materials.Length);
                Material randomMaterial = materials[randomMaterialIndex];

                // Apply the material to the child object
                Renderer childRenderer = newObject.transform.GetChild(0).GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    childRenderer.material = randomMaterial;
                }
                ScoreCalculator.isCalculated = false;
                SetCurrentPosition(newObject);

                isAPressed = false;
                // cube visibility time before destroying it
                yield return new WaitForSeconds(0.76f);

                if (!isAPressed && AudioSpawnSharedVariables.trialsCount != 0)
                {
                    ScoreCalculator.CalculateScoreWithoutPressing(oldPosition, currentPosition);
                }

                yield return new WaitForSeconds(1.0f);
                Destroy(newObject);
                SetOldPosition(spawnPos);
                AudioSpawnSharedVariables.trialsCount++;
            }
            yield return new WaitForSeconds(0.7f);
            score3 = ScoreCalculator.score;
            ScoreCalculator.isLevel3 = false;
            CheckLevel3();
        }
    }   
    
    void SetCurrentPosition(GameObject gameObject)
    {
        currentPosition = gameObject.transform.position;
    }
    public Vector3 GetCurrentPosition()
    {
        return currentPosition;
    }
    void SetOldPosition(Vector3 position)
    {
        oldPosition = position;
    }
    public Vector3 GetOldPosition()
    {
        return oldPosition;
    }
    public void TriggerPositionComparison()
    {
        if (AudioSpawnSharedVariables.trialsCount != 0)
        {
            ScoreCalculator.CalculateScoreWhenPressed(oldPosition, currentPosition);
        }
    }

    private void ShowLevelOneInstructions() { instructionsLvl1RetryCanvas.SetActive(true); }
    private void ShowLevelTwoInstructions() { instructionsLvl2RetryCanvas.SetActive(true); }
    private void ShowLevelThreeInstructions() { instructionsLvl3RetryCanvas.SetActive(true); }

    public void PlayButtonClicked(int level)
    {
        ScoreCalculator.isGameStart = false;
        StartCoroutine(SpawnObjectsRandomly(level));
    }

    private void ShowCompleteLevel1Canvas()
    {
        completeLevel1Canvas.SetActive(true);
        scorelvl1Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void ShowCompleteLevel2Canvas()
    {
        completeLevel2Canvas.SetActive(true);
        scorelvl2Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void ShowCompleteLevel3Canvas()
    {
        completeLevel3Canvas.SetActive(true);
        scorelvl3Text.text = $"Your Score: {ScoreCalculator.score}";
    }

    private void CheckLevel1()
    {
        if (ScoreCalculator.score >= 5)// && ScoreCalculator.isLevel1)
        {
            // pass lvl 1
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel1Canvas();
            ScoreCalculator.score = 0;
            level2Button.SetActive(true);
            level2LockButton.SetActive(false);
            //ScoreCalculator.isLevel1 = false;
            //ScoreCalculator.isLevel2 = true;
            //ScoreCalculator.isStartLevel2 = true;
        }
        else if (ScoreCalculator.score <= 5)// && ScoreCalculator.isLevel1)
        {
            // retry lvl1
            ScoreCalculator.reinforcementText = "";
            ShowLevelOneInstructions();
            ScoreCalculator.score = 0;
            //ScoreCalculator.isStartLevel1 = true;
        }
    }

    private void CheckLevel2()
    {
        if (ScoreCalculator.score >= 10)// && ScoreCalculator.isLevel2)
        {
            // pass lvl2
            score2Only = score2 - score1;
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel2Canvas();
            ScoreCalculator.score = 0;
            level3Button.SetActive(true);
            level3LockButton.SetActive(false);
            //ScoreCalculator.isLevel3 = true;
            //ScoreCalculator.isLevel1 = false;
            //ScoreCalculator.isLevel2 = false;
            //ScoreCalculator.isStartLevel3 = true;
        }
        else if (ScoreCalculator.score <= 10)// && ScoreCalculator.isLevel2)
        {
            // retry lvl 2
            ScoreCalculator.reinforcementText = "";
            ShowLevelTwoInstructions();
            ScoreCalculator.score = 0;
            //ScoreCalculator.isLevel2 = true;
            //ScoreCalculator.isLevel3 = false;
            //ScoreCalculator.isLevel1 = false;
            //ScoreCalculator.score = score1;
            //ScoreCalculator.isStartLevel2 = true;
        }
    }

    private void CheckLevel3()
    {
        if (ScoreCalculator.score >= 15)// && ScoreCalculator.isLevel3)
        {
            // pass lvl3
            score3Only = score3 - (score1 + score2);
            ScoreCalculator.reinforcementText = "";
            ShowCompleteLevel3Canvas();
            //ScoreCalculator.isLevel1 = true;
            //ScoreCalculator.isLevel2 = false;
            //ScoreCalculator.isLevel3 = false;
            ScoreCalculator.score = 0;
            //ScoreCalculator.isGameOver = true;
            Debug.Log("game over test");
        }
        else if (ScoreCalculator.score <= 15)// && ScoreCalculator.isLevel3)
        {
            // retry lvl3
            ScoreCalculator.reinforcementText = "";
            ShowLevelThreeInstructions();
            ScoreCalculator.score = 0;
            //ScoreCalculator.isLevel3 = true;
            //ScoreCalculator.isLevel1 = false;
            //ScoreCalculator.isLevel2 = false;
            //ScoreCalculator.score = score2;
            //ScoreCalculator.isStartLevel3 = true;
        }
    }

    public void level1()
    {
        ScoreCalculator.isLevel1 = true;
        ScoreCalculator.isLevel2 = false;
        ScoreCalculator.isLevel3 = false;
        ScoreCalculator.isGameOver = true;
        isHomeClicked = false;
    }

    public void level2()
    {
        ScoreCalculator.isLevel1 = false;
        ScoreCalculator.isLevel2 = true;
        ScoreCalculator.isLevel3 = true;
        ScoreCalculator.isGameOver = true;
        isHomeClicked = false;
    }

    public void level3()
    {
        ScoreCalculator.isLevel1 = false;
        ScoreCalculator.isLevel2 = false;
        ScoreCalculator.isLevel3 = true;
        ScoreCalculator.isGameOver = true;
        isHomeClicked = false;
}

    public void HomeButtonClicked()
    {
        isHomeClicked = true;
        ScoreCalculator.reinforcementText = "";

        ScoreCalculator.isLevel1 = false;
        ScoreCalculator.isLevel2 = false;
        ScoreCalculator.isLevel3 = false;
        ScoreCalculator.isGameOver = true;

        ScoreCalculator.score = 0;
        AudioSpawnSharedVariables.trialsCount = 0;
        AudioSpawnSharedVariables.maxTrials = 5;
    }
}