using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.Selfie
{
    public class SelfieAimArea : MonoBehaviour
    {
        private List<SelfieTargetPoint> points;

        public IEnumerable<SelfieTargetPoint> PointsInRange
        {
            get
            {
                return points.AsReadOnly();
            }
        }


        // Use this for initialization
        void Start()
        {
            points = new List<SelfieTargetPoint>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var targetPoint = other.GetComponent<SelfieTargetPoint>();
            if (targetPoint != null)
            {
                points.Add(targetPoint);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var targetPoint = other.GetComponent<SelfieTargetPoint>();
            if (targetPoint != null)
            {
                points.Remove(targetPoint);
            }
        }
    }
}
