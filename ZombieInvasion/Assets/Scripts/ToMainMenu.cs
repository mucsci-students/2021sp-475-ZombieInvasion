using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void GotMainMenu()
    {
        // Print to the console
        // Quit the game
        SceneManager.LoadScene("Main Menu");
    }
}
