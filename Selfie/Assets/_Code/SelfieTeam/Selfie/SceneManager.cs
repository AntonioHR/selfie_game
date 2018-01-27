using SelfieTeam.Selfie.Aiming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance { get; private set; }
        [Serializable]
        public class Config
        {
            public List<SelfieTarget> Targets;
            public Quest.Config questConfigs;
        }
        
        public Quest CurrentQuest { get; private set; }

        [SerializeField]
        private Config config;


        public void Init()
        {
            Debug.Assert(Instance == null);
            Instance = this;
            PrepareNextQuest();
        }

        public void Update()
        {
            if (CurrentQuest != null)
            {
                CheckQuest();
            }
        }

        private void CheckQuest()
        {
            if (CurrentQuest.Finished)
            {
                CurrentQuest.OnFinish();
                PrepareNextQuest();
            }
        }

        private void PrepareNextQuest()
        {
            var nextTarget = config.Targets[UnityEngine.Random.Range(0, config.Targets.Count)];

            CurrentQuest = new Quest(nextTarget, config.questConfigs);
            CurrentQuest.OnBegin();
        }
    }
}
