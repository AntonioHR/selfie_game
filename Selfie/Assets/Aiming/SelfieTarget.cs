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
        #endregion

        private bool isInSelfie;
        private float selfieStart = 0;

        public float SelfieTime { get { return isInSelfie ? Time.time - selfieStart : 0; } }
        public bool IsInSelfie { get { return isInSelfie ; } }

        [SerializeField]
        private Vector3 interestPoint;
        [SerializeField]
        private Vector3 indicatorPoint;
        [SerializeField]
        private bool ignoreDistance;

        public Vector3 InterestPoint { get { return transform.TransformPoint(interestPoint); } }
        public Vector3 IndicatorPoint { get { return transform.TransformPoint(indicatorPoint); } }

        public Collider Col
        {
            get { return GetComponent<Collider>(); }
        }

        public bool IgnoresDistance { get { return ignoreDistance; }  }

        private int targetedChildren = 0;
        
        void Start()
        {
        }
        internal void OnEnteredSelfie()
        {
            Debug.Assert(!isInSelfie);
            isInSelfie = true;
            selfieStart = Time.time;
            EnteredSelfie.Invoke();
        }
        internal void OnLeftSelfie()
        {
            Debug.Assert(isInSelfie);
            isInSelfie = false;
            LeftSelfie.Invoke();
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawSphere(InterestPoint, .1f);
            Gizmos.color = Color.cyan;

            Gizmos.DrawSphere(IndicatorPoint, .1f);
        }
    }
}