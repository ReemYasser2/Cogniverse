using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] alienOne;
    public GameObject[] alienTwo;
    public float targetYPositionUp = 6.2f;
    public float targetYPositionDown = 3.7f;
    public float movementSpeed = 1.5f;
    
    float[] waitingPeriods = new float[] { 0.1f, 0.15f, 0.2f , 0.25f ,0.3f , 0.35f };

    public LevelTransitionWhack levelTransition;
    //public bool[] isUp;

    IEnumerator AliensSpawner(int level)
    { if (level == 1 )
        {
            while (!ScoreCalculationWhack.isTimeOver && !ScoreCalculationWhack.isHomeButtonClicked)
            {
                ScoreCalculationWhack.isFirstObjectCollide = false;
                ScoreCalculationWhack.isSecondObjectCollide = false;

                int selectedPeriodIndex = Random.Range(0, waitingPeriods.Length);
                float randomWaitTime = waitingPeriods[selectedPeriodIndex];

                int randomIndex = Random.Range(0, alienOne.Length);
                GameObject firstObject = alienOne[randomIndex];
                firstObject.SetActive(true);
                ScoreCalculationWhack.spawnsCounter++;

                int randomIndex2 = Random.Range(0, alienOne.Length);

                GameObject secondObject = alienOne[randomIndex2]; secondObject.SetActive(true);
                ScoreCalculationWhack.spawnsCounter++;
                
                yield return new WaitForSeconds(0.35f);
                
                // start response time
                ScoreCalculationWhack.tag1 = firstObject.tag;
                ScoreCalculationWhack.isStopWatch1Start = true;

                ScoreCalculationWhack.tag2 = secondObject.tag;
                ScoreCalculationWhack.isStopWatch2Start = true;

                MoveObjectUp(firstObject, targetYPositionUp);
                yield return new WaitForSeconds(randomWaitTime);
                MoveObjectUp(secondObject, targetYPositionUp);

                //isUp[randomIndex] = true;
                //isUp[randomIndex2] = true;
                selectedPeriodIndex = Random.Range(0, waitingPeriods.Length);
                randomWaitTime = waitingPeriods[selectedPeriodIndex];

                yield return new WaitForSeconds(0.8f);      
                MoveObjectDown(firstObject, targetYPositionDown);

                if (!ScoreCalculationWhack.isFirstObjectCollide)
                {
                    ScoreCalculationWhack.isStopWatch1Start = false;
                    ScoreCalculationWhack.elapsedTimeStopWatch1 = 0;
                    ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime1;
                }

                firstObject.SetActive(false);
                //isUp[randomIndex] = false;
                yield return new WaitForSeconds(randomWaitTime); 
                MoveObjectDown(secondObject, targetYPositionDown);

                if (!ScoreCalculationWhack.isSecondObjectCollide)
                {
                    ScoreCalculationWhack.isStopWatch2Start = false;
                    ScoreCalculationWhack.elapsedTimeStopWatch2 = 0;
                    ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime2;
                }

                secondObject.SetActive(false);
                //isUp[randomIndex2] = false;
            }
            if (!ScoreCalculationWhack.isHomeButtonClicked) { levelTransition.CheckLevel1(); }
            ScoreCalculationWhack.isLevel1 = false;
            ScoreCalculationWhack.spawnsCounter = 0;
            ScoreCalculationWhack.spawnerGoCounter = 0;
            ScoreCalculationWhack.spawnerNoGoCounter = 0;

        }
    else if (level == 2)
        {
            
            //deactivate all objects for level 1
            foreach (GameObject obj in alienOne)
            {
                obj.SetActive(false);
            }
           
            while (!ScoreCalculationWhack.isTimeOver && !ScoreCalculationWhack.isHomeButtonClicked)
            {
                int selectedPeriodIndex = Random.Range(0, waitingPeriods.Length);
                float randomWaitTime = waitingPeriods[selectedPeriodIndex];

                int randomIndex = Random.Range(0, alienTwo.Length);
                GameObject firstObject = alienTwo[randomIndex];
                firstObject.SetActive(true);
                ScoreCalculationWhack.spawnsCounter++;

                if (firstObject.layer == 11) { ScoreCalculationWhack.spawnerNoGoCounter++; }
                else { ScoreCalculationWhack.spawnerGoCounter++; }

                int randomIndex2 = Random.Range(0, alienOne.Length);
                if (randomIndex2 == randomIndex)
                {
                    randomIndex2 = Random.Range(0, alienOne.Length);
                }
                GameObject secondObject = alienOne[randomIndex2]; 
                secondObject.SetActive(true);
                ScoreCalculationWhack.spawnsCounter++;

                if (secondObject.layer == 11) { ScoreCalculationWhack.spawnerNoGoCounter++; }
                else { ScoreCalculationWhack.spawnerGoCounter++; }

                yield return new WaitForSeconds(0.35f);

                // start response time
                ScoreCalculationWhack.tag1 = firstObject.tag;
                ScoreCalculationWhack.isStopWatch1Start = true;

                ScoreCalculationWhack.tag2 = secondObject.tag;
                ScoreCalculationWhack.isStopWatch2Start = true;

                MoveObjectUp(firstObject, targetYPositionUp); 
                yield return new WaitForSeconds(randomWaitTime);
                MoveObjectUp(secondObject, targetYPositionUp);
                //isUp[randomIndex] = true;
                //isUp[randomIndex2] = true;

                selectedPeriodIndex = Random.Range(0, waitingPeriods.Length);
                randomWaitTime = waitingPeriods[selectedPeriodIndex];
                yield return new WaitForSeconds(0.8f);

                MoveObjectDown(firstObject, targetYPositionDown);

                if (!ScoreCalculationWhack.isFirstObjectCollide)
                {
                    ScoreCalculationWhack.isStopWatch1Start = false;
                    ScoreCalculationWhack.elapsedTimeStopWatch1 = 0;
                    if (firstObject.layer == 11) { ScoreCalculationWhack.responseTimeNoGo = ScoreCalculationWhack.responseTimeNoGo + ScoreCalculationWhack.stopWatchtime1; }
                    else { ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime1; }
                }

                firstObject.SetActive(false);
                //isUp[randomIndex] = false;
                yield return new WaitForSeconds(randomWaitTime);
                MoveObjectDown(secondObject, targetYPositionDown);

                if (!ScoreCalculationWhack.isSecondObjectCollide)
                {
                    ScoreCalculationWhack.isStopWatch2Start = false;
                    ScoreCalculationWhack.elapsedTimeStopWatch2 = 0;
                    if (secondObject.layer == 11) { ScoreCalculationWhack.responseTimeNoGo = ScoreCalculationWhack.responseTimeNoGo + ScoreCalculationWhack.stopWatchtime2; }
                    else { ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime2; }
                }

                secondObject.SetActive(false);
                //isUp[randomIndex2] = false;
            }
            if (!ScoreCalculationWhack.isHomeButtonClicked) { levelTransition.CheckLevel2(); }
            ScoreCalculationWhack.isLevel2 = false;;
            ScoreCalculationWhack.spawnsCounter = 0;
            ScoreCalculationWhack.spawnerGoCounter = 0;
            ScoreCalculationWhack.spawnerNoGoCounter = 0;

        }
    }
    public void StartAliensSpawning(int level)
    {
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

    public void level1()
    {
        ScoreCalculationWhack.isLevel1 = true;
        ScoreCalculationWhack.isLevel2 = false;
        ScoreCalculationWhack.isGameOver = false;
        ScoreCalculationWhack.isHomeButtonClicked = false;
    }

    public void level2()
    {
        ScoreCalculationWhack.isLevel1 = false;
        ScoreCalculationWhack.isLevel2 = true;
        ScoreCalculationWhack.isGameOver = false;
        ScoreCalculationWhack.isHomeButtonClicked = false;
    }


}
