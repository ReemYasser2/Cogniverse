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

    // signup data
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

    public SceneHandler sceneHandler;

    public GameObject usernameCanvas;
    public GameObject demographicsCanvas;
    public GameObject diagnosisCanvas;
    public GameObject loginCanvas;
    public GameObject signupCanvas;
    public GameObject groupTypeCanvas; 
    public GameObject messageCanvas;
    public TMP_Text messageText;

    public static bool isGroupChoosen = false;
    public static bool isGenderChoosen = false;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        // Get the Firebase authentication instance.
        auth = FirebaseAuth.DefaultInstance;
    }

    public void username()
    {
        firstName = firstNameField.text;
        lastName = lastNameField.text;
    }

    public void Age()
    {

        if (string.IsNullOrEmpty(ageField.text))
        {
            Debug.Log("Please enter your age.");
            messageText.text = "Please, Enter your age.";
            messageCanvas.SetActive(true);
            return;
        }

        if (!int.TryParse(ageField.text, out int parsedAge))
        {
            Debug.Log("Invalid age format. Please enter a valid number.");
            messageText.text = "Invalid age format. Please enter a valid number.";
            messageCanvas.SetActive(true);
            return;
        }
        age = parsedAge;
    }

    public void FemaleGender()
    {
        female = "yes";
        male = "no";
        isGenderChoosen = true;
    }

    public void MaleGender()
    {
        female = "no";
        male = "yes";
        isGenderChoosen = true;
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
        isGroupChoosen = true;
    }

    public void positive()
    {
        iscontrolGroup = false;
        isnegativeGroup = false;
        ispositiveGroup = true;
        isGroupChoosen = true;
    }

    public void negative()
    {
        iscontrolGroup = false;
        isnegativeGroup = true;
        ispositiveGroup = false;
        isGroupChoosen = true;
    }


    // input validation 
    private void usernameValidation(string fname, string lname)
    {
        if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
        {
            Debug.Log("Please, Enter your name.");
            messageText.text = "Please, Enter your name.";
            messageCanvas.SetActive(true);
            return;
        }
        else 
        { 
            usernameCanvas.SetActive(false);
            demographicsCanvas.SetActive(true);
        }
    }

    private void ageValidation(string age)
    {

        if (string.IsNullOrEmpty(age))
        {
            Debug.Log("Please, Enter your age.");
            messageText.text = "Please, Enter your age.";
            messageCanvas.SetActive(true);
            return;
        }
        else if (!isGenderChoosen)
        {
            Debug.Log("Please, Enter your age.");
            messageText.text = "Please, Enter choose your gender.";
            messageCanvas.SetActive(true);
            return;
        }
        else if (!int.TryParse(age, out int ageInteger))
        {
            Debug.Log("Invalid age format. Please enter a valid number.");
            // Handle the case where the age text is not a valid integer
            messageText.text = "Invalid age format. Please enter a valid number.";
            messageCanvas.SetActive(true);
            return;
        }
        else
        {
            demographicsCanvas.SetActive(false);
            signupCanvas.SetActive(true);
        }
    }

    public void groupValidation()
    {
        if (!isGroupChoosen)
        {
            Debug.Log("Please, Choose a number.");
            messageText.text = "Please, Choose a number.";
            messageCanvas.SetActive(true);
            return;
        }
        else
        {
            groupTypeCanvas.SetActive(false);
            usernameCanvas.SetActive(true);
        }
    }

    public void checkUsername() { usernameValidation(firstNameField.text, lastNameField.text); }

    public void checkDemographics() 
    {
        ageValidation(ageField.text.ToString());
    }
    public void CreateUser(string userID)
    {
        SignupCredentials();

        if (userID != null)
        {

            User newUser = new User(firstName, lastName, email, password, age, female, male,
                yesdiagnosis, nodiagnosis, diagnosis, iscontrolGroup, ispositiveGroup, isnegativeGroup);

            string json = JsonUtility.ToJson(newUser);

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
        GetUserData(userID);
        //GetStatisticsData(userID);
        //GetStatisticsDataTrail(userID);
        //GetStatisticsMazeData(userID);
        //GetStatisticsWhackData(userID);
        //GetStatisticsFFData(userID);
    }

    public void GetUserData(string userID)
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

                        Debug.Log("getting data done.");
                        return;
                    }
                }
            }
        });


    }

    public void GetStatisticsData(string userID)
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").Child(userID).Child("GameHandler").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    if (data.Key == "dual")
                    {
                        IDictionary dictUser = (IDictionary)data.Value;
                        

                        DatabaseGamesVariables.islvlOnePasseddual = dictUser.Contains("islvlOnePassed") ? bool.Parse(dictUser["islvlOnePassed"].ToString()) : false;
                        DatabaseGamesVariables.islvlTwoPasseddual = dictUser.Contains("islvlTwoPassed") ? bool.Parse(dictUser["islvlTwoPassed"].ToString()) : false;
                        DatabaseGamesVariables.islvlThreePasseddual = dictUser.Contains("islvlThreePassed") ? bool.Parse(dictUser["islvlThreePassed"].ToString()) : false;
                        DatabaseGamesVariables.highestAccuracyDual = dictUser.Contains("highestAccuracy") ? float.Parse(dictUser["highestAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.lastAccuracyDual = dictUser.Contains("lastAccuracy") ? float.Parse(dictUser["lastAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.highestScoreDual = dictUser.Contains("highestScore") ? float.Parse(dictUser["highestScore"].ToString()) : 0;
                        DatabaseGamesVariables.lastScoreDual = dictUser.Contains("lastScore") ? float.Parse(dictUser["lastScore"].ToString()) : 0;
                        DatabaseGamesVariables.highestGoRTDual = dictUser.Contains("highestGoRT") ? float.Parse(dictUser["highestGoRT"].ToString()) : 0;
                        DatabaseGamesVariables.lastGoRTDual = dictUser.Contains("lastGoRT") ? float.Parse(dictUser["lastGoRT"].ToString()) : 0;
                        DatabaseGamesVariables.highestNoRTDual = dictUser.Contains("highestNoRT") ? float.Parse(dictUser["highestNoRT"].ToString()) : 0;
                        DatabaseGamesVariables.lastNoRTDual = dictUser.Contains("lastNoRT") ? float.Parse(dictUser["lastNoRT"].ToString()) : 0;

                        Debug.Log("acc: " + dictUser["highestAccuracy"]);
                        Debug.Log("accu" + float.Parse(dictUser["lastAccuracy"].ToString()));
                    }
                }
            }
        });
    }
    public void CreateDualData(string userID, string date, string time, int level, float scorePercent,
        float accuracy, float overallTime, float goResponseTime, float noGoResponseTime)
    {
        if (userID != null)
        {
            DualNback newDual = new DualNback(date, time, level, scorePercent, accuracy,
                overallTime, goResponseTime, noGoResponseTime);

            string json = JsonUtility.ToJson(newDual);

            DatabaseReference Ref = dbReference.Child("users").Child(userID).Child("dualNback");

            Ref.Push().SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("dual data added to Firebase with UID: " + userID);
                }
                else
                {
                    Debug.LogError("Failed to add dual data to Firebase: " + task.Exception);
                }
            });

        }
        else
        {
            Debug.LogWarning("Cannot add dual data: No user is currently signed in.");
        }
    }

    public void CreateMazeData(string userID, string date, string time, int level, float overallTime, int numberOfHits)
    {
        if (userID != null)
        {
            Maze newMaze = new Maze(date, time, level, overallTime, numberOfHits);

            string json = JsonUtility.ToJson(newMaze);

            DatabaseReference Ref = dbReference.Child("users").Child(userID).Child("maze");

            Ref.Push().SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("maze data added to Firebase with UID: " + userID);
                }
                else
                {
                    Debug.LogError("Failed to add maze data to Firebase: " + task.Exception);
                }
            });

        }
        else
        {
            Debug.LogWarning("Cannot add maze data: No user is currently signed in.");
        }
    }

    public void CreateTrailData(string userID, string date, string time, int level, float scorePercent,
        float accuracy, float overallTime, int numberOfMistakes)
    {
        if (userID != null)
        {
            TrailMaking newTrail = new TrailMaking(date, time, level, scorePercent,
            accuracy, overallTime, numberOfMistakes);

            string json = JsonUtility.ToJson(newTrail);

            DatabaseReference Ref = dbReference.Child("users").Child(userID).Child("trail");

            Ref.Push().SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("trail data added to Firebase with UID: " + userID);
                }
                else
                {
                    Debug.LogError("Failed to add trail data to Firebase: " + task.Exception);
                }
            });

        }
        else
        {
            Debug.LogWarning("Cannot add trail data: No user is currently signed in.");
        }
    }

    public void CreateWhackData(string userID, string date, string time, int level, float scorePercent,
        float accuracy, float overallTime, float goResponseTime, float noGoResponseTime)
    {
        if (userID != null)
        {
            WhackAmole newWhack = new WhackAmole(date, time, level, scorePercent,
            accuracy, overallTime, goResponseTime, noGoResponseTime);

            string json = JsonUtility.ToJson(newWhack);

            DatabaseReference Ref = dbReference.Child("users").Child(userID).Child("whack");

            Ref.Push().SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("whack data added to Firebase with UID: " + userID);
                }
                else
                {
                    Debug.LogError("Failed to add whack data to Firebase: " + task.Exception);
                }
            });

        }
        else
        {
            Debug.LogWarning("Cannot add whack data: No user is currently signed in.");
        }
    }

    public void CreateFocusData(string userID, string date, string time, int level, float scorePercent,
        float accuracy, float overallTime, float goResponseTime, float noGoResponseTime)
    {
        if (userID != null)
        {
            FocusFusion newfocus = new FocusFusion(date, time, level, scorePercent,
            accuracy, overallTime, goResponseTime, noGoResponseTime);

            string json = JsonUtility.ToJson(newfocus);

            DatabaseReference Ref = dbReference.Child("users").Child(userID).Child("focus");

            Ref.Push().SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("focus data added to Firebase with UID: " + userID);
                }
                else
                {
                    Debug.LogError("Failed to add focus data to Firebase: " + task.Exception);
                }
            });

        }
        else
        {
            Debug.LogWarning("Cannot add focus data: No user is currently signed in.");
        }
    }

    public void GetStatisticsDataTrail(string userID)
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").Child(userID).Child("GameHandler").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    if (data.Key == "trail")
                    {
                        IDictionary dictUser = (IDictionary)data.Value;
                        

                        DatabaseGamesVariables.islvlOnePassedtrail = dictUser.Contains("islvlOnePassed") ? bool.Parse(dictUser["islvlOnePassed"].ToString()) : false;
                        DatabaseGamesVariables.islvlTwoPassedtrail = dictUser.Contains("islvlTwoPassed") ? bool.Parse(dictUser["islvlTwoPassed"].ToString()) : false;
                        DatabaseGamesVariables.islvlThreePassedtrail = dictUser.Contains("islvlThreePassed") ? bool.Parse(dictUser["islvlThreePassed"].ToString()) : false;
                        DatabaseGamesVariables.highestAccuracyTrail = dictUser.Contains("highestAccuracy") ? float.Parse(dictUser["highestAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.lastAccuracyTrail = dictUser.Contains("lastAccuracy") ? float.Parse(dictUser["lastAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.highestScoreTrail = dictUser.Contains("highestScore") ? float.Parse(dictUser["highestScore"].ToString()) : 0;
                        DatabaseGamesVariables.lastScoreTrail = dictUser.Contains("lastScore") ? float.Parse(dictUser["lastScore"].ToString()) : 0;

                        Debug.Log("acc: " + dictUser["highestAccuracy"]);
                        Debug.Log("accu" + float.Parse(dictUser["lastAccuracy"].ToString()));
                    }
                }
            }
        });
    }

    public void GetStatisticsFFData(string userID)
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").Child(userID).Child("GameHandler").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    if (data.Key == "focus")
                    {
                        IDictionary dictUser = (IDictionary)data.Value;

                        DatabaseGamesVariables.islvlOnePassedFF = dictUser.Contains("islvlOnePassed") ? bool.Parse(dictUser["islvlOnePassed"].ToString()) : false;
                        DatabaseGamesVariables.islvlTwoPassedFF = dictUser.Contains("islvlTwoPassed") ? bool.Parse(dictUser["islvlTwoPassed"].ToString()) : false;
                        DatabaseGamesVariables.highestAccuracyFF = dictUser.Contains("highestAccuracy") ? float.Parse(dictUser["highestAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.lastAccuracyFF = dictUser.Contains("lastAccuracy") ? float.Parse(dictUser["lastAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.highestScoreFF = dictUser.Contains("highestScore") ? float.Parse(dictUser["highestScore"].ToString()) : 0;
                        DatabaseGamesVariables.lastScoreFF = dictUser.Contains("lastScore") ? float.Parse(dictUser["lastScore"].ToString()) : 0;
                        DatabaseGamesVariables.highestGoRTFF = dictUser.Contains("highestGoRT") ? float.Parse(dictUser["highestGoRT"].ToString()) : 0;
                        DatabaseGamesVariables.lastGoRTFF = dictUser.Contains("lastGoRT") ? float.Parse(dictUser["lastGoRT"].ToString()) : 0;
                        DatabaseGamesVariables.highestNoRTFF = dictUser.Contains("highestNoRT") ? float.Parse(dictUser["highestNoRT"].ToString()) : 0;
                        DatabaseGamesVariables.lastNoRTFF = dictUser.Contains("lastNoRT") ? float.Parse(dictUser["lastNoRT"].ToString()) : 0;

                        Debug.Log("acc: " + dictUser["highestAccuracy"]);
                        Debug.Log("accu" + float.Parse(dictUser["lastAccuracy"].ToString()));
                    }
                }
            }
        });
    }

    public void GetStatisticsWhackData(string userID)
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").Child(userID).Child("GameHandler").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    if (data.Key == "whack")
                    {
                        IDictionary dictUser = (IDictionary)data.Value;

                        DatabaseGamesVariables.islvlOnePassedWhack = dictUser.Contains("islvlOnePassed") ? bool.Parse(dictUser["islvlOnePassed"].ToString()) : false;
                        DatabaseGamesVariables.islvlTwoPassedWhack = dictUser.Contains("islvlTwoPassed") ? bool.Parse(dictUser["islvlTwoPassed"].ToString()) : false;
                        DatabaseGamesVariables.highestAccuracyWhack = dictUser.Contains("highestAccuracy") ? float.Parse(dictUser["highestAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.lastAccuracyWhack = dictUser.Contains("lastAccuracy") ? float.Parse(dictUser["lastAccuracy"].ToString()) : 0;
                        DatabaseGamesVariables.highestScoreWhack = dictUser.Contains("highestScore") ? float.Parse(dictUser["highestScore"].ToString()) : 0;
                        DatabaseGamesVariables.lastScoreWhack = dictUser.Contains("lastScore") ? float.Parse(dictUser["lastScore"].ToString()) : 0;
                        DatabaseGamesVariables.highestGoRTWhack = dictUser.Contains("highestGoRT") ? float.Parse(dictUser["highestGoRT"].ToString()) : 0;
                        DatabaseGamesVariables.lastGoRTWhack = dictUser.Contains("lastGoRT") ? float.Parse(dictUser["lastGoRT"].ToString()) : 0;
                        DatabaseGamesVariables.highestNoRTWhack = dictUser.Contains("highestNoRT") ? float.Parse(dictUser["highestNoRT"].ToString()) : 0;
                        DatabaseGamesVariables.lastNoRTWhack = dictUser.Contains("lastNoRT") ? float.Parse(dictUser["lastNoRT"].ToString()) : 0;

                        Debug.Log("acc: " + dictUser["highestAccuracy"]);
                        Debug.Log("accu" + float.Parse(dictUser["lastAccuracy"].ToString()));
                    }
                }
            }
        });
    }

    public void GetStatisticsMazeData(string userID)
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").Child(userID).Child("GameHandler").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    if (data.Key == "maze")
                    {
                        IDictionary dictUser = (IDictionary)data.Value;

                        DatabaseGamesVariables.islvlOnePassedMaze = dictUser.Contains("islvlOnePassed") ? bool.Parse(dictUser["islvlOnePassed"].ToString()) : false;
                        DatabaseGamesVariables.islvlTwoPassedMaze = dictUser.Contains("islvlTwoPassed") ? bool.Parse(dictUser["islvlTwoPassed"].ToString()) : false;
                    }
                }
            }
        });
    }

    public void UpdatelvlStatus(string userID, string gameName, string varName, bool isPassed)
    {
        dbReference.Child("users").Child(userID).Child("GameHandler").Child(gameName).Child(varName).SetValueAsync(isPassed);
    }

    public void UpdateStatistics(string userID, string gameName, string varName, float value)
    {
        dbReference.Child("users").Child(userID).Child("GameHandler").Child(gameName).Child(varName).SetValueAsync(value);
    }
}
