using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeft : MonoBehaviour
{
    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        // move the button down if the letter A is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            button.transform.localPosition = new Vector3(-0.088f, -1.106f, -0.107f);

        }

        // if letter L is released return the button to its position
        if (Input.GetKeyUp(KeyCode.A))
        {
            button.transform.localPosition = new Vector3(-0.088f, -1.065f, -0.107f);

        }
    }
}
