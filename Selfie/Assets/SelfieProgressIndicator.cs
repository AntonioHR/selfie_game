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
    public static SelfieProgressIndicator Instance { get; private set; }

    public List<Sprite> spriteSequence;
    public Image img;
    [HideInInspector]
    public Player player;
    
    private void Start()
    {
        var look = gameObject.AddComponent<LookAtWithAxis>();
        look.axis = Vector3.up;
        look.target = player.transform;

        Instance = this;
    }
    private void Update()
    {
        
    }
    public void SetProgress(float val)
    {
        int result = (int)((spriteSequence.Count - 1) * val);
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
}
