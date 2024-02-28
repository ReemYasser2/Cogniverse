using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollision : MonoBehaviour
{

    private float lastCollisionTime;

    public float collisionCooldown = 1f; // Cooldown period to prevent multiple collisions in the same frame

    private void OnCollisionEnter(Collision collision)
    {
        int layerNumber = collision.collider.gameObject.layer;
        if (layerNumber == 6) // layer 6 represents the maze
        {
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
