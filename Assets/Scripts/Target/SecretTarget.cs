using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Targets
{
    public class SecretTarget : BaseTarget
    { 
        private int secretScore;

        //Overrides specific values for the high point target once it detects a collision from a bullet
        protected override void OnHitByBullet(GameObject gameObject)
        {
            if (targetHitState == false)
            {
                hitSound.Play();
                Destroy(gameObject.gameObject);
                ui.score += secretScore;
                targetHitState = true;
                targetCollider.enabled = false;
            }
        }

        void Explode()
        {

        }
    }
}

