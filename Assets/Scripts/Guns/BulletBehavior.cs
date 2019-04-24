using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author - James Foy
//This script is only used to destroy the bullets after a few seconds to reduce performance issues

public class BulletBehavior : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Destroy());
	}

    //starts countdown till the object is destroyed
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);

        yield break;
    }

}
