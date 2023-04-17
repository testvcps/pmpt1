using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void logIn()
    {
        SceneManager.LoadScene("GameMenu");

    }

    public void signUp()
    {
        Debug.Log("Sign Up activated");
    }

    public void exit()
    {
        Application.Quit();
    }
}
