using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DualMenuHandler : MonoBehaviour
{
    // menu without instructions
    public GameObject instructionsLevel1RetryCanvas;
    public GameObject instructionsLevel2RetryCanvas;
    public GameObject instructionsLevel3RetryCanvas;

    // menu without instructions
    public GameObject instructionsLevel2NextCanvas;
    public GameObject instructionsLevel3NextCanvas;

    // menu without instructions
    public GameObject instructionsLevel1SelectlvlCanvas;
    public GameObject instructionsLevel2SelectlvlCanvas;
    public GameObject instructionsLevel3SelectlvlCanvas;

    // menu with instrucrions 
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject instructionsLevel3MenuCanvas;

    // menu without instructions
    public GameObject completeLevel1Canvas;
    public GameObject completeLevel2Canvas;
    public GameObject completeLevel3Canvas;


    public GameObject menuCanvas;
    public GameObject menuWithoutInstructionsCanvas;
    public GameObject mainMenuCanvas;
    public GameObject selectLevelCanvas;

    public TextMeshProUGUI scorelvl1Text;
    public TextMeshProUGUI scorelvl2Text;
    public TextMeshProUGUI scorelvl3Text;

    public GameObject level2Button;
    public GameObject level2LockButton;
    public GameObject level3Button;
    public GameObject level3LockButton;

    public TextMeshProUGUI scorelvl1retryText;
    public TextMeshProUGUI scorelvl2retryText;
    public TextMeshProUGUI scorelvl3retryText;

    public AudioSource[] audioSources;
    private List<AudioSource> pausedAudioSources = new List<AudioSource>(); // Store paused audio sources

    public void InstructionsHandler()
    {
        GeneralMenuHandler.InstructionsHandler(ScoreCalculator.isLevel1, ScoreCalculator.isLevel2, ScoreCalculator.isLevel3, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas);
    }

    public void ShowMenuHandler()
    {
        //GeneralMenuHandler.ShowMenuHandler(ScoreCalculator.isGameStart, ScoreCalculator.isLevel2, ScoreCalculator.isLevel3, ScoreCalculator.isGameOver, menuCanvas, instructionsLevel1Canvas, instructionsLevel2Canvas, instructionsLevel3Canvas, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas, 1, 3);
        if (menuCanvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false && instructionsLevel3MenuCanvas.activeSelf == false && completeLevel1Canvas.activeSelf == false && completeLevel2Canvas.activeSelf == false && completeLevel3Canvas.activeSelf == false && instructionsLevel2NextCanvas.activeSelf == false && instructionsLevel3NextCanvas.activeSelf == false)
        {
            if ((ScoreCalculator.isLevel1 || ScoreCalculator.isLevel2 || ScoreCalculator.isLevel3) && !ScoreCalculator.isGameOver)
            {
                menuCanvas.SetActive(true);
                TimerDual.PauseTimer();
                PauseGame.Pause();
            }
        }
        if ((instructionsLevel1RetryCanvas.activeSelf == true || instructionsLevel2RetryCanvas.activeSelf == true || instructionsLevel3RetryCanvas.activeSelf == true || instructionsLevel2NextCanvas.activeSelf == true || instructionsLevel3NextCanvas.activeSelf == true || instructionsLevel1SelectlvlCanvas.activeSelf == true || instructionsLevel2SelectlvlCanvas.activeSelf == true || instructionsLevel3SelectlvlCanvas.activeSelf == true || completeLevel1Canvas.activeSelf == true || completeLevel2Canvas.activeSelf == true || completeLevel3Canvas.activeSelf == true) && mainMenuCanvas.activeSelf == false && selectLevelCanvas.activeSelf == false)
        {
            menuWithoutInstructionsCanvas.SetActive(true);
            PauseResumeInstructionsAudio();
        }
    }

    public void PauseResumeInstructionsAudio()
    {
        if (instructionsLevel1SelectlvlCanvas.activeSelf == true || instructionsLevel2SelectlvlCanvas.activeSelf == true || instructionsLevel3SelectlvlCanvas.activeSelf == true || instructionsLevel2NextCanvas.activeSelf == true || instructionsLevel3NextCanvas.activeSelf == true)
        {
            TogglePauseResume();
        }
    }

    public void TogglePauseResume()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            AudioSource audioSource = audioSources[i];
            if (audioSource.isPlaying)
            {
               // Debug.Log("Audio " + i + " is currently playing.");
                if (audioSource.isPlaying && !pausedAudioSources.Contains(audioSource))
                {
                    audioSource.Pause();
                    pausedAudioSources.Add(audioSource); // Add paused audio source to the list
                }

            }
            else if (pausedAudioSources.Contains(audioSource))
            {
                audioSource.UnPause();
                pausedAudioSources.Remove(audioSource); // Remove resumed audio source from the list
            }
        }
    }

    public void StopAudio()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            AudioSource audioSource = audioSources[i];
            pausedAudioSources.Remove(audioSource);
        }
    }
}
