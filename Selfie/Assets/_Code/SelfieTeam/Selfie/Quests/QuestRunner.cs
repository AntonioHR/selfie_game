using SelfieTeam.Selfie.Aiming;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfieTeam.Selfie.Quests
{
    public class QuestRunner : MonoBehaviour
    {
        private int points;

        public GameObject SelfieProgressIndicatorPrefab;
        public AnimationCurve viewersCurve;
        public float pointsTarget;
        public int viewersTarget;

        public static QuestRunner Instance { get; private set; }
        InterfaceManager interfManager;
        TargetDatabase db;

        internal void ShowMessage(string msg1, Sprite avatar)
        {
            interfManager.AddComent(msg1, avatar);
        }
        

        public float defaultSelfieTime = 2;
        public float fastSelfieTime = 1f;

        public void Init(InterfaceManager interfManager, TargetDatabase db)
        {
            this.interfManager = interfManager;
            this.db = db;
        }
        internal void GivePoints(int extraPoints)
        {
            this.points += extraPoints;
            float interp = viewersCurve.Evaluate((float)points / pointsTarget);
            InterfaceManager.Instance.SetViewers( (int)(interp * viewersTarget));
        }

        public void RunQuest(QuestDescription description, Action callback)
        {
            StartCoroutine(QuestThenCallback(description, callback));
        }

        private IEnumerator QuestThenCallback(QuestDescription description, Action callback)
        {
            yield return description.Run(this);
            callback();
        }

        public IEnumerator ListenForSelfie(SelfieTarget selfieTarget)
        {
            return ListenForSelfie(selfieTarget, defaultSelfieTime);
        }

        internal SelfieTarget GetTarget(string targetId)
        {
            return db.GetTarget(targetId);
        }


        private void Awake()
        {
            Instance = this;
        }
        // Use this for initialization
        void Start()
        {
            InterfaceManager.Instance.SetViewers(0);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator ListenForSelfie(SelfieTarget target, float requiredTime)
        {
            var progressIndicator = GameObject.Instantiate(SelfieProgressIndicatorPrefab).GetComponent<SelfieProgressIndicator>();
            progressIndicator.Init(Player.Instance);
            progressIndicator.SetTarget(target);
            bool inSelfie = target.IsInSelfie;
            progressIndicator.SetVisible(inSelfie);
            while (true)
            {
                float lerp = Mathf.InverseLerp(0, requiredTime, target.SelfieTime);
                if (target.IsInSelfie != inSelfie)
                {
                    inSelfie = target.IsInSelfie;
                    progressIndicator.SetVisible(inSelfie);
                }
                if (inSelfie)
                    progressIndicator.SetProgress(lerp);
                if (lerp >= 1)
                    break;
                progressIndicator.SetTarget(target);
                yield return null;
            }
            GameObject.Destroy(progressIndicator);
        }
    }
}