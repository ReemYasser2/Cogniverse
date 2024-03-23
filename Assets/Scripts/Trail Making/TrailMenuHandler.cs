using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMenuHandler : MonoBehaviour
{
    public LevelsHandler levelsHandler;

    public GameObject instructionsLevel1Canvas;
    public GameObject instructionsLevel2Canvas;
    public GameObject instructionsLevel3Canvas;
    public GameObject completeLevel1Canvas;
    public GameObject completeLevel2Canvas;
    public GameObject completeLevel3Canvas;
    public GameObject instructionsLevel1AudioCanvas;
    public GameObject instructionsLevel2AudioCanvas;
    public GameObject instructionsLevel3AudioCanvas;
    public GameObject instructionsLevel1MenuCanvas;
    public GameObject instructionsLevel2MenuCanvas;
    public GameObject instructionsLevel3MenuCanvas;
    public GameObject menuCanvas;
    public GameObject menuWithoutInstructionsCanvas;
    public GameObject mainMenuCanvas;
    public GameObject selectLevelCanvas;

    public AudioSource[] audioSources;
    private List<AudioSource> pausedAudioSources = new List<AudioSource>(); // Store paused audio sources

    public void TrailInstructionsHandler()
    {
        GeneralMenuHandler.InstructionsHandler(levelsHandler.level1_menu, levelsHandler.level_2, levelsHandler.level_3, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas);
    }

    public void ShowMenuHandlerTrail()
    {
        //GeneralMenuHandler.ShowMenuHandler(levelsHandler.level1_menu, levelsHandler.level_2, levelsHandler.level_3, TrailLevel3.isGameOver, menuCanvas, instructionsLevel1Canvas, instructionsLevel2Canvas, instructionsLevel3Canvas, instructionsLevel1MenuCanvas, instructionsLevel2MenuCanvas, instructionsLevel3MenuCanvas, 2, 3);

        if (menuCanvas.activeSelf == false && instructionsLevel1Canvas.activeSelf == false && instructionsLevel2Canvas.activeSelf == false && instructionsLevel3Canvas.activeSelf == false && instructionsLevel1MenuCanvas.activeSelf == false && instructionsLevel2MenuCanvas.activeSelf == false && instructionsLevel3MenuCanvas.activeSelf == false && completeLevel1Canvas.activeSelf == false && completeLevel2Canvas.activeSelf == false && completeLevel3Canvas.activeSelf == false)
        {
            if ((levelsHandler.level1_menu || levelsHandler.level_2 || levelsHandler.level_3) && !TrailLevel3.isGameOver)
            {
                menuCanvas.SetActive(true);
                CountUpTimer.PauseTimer();
            }
        }
        if ((instructionsLevel1Canvas.activeSelf == true || instructionsLevel2Canvas.activeSelf == true || instructionsLevel3Canvas.activeSelf == true || instructionsLevel1AudioCanvas.activeSelf == true || instructionsLevel2AudioCanvas.activeSelf == true || instructionsLevel3AudioCanvas.activeSelf == true || selectLevelCanvas.activeSelf == true) && mainMenuCanvas.activeSelf == false)
        {
            menuWithoutInstructionsCanvas.SetActive(true);
            PauseResumeInstructionsAudio();
        }
    }

    public void PauseResumeInstructionsAudio()
    {
        if (instructionsLevel1AudioCanvas.activeSelf == true || instructionsLevel2AudioCanvas.activeSelf == true || instructionsLevel3AudioCanvas.activeSelf == true)
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
                Debug.Log("Audio " + i + " is currently playing.");
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
}
