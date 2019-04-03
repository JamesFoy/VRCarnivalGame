using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Destroy());
	}

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);

        yield break;
    }

}
