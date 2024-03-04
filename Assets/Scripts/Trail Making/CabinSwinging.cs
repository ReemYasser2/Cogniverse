using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Trail_Making
{
    public class CabinSwinging : MonoBehaviour
    {
        public float swingAmplitude = 10f; // Adjust the amplitude of the swing
        public float swingFrequency = 1f; // Adjust the frequency of the swing
        private float timeElapsed = 0f;

      

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;

            // Calculate the swing angle based on time, amplitude, and frequency
            float swingAngle = Mathf.Sin(timeElapsed * swingFrequency) * swingAmplitude;

            // Apply the swing to the cabin
            transform.localRotation = Quaternion.Euler(0f, 0f, swingAngle);
        }
    }
}