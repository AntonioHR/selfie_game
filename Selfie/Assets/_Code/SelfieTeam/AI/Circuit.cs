﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.AI
{
    public class Circuit : MonoBehaviour
    {

        private List<Transform> waypoints;

        // Use this for initialization
        void Awake()
        {
            waypoints = new List<Transform>();
            foreach (Transform child in transform)
            {
                waypoints.Add(child);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public List<Transform> Waypoints
        {
            get
            {
                return new List<Transform>(waypoints);
            }
        }

    }
}
