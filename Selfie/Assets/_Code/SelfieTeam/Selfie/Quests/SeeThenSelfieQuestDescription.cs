using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie.Quests
{
    [CreateAssetMenu()]
    class SeeThenSelfieQuestDescription : QuestDescription
    {
        public string targetId;
        public Sprite avatar;
        public string msg1;
        public string msg2;
        public string msg3;
        public float followTime = 3;

        protected override IEnumerator RunQuest(QuestRunner runner)
        {
            var target = runner.GetTarget(targetId);

            yield return new WaitUntil(()=>target.IsInSelfie);
            runner.ShowMessage(msg1, avatar);
            yield return new WaitForSeconds(followTime);
            yield return runner.ListenForSelfie(target, runner.fastSelfieTime);
            runner.ShowMessage(msg2, avatar);
            yield return new WaitForSeconds(followTime);
            yield return runner.ListenForSelfie(target, runner.fastSelfieTime);
            runner.ShowMessage(msg3, avatar);
        }
    }
}
