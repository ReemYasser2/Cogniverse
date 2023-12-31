using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InstructionAudio : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource; 
    public GameObject startButtonPanel;

    void Start()
    {
        startButtonPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlayAudio);
        }

        if (audioSource != null && audioSource.clip != null)
        {
            // Calculate the duration of the audio clip
            float audioDuration = audioSource.clip.length;

            // Invoke a method after the audio clip duration
            Invoke("ShowPanelAfterAudio", audioDuration);
        }
    }

    void PlayAudio()
    {
        // Check if an audio clip is assigned
        if (audioClip != null)
        {
            // Play the audio clip
            audioSource.PlayOneShot(audioClip);
        }
    }

    void ShowPanelAfterAudio()
    {
        if (startButtonPanel != null)
        {
            startButtonPanel.SetActive(true);
        }
    }

    public void StartButtonClick()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); 
        }
    }
}
