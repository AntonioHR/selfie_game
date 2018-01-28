using SelfieTeam.Selfie.Aiming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie
{
    public class TargetDatabase: MonoBehaviour
    {
        [Serializable]
        public class Entry
        {
            public string id;
            public SelfieTarget target;
        }

        public List<Entry> entries;
        public Dictionary<string, SelfieTarget> dict;
        
        public SelfieTarget GetTarget(string id)
        {
            return dict[id];
        }

        void Awake()
        {
            dict = new Dictionary<string, SelfieTarget>();
            foreach (var entry in entries)
            {
                dict.Add(entry.id, entry.target);
            }
        }
    }
}
