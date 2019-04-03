using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPointTarget : BaseTaget
{

    protected override void SetTarget()
    {
        score = 2;
    }

    protected override void OnHitByBullet(GameObject gameObject)
    {
        hitSound.Play();
        Destroy(gameObject.gameObject);
        anim.SetTrigger("beenShot");
        ui.score += score;
    }


    protected override void ResetTarget()
    {
        anim.SetTrigger("ResetTarget");
    }
}
