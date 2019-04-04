using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLowPointTarget : BaseTarget {

    protected override void SetTarget()
    {
        score = 4;
    }

    public override void DifficultyScoreChange()
    {
        score = (score += 4);
        Debug.Log("Score is now " + score);
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
