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
    public GameObject colourButton;

    public Transform[] spawnPositions;
    public Material[] materials;

    public Vector3 currentPosition;
    private Vector3 oldPosition;

    public float intervalBetweenSpawns;
    public bool isAPressed = false;

    public int score1;
    public int score2;
    public int score3;

    public LevelTransitionDual levelTransition;
  
    IEnumerator SpawnObjectsRandomly(int level)
    {
        if (level == 1)
        {
            ScoreCalculator.trialsCount = 0;
            ScoreCalculator.maxTrials = 5;
            ScoreCalculator.score = 0;
            while (ScoreCalculator.trialsCount < ScoreCalculator.maxTrials && !ScoreCalculator.isHomeClicked)
            {
                ScoreCalculator.isGameOver = false;
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

                if (!isAPressed && ScoreCalculator.trialsCount != 0)
                {
                    ScoreCalculator.CalculateScoreWithoutPressing(oldPosition, currentPosition);
                }

                yield return new WaitForSeconds(1.0f);
                Destroy(newObject);
                SetOldPosition(spawnPos);
                ScoreCalculator.trialsCount++;
            }
            yield return new WaitForSeconds(0.7f);
            score1 = ScoreCalculator.score;
            if (!ScoreCalculator.isHomeClicked) { levelTransition.CheckLevel1(); }
            ScoreCalculator.isLevel1 = false;
            
        }
        else if (level == 2)
        {
            ScoreCalculator.trialsCount = 0;
            ScoreCalculator.maxTrials = 5;
            ScoreCalculator.score = 0;
            while (ScoreCalculator.trialsCount < ScoreCalculator.maxTrials && !ScoreCalculator.isHomeClicked)
            {
                ScoreCalculator.isGameOver = false;
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

                if (!isAPressed && ScoreCalculator.trialsCount != 0)
                {
                    ScoreCalculator.CalculateScoreWithoutPressing(oldPosition, currentPosition);
                }

                yield return new WaitForSeconds(1.0f);
                Destroy(newObject);
                SetOldPosition(spawnPos);
                ScoreCalculator.trialsCount++;
            }
            yield return new WaitForSeconds(0.7f);
            score2 = ScoreCalculator.score;
            ScoreCalculator.isLevel2 = false;
            if (!ScoreCalculator.isHomeClicked) { levelTransition.CheckLevel2(); }
        }
        else if (level == 3)
        {
            ScoreCalculator.trialsCount = 0;
            ScoreCalculator.maxTrials = 5;
            ScoreCalculator.score = 0;
            while (ScoreCalculator.trialsCount < ScoreCalculator.maxTrials && !ScoreCalculator.isHomeClicked)
            {
                ScoreCalculator.isGameOver = false;
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

                if (!isAPressed && ScoreCalculator.trialsCount != 0)
                {
                    ScoreCalculator.CalculateScoreWithoutPressing(oldPosition, currentPosition);
                }

                yield return new WaitForSeconds(1.0f);
                Destroy(newObject);
                SetOldPosition(spawnPos);
                ScoreCalculator.trialsCount++;
            }
            yield return new WaitForSeconds(0.7f);
            score3 = ScoreCalculator.score;
            ScoreCalculator.isLevel3 = false;
            if (!ScoreCalculator.isHomeClicked) { levelTransition.CheckLevel3(); }
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
        if (ScoreCalculator.trialsCount != 0)
        {
            ScoreCalculator.CalculateScoreWhenPressed(oldPosition, currentPosition);
        }
    }

    public void PlayButtonClicked(int level)
    {
        StartCoroutine(SpawnObjectsRandomly(level));
    }

    public void level1()
    {
        ScoreCalculator.isLevel1 = true;
        ScoreCalculator.isLevel2 = false;
        ScoreCalculator.isLevel3 = false;
        ScoreCalculator.isGameOver = true;
        ScoreCalculator.isHomeClicked = false;
    }

    public void level2()
    {
        ScoreCalculator.isLevel1 = false;
        ScoreCalculator.isLevel2 = true;
        ScoreCalculator.isLevel3 = true;
        ScoreCalculator.isGameOver = true;
        ScoreCalculator.isHomeClicked = false;
    }

    public void level3()
    {
        ScoreCalculator.isLevel1 = false;
        ScoreCalculator.isLevel2 = false;
        ScoreCalculator.isLevel3 = true;
        ScoreCalculator.isGameOver = true;
        ScoreCalculator.isHomeClicked = false;
    }
}