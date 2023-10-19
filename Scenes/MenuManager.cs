using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // IF the "Play" button is clicked, load the "GamePlay" scene
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        // IF the "Quit" button is clicked, end the game or close the application
        Debug.Log("Game is QUIT!");
        Application.Quit(); // This will work in a standalone build, not in the Unity Editor

    }
}
