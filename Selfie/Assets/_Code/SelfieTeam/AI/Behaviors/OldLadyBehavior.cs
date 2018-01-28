using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.AI
{

    public class OldLadyBehavior : SelfieBehaviorAgent {
            
        // Use this for initialization
	    void Awake () {
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        public override IEnumerator bootCoroutine(NPCController controller)
        {
            while (true)
            {
                yield return WalkAround(controller, controller.Agent);
            }  
        }

    }

}
