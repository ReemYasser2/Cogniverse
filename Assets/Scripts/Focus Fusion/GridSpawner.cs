using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.Oculus;
using UnityEditor.Rendering;

public class GridSpawner : MonoBehaviour
{
    public GameObject[] gridsPrefabs;
    public Transform spawnPosition; 
    public Transform[] levelTwoSpawnPos;
    GameObject newObject;
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
          //  while (!FocusTimer.isTimeOver)
            {
                
                int randomIndex = Random.Range(0, gridsPrefabs.Length);

                newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.75f);
                if (newObject != null)
                {
                    newObject.SetActive(false);
                   // Destroy(newObject);
                }
            }
        }
        else if (level == 2)
        {
            while (!FocusTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, gridsPrefabs.Length);
                int randomPosIndex = Random.Range(0, levelTwoSpawnPos.Length);
                newObject = Instantiate(gridsPrefabs[randomIndex], levelTwoSpawnPos[randomPosIndex].position, Quaternion.identity);
                yield return new WaitForSeconds(1);
                if (newObject != null)
                {
                    newObject.SetActive(false);
                    Destroy(newObject);
                }
            }
        }
    }
    public void StartSpawning(int level)
    {
        StartCoroutine(RandomSpawner(level));
    }
    public void GetUserResponse()
    {
        Destroy(newObject);
        Debug.Log("AAAAAAAAAAAAA");
    }
    public void UserReleased()
    {
        int randomIndex = Random.Range(0, gridsPrefabs.Length);
        newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity); newObject.SetActive(true);
        new WaitForSeconds(0.75f);
        Debug.Log("Hii");
        newObject.SetActive(false);
        Destroy(newObject);
    }

}
