using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SelfieTeam.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCController : MonoBehaviour
    {
        public Circuit circuit;
        public SelfieBehaviorAgent behaviorAgent;
        private NavMeshAgent agent;
        public bool isIdle;
        public bool isWalking;
        public bool isAction;
        public bool lookAt;

        // Use this for initialization
        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            isIdle = false;
            isWalking = false;
            isAction = false;
            lookAt = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
