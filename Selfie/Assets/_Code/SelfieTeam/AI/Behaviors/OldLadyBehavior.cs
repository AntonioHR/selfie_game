using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.AI
{

    public class OldLadyBehavior : SelfieBehaviorAgent {
            
        // Use this for initialization
	    void Awake () {
            StartCoroutine(OnStartBehavior());
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        private IEnumerator OnStartBehavior()
        {
            while (true)
            {
                yield return WalkAround();
            }  
        }

    }

}
