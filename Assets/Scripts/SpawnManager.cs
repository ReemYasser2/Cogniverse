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
    public GameObject endGamePanel;
    public GameObject level1GamePanel;
    public GameObject level2GamePanel;
    public GameObject level3GamePanel;
    //public GameObject menuePanel;
    public Transform[] spawnPositions;
    public Material[] materials;
    public Vector3 currentPosition;
    private Vector3 oldPosition;
    public float intervalBetweenSpawns;
    public bool isAPressed = false;
    public bool isLevel1 = true;
    public bool isLevel2 = false;
    public bool isLevel3 = false;
    public static bool isGameOver = false;
    public TextMeshProUGUI scoreText;
    public Button startButton;
    public int score1;
    public int score2;
    public int score3;

    // Start is called before the first frame update
    //private void Start()
    //{
    //StartCoroutine(SpawnObjectsRandomly());
    //}

    IEnumerator SpawnObjectsRandomly()
    {
        while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials)
        {
            isGameOver = false;
            if (isLevel3 == true)
            {
                intervalBetweenSpawns = 0.5f;
            }
            else
            {
                intervalBetweenSpawns = 2.0f;
            }
            
            yield return new WaitForSeconds(intervalBetweenSpawns);
            ScoreCalculator.reinforcementText = "";

            // Randomly selecting one of the positions
            int randomIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnPos = spawnPositions[randomIndex].position;

            // Instantiate the cube at the chosen position
            GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);// Get or add a Renderer component

            if(isLevel2 == true || isLevel3 == true)
            {             
                // Randomly select a material from the materials array
                int randomMaterialIndex = Random.Range(0, materials.Length);
                Material randomMaterial = materials[randomMaterialIndex];

                // Apply the material to the child object
                Renderer childRenderer = newObject.transform.GetChild(0).GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    childRenderer.material = randomMaterial;
                }
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
        if (isLevel1)
        {
            score1 = ScoreCalculator.score;
        }
        else if (isLevel2)
        {
            score2 = ScoreCalculator.score;
        }
        else
        {
            score3 = ScoreCalculator.score;
        }


        if (ScoreCalculator.score >= 5 && isLevel1)
        {
            ShowLevelTwoInstructions();
            isLevel1 = false;
            isLevel2 = true;
        }
        else if (ScoreCalculator.score <= 5 && isLevel1)
        {
            ShowLevelOneInstructions();
            ScoreCalculator.score = 0;
        }
        else if (ScoreCalculator.score >= 10 && isLevel2)
        {
            ShowLevelThreeInstructions();
            isLevel3 = true;
            isLevel1 = false;
            isLevel2 = false;
        }
        else if (ScoreCalculator.score <= 10 && isLevel2)
        {
            ShowLevelTwoInstructions();
            isLevel2 = true;
            isLevel3 = false;
            isLevel1 = false;
            ScoreCalculator.score = score1;
        }
        else if (ScoreCalculator.score >= 15 && isLevel3)
        {
            ShowEndGamePanel();
            isLevel1 = true;
            isLevel2 = false;
            isLevel3 = false;
            ScoreCalculator.score = 0;
            isGameOver = true;
            Debug.Log("game over test");
        }
        else if (ScoreCalculator.score <= 15 && isLevel3)
        {
            ShowLevelThreeInstructions();
            isLevel3 = true;
            isLevel1 = false;
            isLevel2 = false;
            ScoreCalculator.score = score2;
        }
        else
        {
            ShowEndGamePanel();
            isLevel2 = false;
            isLevel3 = false;
            isGameOver = true;
            Debug.Log("game over test");
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

    private void ShowLevelOneInstructions()
    {
        level1GamePanel.SetActive(true);
        //menuePanel.SetActive(false);
    }
    private void ShowLevelTwoInstructions()
    {
        level2GamePanel.SetActive(true);
        //menuePanel.SetActive(false);
    }
    private void ShowLevelThreeInstructions()
    {
        level3GamePanel.SetActive(true);
        //menuePanel.SetActive(false);
    }

    private void ShowEndGamePanel()
    {
        endGamePanel.SetActive(true);
        //menuePanel.SetActive(false);
        scoreText.text = $"Score: {ScoreCalculator.score}";
    }

    public void StartButtonClick()
    {
        AudioSpawnSharedVariables.trialsCount = 0;
        AudioSpawnSharedVariables.maxTrials = 5;
        StartCoroutine(SpawnObjectsRandomly());
    }
}