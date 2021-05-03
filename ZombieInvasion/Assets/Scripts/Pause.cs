using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject rifle;
    public GameObject firstPersonScript;

    void Start() 
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Has to be get key down so it only registers during the time 
        // the key is in the down position
        // otherwise it is called every frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if the game is paused or not
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseActivate();
            }
        }
    }

    public void PauseActivate()
    {
        // activate the pause menu screen
        // sets the time scale to 0 so nothing moves
        // then sets the true or false to true 
        pauseMenuUI.SetActive(true);
        rifle.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        firstPersonScript.GetComponent<FirstPersonController>().enabled = false;
    }

    public void Resume()
    {

        // deactivate the pause menu screen
        // sets the time scale to 1 so things start to move
        // then sets the true or false to false
        pauseMenuUI.SetActive(false);
        rifle.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        firstPersonScript.GetComponent<FirstPersonController>().enabled = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public bool isPaused()
    {
       return gameIsPaused = false;
    }

}
