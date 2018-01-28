using SelfieTeam.Selfie.Aiming;
using SelfieTeam.Selfie.Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie
{
    public class SceneAssembler : MonoBehaviour
    {
        public Player player;
        public InterfaceManager interfaceManager;
        public QuestRunner questRunner;
        public TargetDatabase db;
        public SelfieTarget basicTarget;
        public SelfieProgressIndicator progressIndicator;

        public void Awake()
        {
            player.Init();
            progressIndicator.player = player;

            questRunner.Init(interfaceManager, db);
            
        }
    }
}
