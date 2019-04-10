using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    Quaternion startRotation;
    float rotate = 90;

	// Use this for initialization
	void Start ()
    {
        startRotation = this.gameObject.transform.rotation;
	}
	
    public void RotateObject()
    {
        startRotation.x += 90;
    }
}
