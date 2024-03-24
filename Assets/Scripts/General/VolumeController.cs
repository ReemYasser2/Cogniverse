using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource[] audioSources;

    void Start()
    {
        // Initialize slider value to current audio volume
        volumeSlider.value = 1f;

        // Set up listener for slider value change
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        // Update audio volume for all audio sources
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = value;
        }

        // Update global audio listener volume
        AudioListener.volume = value;
    }
}
