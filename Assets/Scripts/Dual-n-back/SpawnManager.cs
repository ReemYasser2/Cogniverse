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

    public TextMeshProUGUI scoreText;
    public Button startButton;
    public int score1;
    public int score2;
    public int score3;
    public static bool isGameStart = false;
    public GameObject colourButton;
    // Start is called before the first frame update
    //private void Start()
    //{
    //StartCoroutine(SpawnObjectsRandomly());
    //}

    IEnumerator SpawnObjectsRandomly()
    {
        while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials)
        {
            isGameStart = true;
            ScoreCalculator.isGameOver = false;
            ScoreCalculator.isStartLevel1 = false;
            ScoreCalculator.isStartLevel2 = false;
            ScoreCalculator.isStartLevel3 = false;
            colourButton.SetActive(false);
            if (ScoreCalculator.isLevel3 == true || ScoreCalculator.isLevel2 == true)
            {               
                colourButton.SetActive(true);
            }
            if (ScoreCalculator.isLevel3 == true)
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

            if(ScoreCalculator.isLevel2 == true || ScoreCalculator.isLevel3 == true)
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
        if (ScoreCalculator.isLevel1)
        {
            score1 = ScoreCalculator.score;
        }
        else if (ScoreCalculator.isLevel2)
        {
            score2 = ScoreCalculator.score;
        }
        else
        {
            score3 = ScoreCalculator.score;
        }


        if (ScoreCalculator.score >= 5 && ScoreCalculator.isLevel1)
        {
            ShowLevelTwoInstructions();
            ScoreCalculator.isLevel1 = false;
            ScoreCalculator.isLevel2 = true;
            ScoreCalculator.isStartLevel2 = true;
        }
        else if (ScoreCalculator.score <= 5 && ScoreCalculator.isLevel1)
        {
            ShowLevelOneInstructions();
            ScoreCalculator.score = 0;
            ScoreCalculator.isStartLevel1 = true;
        }
        else if (ScoreCalculator.score >= 10 && ScoreCalculator.isLevel2)
        {
            ShowLevelThreeInstructions();
            ScoreCalculator.isLevel3 = true;
            ScoreCalculator.isLevel1 = false;
            ScoreCalculator.isLevel2 = false;
            ScoreCalculator.isStartLevel3 = true;
        }
        else if (ScoreCalculator.score <= 10 && ScoreCalculator.isLevel2)
        {
            ShowLevelTwoInstructions();
            ScoreCalculator.isLevel2 = true;
            ScoreCalculator.isLevel3 = false;
            ScoreCalculator.isLevel1 = false;
            ScoreCalculator.score = score1;
            ScoreCalculator.isStartLevel2 = true;
        }
        else if (ScoreCalculator.score >= 15 && ScoreCalculator.isLevel3)
        {
            ShowEndGamePanel();
            ScoreCalculator.isLevel1 = true;
            ScoreCalculator.isLevel2 = false;
            ScoreCalculator.isLevel3 = false;
            ScoreCalculator.score = 0;
            ScoreCalculator.isGameOver = true;
            Debug.Log("game over test");
        }
        else if (ScoreCalculator.score <= 15 && ScoreCalculator.isLevel3)
        {
            ShowLevelThreeInstructions();
            ScoreCalculator.isLevel3 = true;
            ScoreCalculator.isLevel1 = false;
            ScoreCalculator.isLevel2 = false;
            ScoreCalculator.score = score2;
            ScoreCalculator.isStartLevel3 = true;
        }
        else
        {
            ShowEndGamePanel();
            ScoreCalculator.isLevel2 = false;
            ScoreCalculator.isLevel3 = false;
            ScoreCalculator.isGameOver = true;
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