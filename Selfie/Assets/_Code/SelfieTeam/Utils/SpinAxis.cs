using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAxis : MonoBehaviour {

    public Vector3 rotation;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(rotation * speed);
		
	}
}
