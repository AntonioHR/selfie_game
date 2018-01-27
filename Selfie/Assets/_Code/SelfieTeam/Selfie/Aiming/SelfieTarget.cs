using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SelfieTeam.Selfie.Aiming
{
    public class SelfieTarget : MonoBehaviour
    {

        #region Unity Vars
        public UnityEvent EnteredSelfie;
        public UnityEvent LeftSelfie;

        public UnityEvent BecameQuestTarget;
        public UnityEvent StopedBeginQuestTarget;
        #endregion

        private bool isInSelfie;
        private bool isInQuest;

        private int targetedChildren = 0;

        public bool IsQuestTarget
        {
            get
            {
                return isInQuest;
            }
        }

        void Start()
        {
        }

        void LateUpdate()
        {
            if (targetedChildren == 0 && isInSelfie)
            {
                OnUntargeted();
            } else if(targetedChildren > 0 && !isInSelfie)
            {
                OnTargeted();
            }
        }


        public void OnChildTargeted()
        {
            targetedChildren++;
        }
        public void OnChildUntargeted()
        {
            Debug.Assert(targetedChildren >= 0);
            targetedChildren--;
        }

        public void OnBecameQuestTarget()
        {
            isInQuest = true;
            BecameQuestTarget.Invoke();
        }
        public void OnStopedBeingQuestTarget()
        {
            isInQuest = false;
            StopedBeginQuestTarget.Invoke();
        }


        private void OnTargeted()
        {
            Debug.Assert(!isInSelfie);
            isInSelfie = true;
            EnteredSelfie.Invoke();
        }

        private void OnUntargeted()
        {
            Debug.Assert(isInSelfie);
            isInSelfie = false;
            LeftSelfie.Invoke();
        }
    }
}