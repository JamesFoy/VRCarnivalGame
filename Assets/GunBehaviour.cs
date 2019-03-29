using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bulletForce;

    [SerializeField]
    Transform firePoint;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody body = spawnedBullet.GetComponent<Rigidbody>();
        body.AddForce(transform.right * bulletForce, ForceMode.Acceleration);
    }
}
