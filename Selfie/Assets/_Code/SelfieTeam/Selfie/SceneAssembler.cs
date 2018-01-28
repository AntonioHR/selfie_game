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

        public void Awake()
        {
            player.Init();

            questRunner.Init(interfaceManager, db);
            
        }
    }
}
