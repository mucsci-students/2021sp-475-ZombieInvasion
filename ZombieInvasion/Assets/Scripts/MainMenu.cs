using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // When this script is called the game is paused
        PauseGame();
    }

    public void PlayGame()
    {
        // Changes from the menu scene to the game scene
        // Unpauses the time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ResumeGame();
    }

    public void QuitGame()
    {
        // Print to the console
        // Quit the game
        Debug.Log("Game has quit");
        Application.Quit();
    }

    void PauseGame()
    {
        // Change time scale to 0 so the game is paused
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        // Change time scale to 1 so the game starts
        Time.timeScale = 1;
    }

}
