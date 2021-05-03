using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoretext;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Prints the final Score and high score to the end screen
        scoretext.text = "Final Score:  " + PlayerPrefs.GetInt("PlayerFinalScore").ToString();
        highScoreText.text = "High Score:  " + PlayerPrefs.GetInt("PlayerHighScore").ToString();
    }

}
