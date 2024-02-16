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
    public GameObject menuePanel;
    public Transform[] spawnPositions;
    public Vector3 currentPosition;
    private Vector3 oldPosition;
    public float intervalBetweenSpawns = 2.0f;
    public bool isAPressed = false;
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
            yield return new WaitForSeconds(intervalBetweenSpawns);
            ScoreCalculator.reinforcementText = "";
            // Randomly selecting one of the positions
            int randomIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnPos = spawnPositions[randomIndex].position;

            // Instantiate the cube at the chosen position
            GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
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
        ShowEndGamePanel();
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

    private void ShowEndGamePanel()
    {
        endGamePanel.SetActive(true);
        menuePanel.SetActive(false);
        scoreText.text = $"Score: {ScoreCalculator.score}";
    }

    public void StartButtonClick()
    {
        StartCoroutine(SpawnObjectsRandomly());
    }
}
