using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class SpeedUp : MonoBehaviour {

    public float speed = 2;
    private UnityEngine.AI.NavMeshAgent agent;
	// Use this for initialization
	void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
