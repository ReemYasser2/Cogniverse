using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float hitDownwardSpeed = 0.5f;
    public float delay = 2.5f;
    public Spawner spawner;
    public AudioClip collisionAudio;
    private AudioSource audioSource;
    public WhackReiforcement WhackReiforcement;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entered collision with " + collision.gameObject.name);
        spawner = GetComponent<Spawner>();
        if (collision.gameObject.CompareTag("Bat") && gameObject.activeSelf)
        {
            if (ScoreCalculationWhack.isLevel1 && gameObject.tag == ScoreCalculationWhack.tag1)
            {
                TimerStop(1);
                ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime1;
            }
            if (ScoreCalculationWhack.isLevel1 &&  gameObject.tag == ScoreCalculationWhack.tag2)
            {
                TimerStop(2);
                ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime2;
            }
            if (ScoreCalculationWhack.isLevel2 && gameObject.tag == ScoreCalculationWhack.tag1)
            {
                TimerStop(1);
                if (gameObject.layer == 11) { ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime1; }
                else { ScoreCalculationWhack.responseTimeNoGo = ScoreCalculationWhack.responseTimeNoGo + ScoreCalculationWhack.stopWatchtime1; }
            }
            if (ScoreCalculationWhack.isLevel2 &&  gameObject.tag == ScoreCalculationWhack.tag2)
            {
                TimerStop(2);
                if (gameObject.layer == 11) { ScoreCalculationWhack.responseTimeGo = ScoreCalculationWhack.responseTimeGo + ScoreCalculationWhack.stopWatchtime2; }
                else { ScoreCalculationWhack.responseTimeNoGo = ScoreCalculationWhack.responseTimeNoGo + ScoreCalculationWhack.stopWatchtime2; }
            }

            while (gameObject.transform.position.y > 3.7f)
            {
                float step = hitDownwardSpeed * Time.deltaTime;
                gameObject.transform.Translate(Vector3.down * step);
            }
            //DeactivateObject();
            if (ScoreCalculationWhack.isLevel1 ) 
            {
                ScoreCalculationWhack.Increment();
 

                WhackReiforcement.increaseAudio(ScoreCalculationWhack.randomIndexPositiveInc);
                audioSource.PlayOneShot(collisionAudio);
            }
            else if(ScoreCalculationWhack.isLevel2 && gameObject.layer == 11)
            {
                ScoreCalculationWhack.Increment();

                WhackReiforcement.increaseAudio(ScoreCalculationWhack.randomIndexPositiveInc);
                audioSource.PlayOneShot(collisionAudio);
            }
            else if (ScoreCalculationWhack.isLevel2) {
                ScoreCalculationWhack.Decrement();

                WhackReiforcement.decreaseAudio(ScoreCalculationWhack.randomIndexPositiveDec);
                audioSource.PlayOneShot(collisionAudio);
            }
            StartCoroutine(ResetTextAfterDelay());

        }

    }
    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("delay");
        // After waiting for the specified duration, reset the text to nothing
        ScoreCalculationWhack.reinforcementText = "";
    }

    private void TimerStop(int obj)
    {
        if (obj == 1)
        {
            ScoreCalculationWhack.isFirstObjectCollide = true;
            ScoreCalculationWhack.isStopWatch1Start = false;
            ScoreCalculationWhack.elapsedTimeStopWatch1 = 0;
        }
        else if (obj == 2)
        {
            ScoreCalculationWhack.isSecondObjectCollide = true;
            ScoreCalculationWhack.isStopWatch2Start = false;
            ScoreCalculationWhack.elapsedTimeStopWatch2 = 0;
        }
    }
}

