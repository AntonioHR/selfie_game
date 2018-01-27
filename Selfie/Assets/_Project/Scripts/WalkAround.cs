using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WalkAround : MonoBehaviour {
    public GameObject CircuitObject;
    private List<Transform> waypoints;
    private Circuit circuit;
    NavMeshAgent agent;
    int destinationPoint = 0;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        circuit = CircuitObject.GetComponent<Circuit>();

        waypoints = circuit.Waypoints;
        agent.SetDestination(waypoints[destinationPoint].position);
        
	}
	
	// Update is called once per frame
	void Update () {
        agent.autoBraking = false;

        this.GoToNextPoint();
	}

    void GoToNextPoint()
    {
        if (waypoints.Count == 0)
        {
            return;
        } else if (Vector3.Distance(waypoints[destinationPoint].position, transform.position) < 1)
        {
            destinationPoint = (destinationPoint + 1) % waypoints.Count;
            agent.SetDestination(waypoints[destinationPoint].position);
        }


    }
}
