using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    AudioManager audioManager;
    SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {   
        audioManager = FindObjectOfType<AudioManager>();
        spawnManager = FindObjectOfType<SpawnManager>();

    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnManager.TriggerPositionComparison();
            spawnManager.isAPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Letter L pressed");
            audioManager.TriggerAudioComparison();
            audioManager.keyPressedDuringAudioPlayback = true;
        }
    }
    */
    // 
    public void whenPositionButtonPressed(){
        Debug.Log("Position button pressed");
        spawnManager.TriggerPositionComparison();
        spawnManager.isAPressed = true;
    }

    // 
    public void whenAudioButtonPressed(){
        Debug.Log("Audio button pressed");
        audioManager.TriggerAudioComparison();
        audioManager.keyPressedDuringAudioPlayback = true;
    }
}