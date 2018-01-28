using SelfieTeam.Selfie;
using SelfieTeam.Selfie.Aiming;
using SelfieTeam.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelfieProgressIndicator : MonoBehaviour
{
    

    public AnimationCurve curve;
    public List<Sprite> spriteSequence;
    public Image img;
    [HideInInspector]
    public Player player;


    public void Init(Player player)
    {
        this.player = player;
    }

    private void Start()
    {
        var look = gameObject.AddComponent<LookAtWithAxis>();
        look.axis = Vector3.up;
        look.target = player.transform;

    }
    private void Update()
    {
        
    }
    public void SetProgress(float val)
    {
        int result = (int)((spriteSequence.Count - 1) * curve.Evaluate(val));
        img.sprite = spriteSequence[result];
    }
    public void SetTarget(SelfieTarget target)
    {
        transform.position = target.IndicatorPoint;
    }

    internal void SetVisible(bool val)
    {
        img.enabled = val;
    }

    internal void Init(object instance)
    {
        throw new NotImplementedException();
    }
}
