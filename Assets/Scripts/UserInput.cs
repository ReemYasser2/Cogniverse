using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{ 
    SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

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
            Debug.Log("letter L");
        }
    }
}
