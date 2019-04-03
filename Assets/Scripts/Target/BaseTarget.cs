using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTaget : MonoBehaviour {

    protected int score;
    public Animator anim;
    public AudioSource hitSound;
    protected UIScript ui;

    protected virtual void SetTarget()
    {
        Debug.Log("Setup the target");
    }

	// Use this for initialization
	void Start ()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
        SetTarget();
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            OnHitByBullet(other.gameObject);
        }
    }

    protected virtual void OnHitByBullet(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}
