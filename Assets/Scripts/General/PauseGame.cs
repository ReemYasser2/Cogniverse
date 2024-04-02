using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    static bool paused = false;
    public static void Pause()
    {
        if(paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
        }

    }

    // Reset the timer when unpausing the game
    public void Unpause()
    {
        Time.timeScale = 1;
        paused = false;
    }
}
