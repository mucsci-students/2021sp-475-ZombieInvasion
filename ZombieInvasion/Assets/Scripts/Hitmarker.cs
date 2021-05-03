using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitmarker : MonoBehaviour
{

    public GameObject hitmarker;
    public float distance = 100f;
        
    // Start is called before the first frame update
    void Start()
    {
        HitDisable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void Shoot() 
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.collider.tag == "Enemy")
            {
                HitActive();
                Invoke("HitDisable", 0.2f);
            }
        }
    }

    private void HitActive() 
    {
        hitmarker.SetActive(true);
    }

    private void HitDisable()
    {
        hitmarker.SetActive(false);
    }
}
