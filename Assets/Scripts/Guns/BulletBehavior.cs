using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author - James Foy (Foy14355306)
//This script is only used to destroy the bullets after a few seconds to reduce performance issues

namespace Guns
{
    public class BulletBehavior : MonoBehaviour
    {

        // Use this for initialization
        void Start()
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
}

