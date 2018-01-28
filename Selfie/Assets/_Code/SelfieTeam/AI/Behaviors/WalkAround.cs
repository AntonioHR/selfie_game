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
        private Circuit circuit;
        private NPCController controller;
        private List<Transform> waypoints;
        private NavMeshAgent agent;
        int destinationPoint = 0;
        // Use this for initialization
        void Start()
        {
            controller = GetComponent<NPCController>();
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
            //agent.SetDestination(waypoints[destinationPoint].position);
        }

        // Update is called once per frame
        void Update()
        {
            circuit = controller.circuit;
            if(agent.speed > 1)
            {
                controller.isWalking = true;
            } else
            {
                controller.isWalking = false;
            }

            if(circuit == null)
            {
                circuit = GetComponent<Circuit>();
            }

            waypoints = new List<Transform>();
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
            agent = controller.Agent;
            waypoints = circuit.Waypoints;
            if (waypoints == null || waypoints.Count == 0)
            {
                return;
            }
            else if (Vector3.Distance(waypoints[destinationPoint].position, transform.position) < 1)
            {
                destinationPoint = (destinationPoint + 1) % waypoints.Count;
            }

            agent.SetDestination(waypoints[destinationPoint].position);
        }


    }
}
