using SelfieTeam.Selfie.Aiming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace SelfieTeam.Selfie
{
    [RequireComponent(typeof(FirstPersonController))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private FirstPersonController controller;
        [SerializeField]
        private SelfieAim aim;
        [SerializeField]
        private SelfieAimArea area;
        [SerializeField]
        private Camera selfieCam;

        private bool init;

        internal void Init()
        {
            Debug.Assert(!init, "Player is being initialized multiple times");
            init = true;
            aim.Init(area, selfieCam);
        }
        private void Start()
        {
            Debug.Assert(init, "Player is not being initalized");
        }
    }
}
