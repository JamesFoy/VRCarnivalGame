using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActionRifle : GunsBase {

    public override void SetAttributes()
    {
        anim = this.gameObject.GetComponent<Animator>();
        bulletForce = 6000;
        fireRate = 2.5f;
        maxShots = 10;
        shotsDone = 0;
    }

    public override void Shoot()
    {
        if (Time.time > nextFire && shotsDone < maxShots)
        {
            nextFire = Time.time + fireRate;
            shotsDone++;
            anim.SetTrigger("Shoot");
            bulletDropSound.Play();
            gunShotSound.Play();
            GameObject spawnedEffect = Instantiate(fireEffect, firePoint.position, firePoint.rotation);
            GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody body = spawnedBullet.GetComponent<Rigidbody>();
            body.AddForce(firePoint.transform.forward * bulletForce, ForceMode.Acceleration);
        }
    }
}
