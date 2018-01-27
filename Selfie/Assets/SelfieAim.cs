using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelfieAim : MonoBehaviour {
    public Camera camera;
    public SelfieAimArea area;
    
    public Vector2 range;
    public Vector2 center;

    private IEnumerable<SelfieTargetPoint> lastPoints = new List<SelfieTargetPoint>();



    // Use this for initialization
    void Start () {
	}

	void Update () {
        var hits = new List<SelfieTargetPoint>(PossibleTargets.Where(IsInRange));
        
        var newlyMissed = new List<SelfieTargetPoint>(lastPoints.Except(hits));
        foreach (var missed in newlyMissed)
        {
            missed.OnstoppedAiming();
        }

        var newlyHit = new List<SelfieTargetPoint>(hits.Except(lastPoints));
        foreach (var hit in newlyHit)
        {
            hit.OnStartedAiming();
        }

        lastPoints = hits;
    }

    private bool IsInRange(SelfieTargetPoint target)
    {
        var pos = camera.WorldToViewportPoint(target.transform.position);
        var xOk = pos.x > center.x - range.x && pos.x < center.x + range.x;
        var yOk = pos.y > center.y - range.y && pos.y < center.y + range.y;
        var distanceOk = pos.z > 0;
        return xOk && yOk && distanceOk;
    }

    private IEnumerable<SelfieTargetPoint> PossibleTargets
    {
        get
        {
            return area.PointsInRange;
        }
    }
}
