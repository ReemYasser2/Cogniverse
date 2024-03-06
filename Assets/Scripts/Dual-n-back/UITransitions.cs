using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITransitions : MonoBehaviour
{
    // function that restarts the game 
    public void PlayAgainButtonClik()
    {
        SceneManager.LoadScene(2);
        AudioSpawnSharedVariables.trialsCount = 0;
        ScoreCalculator.score = 0;
        SpawnManager.isGameStart = false;
    }
}
