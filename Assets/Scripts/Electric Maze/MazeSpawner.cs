using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSpawner : MonoBehaviour
{
    public GameObject[] mazePrefabs;
    public Transform spawnPosition;
    public int mazeSelection = 0;
    public GameObject maze1Canvas;
    public GameObject maze2Canvas;
    public int mazeIndex;

    // This function chooses one maze randomly 
    public void SelectMazeRandomly()
    {
        LevelsTransition.isGameOver = false;
        mazeIndex = Random.Range(0, mazePrefabs.Length);
        mazePrefabs[mazeIndex].SetActive(true);
        if (mazeIndex == 0)
        {
            mazeSelection = 1;
            maze1Canvas.SetActive(true);
        }
        else if (mazeIndex == 1)
        {
            mazeSelection = 2;
            maze2Canvas.SetActive(true);
        }
    }

    public void RestartGame()
    {
        mazePrefabs[mazeIndex].SetActive(false);
        maze1Canvas.SetActive(false);
        maze2Canvas.SetActive(false);
        SelectMazeRandomly();
        LevelsTransition.level1();
    }
}
