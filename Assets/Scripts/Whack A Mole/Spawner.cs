using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] alienOne;
    public GameObject[] alienTwo;
    public float targetYPositionUp = 4.2f;
    public float targetYPositionDown = 3.7f;
    public float movementSpeed = 0.1f;
    public static bool isLevel1;
    public static bool isLevel2;
    public static bool isGameOver;

    //public bool[] isUp;
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
            isLevel1 = true;
            isLevel2 = false;
            isGameOver = false;
            //activate all objects for level 1
            foreach (GameObject obj in alienOne)
            {
                obj.SetActive(true);
            }
                while (!WhackTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, alienOne.Length);
                GameObject firstObject = alienOne[randomIndex];
                int randomIndex2 = Random.Range(0, alienOne.Length);
                GameObject secondObject = alienOne[randomIndex2];
                MoveObjectUp(firstObject, targetYPositionUp);
                MoveObjectUp(secondObject, targetYPositionUp);
                //isUp[randomIndex] = true;
                //isUp[randomIndex2] = true;

                yield return new WaitForSeconds(0.75f);      
                MoveObjectDown(firstObject, targetYPositionDown);
                //isUp[randomIndex] = false;
                yield return new WaitForSeconds(0.2f);            
                MoveObjectDown(secondObject, targetYPositionDown);
                //isUp[randomIndex2] = false;
            }
        }
    else if (level == 2)
        {
            isLevel1 = false;
            isLevel2 = true;
            isGameOver = false;
            //deactivate all objects for level 1
            foreach (GameObject obj in alienOne)
            {
                obj.SetActive(false);
            }
            //activate all objects for level 2
            foreach (GameObject obj in alienTwo)
            {
                obj.SetActive(true);
            }
          
            while (!WhackTimer.isTimeOver)
            {
                int randomIndex = Random.Range(0, alienTwo.Length);
                GameObject firstObject = alienTwo[randomIndex];
                int randomIndex2 = Random.Range(0, alienTwo.Length);
                GameObject secondObject = alienTwo[randomIndex2];
                MoveObjectUp(firstObject, targetYPositionUp);
                MoveObjectUp(secondObject, targetYPositionUp);
                //isUp[randomIndex] = true;
                //isUp[randomIndex2] = true;
                yield return new WaitForSeconds(0.75f);
                MoveObjectDown(firstObject, targetYPositionDown);
                //isUp[randomIndex] = false;
                yield return new WaitForSeconds(0.2f);
                MoveObjectDown(secondObject, targetYPositionDown);
                //isUp[randomIndex2] = false;
            }
        }
    }
    public void StartAliensSpawning(int level)
    {
     
            WhackTimer.remainingTime = 60;
        

        StartCoroutine(AliensSpawner(level));
    }

    void MoveObjectUp(GameObject obj, float targetYPosition)
    {
        // Move the object upward if it's below the target Y-position
        while (obj.transform.position.y < targetYPosition)
        {
            float step = movementSpeed * Time.deltaTime;
            //Vector3 targetPosition = new Vector3(obj.transform.position.x, targetYPosition, obj.transform.position.z);
            //obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, step);
            obj.transform.Translate(Vector3.up * step);
        }
    }
    void MoveObjectDown(GameObject obj, float targetYPosition)
    {
        // Move the object upward if it's below the target Y-position
        while (obj.transform.position.y > targetYPosition)
        {
            float step = movementSpeed * Time.deltaTime;
            //Vector3 targetPosition = new Vector3(obj.transform.position.x, targetYPosition, obj.transform.position.z);
            //obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, step);
            obj.transform.Translate(Vector3.down * step);
        }
    }
}
