using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.AI
{
    public class Circuit : MonoBehaviour
    {

        private List<Transform> waypoints;

        public List<Transform> Waypoints
        {
            get
            {
                return waypoints;
            }

            set
            {
                waypoints = value;
            }
        }

        // Use this for initialization
        void Awake()
        {
            generateWaypoints();
            Debug.Log(Waypoints[0] == transform);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void generateWaypoints()
        {
            Waypoints = new List<Transform>();
            foreach (Transform child in transform)
            {
                Waypoints.Add(child);
            }
        }

        

    }
}
