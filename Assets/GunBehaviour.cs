using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject fireEffect;

    [SerializeField]
    float bulletForce;

    [SerializeField]
    Transform firePoint;

    public void Shoot()
    {
        GameObject spawnedEffect = Instantiate(fireEffect, firePoint.position, firePoint.rotation);
        GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody body = spawnedBullet.GetComponent<Rigidbody>();
        body.AddForce(transform.right * bulletForce, ForceMode.Acceleration);
    }
}
