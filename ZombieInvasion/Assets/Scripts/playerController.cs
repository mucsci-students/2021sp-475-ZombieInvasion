using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public float health = 100f;
    public GameObject GameManager;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        Debug.Log("Player Died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        GameManager.GetComponent<GameManager>().health -= 10;
        if(health <= 0)
        {
            isDead = true;
            health = 0;
            FindObjectOfType<ScoreKeeper>().deathCheck();
            Death();
        }
    }
}
