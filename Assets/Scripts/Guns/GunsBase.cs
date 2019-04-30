using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author - James Foy (Foy14355306)
//This script is used as a base class for all other weapons to inherit from
namespace Guns
{
    public class GunsBase : MonoBehaviour
    {

        protected float bulletForce;
        protected float fireRate;
        protected float nextFire;
        protected int maxShots;
        protected int shotsDone;
        public Transform firePoint;
        public AudioSource gunShotSound;
        public AudioSource bulletDropSound;
        public GameObject bullet;
        public ParticleSystem fireEffect;
        public Animator anim;

        //this allows each gun to have their own stats
        public virtual void SetAttributes()
        {
            Debug.Log("Weapon Attributes Set");
        }

        //this allows each gun to shoot
        public virtual void Shoot()
        {
            Debug.Log("Shoot Gun");
        }

        //this allows all guns to reload
        public void Reload()
        {
            shotsDone = 0;
            anim.SetTrigger("Reload");
        }

        // Use this for initialization
        void Start()
        {
            SetAttributes();
        }

        // The update is used to show the gunshot particle effect on each gun if it isnt playing
        void Update()
        {
            if (!fireEffect.isPlaying)
            {
                fireEffect.gameObject.SetActive(false);
            }

            if (shotsDone >= maxShots)
            {
                Reload();
            }
        }
    }
}
