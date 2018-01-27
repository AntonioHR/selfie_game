using SelfieTeam.Selfie.Aiming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie
{
    public class Quest
    {
        [Serializable]
        public class Config
        {
            public float aimTimeRequirement;
        }
        public SelfieTarget target;
        public Config configs;


        private float aimStart;
        private bool targeted;

        public Quest(SelfieTarget target, Config config)
        {
            this.target = target;
            this.configs = config;
        }

        public bool Finished
        {
            get
            {
                return Progress == 1;
            }
        }
        public float Progress
        {
            get
            {
                return !targeted ? 0 : Mathf.Clamp((Time.time - aimStart) / configs.aimTimeRequirement, 0, 1);
            }
        }

        public void OnBegin()
        {
            target.EnteredSelfie.AddListener(TargetingBegan);
            target.LeftSelfie.AddListener(TargetingEnded);
            target.OnBecameQuestTarget();
        }
        public void OnFinish()
        {
            target.EnteredSelfie.RemoveListener(TargetingBegan);
            target.LeftSelfie.RemoveListener(TargetingEnded);
            target.OnStopedBeingQuestTarget();
        }
        

        private void TargetingBegan()
        {
            aimStart = Time.time;
            targeted = true;
            Debug.Log("Targeting Began");
        }
        private void TargetingEnded()
        {
            Debug.Log("Targeting Ended");
            targeted = false;
        }
    }
}
