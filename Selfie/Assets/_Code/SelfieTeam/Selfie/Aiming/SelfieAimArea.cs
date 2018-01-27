using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.Selfie.Aiming
{
    public class SelfieAimArea : MonoBehaviour
    {
        private List<SelfieTarget> points;

        public IEnumerable<SelfieTarget> PointsInRange
        {
            get
            {
                return points.AsReadOnly();
            }
        }


        // Use this for initialization
        void Start()
        {
            points = new List<SelfieTarget>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var targetPoint = other.GetComponent<SelfieTarget>();
            if (targetPoint != null)
            {
                points.Add(targetPoint);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var targetPoint = other.GetComponent<SelfieTarget>();
            if (targetPoint != null)
            {
                points.Remove(targetPoint);
            }
        }
    }
}
