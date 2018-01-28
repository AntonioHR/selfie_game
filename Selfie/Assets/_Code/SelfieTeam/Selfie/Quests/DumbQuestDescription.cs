using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie.Quests
{
    [CreateAssetMenu()]
    class DumbQuestDescription : QuestDescription
    {
        public string targetId;
        public Sprite avatar1;
        public string msg1;
        public Sprite avatar2;
        public string msg2;

        protected override IEnumerator RunQuest(QuestRunner runner)
        {
            runner.ShowMessage(msg1, avatar1);
            yield return runner.ListenForSelfie(runner.GetTarget(targetId));
            //runner.RemoveMessage()
            runner.ShowMessage(msg2, avatar2);
        }
        
    }
}
