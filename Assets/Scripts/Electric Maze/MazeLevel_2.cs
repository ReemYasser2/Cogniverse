using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeLevel_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] powerUpsMazeOne;
    public GameObject[] obstaclesMazeOne;
    public GameObject[] obstaclesMazeTwo;
    public GameObject[] powerUpsMazeTwo;
    MazeSpawner mazeSpawner;
    
    void Start()
    {
       mazeSpawner = FindObjectOfType<MazeSpawner>();
    }

    // Update is called once per frame
    public void objectsSpawner() // 5 osbtacles & 3 poweups will appear 
    {
        if (mazeSpawner.mazeSelection == 1)
        {
            int[] randomObstacleIndices = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomObstacleIndices[i] = Random.Range(0, obstaclesMazeOne.Length);
            }
            obstaclesMazeOne[randomObstacleIndices[0]].SetActive(true); obstaclesMazeOne[randomObstacleIndices[1]].SetActive(true); obstaclesMazeOne[randomObstacleIndices[2]].SetActive(true);
            obstaclesMazeOne[randomObstacleIndices[3]].SetActive(true); obstaclesMazeOne[randomObstacleIndices[4]].SetActive(true);

            if (mazeSpawner.mazeSelection == 0)
            {
                obstaclesMazeOne[randomObstacleIndices[0]].SetActive(false); obstaclesMazeOne[randomObstacleIndices[1]].SetActive(false);
                obstaclesMazeOne[randomObstacleIndices[2]].SetActive(false); obstaclesMazeOne[randomObstacleIndices[3]].SetActive(false); obstaclesMazeOne[randomObstacleIndices[4]].SetActive(false);
            }

            int[] randomPowerUpIndices = new int[3];

            for (int i = 0; i < 3; i++)
            {
                randomPowerUpIndices[i] = Random.Range(0, powerUpsMazeOne.Length);
            }
            powerUpsMazeOne[randomPowerUpIndices[0]].SetActive(true); powerUpsMazeOne[randomPowerUpIndices[1]].SetActive(true); powerUpsMazeOne[randomPowerUpIndices[2]].SetActive(true);

            if (mazeSpawner.mazeSelection == 0)
            {
                powerUpsMazeOne[randomPowerUpIndices[0]].SetActive(false); powerUpsMazeOne[randomPowerUpIndices[1]].SetActive(false); powerUpsMazeOne[randomPowerUpIndices[2]].SetActive(false);
            }
        }
        else if (mazeSpawner.mazeSelection == 2)
        {
            int[] randomObstacleIndices = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomObstacleIndices[i] = Random.Range(0, obstaclesMazeTwo.Length);
            }
            obstaclesMazeTwo[randomObstacleIndices[0]].SetActive(true); obstaclesMazeTwo[randomObstacleIndices[1]].SetActive(true); obstaclesMazeTwo[randomObstacleIndices[2]].SetActive(true);
            obstaclesMazeTwo[randomObstacleIndices[3]].SetActive(true); obstaclesMazeTwo[randomObstacleIndices[4]].SetActive(true);

            int[] randomPowerUpIndices = new int[3];

            for (int i = 0; i < 3; i++)
            {
                randomPowerUpIndices[i] = Random.Range(0, powerUpsMazeTwo.Length);
            }
            powerUpsMazeTwo[randomPowerUpIndices[0]].SetActive(true);
            powerUpsMazeTwo[randomPowerUpIndices[1]].SetActive(true);
            powerUpsMazeTwo[randomPowerUpIndices[2]].SetActive(true);
            
        }
    
   }
    public void ShowHideMushrooms(bool isVisible)
    {
        if (mazeSpawner.mazeSelection == 2)
        {
            for (int i = 0; i < powerUpsMazeTwo.Length; i++)
            {
                powerUpsMazeTwo[i].SetActive(isVisible);
            }
            for (int i = 0; i < obstaclesMazeTwo.Length; i++)
            {
                obstaclesMazeTwo[i].SetActive(isVisible);
            }
        }
        else if(mazeSpawner.mazeSelection == 1)
        {
            for (int i = 0; i < obstaclesMazeOne.Length; i++)
            {
                obstaclesMazeOne[i].SetActive(isVisible);
            }
            for (int i = 0; i < powerUpsMazeOne.Length; i++)
            {
                powerUpsMazeOne[i].SetActive(isVisible);
            }
        }
    }
}
