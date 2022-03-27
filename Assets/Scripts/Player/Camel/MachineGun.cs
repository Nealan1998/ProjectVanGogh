using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    // Gun 
    public int damage, magazineSize, bulletsPerTap, bulletsLeft, bulletsShot;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public bool allowButtonHeld;

    // Bools
    public bool shooting, readyToShoot, reloading;

    //References
    //public Camera cam;
    public GameObject plane;
    public Transform attackPoint;
    public RaycastHit rayBullet;
    public LayerMask enemies;

    private void Start()
    {
        readyToShoot = true;
    }
    private void Update()
    {
        GunInput();
    }
    private void GunInput()
    {
        // Set buton
        if (allowButtonHeld) shooting = Input.GetKey(KeyCode.LeftShift);
        else shooting = Input.GetKeyDown(KeyCode.V);

        if(readyToShoot && shooting && bulletsLeft > 0 )
        {
            Shoot();
        }
        
    }

    private void ResetShot()
    {

        readyToShoot = true;
    }
    void Shoot()
    {
        // Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // Calculate
        Vector3 shootingDirection = plane.transform.forward + new Vector3(x, y, 0);

        // Raycast
        if (Physics.Raycast(plane.transform.position, plane.transform.forward, out rayBullet, range, enemies))
        {
            Debug.Log(rayBullet.collider.name);
            if (rayBullet.collider.CompareTag("Enemy"))
                rayBullet.collider.GetComponent<ShootingTarget>().TakeDamage(damage);
        }

        // Set For next shot
        readyToShoot = false;
        bulletsLeft--;
        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
}
