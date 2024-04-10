using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Firebase.Auth;
using System;
using System.Globalization;

public class DatabaseManager : MonoBehaviour
{
    private string userID;
    private DatabaseReference dbReference;
    private FirebaseAuth auth;
    // Registration Variables
    [Space]
    [Header("Registration")]
    public TMP_InputField firstNameField;
    public TMP_InputField lastNameField;
    public TMP_InputField ageField;
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_InputField diagnosisField;
    public Button femalegender;
    public Button malegender;
    public Button yesDiagnosis;
    public Button noDiagnosis;
    //public Button control;
    //public Button positive;
    //public Button negative;
    // gender and diagnosis

    public string firstName;
    public string lastName;
    public string email;
    public string password;
    public int age;
    public string female;
    public string male;
    public string yesdiagnosis;
    public string nodiagnosis;
    public string diagnosis;
    public bool iscontrolGroup;
    public bool ispositiveGroup;
    public bool isnegativeGroup;


    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        // Get the Firebase authentication instance.
        auth = FirebaseAuth.DefaultInstance;
        /*
        // Check if a user is already signed in.
        FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            // User is signed in, retrieve their UID and use it for database operations.
            string userID = user.UserId;
            Debug.Log("User is signed in with UID: " + userID);
        }
        else
        {
            Debug.Log("No user is currently signed in.");
        }
        */
    }

    public void username()
    {
        firstName = firstNameField.text;
        lastName = lastNameField.text;
    }

    public void Age()
    {
        age = int.Parse(ageField.text);
    }

    public void FemaleGender()
    {
        female = "yes";
        male = "no";
    }

    public void MaleGender()
    {
        female = "no";
        male = "yes";
    }

    public void YesDiagnosis()
    {
        yesdiagnosis = "yes";
        nodiagnosis = "no";
    }

    public void NoDiagnosis()
    {
        yesdiagnosis = "no";
        nodiagnosis = "yes";
        diagnosis = "none";
    }

    public void Diagnosis()
    {
        diagnosis = diagnosisField.text;
    }

    public void SignupCredentials()
    {
        email = emailField.text;
        password = passwordField.text;
    }

    public void control()
    {
        iscontrolGroup = true;
        isnegativeGroup = false;
        ispositiveGroup = false;
    }

    public void positive()
    {
        iscontrolGroup = false;
        isnegativeGroup = false;
        ispositiveGroup = true;
    }

    public void negative()
    {
        iscontrolGroup = false;
        isnegativeGroup = true;
        ispositiveGroup = false;
    }

    public void CreateUser(string userID)
    {
        SignupCredentials();
        // Check if a user is signed in.
        //FirebaseUser user = auth.CurrentUser;
        if (userID != null)
        {
            // User is signed in, retrieve their UID and use it as the key for storing user data.
            //string userID = user.UserId;

            User newUser = new User(firstName, lastName, email, password, age, female, male,
                yesdiagnosis, nodiagnosis, diagnosis, iscontrolGroup, ispositiveGroup, isnegativeGroup);
            string json = JsonUtility.ToJson(newUser);

            // Add user data to the Realtime Database with the user's UID as the key
            dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("User data added to Firebase with UID: " + userID);
                }
                else
                {
                    Debug.LogError("Failed to add user data to Firebase: " + task.Exception);
                }
            });
        }
        else
        {
            Debug.LogWarning("Cannot add user data: No user is currently signed in.");
        }

    }
    public void GetGroupType(string userID)
    {
        GetUsers(userID);
     
    }

    public void GetUsers(string userID)
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                
                foreach (DataSnapshot user in snapshot.Children)
                {
                    if (user.Key == userID)
                    {
                        IDictionary dictUser = (IDictionary)user.Value;
                        
                        DatabaseGamesVariables.firstName = dictUser.Contains("firstName") ? dictUser["firstName"].ToString() : "";
                        DatabaseGamesVariables.lastName = dictUser.Contains("lastName") ? dictUser["lastName"].ToString() : "";
                        DatabaseGamesVariables.email = dictUser.Contains("email") ? dictUser["email"].ToString() : "";
                        DatabaseGamesVariables.password = dictUser.Contains("password") ? dictUser["password"].ToString() : "";
                        DatabaseGamesVariables.age = dictUser.Contains("age") ? int.Parse(dictUser["age"].ToString()) : 0;
                        DatabaseGamesVariables.femalegender = dictUser.Contains("femalegender") ? dictUser["femalegender"].ToString() : "";
                        DatabaseGamesVariables.malegender = dictUser.Contains("malegender") ? dictUser["malegender"].ToString() : "";
                        DatabaseGamesVariables.isYesDiagnosis = dictUser.Contains("isYesDiagnosis") ? dictUser["isYesDiagnosis"].ToString() : "";
                        DatabaseGamesVariables.isNoDiagnosis = dictUser.Contains("isNoDiagnosis") ? dictUser["isNoDiagnosis"].ToString() : "";
                        DatabaseGamesVariables.diagnosis = dictUser.Contains("diagnosis") ? dictUser["diagnosis"].ToString() : "";
                        DatabaseGamesVariables.iscontrolGroup = dictUser.Contains("iscontrolGroup") ? bool.Parse(dictUser["iscontrolGroup"].ToString()) : false;
                        DatabaseGamesVariables.ispositiveGroup = dictUser.Contains("ispositiveGroup") ? bool.Parse(dictUser["ispositiveGroup"].ToString()) : false;
                        DatabaseGamesVariables.isnegativeGroup = dictUser.Contains("isnegativeGroup") ? bool.Parse(dictUser["isnegativeGroup"].ToString()) : false;
                    }
                }
            }
        });
    }
}
