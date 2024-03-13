using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject[] gridsPrefabs;
    public Transform spawnPosition; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator RandomSpawner()
    {
        while (!FocusTimer.isTimeOver)
        {
            int randomIndex = Random.Range(0, gridsPrefabs.Length);
            
            GameObject newObject = Instantiate(gridsPrefabs[randomIndex], spawnPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(0.8f);
            Destroy( newObject );
        }
        
    } 
    public void StartSpawning()
    {
        StartCoroutine(RandomSpawner());
    }

}
