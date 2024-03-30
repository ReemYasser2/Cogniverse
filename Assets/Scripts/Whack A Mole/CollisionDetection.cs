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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collision with " + collision.gameObject.name);
        spawner = GetComponent<Spawner>();
        if (collision.gameObject.CompareTag("Bat") && gameObject.activeSelf)
        {
            while (gameObject.transform.position.y > 3.7f)
            {
                float step = hitDownwardSpeed * Time.deltaTime;
                gameObject.transform.Translate(Vector3.down * step);
            }
            if (ScoreCalculationWhack.isLevel1 ) {
            ScoreCalculationWhack.Increment();
            audioSource.PlayOneShot(collisionAudio);
            }
            else if(ScoreCalculationWhack.isLevel2 && gameObject.layer == 11)
            {
                ScoreCalculationWhack.Increment();
                audioSource.PlayOneShot(collisionAudio);
            }
            else if (ScoreCalculationWhack.isLevel2) {
                ScoreCalculationWhack.Decrement();
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
        yield return new WaitForSeconds(1.0f);

        // After waiting for the specified duration, reset the text to nothing
        ScoreCalculationWhack.reinforcementText = "";
    }
}

