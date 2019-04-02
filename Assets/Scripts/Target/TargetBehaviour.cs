using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour {

    Animator anim;

    [SerializeField]
    AudioSource hitSound;

    UIScript ui;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hitSound.Play();
            Destroy(other.gameObject);
            anim.SetTrigger("beenShot");
            ui.score++;
        }
    }
}
