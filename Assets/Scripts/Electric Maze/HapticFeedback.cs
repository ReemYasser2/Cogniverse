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
            xrController.SendHapticImpulse(0.7f, 2.0f);

            if (Time.time - lastCollisionTime > collisionCooldown)
            {
                Debug.Log("Collision detected with a maze");
                ScoreCalculatorMaze.Increment();
            } 
        }
        lastCollisionTime = Time.time;

        if (collision.gameObject.name == "Mushroom 1(Clone)")
        {
            ScoreCalculatorMaze.Increment();
            Debug.Log("Collision with an obstacle!");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Mushroom 3(Clone)")
        {
            ScoreCalculatorMaze.Decrement();
            Debug.Log("Collision with a power-up!");
            Destroy(collision.gameObject);
        }
    }
}
