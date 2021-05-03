using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera Cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource gunFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot()
    {
        gunFire.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range)){
            
            enemy target = hit.transform.GetComponent<enemy>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }
    }
}
