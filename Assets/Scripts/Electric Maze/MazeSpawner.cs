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

    public GameObject timerCanvas;

    public MazeLevel_2 level2;

    // This function chooses one maze randomly 
    public void SelectMazeRandomly()
    {
        ScoreCalculatorMaze.isGameOver = false;
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

    public void ShowHideMaze(bool isVisible)
    {
        mazePrefabs[mazeIndex].SetActive(isVisible);
        timerCanvas.SetActive(isVisible);

        if (ScoreCalculatorMaze.isLevel2)
        {
            level2.ShowHideMushrooms(isVisible);
        }

        if (mazeIndex == 0)
        {
            maze1Canvas.SetActive(isVisible);
        }
        else if (mazeIndex == 1)
        {
            maze2Canvas.SetActive(isVisible);
        }
    }
}
