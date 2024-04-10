using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrailReinforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText;
    public AudioSource[] positiveIncreaseAudios;
    public AudioSource[] positiveDecreaseAudios;
    public AudioSource[] negativeIncreaseAudios;
    public AudioSource[] negativeDecreaseAudios;

    // Update is called once per frame
    void Update()
    {
        reinforcmentText.text = ReinforcementManagement.reinforcementText;

    }

    public void increaseAudio(int randomIndexPositiveInc)
    {
        if (ReinforcementManagement.incrementCounter % 5 == 0)
        {
            if (DatabaseGamesVariables.ispositiveGroup)
            {
                for (int i = 0; i < positiveIncreaseAudios.Length; i++)
                {
                    if (i == randomIndexPositiveInc)
                    {
                        AudioSource audioSource = positiveIncreaseAudios[i];
                        audioSource.Play();
                    }
                }
            }
            else if (DatabaseGamesVariables.isnegativeGroup)
            {
                for (int i = 0; i < negativeIncreaseAudios.Length; i++)
                {
                    if (i == randomIndexPositiveInc)
                    {
                        AudioSource audioSource = negativeIncreaseAudios[i];
                        audioSource.Play();
                    }
                }
            }
            else if (DatabaseGamesVariables.iscontrolGroup) { return; }
            else { return; }
        }
    }

    public void decreaseAudio(int randomIndexPositiveDec)
    {
        if (DatabaseGamesVariables.ispositiveGroup)
        {
            for (int i = 0; i < positiveDecreaseAudios.Length; i++)
            {
                if (i == randomIndexPositiveDec)
                {
                    AudioSource audioSource = positiveDecreaseAudios[i];
                    audioSource.Play();
                }
            }
        }
        else if (DatabaseGamesVariables.isnegativeGroup)
        {
            for (int i = 0; i < negativeDecreaseAudios.Length; i++)
            {
                if (i == randomIndexPositiveDec)
                {
                    AudioSource audioSource = negativeDecreaseAudios[i];
                    audioSource.Play();
                }
            }
        }
        else if (DatabaseGamesVariables.iscontrolGroup) {  return ; }
        else { return; }
    }
}
