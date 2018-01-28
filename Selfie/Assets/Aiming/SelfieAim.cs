using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SelfieTeam.Selfie.Aiming
{
    public class SelfieAim : MonoBehaviour
    {
        private Camera cam;
        private SelfieAimArea area;
        private bool init = false;

        public float maxDistance = 11;
        public Vector2 range;
        public Vector2 center;
        public LayerMask raycastLayers;

        private IEnumerable<SelfieTarget> lastPoints = new List<SelfieTarget>();



        // Use this for initialization
        void Start()
        {
            Debug.Assert(init);
        }

        internal void Init(SelfieAimArea area, Camera camera)
        {
            Debug.Assert(!init);
            init = true;
            this.area = area;
            this.cam = camera;
        }

        void Update()
        {
            var hits = new List<SelfieTarget>(PossibleTargets.Where(IsInRange));

            var newlyMissed = new List<SelfieTarget>(lastPoints.Except(hits));
            foreach (var missed in newlyMissed)
            {
                missed.OnLeftSelfie();
            }

            var newlyHit = new List<SelfieTarget>(hits.Except(lastPoints));
            foreach (var hit in newlyHit)
            {
                hit.OnEnteredSelfie();
            }

            lastPoints = hits;
        }

        private bool IsInRange(SelfieTarget target)
        {
            var pos = cam.WorldToViewportPoint(target.InterestPoint);
            var xOk = pos.x > center.x - range.x && pos.x < center.x + range.x;
            var yOk = pos.y > center.y - range.y && pos.y < center.y + range.y;
            var dist = Vector3.Distance(target.InterestPoint, transform.position);
            var distanceOk = pos.z > 0 && (dist < maxDistance || target.IgnoresDistance);

            var ray = cam.ViewportPointToRay(pos);
            RaycastHit hit;
            var raycastOk = target.IgnoresCollision || Physics.Raycast(ray, out hit, float.PositiveInfinity, raycastLayers.value) && hit.collider.gameObject == target.gameObject;
            return xOk && yOk && distanceOk && raycastOk;
        }

        private IEnumerable<SelfieTarget> PossibleTargets
        {
            get
            {
                return area.PointsInRange;
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, maxDistance);
        }
    }
}