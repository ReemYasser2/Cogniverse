using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRight : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the button down if the letter L is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            button.transform.localPosition = new Vector3(2.57f, 0.037f, 0);

        }

        // if letter L is released return the button to its position
        if (Input.GetKeyUp(KeyCode.L))
        {
            button.transform.localPosition = new Vector3(2.57f, 0.078f, 0);

        }
    }
}
