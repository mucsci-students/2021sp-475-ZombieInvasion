using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public float attacksPerSecond;
    public float damage;
    public int Rays;
    public float rayRange;

    public GameObject Player;
    public GameObject GameManager;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;
    private bool isAlive = true;
    private bool canAttack = true;
    private bool left = true;
    private float angle = 90;
    private bool colliding = false;
    private bool attacking;
    
    private float count = 0f;

    void Start() {
        attacking = false;
        Player = GameObject.Find("ThePlayer");
        GameManager = GameObject.Find("GameManager");
    }

    void Update() {
        playerPosition = Player.transform.position;
        enemyPosition = gameObject.transform.position;

        if(!colliding && isAlive)
        {
            Vector3 dir = playerPosition - transform.position;
            Vector3 rot = transform.eulerAngles;
            rot.y = Quaternion.LookRotation(dir).eulerAngles.y;
            Quaternion targetRot = Quaternion.Euler(rot);
            transform.rotation = Quaternion.Slerp (transform.rotation, targetRot, Time.deltaTime * 5.0f);
        }

        if(isAlive)
        {            
            var positionChange = Vector3.zero;
            int tempCount = 0;
            for(int i = 0; i < Rays; ++i) {
                tempCount++;
                var rotation = gameObject.transform.rotation;
                var moddedRot = Quaternion.AngleAxis((i / (float)Rays) * angle * 2 - angle, gameObject.transform.up);
                var direction = rotation * moddedRot * Vector3.forward;
                var tempPos = enemyPosition + (direction * 1f) + new Vector3(0f, 2f,0f);
                var ray = new Ray(tempPos, direction);

                RaycastHit hitInfo;

                if(Physics.Raycast(ray, out hitInfo, rayRange))
                {
                    if(!(hitInfo.collider.CompareTag("Terrain") || hitInfo.collider.CompareTag("Player")))
                    {
                        colliding = true;
                        if(tempCount < 7)
                        {
                            //rotate right
                            float rot = gameObject.transform.eulerAngles.y + (i * 5f);
                            gameObject.transform.eulerAngles = new Vector3(0f,rot, 0f);
                        }
                        else
                        {
                            //rotate left
                            float rot = gameObject.transform.eulerAngles.y - (i * 5f);
                            gameObject.transform.eulerAngles = new Vector3(0f,rot, 0f);
                        }
                    }  
                }
                else
                {
                    colliding = false;
                }
            }

        }
        
    }

    void FixedUpdate() {
        if(!attacking)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }

    void OnDrawGizmos() {
        for(int i = 0; i < Rays; ++i) {
            var rotation = gameObject.transform.rotation;
            var moddedRot = Quaternion.AngleAxis((i / (float)Rays) * angle * 2 - angle, gameObject.transform.up);
            var dir = rotation * moddedRot * Vector3.forward;
            var tempPos = enemyPosition + (dir * 1f) + new Vector3(0f, 1f,0f);
            Gizmos.DrawRay(tempPos, dir);
        }
    }

    private void OnTriggerStay(Collider other) {
        attacking = true;
        transform.position += new Vector3(0f,0f,0f);
        if(canAttack && GameObject.ReferenceEquals(Player, other.gameObject))
        {
            StartCoroutine("damagePlayer");
        }
    }

    private void OnTriggerEnter(Collider other) {
        attacking = true;
        gameObject.GetComponent<Animation>().Play("Z_Attack");
        left = false;
    }

    private void OnTriggerExit(Collider other) {
        if (GameObject.ReferenceEquals(Player, other.gameObject))
        {
            Invoke("stopAttacking", 1.0f);
        }
    }

    public void stopAttacking() 
    {
        left = true;
        attacking = false;
        gameObject.GetComponent<Animation>().Play("Z_Run_InPlace");
    }

    public IEnumerator damagePlayer() {
        canAttack = false;
        Player.GetComponent<playerController>().TakeDamage(damage);
        yield return new WaitForSeconds(1/attacksPerSecond);
        canAttack = true;
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isAlive = false;
            Die();
        }
    }

    public void Die ()
    {
        gameObject.GetComponent<Animation>().Play("Z_FallingBack");
        moveSpeed = 0;
        foreach(Collider c in gameObject.GetComponents<Collider>()) {
            c.enabled = false;
        }
        AddScore();
        Destroy(gameObject, 1.5f);
    }

    public void AddScore()
    {
        FindObjectOfType<ScoreKeeper>().addScore();
    }
}
