using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author - James Foy (Foy14355306)
//This script is used as for the lever action rifle weapon and inherits from the guns base class

namespace Guns
{
    public class LeverActionRifle : GunsBase
    {

        //Overrides the variables of the lever action rifle
        public override void SetAttributes()
        {
            anim = this.gameObject.GetComponent<Animator>();
            bulletForce = 10000;
            fireRate = 0.5f;
            maxShots = 10;
            shotsDone = 0;
        }

        //Overrides the shooting variables to work with the gun that this script is attached to
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
}

