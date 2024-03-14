using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject[] gridsPrefabs;
    public Transform spawnPosition; 
    public Transform[] levelTwoSpawnPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RandomSpawner(int level)
    {
        if (level == 1)
        {
            while (!FocusTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, gridsPrefabs.Length);

                GameObject newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.8f);
                Destroy(newObject);
            }
        }
        else if (level == 2)
        {
            while (!FocusTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, gridsPrefabs.Length);
                int randomPosIndex = Random.Range(0, levelTwoSpawnPos.Length);
                GameObject newObject = Instantiate(gridsPrefabs[randomIndex], levelTwoSpawnPos[randomPosIndex].position, Quaternion.identity);
                yield return new WaitForSeconds(0.8f);
                Destroy(newObject);
            }
        }
    } 
    public void StartSpawning(int level)
    {
        StartCoroutine(RandomSpawner(level));
    }

}
