using SelfieTeam.Selfie;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie.Quests
{
    public abstract class QuestDescription : ScriptableObject
    {
        public int points;
        protected abstract IEnumerator RunQuest(QuestRunner runner);

        public IEnumerator Run(QuestRunner runner)
        {
            yield return RunQuest(runner);

            runner.GivePoints(points);
        }
    }
}
