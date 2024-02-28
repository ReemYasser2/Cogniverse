using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject[] mazePrefabs;
    public Transform spawnPosition;
    public int mazeSelection = 0;

    // This function chooses one maze randomly 
    public void SelectMazeRandomly()
    {
        int mazeIndex = Random.Range(0, mazePrefabs.Length);
        mazePrefabs[mazeIndex].SetActive(true);
        if (mazeIndex == 0)
        {
            mazeSelection = 1;
        }
        else if (mazeIndex == 1)
        {
            mazeSelection = 2;
        }
    }
}
