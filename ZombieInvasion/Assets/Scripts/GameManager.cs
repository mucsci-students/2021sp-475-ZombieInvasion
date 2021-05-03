using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int spawnTime = 25;
    public int health = 100;
    public Text HealthText;
    public GameObject Zombie;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;

    private int i = 0;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = "Health: " + health; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > i) 
        {
            i += spawnTime;
            SpawnZombies();
            count++;
            if(count % 3 == 0 && spawnTime > 4)
            {
                spawnTime -= 1;
            }
        }
        
        HealthText.text = "Health: " + health;
    }

    private void SpawnZombies() 
    {
        GameObject.Instantiate(Zombie, Spawn1.transform.position, Quaternion.identity);
        GameObject.Instantiate(Zombie, Spawn2.transform.position, Quaternion.identity);
        GameObject.Instantiate(Zombie, Spawn3.transform.position, Quaternion.identity);
        GameObject.Instantiate(Zombie, Spawn4.transform.position, Quaternion.identity);
        GameObject.Instantiate(Zombie, Spawn5.transform.position, Quaternion.identity);
    }
}
