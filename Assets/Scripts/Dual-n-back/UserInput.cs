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

    public void whenPositionButtonPressed(){
        //Debug.Log("Position button pressed");
        spawnManager.TriggerPositionComparison();
        spawnManager.isAPressed = true;
    }

    // 
    public void whenAudioButtonPressed(){
       // Debug.Log("Audio button pressed");
        audioManager.TriggerAudioComparison();
        audioManager.keyPressedDuringAudioPlayback = true;

    }

    public void whenColorButtonPressed() 
    {
        //Debug.Log("color button pressed");
        spawnManager.TriggerColorComparison();
        spawnManager.isColorPressed = true;

    }
}