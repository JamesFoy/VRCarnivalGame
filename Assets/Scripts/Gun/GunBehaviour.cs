using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {

    Animator anim;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject fireEffect;

    [SerializeField]
    AudioSource gunShotSound;

    [SerializeField]
    AudioSource bulletDropSound;

    [SerializeField]
    float bulletForce;

    [SerializeField]
    Transform firePoint;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        anim.SetTrigger("Shoot");
        bulletDropSound.Play();
        gunShotSound.Play();
        GameObject spawnedEffect = Instantiate(fireEffect, firePoint.position, firePoint.rotation);
        GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody body = spawnedBullet.GetComponent<Rigidbody>();
        body.AddForce(firePoint.transform.forward * bulletForce, ForceMode.Acceleration);
    }
}
