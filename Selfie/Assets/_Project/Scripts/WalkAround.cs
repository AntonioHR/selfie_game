using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAround : MonoBehaviour {
    public List<Transform> waypoints;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(waypoints[0].position);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
