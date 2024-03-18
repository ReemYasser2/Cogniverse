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
            while (!FocusTimer.isTimeOver)
            {
                if (newObject != null)
                {
                  //  newObject.SetActive(false);
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(0.2f);
                int randomIndex = Random.Range(0, gridsPrefabs.Length);

                newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);

                if (newObject != null)
                {
                    newObject.SetActive(false);
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(0.85f);

            }
        }
        else if (level == 2)
        {                           // will be updated after score calculation 
            while (!FocusTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, gridsPrefabs.Length);
                int randomPosIndex = Random.Range(0, levelTwoSpawnPos.Length);
                newObject = Instantiate(gridsPrefabs[randomIndex], levelTwoSpawnPos[randomPosIndex].position, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
                if (newObject != null)
                {
                    newObject.SetActive(false);
                    Destroy(newObject);
                }
                yield return new WaitForSeconds(1f);

            }
        }
    }
    IEnumerator WhenClicked()
    {
        if (newObject != null)
        {
            newObject.SetActive(false);
            Destroy(newObject);
        }
        int randomIndex = Random.Range(0, gridsPrefabs.Length);
        newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity);
        yield return  new WaitForSeconds(1f);
        
    }
    public void StartSpawning(int level)
    {
        StartCoroutine(RandomSpawner(level));
    }
    public void GetUserResponse()
    {
       StartCoroutine(WhenClicked());       
    }

}
