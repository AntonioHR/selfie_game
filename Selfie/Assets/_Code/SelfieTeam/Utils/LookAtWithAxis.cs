using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.Utils
{
    public class LookAtWithAxis : MonoBehaviour
    {
        public Vector3 axis;
        public Transform target;



        // Update is called once per frame
        void Update()
        {
            Plane plane = new Plane(axis, transform.position);

            transform.rotation = Quaternion.LookRotation(plane.ClosestPointOnPlane(target.position) - transform.position);
        }
    }
}