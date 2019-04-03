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
        throw new NotImplementedException();
    }

	// Use this for initialization
	void Start ()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
        SetTarget();
	}

    IEnumerator TargetReset()
    {
        yield return new WaitForSeconds(3f);
        ResetTarget();

        yield break;
    }

    protected virtual void ResetTarget()
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(TargetReset());
            OnHitByBullet(other.gameObject);
        }
    }

    protected virtual void OnHitByBullet(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}
