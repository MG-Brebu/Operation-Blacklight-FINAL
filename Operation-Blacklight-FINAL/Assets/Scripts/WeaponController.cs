using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // A - Fire Control Variables
    public bool isFiring;
    public ProjectileController projectile;
    public float projectileSpeed;
    public float rateOfFire;
    private float fireCounter;
    public bool fireReady = true;
    public GameObject firepointObj;
    public Transform firePoint;
    private AudioSource gunshot;
    public ParticleSystem shotFX;

    // To Handle Initialization
    void Start()
    {
        gunshot = firepointObj.GetComponent<AudioSource>();
    }

    // To Handle non-Frame-Sensitive Operations
    void Update()
    {
        // A - If weapon is firing, create new projectile respecting set rate of fire
        if (fireReady)
        {
            if (isFiring)
            {
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = rateOfFire;
                    ProjectileController newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                    gunshot.Play();
                    shotFX.Play();
                    newProjectile.projectileSpeed = projectileSpeed;
                    fireReady = false;
                }
            }
            else
            {
                fireCounter = 0;
            }
        }
    }
}
