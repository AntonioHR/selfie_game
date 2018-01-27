using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieTargetPoint : MonoBehaviour {
    public Bounds BoundingBox
    { get { return GetComponent<Collider>().bounds; } }

    public SelfieTarget parent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void OnStartedAiming()
    {
        parent.OnChildTargeted();
    }

    internal void OnstoppedAiming()
    {
        parent.OnChildUntargeted();
    }
}
