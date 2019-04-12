using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : GunsBase {

    public override void SetAttributes()
    {
        anim = this.gameObject.GetComponent<Animator>();
        bulletForce = 4000;
        fireRate = 0.5f;
        maxShots = 6;
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
            fireEffect.gameObject.SetActive(true);
            if (fireEffect.isPlaying)
            {
                fireEffect.Play();
            }
            GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody body = spawnedBullet.GetComponent<Rigidbody>();
            body.AddForce(firePoint.transform.forward * bulletForce, ForceMode.Acceleration);
        }
    }
}
