using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public DatabaseManager databaseManager;
    // A script that handles moving between scenes to open games from the home screen
    // & exit games returning to the home screen

    public  void OpenSignup()
    {
        SceneManager.LoadScene(0);
    }
    // function that redirects to the home system
    public  void BackToHome()
    {
        SceneManager.LoadScene(1);
        databaseManager.GetStatisticsData(DatabaseGamesVariables.userID);
        databaseManager.GetStatisticsDataTrail(DatabaseGamesVariables.userID);
    }

    // function that opens the dual n-back game
    public  void OpenDualNback()
    {
        SceneManager.LoadScene(2);
    }

    // function that opens the electrical maze game
    public  void OpenElectricalMaze()
    {
        SceneManager.LoadScene(3);
    }

    // function that opens the trail making game
    public  void OpenTrailMaking()
    {
        SceneManager.LoadScene(4);
    }

  
    // function that opens the focus fusion game
    public  void OpenFocusFusion()
    {
        SceneManager.LoadScene(5);
    }

    // function that opens the whack-a-mole game
    public  void OpenWhackAmole()
    {
        SceneManager.LoadScene(6);
    }

    

}
