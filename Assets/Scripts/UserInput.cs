using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    AudioManager audioManager;
    SpawnManager spawnManager;
    ScoreCalculation scoreCalculation;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        scoreCalculation = FindObjectOfType<ScoreCalculation>();
        audioManager.AssignScoreCalculation(scoreCalculation);
        spawnManager.AssignScoreCalculation(scoreCalculation);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnManager.TriggerPositionComparison();
            spawnManager.isAPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Letter L pressed");
            audioManager.TriggerAudioComparison();
            audioManager.keyPressedDuringAudioPlayback = true;
        }
    }
}
