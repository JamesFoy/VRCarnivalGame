using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPointTarget : BaseTarget {

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

    protected override void ResetTarget()
    {
        anim.SetTrigger("ResetTarget");
        targetHitState = false;
        targetCollider.enabled = true;
    }
}
