using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie.Quests
{
    class QuestSequencer : MonoBehaviour
    {
        public List<QuestDescription> FirstQuests;
        public List<QuestDescription> AsyncQuests;

        private List<QuestDescription> availableFirstQuests;

        public void Start()
        {
            availableFirstQuests = new List<QuestDescription>(FirstQuests);
            RunNextQuestFromFirstPool();
            foreach (var quest in AsyncQuests)
            {
                QuestRunner.Instance.RunQuest(quest, ()=>{ });
            }
        }

        private void RunNextQuestFromFirstPool()
        {
            if(availableFirstQuests.Count == 0)
            {
                
            } else
            {
                var quest = TakeRandomFrom(availableFirstQuests);
                QuestRunner.Instance.RunQuest(quest, RunNextQuestFromFirstPool);
            }
        }

        public static QuestDescription TakeRandomFrom(List<QuestDescription> pool)
        {
            int nextQuest = UnityEngine.Random.Range(0, pool.Count);
            var quest = pool[nextQuest];
            pool.RemoveAt(nextQuest);
            return quest;
        }
    }
}
