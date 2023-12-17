using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips; 
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioRandomly());
    }

    IEnumerator PlayAudioRandomly()
    {
        while (AudioSpawnSharedVariables.trialsCount < AudioSpawnSharedVariables.maxTrials)
        {
            if (!isPlaying)
            {
                yield return new WaitForSeconds(2.0f);

                int randomIndex = Random.Range(0, audioClips.Length);
                AudioClip clipToPlay = audioClips[randomIndex];

                if (clipToPlay != null)
                {
                    isPlaying = true;
                    audioSource.clip = clipToPlay;
                    audioSource.Play();
                    yield return new WaitForSeconds(clipToPlay.length); // Wait until the audio clip finishes playing
                    isPlaying = false;
                    //+AudioSpawnSharedVariables.trialsCount++;
                }
            }
            yield return null;
        }
    }
}
