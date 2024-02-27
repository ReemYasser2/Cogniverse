using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject powerUp;
    public GameObject obstacle;
    public GameObject stick;
    public Transform [] powerUpPos;
    public Transform[] obstaclePos;
    MazeSpawner mazeSpawner;
    int trials=5;
    void Start()
    {
       mazeSpawner =FindObjectOfType<MazeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        objectsSpawner();
    }
    public void objectsSpawner() // 5 osbtacles & 3 poweups will appear 
    {
        positionAssignment();
        int[] randomObstacleIndices = new int[5];
        for (int i = 0; i < 5; i++)
        {
            randomObstacleIndices[i] = Random.Range(0, obstaclePos.Length);
        }
        GameObject firstObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[0]].position, Quaternion.identity);
        GameObject secondObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[1]].position, Quaternion.identity);
        GameObject thirdObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[2]].position, Quaternion.identity);
        GameObject fourthtObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[3]].position, Quaternion.identity);
        GameObject fifthObstacle = Instantiate(obstacle, obstaclePos[randomObstacleIndices[4]].position, Quaternion.identity);
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
        GameObject firstPowerUp = Instantiate(powerUp, powerUpPos[randomPowerUpIndices[0]].position, Quaternion.identity);
        GameObject secondPowerUp = Instantiate(powerUp, powerUpPos[randomPowerUpIndices[1]].position, Quaternion.identity);
        GameObject thirdPowerUp = Instantiate(powerUp, powerUpPos[randomPowerUpIndices[2]].position, Quaternion.identity);
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

            obstaclePos[0].position = new Vector3(9.918f, 1.344f, -1.118f); obstaclePos[1].position = new Vector3(9.864f, 1.3441f, -1.105f); obstaclePos[2].position = new Vector3(9.935f, 1.193f, -1.117f);
            obstaclePos[3].position = new Vector3(10.097f, 1.1378f, -1.1128f); obstaclePos[4].position = new Vector3(9.918f, 1.344f, -1.118f); obstaclePos[5].position = new Vector3(9.8443f, 1.461f, -1.097f);
            obstaclePos[6].position = new Vector3(10.046f, 1.4621f, -1.087f);
            // power up assignment in maze 2
            powerUpPos[0].position = new Vector3(9.792f, 1.416f, -1.116f); powerUpPos[1].position = new Vector3(9.8029f, 1.149f, -1.12f); powerUpPos[2].position = new Vector3(10.165f, 1.145f, -1.118f);
            powerUpPos[3].position = new Vector3(9.872f, 1.133f, -1.106f); powerUpPos[4].position = new Vector3(10.165f, 1.252f, -1.118f);
        }
        else if (mazeSpawner.mazeSelection == 1)
        {
            Debug.Log("Maze 1");
        }
    }


}
