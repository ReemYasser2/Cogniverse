using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowUserData : MonoBehaviour
{
    [SerializeField] TMP_Text welcomeText;
    [SerializeField] TMP_Text usernameRecordText;


    public void ShowWelcomeUserName()
    {
        welcomeText.text = "Welcome, " + DatabaseGamesVariables.firstName;
    }

    public void ShowUserNameRecords() 
    { 
        usernameRecordText.text = DatabaseGamesVariables.firstName;
    }
}
