using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loginScene : MonoBehaviour
{
    public SceneHandler SceneHandler;
    public void openHome()
    {
        if (FirebaseAuthManager.islogin)
        {
            SceneHandler.BackToHome();
        }
    }
}
