using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.OpenXR.Input;

public class HapticFeedback : MonoBehaviour
{
    public AudioClip collisionSound;
    private XRController xrController;
    private AudioSource audioSource;
    public static int checkpointCounter =15 ;
    private float lastCollisionTime;
    public float collisionCooldown = 1f; // Cooldown period to prevent multiple collisions in the same frame

    void Start()
    {
        xrController = GetComponent<XRController>();
        Debug.Log("controller");

        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the "MazeObject" tag
        if (collision.gameObject.CompareTag("MazeObject"))
        {
            //Debug.Log("collision");
            
            //Debug.Log("buzz");
            audioSource.PlayOneShot(collisionSound);

            // Trigger haptic feedback on the hand controller
            //xrController.SendHapticImpulse(0.7f, 2.0f);

            if (Time.time - lastCollisionTime > collisionCooldown)
            {
                Debug.Log("Collision detected with a maze");
                ScoreCalculatorMaze.Increment();
                StartCoroutine(ResetTextAfterDelay());

            }
        }
        lastCollisionTime = Time.time;

        if (collision.gameObject.CompareTag("MazeObstacle"))
        {
            ScoreCalculatorMaze.Increment();
            StartCoroutine(ResetTextAfterDelay());

            Debug.Log("Collision with an obstacle!");
            //Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MazePowerUp"))
        {
            ScoreCalculatorMaze.Decrement();
            StartCoroutine(ResetTextAfterDelay());

            Debug.Log("Collision with a power-up!");
            Destroy(collision.gameObject); // Change to inActive
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            checkpointCounter++;
            Debug.Log("check " + checkpointCounter);
        }

    }
    IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);

        // After waiting for the specified duration, reset the text to nothing
       ScoreCalculatorMaze.reinforcementText = "";
    }
}
