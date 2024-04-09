using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DatabaseManager : MonoBehaviour
{
    private string userID;
    private DatabaseReference dbReference;
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

    // Start is called before the first frame update
    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
        // Get the root reference location of the database.
        dbReference  = FirebaseDatabase.DefaultInstance.RootReference;
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

    public void CreateUser()
    {
        SignupCredentials();
        User newUser = new User(firstName, lastName, email, password, age, female, male , yesdiagnosis, nodiagnosis, diagnosis);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("user").Child(userID).SetRawJsonValueAsync(json);
    }
}
