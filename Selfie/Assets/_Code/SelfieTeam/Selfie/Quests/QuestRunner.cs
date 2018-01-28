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
            return ListenForSelfie(selfieTarget, defaultSelfieTime, ShowSelfieFeedback, ToggleSelfieDisplay);
        }
        public IEnumerator ListenForSelfie(SelfieTarget selfieTarget, float selfieTime)
        {
            return ListenForSelfie(selfieTarget, selfieTime, ShowSelfieFeedback, ToggleSelfieDisplay);
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
        public void ToggleSelfieDisplay(bool val)
        {
            //interfManager.batteryImage.enabled = val;
            SelfieProgressIndicator.Instance.SetVisible(val);
        }

        public void ShowSelfieFeedback(float val)
        {
            SelfieProgressIndicator.Instance.SetProgress(val);
            //interfManager.SetBatteryNow(val);
        }

        public IEnumerator ListenForSelfie(SelfieTarget target, float requiredTime, Action<float> feedbackCallback, Action<bool> toggleCallback)
        {
            SelfieProgressIndicator.Instance.SetTarget(target);
            SelfieProgressIndicator.Instance.SetVisible(false);
            bool inSelfie = target.IsInSelfie;
            toggleCallback(inSelfie);
            while (true)
            {
                float lerp = Mathf.InverseLerp(0, requiredTime, target.SelfieTime);
                if (target.IsInSelfie != inSelfie)
                {
                    inSelfie = target.IsInSelfie;
                    toggleCallback(inSelfie);
                }
                if (inSelfie)
                    feedbackCallback(lerp);
                if (lerp >= 1)
                    break;
                yield return null;
            }
        }
    }
}