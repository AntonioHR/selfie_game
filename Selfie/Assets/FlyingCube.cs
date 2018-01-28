using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using DG.Tweening;

namespace Assets
{
    public class FlyingCube : MonoBehaviour
    {
        public Vector3 target;
        public float time = 3;
        private void Start()
        {
            transform.DOMove(transform.TransformPoint(target), time).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
