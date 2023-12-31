using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITransitions : MonoBehaviour
{
    public GameObject enterNamePanel;
    public GameObject instructionPanel;
    public GameObject menuPanel;
    public GameObject playButtonPanel;
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI instructionsText;
    public GameObject endGamePanel;

    public void PlayAgainButtonClik()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioSpawnSharedVariables.trialsCount = 0;
        ScoreCalculator.score = 0;
    }

    public void ShowInstructionPanel()
    {
        instructionsText.text = $"Welcome, {playerNameInput.text}!";
        enterNamePanel.SetActive(false);
        instructionPanel.SetActive(true);
        menuPanel.SetActive(false);
        endGamePanel.SetActive(false);
    }

    public void ShowMenuPanel()
    {
        enterNamePanel.SetActive(false);
        instructionPanel.SetActive(false);
        menuPanel.SetActive(true);
        endGamePanel.SetActive(false);
    }
}
