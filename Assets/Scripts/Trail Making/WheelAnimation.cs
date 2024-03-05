using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    public float rotationAngle = 30.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationAngle * Time.deltaTime); //rotates 50 degrees per second around z axis
    }

}
