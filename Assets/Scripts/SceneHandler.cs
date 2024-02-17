using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // A script that handles moving between scenes to open games from the home screen
    // & exit games returning to the home screen

    // function that opens the dual n-back game
    public void OpenDualNback()
    {
        Debug.Log("jkerk");
        SceneManager.LoadScene(1);
    }

    // function that opens the electrical maze game
    public void OpenElectricalMaze()
    {
        SceneManager.LoadScene(2);
    }

    // function that opens the shuffled game
    public void OpenShuffled()
    {
        SceneManager.LoadScene(3);
    }

    // function that opens the trail making game
    public void OpenTrailMaking()
    {
        SceneManager.LoadScene(4);
    }

    // function that opens the focus fusion game
    public void OpenFocusFusion()
    {
        SceneManager.LoadScene(5);
    }

    // function that opens the whack-a-mole game
    public void OpenWhackAmole()
    {
        SceneManager.LoadScene(6);
    }



}
