using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

//Author - James Foy (Foy14355306)
//This script is used as a base class for all other targets to inherit from

namespace Targets
{
    public class BaseTarget : MonoBehaviour
    {

        public int score;
        public Animator anim;
        public AudioSource hitSound;
        protected UIScript ui;
        protected bool targetHitState = false;
        public Collider targetCollider;

        //This provides each target a reference so specific components
        void Start()
        {
            ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
            targetCollider = this.gameObject.GetComponent<Collider>();
        }

        //This will allow the target to reset its rotation after a few seconds
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

        //This is used to allow every target to detect a collison with a bullet that inherits from this class
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
}
