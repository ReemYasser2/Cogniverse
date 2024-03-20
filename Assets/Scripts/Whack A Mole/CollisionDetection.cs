using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float hitDownwardSpeed = 0.5f;
    public float delay = 2.5f;
    public Spawner spawner;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collision with " + collision.gameObject.name);
        spawner = GetComponent<Spawner>();
        if (collision.gameObject.CompareTag("Bat"))
        {
            while (gameObject.transform.position.y > 3.7f)
            {
                float step = hitDownwardSpeed * Time.deltaTime;
                gameObject.transform.Translate(Vector3.down * step);
            }
        }
    }
    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}

