using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Targets;
using Game;

public class DropTargets : MonoBehaviour {

    private void Awake()
    {
        //Drop Targets when the countdown ends
        BaseTarget[] lowPointTargets;

        var lowPointTarget = new LowPointTarget();

        lowPointTargets = GameObject.FindObjectsOfType<LowPointTarget>();

        foreach (BaseTarget target in lowPointTargets)
        {
            target.targetCollider.enabled = false;
            target.anim.SetTrigger("beenShot");
        }

        BaseTarget[] highPointTargets;

        var highPointTarget = new HighPointTarget();

        highPointTargets = GameObject.FindObjectsOfType<HighPointTarget>();

        foreach (BaseTarget target in highPointTargets)
        {
            target.targetCollider.enabled = false;
            target.anim.SetTrigger("beenShot");
        }
    }
}
