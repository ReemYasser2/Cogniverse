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
    GameObject[] selectedObstaclesMazeOne= new GameObject[5];
    GameObject[] selectedObstaclesMazeTwo = new GameObject[5];
    GameObject[] selectedPowerUpsMazeOne= new GameObject[3];
    GameObject[] selectedPowerUpsMazeTwo = new GameObject[3];
    MazeSpawner mazeSpawner;
    
    void Start()
    {
       mazeSpawner = FindObjectOfType<MazeSpawner>();
    }

    // Update is called once per frame
    public void objectsSpawner() 
    {
        if (mazeSpawner.mazeSelection == 1)
        {
            int lastValue = 6;
            int[] randomObstacleIndices = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomObstacleIndices[i] = Random.Range(0, obstaclesMazeOne.Length);
                if (lastValue == randomObstacleIndices[i])
                { 
                    randomObstacleIndices[i] = Random.Range(0, obstaclesMazeOne.Length);
                }
                selectedObstaclesMazeOne[i] = obstaclesMazeOne[randomObstacleIndices[i]];
                lastValue = randomObstacleIndices[i];
            }

            int tempValue = 4;
            int[] randomPowerUpIndices = new int[3];

            for (int i = 0; i < 3; i++)
            {
                randomPowerUpIndices[i] = Random.Range(0, powerUpsMazeOne.Length);
                if (tempValue == randomPowerUpIndices[i])
                {
                    randomPowerUpIndices[i] = Random.Range(0, powerUpsMazeOne.Length);
                }
                selectedPowerUpsMazeOne[i] = powerUpsMazeOne[randomPowerUpIndices[i]];
                tempValue = randomPowerUpIndices[i];
            }
            
        }
        else if (mazeSpawner.mazeSelection == 2)
        {
            int lastValue = 6;
            int[] randomObstacleIndices = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomObstacleIndices[i] = Random.Range(0, obstaclesMazeTwo.Length);
                if (lastValue == randomObstacleIndices[i])
                {
                    randomObstacleIndices[i] = Random.Range(0, obstaclesMazeTwo.Length);
                }
                selectedObstaclesMazeTwo[i] = obstaclesMazeTwo[randomObstacleIndices[i]];
                lastValue = randomObstacleIndices[i];
            }
            

            int[] randomPowerUpIndices = new int[3];
            int tempValue = 4;
            for (int i = 0; i < 3; i++)
            {
                randomPowerUpIndices[i] = Random.Range(0, powerUpsMazeTwo.Length);
                if (tempValue == randomPowerUpIndices[i])
                {
                    randomPowerUpIndices[i] = Random.Range(0, powerUpsMazeTwo.Length);
                }
                selectedPowerUpsMazeTwo[i] = powerUpsMazeTwo[randomPowerUpIndices[i]];
                tempValue = randomPowerUpIndices[i];
            }
        
            
        }
    
   }
    public void ShowHideMushrooms(bool isVisible)
    {
        if (mazeSpawner.mazeSelection == 2)
        {
            for (int i = 0; i < selectedPowerUpsMazeTwo.Length; i++)
            {
                selectedPowerUpsMazeTwo[i].SetActive(isVisible);
            }
            for (int i = 0; i < selectedObstaclesMazeTwo.Length; i++)
            {
                selectedObstaclesMazeTwo[i].SetActive(isVisible);
            }
        }
        else if(mazeSpawner.mazeSelection == 1)
        {
            for (int i = 0; i < selectedObstaclesMazeOne.Length; i++)
            {
                selectedObstaclesMazeOne[i].SetActive(isVisible);
            }
            for (int i = 0; i < selectedPowerUpsMazeOne.Length; i++)
            {
                selectedPowerUpsMazeOne[i].SetActive(isVisible);
            }
        }
    }
}
