using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float hitDownwardSpeed = 0.5f;
    public float delay = 2.5f;


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collision with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Bat"))
        {
            // Move the mole downwards temporarily
            transform.Translate(Vector3.down *hitDownwardSpeed * Time.deltaTime);

            // Destroy the mole after a short delay
            Destroy(gameObject, delay);
        }
    }
}

