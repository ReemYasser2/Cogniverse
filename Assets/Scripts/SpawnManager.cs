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
    public GameObject level2GamePanel;
    public GameObject level3GamePanel;
    //public GameObject menuePanel;
    public Transform[] spawnPositions;
    public Material[] materials;
    public Vector3 currentPosition;
    private Vector3 oldPosition;
    public float intervalBetweenSpawns;
    public bool isAPressed = false;
    public bool isLevel2 = false;
    public bool isLevel3 = false;
    public TextMeshProUGUI scoreText;
    public Button startButton;
    
    // Start is called before the first frame update
    //private void Start()
    //{
        //StartCoroutine(SpawnObjectsRandomly());
    //}

    IEnumerator SpawnObjectsRandomly()
    {
        while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials)
        {
            if (isLevel3 == true)
            {
                intervalBetweenSpawns = 0.5f;
            }
            else
            {
                intervalBetweenSpawns = 2.0f;
            }
            intervalBetweenSpawns = 2.0f;
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
        if (ScoreCalculator.score >= 1 && ScoreCalculator.score <= 5)
        {
            ShowLevelTwoInstructions();
            isLevel2 = true;
        }
        else if (ScoreCalculator.score >= 10)
        {
            ShowLevelThreeInstructions();
            isLevel3 = true;
        }
        else
        {
            ShowEndGamePanel();
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