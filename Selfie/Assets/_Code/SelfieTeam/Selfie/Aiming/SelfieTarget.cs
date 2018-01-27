using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SelfieTeam.Selfie.Aiming
{
    [RequireComponent(typeof(Collider))]
    public class SelfieTarget : MonoBehaviour
    {

        #region Unity Vars
        public UnityEvent EnteredSelfie;
        public UnityEvent LeftSelfie;

        public UnityEvent BecameQuestTarget;
        public UnityEvent StopedBeginQuestTarget;
        #endregion

        private bool isInSelfie;
        private bool isInQuest;

        [SerializeField]
        private Vector3 interestPoint;

        public Vector3 InterestPoint { get { return transform.TransformPoint(interestPoint); } }

        private int targetedChildren = 0;

        public bool IsQuestTarget
        {
            get
            {
                return isInQuest;
            }
        }

        void Start()
        {
        }
        
        internal void OnEnteredSelfie()
        {
            Debug.Assert(!isInSelfie);
            isInSelfie = true;
            EnteredSelfie.Invoke();
        }
        internal void OnLeftSelfie()
        {
            Debug.Assert(isInSelfie);
            isInSelfie = false;
            LeftSelfie.Invoke();
        }

        public void OnBecameQuestTarget()
        {
            isInQuest = true;
            BecameQuestTarget.Invoke();
        }
        public void OnStopedBeingQuestTarget()
        {
            isInQuest = false;
            StopedBeginQuestTarget.Invoke();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawSphere(InterestPoint, .1f);
        }
    }
}