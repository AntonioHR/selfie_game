using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SelfieTeam.AI {     
    public class SelfieBehaviorAgent : MonoBehaviour {

	    // Use this for initialization
	    void Start () {
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }


        // Function to be Overrided on children
        public virtual IEnumerator bootCoroutine(NPCController controller)
        {
            yield return null;
        }

        protected IEnumerator WalkAround(NPCController controller, NavMeshAgent agent)
        {
            int destinationPoint = 0;
            
            controller = GetComponent<NPCController>();
            //Circuit circuit = controller.GetComponent<Circuit>();
            agent = GetComponent<NavMeshAgent>();
            // Maybe, an IF instead of a while? 
            List<Transform> waypoints = controller.GetComponent<Circuit>().Waypoints;
            
            if (waypoints == null || waypoints.Count == 0)
            {
                yield return null;
            }
            else if (Vector3.Distance(waypoints[destinationPoint].position, transform.position) < 1)
            {
                destinationPoint = (destinationPoint + 1) % waypoints.Count;
                agent.SetDestination(waypoints[destinationPoint].position);
            }
            yield return null;
        }
        

        
    }
}
