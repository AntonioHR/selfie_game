using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SelfieTeam.Selfie
{
    public class SelfieTarget : MonoBehaviour
    {

        #region Unity Vars
        public UnityEvent Targeted;
        public UnityEvent Untargeted;
        #endregion

        private bool targeted;

        private int targetedChildren = 0;

        void Start()
        {
        }

        void Update()
        {

        }


        public void OnChildTargeted()
        {
            targetedChildren++;
            if (targetedChildren == 1)
            {
                OnTargeted();
            }
        }
        public void OnChildUntargeted()
        {
            Debug.Assert(targetedChildren >= 0);
            targetedChildren--;
            if (targetedChildren == 0)
            {
                OnUntargeted();
            }
        }


        private void OnTargeted()
        {
            Debug.Assert(!targeted);
            targeted = true;
            Targeted.Invoke();
        }

        private void OnUntargeted()
        {
            Debug.Assert(targeted);
            targeted = false;
            Untargeted.Invoke();
        }
    }
}