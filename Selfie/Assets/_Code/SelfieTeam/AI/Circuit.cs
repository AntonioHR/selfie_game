using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.AI
{
    public class Circuit : MonoBehaviour
    {

        public List<Transform> waypoints;

        // Use this for initialization
        void Awake()
        {
            generateWaypoints();
            Debug.Log(waypoints[0] == transform);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void generateWaypoints()
        {
            waypoints = new List<Transform>();
            foreach (Transform child in transform)
            {
                waypoints.Add(child);
            }
        }

        

    }
}
