using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private bool isPlaying = false;
    private AudioClip oldAudioClip;
    private AudioClip currentAudioClip;
    public bool keyPressedDuringAudioPlayback = false;
    public Button startButton;

    //void Start()
    //{
        //audioSource = GetComponent<AudioSource>();
        //StartCoroutine(PlayAudioRandomly());
    //}

    IEnumerator PlayAudioRandomly()
    {
        while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials)
        {
            if (!isPlaying)
            {
                yield return new WaitForSeconds(2.0f);
                ScoreCalculator.isComparisonDone = false;
                int randomIndex = Random.Range(0, audioClips.Length - 19);


                AudioClip clipToPlay = audioClips[randomIndex];

                if (currentAudioClip != null)
                {
                    SetOldClip(currentAudioClip);
                }

                SetCurrentClip(clipToPlay);



                if (clipToPlay != null)
                {
                    isPlaying = true;
                    audioSource.clip = clipToPlay;
                    audioSource.Play();


                    yield return new WaitForSeconds(clipToPlay.length); // Wait until the audio clip finishes playing

                    isPlaying = false;
                    yield return new WaitForSeconds(1.0f);

                    if (!keyPressedDuringAudioPlayback && currentAudioClip != null && oldAudioClip != null)
                    {
                        ScoreCalculator.Increment(oldAudioClip, currentAudioClip);


                    }
                    keyPressedDuringAudioPlayback = false;

                    //+AudioSpawnSharedVariables.trialsCount++;
                }




            }
            yield return null;
        }
    }
    void SetCurrentClip(AudioClip audio)
    {
        currentAudioClip = audio;
    }

    void SetOldClip(AudioClip audio)
    {
        oldAudioClip = audio;
    }
    public AudioClip GetOldClip()
    {
        return oldAudioClip;
    }

    public AudioClip GetCurrentClip()
    {
        return currentAudioClip;
    }
    public void TriggerAudioComparison()
    {

        // If the AudioManager receives the 'L' key press signal, check for audio comparison
        if (currentAudioClip != null && oldAudioClip != null)
        {
            ScoreCalculator.CalculateAudioScore(oldAudioClip, currentAudioClip);
        }
    }

    public void StartButtonClicked()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioRandomly());
    }
}