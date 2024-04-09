using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhackReiforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText;
    public AudioSource[] positiveIncreaseAudios;
    public AudioSource[] positiveDecreaseAudios;
    public AudioSource[] negativeIncreaseAudios;
    public AudioSource[] negativeDecreaseAudios;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        reinforcmentText.text = ScoreCalculationWhack.reinforcementText;

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
