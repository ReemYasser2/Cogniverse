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

    public void HideMaze()
    {
        mazePrefabs[mazeIndex].SetActive(false);
        timerCanvas.SetActive(false);

        if (LevelsTransition.isLevel2)
        {
            level2.ShowHideMushrooms(false);
        }

        if (mazeIndex == 0)
        {
            maze1Canvas.SetActive(false);
        }
        else if (mazeIndex == 1)
        {
            maze2Canvas.SetActive(false);
        }
    }

    public void ShowMaze()
    {
        mazePrefabs[mazeIndex].SetActive(true);
        timerCanvas.SetActive(true);

        if (LevelsTransition.isLevel2)
        {
            level2.ShowHideMushrooms(true);
        }

        if (mazeIndex == 0)
        {
            maze1Canvas.SetActive(true);
        }
        else if (mazeIndex == 1)
        {
            maze2Canvas.SetActive(true);
        }
    }
}
