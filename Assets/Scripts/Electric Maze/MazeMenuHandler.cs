using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMenuHandler : MonoBehaviour
{
    public MazeSpawner mazeSpawner;

    // menu without instructions
    public GameObject instructionsLevel1RetryCanvas;
    public GameObject instructionsLevel2RetryCanvas;

    // menu without instructions
    public GameObject instructionsLevel2NextCanvas;

    // menu without instructions
    public GameObject instructionsLevel1SelectlvlCanvas;
    public GameObject instructionsLevel2SelectlvlCanvas;

    // menu with instrucrions 
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;

    // menu without instructions
    public GameObject completeLevel1Canvas;
    public GameObject completeLevel2Canvas;


    public GameObject menuCanvas;
    public GameObject menuWithoutInstructionsCanvas;
    public GameObject mainMenuCanvas;
    public GameObject selectLevelCanvas;


    public GameObject level2Button;
    public GameObject level2LockButton;

    public AudioSource[] audioSources;
    private List<AudioSource> pausedAudioSources = new List<AudioSource>(); // Store paused audio sources

    public void MazeInstructionsHandler()
    {
        GeneralMenuHandler.InstructionsHandler(ScoreCalculatorMaze.isLevel1, ScoreCalculatorMaze.isLevel2, false, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel2MenuCanvas);
    }

    public void ShowMenuHandlerMaze()
    {
        //GeneralMenuHandler.ShowMenuHandler(LevelsTransition.isLevel1, LevelsTransition.isLevel2, false, LevelsTransition.isGameOver, menuCanvas, instructionsLevel1Canvas, instructionsLevel2Canvas, instructionsLevel2Canvas, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel2MenuCanvas, 1, 2);

        if (menuCanvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false && completeLevel1Canvas.activeSelf == false && completeLevel2Canvas.activeSelf == false && instructionsLevel2NextCanvas.activeSelf == false)
        {
            if ((ScoreCalculatorMaze.isLevel1 || ScoreCalculatorMaze.isLevel2) && !ScoreCalculatorMaze.isGameOver)
            {
                GeneralMenuHandler.MenuHelperFuncrion(menuCanvas, 1);
                //mazeSpawner.HideMaze();
                mazeSpawner.ShowHideMaze(false);
            }
        }
        if (instructionsLevel1RetryCanvas.activeSelf == true || instructionsLevel2RetryCanvas.activeSelf == true || instructionsLevel2NextCanvas.activeSelf == true || instructionsLevel1SelectlvlCanvas.activeSelf == true || instructionsLevel2SelectlvlCanvas.activeSelf == true || completeLevel1Canvas.activeSelf == true || completeLevel2Canvas.activeSelf == true || mainMenuCanvas.activeSelf == true || selectLevelCanvas.activeSelf == true)
        {
            menuWithoutInstructionsCanvas.SetActive(true);
            PauseResumeInstructionsAudio();
        }
    }

    public void PauseResumeInstructionsAudio()
    {
        if (instructionsLevel1SelectlvlCanvas.activeSelf == true || instructionsLevel2SelectlvlCanvas.activeSelf == true || instructionsLevel2NextCanvas.activeSelf == true)
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
                //Debug.Log("Audio " + i + " is currently playing.");
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
