using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author - James Foy (Foy14355306)
//This script is used as for the high point target and inherits from the base target class

namespace Targets
{
    public class HighPointTarget : BaseTarget
    {

        //Overrides specific values for the high point target once it detects a collision from a bullet
        protected override void OnHitByBullet(GameObject gameObject)
        {
            if (targetHitState == false)
            {
                hitSound.Play();
                Destroy(gameObject.gameObject);
                anim.SetTrigger("beenShot");
                ui.score += score;
                targetHitState = true;
                targetCollider.enabled = false;
            }
        }

        //Allows the target to reset itself
        protected override void ResetTarget()
        {
            anim.SetTrigger("ResetTarget");
            targetHitState = false;
            targetCollider.enabled = true;
        }
    }
}

