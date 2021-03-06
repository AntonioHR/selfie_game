﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SelfieTeam.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCController : MonoBehaviour
    {
        public Circuit circuit;
        private NavMeshAgent agent;
        public bool isIdle;
        public bool isWalking;
        public bool isAction;
        public bool lookAt;

        public NavMeshAgent Agent
        {
            get
            {
                return agent;
            }
        }

        // Use this for initialization
        void Start()
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
