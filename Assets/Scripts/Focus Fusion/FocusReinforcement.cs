using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FocusReinforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText;
    public AudioSource[] positiveIncreaseAudios;
    public AudioSource[] positiveDecreaseAudios;
    public AudioSource[] negativeIncreaseAudios;
    public AudioSource[] negativeDecreaseAudios;


    // Update is called once per frame
    void Update()
    {
        reinforcmentText.text = ScoreCalculationFocus.reinforcementText;

    }

    public void increaseAudio(int randomIndexPositiveInc)
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

    public void decreaseAudio(int randomIndexPositiveDec)
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
}
