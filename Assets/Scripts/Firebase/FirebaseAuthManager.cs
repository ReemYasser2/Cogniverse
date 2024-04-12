using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Net.Mail;
using System.Threading.Tasks;
using Firebase.Extensions;
using Unity.VisualScripting;
using Firebase.Database;
using System;
using UnityEngine.SceneManagement;

public class FirebaseAuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    public static string IDcopy;

    public SignupinVariables variables;
    public DatabaseManager databaseManager;

    public SceneHandler SceneHandler;
    public static bool islogin = false;
    private bool sceneLoaded = false;

    private void Awake()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.Log(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

    }

    public void Signup()
    {
        CreateUser(variables.emailField.text, variables.passwordField.text);
        
    }

    public void Login()
    {
        SignInUser(variables.emailLoginField.text, variables.passwordLoginField.text);
    }

    public void Logout()
    {
        auth.SignOut();
        islogin = false;
        DatabaseManager.isGroupChoosen = false;
        DatabaseManager.isGenderChoosen = false;
        Debug.Log("User signed out.");
        sceneLoaded = false;
    }

    void CreateUser(string email, string password)
    {
        // Check if email and password are valid
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Invalid email or password.");
            databaseManager.messageText.text = "Invalid email or password.";
            databaseManager.messageCanvas.SetActive(true);
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.Log("CreateUserWithEmailAndPasswordAsync was canceled.");
                databaseManager.messageText.text = "Process was canceled.";
                databaseManager.messageCanvas.SetActive(true);
                return;
            }
            if (task.IsFaulted)
            {
                // Parse the exception message to determine the error
                string errorMessage = task.Exception?.InnerException?.Message;

                if (errorMessage != null)
                {
                    if (errorMessage.Contains("email is already in use"))
                    {
                        Debug.Log("Email is already in use. Please use a different email.");
                        databaseManager.messageText.text = "Email is already in use. Please use a different email.";
                        databaseManager.messageCanvas.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("CreateUserWithEmailAndPasswordAsync encountered an error: " + errorMessage);
                        databaseManager.messageText.text = "An error occurs, please try again..";
                        databaseManager.messageCanvas.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    databaseManager.messageText.text = "An error occurs, please try again..";
                    databaseManager.messageCanvas.SetActive(true);
                }
                return;
            }
            //databaseManager.validMessageText.text = "You account has been successfully created.";
            //databaseManager.validMessageCanvas.SetActive(true);
            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            DatabaseGamesVariables.userID = result.User.UserId;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
            islogin = true;
            databaseManager.CreateUser(DatabaseGamesVariables.userID);
            databaseManager.GetGroupType(DatabaseGamesVariables.userID);
            sceneLoaded = false;

            
        });

    }

    public void SignInUser(string email, string password)
    {
        // Check if email and password are valid
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Invalid email or password.");
            databaseManager.messageText.text = "Invalid email or password.";
            databaseManager.messageCanvas.SetActive(true);
            return;
        }

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.Log("SignInWithEmailAndPasswordAsync was canceled.");
                databaseManager.messageText.text = "Process was canceled.";
                databaseManager.messageCanvas.SetActive(true);
                return;
            }
            if (task.IsFaulted)
            {
                // Parse the exception message to determine the error
                string errorMessage = task.Exception?.InnerException?.Message;

                if (errorMessage != null)
                {
                    if (errorMessage.Contains("password is invalid"))
                    {
                        Debug.Log("Invalid password. Please enter the correct password.");
                        databaseManager.messageText.text = "Invalid password. Please enter the correct password.";
                        databaseManager.messageCanvas.SetActive(true);
                    }
                    else if (errorMessage.Contains("no user record"))
                    {
                        Debug.Log("No user found with this email address. Please sign up first.");
                        databaseManager.messageText.text = "No user found with this email address. Please sign up first.";
                        databaseManager.messageCanvas.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("SignInWithEmailAndPasswordAsync encountered an error: " + errorMessage);
                        databaseManager.messageText.text = "An error occurs, please try again..";
                        databaseManager.messageCanvas.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    databaseManager.messageText.text = "An error occurs, please try again..";
                    databaseManager.messageCanvas.SetActive(true);
                }
                return;
            }
            islogin = true;
            //databaseManager.validMessageText.text = "Login Successful.";
            //databaseManager.validMessageCanvas.SetActive(true);
            Firebase.Auth.AuthResult result = task.Result;
            DatabaseGamesVariables.userID = result.User.UserId;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
            databaseManager.GetGroupType(DatabaseGamesVariables.userID);
            sceneLoaded = false;

            
        });
    }

    // Handle initialization of the necessary firebase modules:
    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
                DatabaseGamesVariables.userID = null;
            }
            user = auth.CurrentUser;
            if (signedIn && !sceneLoaded)
            {
                Debug.Log("Signed in " + user.UserId);
                //SceneManager.LoadScene(1);
                sceneLoaded = true; 
            }
        }
    }

    // Handle removing subscription and reference to the Auth instance.
    // Automatically called by a Monobehaviour after Destroy is called on it.
    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }
}
