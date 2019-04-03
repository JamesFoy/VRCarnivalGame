using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsBase : MonoBehaviour {

    protected float bulletForce;
    protected float fireRate;
    protected float nextFire;
    protected int maxShots;
    protected int shotsDone;
    public Transform firePoint;
    public AudioSource gunShotSound;
    public AudioSource bulletDropSound;
    public GameObject bullet;
    public GameObject fireEffect;
    public Animator anim;

    public virtual void SetAttributes()
    {
        Debug.Log("Weapon Attributes Set");
    }

    public virtual void Shoot()
    {
        Debug.Log("Shoot Gun");
    }

    public void Reload()
    {
        shotsDone = 0;
        anim.SetTrigger("Reload");
    }

    // Use this for initialization
    void Start ()
    {
        SetAttributes();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shotsDone >= maxShots)
        {
            Reload();
        }
	}
}
