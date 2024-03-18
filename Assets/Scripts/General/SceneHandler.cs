using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // A script that handles moving between scenes to open games from the home screen
    // & exit games returning to the home screen


    // function that redirects to the home system
    public void BackToHome()
    {
        SceneManager.LoadScene(1);
    }

    // function that opens the electrical maze game
    public void OpenElectricalMaze()
    {
        SceneManager.LoadScene(3);
    }
}
