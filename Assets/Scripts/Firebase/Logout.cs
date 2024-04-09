using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logout : MonoBehaviour
{

    private FirebaseAuthManager authManager;

    private void Start()
    {
        // Find the FirebaseAuthManager instance in the scene
        authManager = FindObjectOfType<FirebaseAuthManager>();

        if (authManager == null)
        {
            Debug.LogError("FirebaseAuthManager not found in the scene.");
            return;
        }
    }

    public void logout() { authManager.Logout(); }
}
