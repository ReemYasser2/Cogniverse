using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] alienOne;
    public GameObject[] alienTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AliensSpawner(int level)
    { if (level == 1 )
        {
            while (!WhackTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, alienOne.Length);
                GameObject firstObject = alienOne[randomIndex];
                int randomIndex2 = Random.Range(0, alienOne.Length);
                GameObject secondObject = alienOne[randomIndex2];
                firstObject.SetActive(true); secondObject.SetActive(true);
                yield return new WaitForSeconds(0.75f);
                firstObject.SetActive(false);
                yield return new WaitForSeconds(0.2f); secondObject.SetActive(false);
            }
        }
    else if (level == 2)
        {
            while (!WhackTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, alienOne.Length);
                GameObject firstObject = alienOne[randomIndex];
                int randomIndex2 = Random.Range(0, alienOne.Length);
                GameObject secondObject = alienTwo[randomIndex2];
                firstObject.SetActive(true); secondObject.SetActive(true);
                yield return new WaitForSeconds(0.75f);
                firstObject.SetActive(false);
                yield return new WaitForSeconds(0.2f); secondObject.SetActive(false);
            }
        }
    }
    public void StartAliensSpawning(int level)
    {
        StartCoroutine(AliensSpawner(level));
    }
}
