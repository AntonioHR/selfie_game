using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.AI
{
    [RequireComponent(typeof(Circuit))]
    public class NPCController : MonoBehaviour
    {
        public bool isIdle;
        public bool isWalking;
        public bool isAction;
        public bool lookAt;

        // Use this for initialization
        void Start()
        {
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
