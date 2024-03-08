using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject powerUp;
    public GameObject obstacle;
    public Transform [] powerUpPos;
    public Transform[] obstaclePos;
    MazeSpawner mazeSpawner;
    
    void Start()
    {
       mazeSpawner =FindObjectOfType<MazeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void objectsSpawner() // 5 osbtacles & 3 poweups will appear 
    {
        positionAssignment();
        int[] randomObstacleIndices = new int[5];
        for (int i = 0; i < 5; i++)
        {
            randomObstacleIndices[i] = Random.Range(0, obstaclePos.Length);
        }
        GameObject firstObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[0]].position, Quaternion.identity); firstObstacle.SetActive(true);   
        GameObject secondObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[1]].position, Quaternion.identity); secondObstacle.SetActive(true); 
        GameObject thirdObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[2]].position, Quaternion.identity); thirdObstacle.SetActive(true);   
        GameObject fourthtObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[3]].position, Quaternion.identity); fourthtObstacle.SetActive(true);
        GameObject fifthObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[4]].position, Quaternion.identity); fifthObstacle.SetActive(true);
        if (mazeSpawner.mazeSelection == 0)
        {
            firstObstacle.SetActive(false); secondObstacle.SetActive(false); 
            thirdObstacle.SetActive(false); fourthtObstacle.SetActive(false); fifthObstacle.SetActive(false);
        }

        int[] randomPowerUpIndices = new int[3];

        for (int i = 0; i < 3; i++)
        {
            randomPowerUpIndices[i] = Random.Range(0, powerUpPos.Length);
        }
        GameObject firstPowerUp = Instantiate(powerUp, powerUpPos[randomPowerUpIndices[0]].position, Quaternion.identity); firstPowerUp.SetActive(true);    
        GameObject secondPowerUp = Instantiate(powerUp, powerUpPos[randomPowerUpIndices[1]].position, Quaternion.identity); secondPowerUp.SetActive(true);  
        GameObject thirdPowerUp = Instantiate(powerUp, powerUpPos[randomPowerUpIndices[2]].position, Quaternion.identity);  thirdPowerUp.SetActive(true);
        if (mazeSpawner.mazeSelection == 0)
        {
            firstPowerUp.SetActive(false); secondPowerUp.SetActive(false); thirdPowerUp.SetActive(false); 
        }
    }

    public void positionAssignment()
    {
        if (mazeSpawner.mazeSelection == 2) //add the 7 obstacle positions and 5 powerup postions based on the maze selection 
        {
            Debug.Log("Maze 2");
            // obstacle assignment in maze 2


            obstaclePos[0].position = new Vector3(9.797f, 2.034f, -1.251f); obstaclePos[1].position = new Vector3(9.846f, 2.208f, -1.227f); obstaclePos[2].position = new Vector3(10.126f, 2.672f, -1.24f);
            obstaclePos[3].position = new Vector3(10.056f, 2.232f, -1.236f); obstaclePos[4].position = new Vector3(10.438f, 2.25f, -1.201f); obstaclePos[5].position = new Vector3(9.797f, 2.445f, -1.251f);
            obstaclePos[6].position = new Vector3(9.892f, 2.445f, -1.238f);
            // power up assignment in maze 2
            powerUpPos[0].position = new Vector3(9.797f, 2.342f, -1.238f); powerUpPos[1].position = new Vector3(9.637f, 2.591f, -1.255f); powerUpPos[2].position = new Vector3(10.275f, 2.243f, -1.234f);
            powerUpPos[3].position = new Vector3(9.79f, 2.449f, -1.234f); powerUpPos[4].position = new Vector3(9.637f, 2.032f, -1.255f);
        }
        else if (mazeSpawner.mazeSelection == 1)
        {
            Debug.Log("Maze 1");
            obstaclePos[0].position = new Vector3(9.849f, 2.407f, -1.239f); obstaclePos[1].position = new Vector3(9.935f, 2.115f, -1.233f); obstaclePos[2].position = new Vector3(10.24f, 1.966f, -1.232f);
            obstaclePos[3].position = new Vector3(9.98f, 2.404f, -1.244f); obstaclePos[4].position = new Vector3(10.242f, 1.968f, -1.235f); obstaclePos[5].position = new Vector3(9.692f, 2.105f, -1.235f);
            obstaclePos[6].position = new Vector3(10.341f, 2.5f, -1.234f);
            // power up assignment in maze 1
            powerUpPos[0].position = new Vector3(9.624f, 2.128f, -1.244f); powerUpPos[1].position = new Vector3(9.78f, 2.261f, -1.242f); powerUpPos[2].position = new Vector3(10.113f, 2.282f, -1.233f);
            powerUpPos[3].position = new Vector3(9.658f, 2.003f, -1.238f); powerUpPos[4].position = new Vector3(10.377f, 1.971f, -1.237f);
        }
    }


}
