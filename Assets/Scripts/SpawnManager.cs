using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] spawnPositions;
    public float intervalBetweenSpawns = 2.0f;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnObjectsRandomly());
    }

    IEnumerator SpawnObjectsRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalBetweenSpawns);

            // Randomly selecting one of the positions
            int randomIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnPos = spawnPositions[randomIndex].position;

            // Instantiate the cube at the chosen position
            GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);

            // cube visibility time before destroying it
            yield return new WaitForSeconds(0.76f);
            Destroy(newObject);
        }
    }
}
