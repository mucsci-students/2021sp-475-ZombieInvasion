using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerFinalScore", currentScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore() 
    {
        currentScore += 10;
        scoreText.text = "Score: " + currentScore.ToString("0");
    }

    public void deathCheck() 
    {
        if (currentScore > PlayerPrefs.GetInt("PlayerHighScore"))
        {
            PlayerPrefs.SetInt("PlayerFinalScore", currentScore);
            PlayerPrefs.SetInt("PlayerHighScore", currentScore);
        }
        else 
        {
            PlayerPrefs.SetInt("PlayerFinalScore", currentScore);
        }


    }
}
