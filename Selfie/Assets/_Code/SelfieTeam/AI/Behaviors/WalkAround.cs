using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace SelfieTeam.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class WalkAround : MonoBehaviour
    {
        public float speed = 2;
        public Circuit circuit;
        private List<Transform> waypoints;
        NavMeshAgent agent;
        int destinationPoint = 0;
        // Use this for initialization
        void Start()
        {
            waypoints = circuit.Waypoints;
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
            agent.SetDestination(waypoints[destinationPoint].position);

        }

        // Update is called once per frame
        void Update()
        {
            waypoints = circuit.Waypoints;
            agent.autoBraking = false;

            if(waypoints == null)
            {
                waypoints = circuit.Waypoints;
            }
            this.GoToNextPoint();
        }

        void GoToNextPoint()
        {
            waypoints = circuit.Waypoints;
            if (waypoints == null || waypoints.Count == 0)
            {
                return;
            }
            else if (Vector3.Distance(waypoints[destinationPoint].position, transform.position) < 1)
            {
                destinationPoint = (destinationPoint + 1) % waypoints.Count;
                agent.SetDestination(waypoints[destinationPoint].position);
            }


        }
    }
}
